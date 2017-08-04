<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoiceRecording.aspx.cs" Inherits="Project_Gunslayah.VoiceRecording" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />
    <section class="main-controls">
            <canvas class="visualizer" height="60px"></canvas>
            <div id="buttons">
                <button class="record">Record</button>
                <button class="stop">Stop</button>
            </div>
        </section>
    <br />
    <br />
        <section class="sound-clips"></section>

    <script src="VoiceRecorder/install.js"></script>

    <script src="VoiceRecorder/mediaDevices-getUserMedia-polyfill.js"></script>

    <!-- Below is your custom application script -->
    <script src="VoiceRecorder/app.js"></script>





</asp:Content>
