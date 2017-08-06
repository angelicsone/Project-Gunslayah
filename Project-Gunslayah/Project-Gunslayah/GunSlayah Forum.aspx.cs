using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpeechLib;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Project_Gunslayah
{
    public partial class GunSlayah_Forum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string searchTerm = transcript.Text;
                Response.Write(searchTerm);
                Response.Redirect("https://www.google.com/search?q=" + searchTerm);


                // SpVoice voice = new SpVoice();
                //voice.Speak("Here are the search results of" + searchTerm);
            }
            else
            {

            }

            //string constr = ConfigurationManager.ConnectionStrings["VoiceProjectdb"].ConnectionString;
            //SqlConnection conn = new SqlConnection();


            //conn.ConnectionString = constr;
            //conn.Open();
        }

       
        //    //SqlCommand cmd = new SqlCommand("SELECT * FROM SubTopic", conn);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    DataTable newsT = dt.Select("subTopicRef = 1").CopyToDataTable();
        //    DataTable genT = dt.Select("subTopicRef = 2").CopyToDataTable();

        //    foreach (DataRow row in newsT.Rows)
        //    {
        //        String topic = row["subTopicDesc"].ToString();
        //        HyperLink link = new HyperLink();
        //        link.NavigateUrl = "http://localhost:50294/GunSlayah%20Forum" + topic;
        //        TableRow r = new TableRow();
        //        TableCell subTopic = new TableCell();
        //        TableCell threads = new TableCell();
        //        TableCell posts = new TableCell();

        //        // Link
        //        link.Text = topic;
        //        subTopic.Controls.Add(link);
        //        r.Controls.Add(subTopic);

        //        // Threads
        //        ThreadController tc = new ThreadController();
        //        threads.Text = tc.getThreadCount(Convert.ToInt32(row["subTopicID"].ToString())).ToString();
        //        r.Controls.Add(threads);

        //        // Posts
        //        DataTable postTable = tc.getSubTopicDt(Convert.ToInt32(row["subTopicID"].ToString()));
        //        int total = 0;
        //        foreach (DataRow postRow in postTable.Rows)
        //        {
        //            total += tc.fetchReplyCount(tc.fetchThreadDesc(Convert.ToInt32(postRow["threadID"].ToString())).ToString());
        //        }
        //        posts.Text = total.ToString();
        //        r.Controls.Add(posts);

        //        NewsTable.Controls.Add(r);

        //    }

        //    foreach (DataRow row in genT.Rows)
        //    {
        //        String topic = row["subTopicDesc"].ToString();
        //        HyperLink link = new HyperLink();
        //        link.NavigateUrl = "https://localhost:44337/MainForum/subForum?subTopicRef=" + topic;
        //        TableRow r = new TableRow();
        //        TableCell c = new TableCell();
        //        TableCell threads = new TableCell();
        //        TableCell posts = new TableCell();

        //        link.Text = topic;
        //        c.Controls.Add(link);
        //        r.Controls.Add(c);
        //        GeneralTable.Controls.Add(r);

        //        // Threads
        //        ThreadController tc = new ThreadController();
        //        threads.Text = tc.getThreadCount(Convert.ToInt32(row["subTopicID"].ToString())).ToString();
        //        r.Controls.Add(threads);

        //        // Posts
        //        DataTable postTable = tc.getSubTopicDt(Convert.ToInt32(row["subTopicID"].ToString()));
        //        int total = 0;
        //        foreach (DataRow postRow in postTable.Rows)
        //        {
        //            total += tc.fetchReplyCount(tc.fetchThreadDesc(Convert.ToInt32(postRow["threadID"].ToString())).ToString());
        //        }
        //        posts.Text = total.ToString();
        //        r.Controls.Add(posts);

        //        GeneralTable.Controls.Add(r);

        //    }

        //}



        //protected void SearchButton_Click(object sender, EventArgs e)
        //{
        //    //GET INPUT FROM SEARCH TEXTBOX
        //    string searchDesc = SearchTextBox.Text;
        //    if (searchDesc != null && searchDesc != "")
        //    {
        //        //Use DataAccess class' getPosts
        //        Response.Redirect("SearchResults.aspx?searchTerm=" + searchDesc);
        //    }
        //}

    }

}
