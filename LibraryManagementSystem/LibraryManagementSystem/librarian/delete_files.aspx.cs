﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{

    public partial class delete_files : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library_Management_System\LibraryManagementSystem\LibraryManagementSystem\App_Data\lms.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if(Request.QueryString["id"] != null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_video='' where id='"+ Request.QueryString["id"].ToString() +"'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_pdf='' where id='" + Request.QueryString["id1"].ToString() + "'";
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("display_all_books.aspx");
        }
    }
}