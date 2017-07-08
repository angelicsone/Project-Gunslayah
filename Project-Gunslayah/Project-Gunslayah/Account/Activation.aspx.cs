using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Gunslayah.Account
{
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["username"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        public class Person
        {
            public string username { get; set; }
            public string actCode { get; set; }
            public string status { get; set; }
            public DateTime dateCode { get; set; }
            public string email { get; set; }
        }

        public Person getUser(string username)
        {
            string constr = ConfigurationManager.ConnectionStrings["VoiceProjectdb"].ConnectionString;
            Person matchingPerson = new Person();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string oString = "Select * from UserActivation WHERE username = @username";
                SqlCommand cmd = new SqlCommand(oString, con);
                cmd.Parameters.AddWithValue("@username", username);
                con.Open();
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson.username = oReader["username"].ToString();
                        matchingPerson.actCode = oReader["activationCode"].ToString();
                        matchingPerson.status = oReader["status"].ToString();
                        matchingPerson.dateCode = Convert.ToDateTime(oReader["dateCode"]);
                    }
                    con.Close();
                }

                using (SqlConnection con1 = new SqlConnection(constr))
                {
                    string iString = "Select * from Users WHERE username = @username";
                    SqlCommand cmd1 = new SqlCommand(iString, con1);
                    cmd1.Parameters.AddWithValue("@username", username);
                    con1.Open();
                    using (SqlDataReader oReader = cmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            matchingPerson.username = oReader["username"].ToString();
                            matchingPerson.email = oReader["email"].ToString();
                        }
                        con1.Close();
                    }
                }
                return matchingPerson;
            }
        }

        protected void VerifyUser_Click(object sender, EventArgs e)
        {
            string username = Request.QueryString["username"];
            string constr = ConfigurationManager.ConnectionStrings["VoiceProjectdb"].ConnectionString;
            Person matchingPerson = new Person();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string oString = "Select * from UserActivation WHERE username = @username";
                SqlCommand cmd = new SqlCommand(oString, con);
                cmd.Parameters.AddWithValue("@username", username);
                con.Open();
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson.username = oReader["username"].ToString();
                        matchingPerson.actCode = oReader["activationCode"].ToString();
                        matchingPerson.status = oReader["status"].ToString();
                        
                    }
                    con.Close();
                }
            }

            using (SqlConnection con1 = new SqlConnection(constr))
            {
                string iString = "Select * from Users WHERE username = @username";
                SqlCommand cmd1 = new SqlCommand(iString, con1);
                cmd1.Parameters.AddWithValue("@username", username);
                con1.Open();
                using (SqlDataReader oReader = cmd1.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson.username = oReader["username"].ToString();
                        matchingPerson.email = oReader["email"].ToString();
                    }
                    con1.Close();
                }
            }


            if (actCode.Text == matchingPerson.actCode && matchingPerson.status == "0")
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    int rowsAffected = 0;
                    int status = 1;
                    using (SqlCommand cmd = new SqlCommand("UPDATE [UserActivation] SET status = @status WHERE username = @username"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {

                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Connection = con;
                            con.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    //success
                    if (rowsAffected > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Scripts", "<script>alert('Account Activated!');window.location ='Login?username=" + username + "';</script>");
                    }
                    else
                    {
                        MessageBox.ForeColor = Color.Red;
                        MessageBox.Text = "Account not activated";
                    }
                }
            }

            else if (matchingPerson.status == "1")
            {
                string message = "Account already activated.";
                Page.ClientScript.RegisterStartupScript(GetType(), "Scripts", "<script>alert('" + message + "');window.location ='Login.aspx';</script>");
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                //Response.Redirect("Login.aspx");
            }

           
            else
            {
                MessageBox.ForeColor = Color.Red;
                MessageBox.Text = "Invalid inputs";
            }
        }
    }
}