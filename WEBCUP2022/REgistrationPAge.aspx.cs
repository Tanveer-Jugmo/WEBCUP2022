using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Net.Mail;

namespace WEBCUP2022
{
    public partial class REgistrationPAge : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["NeoDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            

                SqlConnection con = new SqlConnection(_conString);
                // Create Command
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                //search for username from tbluser 
                cmd.CommandText = "select C_Username from tblClient where C_Username = @uname";
                //create a parameterized query
                cmd.Parameters.AddWithValue("@uname", txtuname.Text.Trim());
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                //Check if username already exists in the DB
                if (dr.HasRows)
                {
                    lblMsg.Text = "Username Already Exist, Please Choose Another";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    txtuname.Focus();
                }
                else
                {
                    //Ensure the DataReader is closed
                    dr.Close();

                    Boolean IsAdded = false;
                    SqlConnection con1 = new SqlConnection(_conString);
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into tblClient(C_Fname, C_Lname, C_City,C_Country, C_Username, C_Password) values (@fname, @lname, @city, @Country, @uname,@pass )";
                    cmd1.Parameters.AddWithValue("@fname", txtfname.Text.Trim());
                    cmd1.Parameters.AddWithValue("@lname", txtlname.Text.Trim());
                    cmd1.Parameters.AddWithValue("@city", txtCity.Text);
                cmd1.Parameters.AddWithValue("@Country", txtCountry.Text.Trim());
                    cmd1.Parameters.AddWithValue("@uname", txtuname.Text.Trim());
                    cmd1.Parameters.AddWithValue("@pass", Encrypt(txtPassword.Text.Trim()));
                    cmd1.Parameters.AddWithValue("@cpass", txtCpassword.Text.Trim());
                 
                    cmd1.Connection = con1;
                    con1.Open();

                    IsAdded = cmd1.ExecuteNonQuery() > 0;
                    
                    con1.Close();
                    Response.Redirect("index.aspx");
                }
            }

        public string Encrypt(string clearText)
        {
            // defining encrytion key
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new
               byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    // encoding using key9 
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


    }
}
