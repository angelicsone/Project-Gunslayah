<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recordingVoices.aspx.cs" Inherits="Project_Gunslayah.Account.recordingVoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script>
        function startDictation() {

            if (window.hasOwnProperty('webkitSpeechRecognition')) {

                var recognition = new webkitSpeechRecognition();

                recognition.continuous = false;
                recognition.interimResults = false;

                recognition.lang = "en-US";
                recognition.start();

                recognition.onresult = function (e) {
                    document.getElementById('<%= transcript.ClientID %>').value
                                             = e.results[0][0].transcript;
                    recognition.stop();
                    document.forms[0].submit();
                };

                recognition.onerror = function (e) {
                    recognition.stop();
                    document.write('failed');
                }

            }
        }
    </script>
     private void StartRecording() {
        this.WaveSource = new WaveInEvent { WaveFormat = new WaveFormat(44100, 1) };

        this.WaveSource.DataAvailable += this.WaveSourceDataAvailable;
        this.WaveSource.RecordingStopped += this.WaveSourceRecordingStopped;

        this.WaveFile = new WaveFileWriter(@"C:\Sample.wav", this.WaveSource.WaveFormat);

        this.WaveSource.StartRecording();
    }

    private void StopRecording() {
        this.WaveSource.StopRecording();
    }

    void WaveSourceDataAvailable(object sender, WaveInEventArgs e) {
        if (this.WaveFile != null) {
            this.WaveFile.Write(e.Buffer, 0, e.BytesRecorded);
            this.WaveFile.Flush();
        }
    }

    void WaveSourceRecordingStopped(object sender, StoppedEventArgs e) {
        if (this.WaveSource != null) {
            this.WaveSource.Dispose();
            this.WaveSource = null;
        }

        if (this.WaveFile != null) {
            this.WaveFile.Dispose();
            this.WaveFile = null;
        }
    }
</asp:Content>
