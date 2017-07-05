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

namespace Project_Gunslayah.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["ForumDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("insert into Users (username,password,email) VALUES (@username,@password,@email)"))
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

                        cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", hashStringpass);
                        cmd.Parameters.AddWithValue("@email", email.Text.Trim());

                        cmd.Connection = con;
                        con.Open();

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
             
                      
                }
                string messageSuccess = "Registration successful.\\nActivation code has been sent.";
            }
        }
    }
}
