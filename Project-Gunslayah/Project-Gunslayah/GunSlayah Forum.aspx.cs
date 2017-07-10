using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpeechLib;

namespace Project_Gunslayah
{
    public partial class GunSlayah_Forum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string searchTerm = transcript.Text;
                //Response.Write(searchTerm);
                //Response.Redirect("https://www.google.com/search?q=" + searchTerm);


                SpVoice voice = new SpVoice();
                voice.Speak("Here are the search results of" +searchTerm);
            }
            else
            {
                
            }
        }
    }
}