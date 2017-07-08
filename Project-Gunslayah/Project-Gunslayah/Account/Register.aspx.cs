using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Project_Gunslayah.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.Data;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net;

namespace Project_Gunslayah.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["VoiceProjectdb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_User"))
               
                {
                    byte[] bytespass = Encoding.Unicode.GetBytes(password.Text);
                    SHA256Managed hashstringpass = new SHA256Managed();
                    byte[] hashpass = hashstringpass.ComputeHash(bytespass);
                    string hashStringpass = string.Empty;
                    foreach (byte x in hashpass)
                    {
                        hashStringpass += string.Format("{0:x2}", x);
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", hashStringpass);
                        cmd.Parameters.AddWithValue("@email", email.Text.Trim());

                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        MessageBox.ForeColor = Color.Red;
                        MessageBox.Text = "Username already exists.\\nPlease choose a different username.";
                        break;
                    case -2:
                        MessageBox.ForeColor = Color.Red;
                        MessageBox.Text = "Email address has already been used.";
                        break;
                    case -3:
                        MessageBox.ForeColor = Color.Red;
                        MessageBox.Text = "Username cannot be the same as password.";
                        break;
                    default:
                        SendActivationEmail(userId);
                        break;

                }

                string messageSuccess = "Registration successful.\\nActivation code has been sent.";
                Page.ClientScript.RegisterStartupScript(GetType(), "Scripts", "<script>alert('" + messageSuccess + "');window.location ='../Account/Activation.aspx?username=" + username.Text + "&email=" + email.Text + "';</script>");
            }
        }
        private void SendActivationEmail(int userId)
        {
            string constr = ConfigurationManager.ConnectionStrings["VoiceProjectdb"].ConnectionString;
            string actCode = otp();
            int status = 0;
            DateTime now = DateTime.Now;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@userId, @username, @activationCode, @status)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                        cmd.Parameters.AddWithValue("@activationCode", actCode);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                using (MailMessage mm = new MailMessage("noobsquad1503@gmail.com", email.Text))
                {
                    try
                    {
                        mm.Subject = "Account Activation";
                        string body = "Hello " + username.Text.Trim() + ",";
                        body += "<br /><br />Please enter the following code to activate your account";
                        body += "<br />" + actCode;
                        body += "<br /><br />Thanks";
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                        MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                        smtp.Port = 587;
                        smtp.Send(mm);
                        MessageBox.Text = "Activation code sent";
                        MessageBox.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Text = ex.ToString();
                    }
                }
            }
        }
        public string otp()
        {
            string num = "0123456789";
            int length = num.Length;
            string otp = string.Empty;
            //set no. of digits for otp
            int otpdigit = 5;
            string finaldigit;
            int getindex;
            for (int i = 0; i < otpdigit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, length);
                    finaldigit = num.ToCharArray()[getindex].ToString();
                } while (otp.IndexOf(finaldigit) != -1);

                otp += finaldigit;
            }
            return otp;
        }
    }
}