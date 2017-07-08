using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Project_Gunslayah.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using System.Drawing;

namespace Project_Gunslayah.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

        public class Person
        {
            public string username { get; set; }
            public string status { get; set; }
            public string actCode { get; set; }
            public string password { get; set; }
            public string email { get; set; }

        }

        public Person getUser(string username)
        {
            string constr = ConfigurationManager.ConnectionStrings["VoiceProjectdb"].ConnectionString;
            Person matchingPerson = new Person();

            using (SqlConnection con = new SqlConnection(constr))
            {
                string oString = "Select * from Users WHERE username = @username";
                SqlCommand cmd = new SqlCommand(oString, con);
                cmd.Parameters.AddWithValue("@username", Username.Text);
                con.Open();
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson.username = oReader["username"].ToString();
                        matchingPerson.email = oReader["email"].ToString();
                        matchingPerson.password = oReader["password"].ToString();
                    }
                    con.Close();
                }

                using (SqlConnection con1 = new SqlConnection(constr))
                {
                    string iString = "Select * from UserActivation WHERE username = @username";
                    SqlCommand icmd = new SqlCommand(iString, con);
                    cmd.Parameters.AddWithValue("@username", Username.Text);
                    con1.Open();
                    using (SqlDataReader iReader = cmd.ExecuteReader())
                    {
                        while (iReader.Read())
                        {
                            matchingPerson.username = iReader["username"].ToString();
                            matchingPerson.actCode = iReader["actCode"].ToString();
                            matchingPerson.status = iReader["status"].ToString();

                        }

                    }
                    con1.Close();
                }

                return matchingPerson;
            }
        }

        //Login
        protected void LogIn(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["VoiceProjectdb"].ConnectionString;
            Person matchingPerson = new Person();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string oString = "Select * from UserActivation WHERE username = @username";
                SqlCommand cmd = new SqlCommand(oString, con);
                cmd.Parameters.AddWithValue("@username", Username.Text.Trim());
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

            using (SqlConnection zcon = new SqlConnection(constr))
            {
                string zString = "Select * from Users WHERE username = @username";
                SqlCommand zcmd = new SqlCommand(zString, zcon);
                zcmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                zcon.Open();
                using (SqlDataReader zReader = zcmd.ExecuteReader())
                {
                    while (zReader.Read())
                    {
                        matchingPerson.username = zReader["username"].ToString();
                        matchingPerson.email = zReader["email"].ToString();
                        matchingPerson.password = zReader["password"].ToString();
                    }
                }
            }


            if (matchingPerson.status == "0")
            {


                //get OTP method from register,set new otp ans status back to 0 (not yet activated) and update database
                Register rg = new Register();
                string otp = rg.otp();
                string newStatus = "0";
                DateTime now = DateTime.Now;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE UserActivation SET activationCode = @activationCode, status = @status WHERE username = @username"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@username", Username.Text);
                            cmd.Parameters.AddWithValue("@activationCode", otp);
                            cmd.Parameters.AddWithValue("@status", newStatus);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }

                //otp send to user email
                using (MailMessage mm = new MailMessage("noobsquad1503@gmail.com", matchingPerson.email))
                {
                    try
                    {
                        mm.Subject = "Account Activation";
                        string body = "Hello " + Username.Text + ",";
                        body += "<br /><br />Please enter the following code to activate your account";
                        body += "<br />" + otp;
                        body += "<br /><br />Thanks";
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("noobsquad1503@gmail.com", "15noobsquad03");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        string message = "Activation code sent to email.";
                        Page.ClientScript.RegisterStartupScript(GetType(), "Scripts", "<script>alert('" + message + "');window.location ='../Account/Activation.aspx?username=" + Username.Text + "';</script>");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Text = ex.ToString();
                    }
                }
            }
              


            else
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string oString = "Select * from Users WHERE username = @username";
                    SqlCommand cmd = new SqlCommand(oString, con);
                    cmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                    con.Open();
                    using (SqlDataReader oReader = cmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            matchingPerson.username = oReader["username"].ToString();
                            matchingPerson.password = oReader["password"].ToString();

                        }
                        con.Close();
                    }
                }

                byte[] bytespass = Encoding.Unicode.GetBytes(Password.Text);
                SHA256Managed hashstringpass = new SHA256Managed();
                byte[] hashpass = hashstringpass.ComputeHash(bytespass);
                string hashStringpass = string.Empty;
                foreach (byte x in hashpass)
                {
                    hashStringpass += string.Format("{0:x2}", x);
                }

                if (matchingPerson.password == hashStringpass)
                {
                    Session["Username"] = Username.Text;
                    //Session.Timeout = 1;                   
                        FormsAuthentication.SetAuthCookie(Session["Username"].ToString(), true);

                        if (Session["prev"] == null)
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                        else
                        {
                            //Response.Redirect(Session["prev"].ToString());
                        }

                    }
                
                else
                {
                    string message = "Invalid Username or Password.";
                    Page.ClientScript.RegisterStartupScript(GetType(), "Scripts", "<script>alert('" + message + "');");
                }
           

            }
        }
       
    }


}


