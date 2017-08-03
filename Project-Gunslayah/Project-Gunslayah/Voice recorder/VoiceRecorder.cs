using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Gunslayah.Voice_recorder
{
    public class VoiceRecorder
    {
        private void StartRecording()
        {
            this.WaveSource = new WaveInEvent { WaveFormat = new WaveFormat(44100, 1) };

            this.WaveSource.DataAvailable += this.WaveSourceDataAvailable;
            this.WaveSource.RecordingStopped += this.WaveSourceRecordingStopped;

            this.WaveFile = new WaveFileWriter(@"C:\Sample.wav", this.WaveSource.WaveFormat);

            this.WaveSource.StartRecording();
        }

        private void StopRecording()
        {
            this.WaveSource.StopRecording();
        }

        void WaveSourceDataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.WaveFile != null)
            {
                this.WaveFile.Write(e.Buffer, 0, e.BytesRecorded);
                this.WaveFile.Flush();
            }
        }

        void WaveSourceRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (this.WaveSource != null)
            {
                this.WaveSource.Dispose();
                this.WaveSource = null;
            }

            if (this.WaveFile != null)
            {
                this.WaveFile.Dispose();
                this.WaveFile = null;
            }
        }
    }