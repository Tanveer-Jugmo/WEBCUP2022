using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace WEBCUP2022
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["NeoDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtuname.Text.Trim();
            string password = txtPassword.Text.Trim();


            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //searching for a record containing matching username & password with 
            //an active status
            cmd.CommandText = "select * from tblClient where C_Username=@un and C_Password=@pass";

            //create two parameterized query for the above select statement
            //use above variables and decrypt password
            cmd.Parameters.AddWithValue("@un", username);
            cmd.Parameters.AddWithValue("@pass", Decrypt(password));
            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            // check if the DataReader contains a record
            if (dr.HasRows)
            {

                if (dr.Read())
                {
                    //create a memory cookie to store username and pwd
                    Response.Cookies["username"].Value = username;
                    Response.Cookies["password"].Value = password;



                    //check if role type is admin or user - optional
                    //create and save username in a session variable
                    Session["uname"] = username;
                    //create and save userid in a session variable
                    Session["cid"] = dr["ClientID"].ToString();
                    //redirect to the corresponding page
                    Response.Redirect("ClientPage.aspx");
                }
                con.Close();
            }
            else
            {
                //delete content of password field 

                lblmsg.Text = "You are not registered or your account has been suspended!";
            }
        }

        public string Decrypt(string cipherText)
        {
            // defining encrytion key
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey,
               new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    // encoding using key
                    using (CryptoStream cs = new CryptoStream(ms,
                   encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    cipherText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}