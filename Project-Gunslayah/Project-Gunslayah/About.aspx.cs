using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Gunslayah
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Make Sure to add this at the top of your project */

            

            var myVoiceIt = new VoiceIt("1d6361f81f3047ca8b0c0332ac0fb17d");

            /* Now myVoiceIt is an instance of the VoiceIt class and can be used to make various different API Calls, as documented below. */
        }
    }
}