using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.Services;
using static VoiceIt;

namespace Project_Gunslayah.Account
{
    public partial class recordingVoices : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        VoiceIt myVoiceIt = new VoiceIt("fa9a2ca3ca3045a9a4641128d9a059b4");

        public class Person
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public class operation
        {
            [JsonProperty("Result")]
            public string result { get; set; }

            [JsonProperty("EnrollmentID")]
            public string enrollmentID { get; set; }

            [JsonProperty("DetectedVoiceprintText")]
            public string detectedvoiceprint { get; set; }

            [JsonProperty("DetectedTextConfidence")]
            public string detectedTextConfidence { get; set; }

            [JsonProperty("ResponseCode")]
            public string responseCode { get; set; }
        }


        protected void voiceEnrollment1(object sender, EventArgs e)
        {
            var response = myVoiceIt.createEnrollment("ericyeap", "A123456z", "C:/MyWavFile/test6.wav", "en-US");


        }
    }
}

        
    

