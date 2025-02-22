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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library_Management_System\LibraryManagementSystem\LibraryManagementSystem\App_Data\lms.mdf;Integrated Security=True");
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            if (IsPostBack) return;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from books where id="+id+"";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                bookstitle.Text = dr["books_title"].ToString();
                authorname.Text = dr["books_author_name"].ToString();
                isbn.Text = dr["books_isbn"].ToString();
                qty.Text = dr["availabel_qty"].ToString();
                booksimage.Text = dr["books_image"].ToString();
                bookspdf.Text = dr["books_pdf"].ToString();
                booksvideo.Text = dr["books_video"].ToString();

            }
          
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string path = "";
            string path2 = "";
            string path3 = "";

            

            if(fo1.FileName.ToString() != "")
            {
                fo1.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + fo1.FileName.ToString());
                path = "books_images/" + fo1.FileName.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title='"+ bookstitle.Text+"',books_image='"+ path.ToString() +"',books_author_name='"+ authorname.Text +"',books_isbn='"+isbn.Text +"',availabel_qty='"+ qty.Text +"' where id="+ id +"";
                cmd.ExecuteNonQuery();
            }

            if (fo2.FileName.ToString() != "")
            {

                fo2.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_pdf/" + fo2.FileName.ToString());
                path2 = "books_pdf/" + fo2.FileName.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title='" + bookstitle.Text + "',books_pdf='" + path2.ToString() + "',books_author_name='" + authorname.Text + "',books_isbn='" + isbn.Text + "',availabel_qty='" + qty.Text + "' where id=" + id + "";
                cmd.ExecuteNonQuery();

            }

            if (fo2.FileName.ToString() != "")
            {

                fo3.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_video/" + fo3.FileName.ToString());
                path3 = "books_video/" + fo3.FileName.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title='" + bookstitle.Text + "',books_video='" + path3.ToString() + "',books_author_name='" + authorname.Text + "',books_isbn='" + isbn.Text + "',availabel_qty='" + qty.Text + "' where id=" + id + "";
                cmd.ExecuteNonQuery();
            }

            if(fo1.FileName.ToString()=="" && fo2.FileName.ToString() == "" && fo3.FileName.ToString() == "")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title='" + bookstitle.Text + "',books_author_name='" + authorname.Text + "',books_isbn='" + isbn.Text + "',availabel_qty='" + qty.Text + "' where id=" + id + "";
                cmd.ExecuteNonQuery();
            }




            Response.Redirect("display_all_books.aspx");
        }
    }
}