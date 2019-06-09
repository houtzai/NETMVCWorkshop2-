using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NETMVCworkshop2.Models
{
    public class BookDataService
    {
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString.ToString();
        }

        public List<BookData> GetBook()
        {
            DataTable dt = new DataTable();
            string sql = @"Select BOOK_CLASS_ID, BOOK_NAME, BOOK_BOUGHT_DATE, BOOK_STATUS, BOOK_KEEPER
                           FROM dbo.BOOK_DATA";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return MapCodeData(dt);
        }

        private List<BookData> MapCodeData(DataTable dt)
        {
            List<BookData> result = new List<BookData>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new BookData()
                {
                    BOOK_CLASS_ID = row["BOOK_CLASS_ID"].ToString(),
                    BOOK_NAME = row["BOOK_NAME"].ToString(),
                    BOOK_BOUGHT_DATE = row["BOOK_BOUGHT_DATE"].ToString(),
                    BOOK_STATUS = row["BOOK_STATUS"].ToString(),
                    BOOK_KEEPER = row["BOOK_KEEPER"].ToString()
                });
            }
            return result;
        }

        public void InsertBook(Models.BookData bookdata)
        {
            string sql = @" Insert Into dbo.BOOK_DATA (BOOK_NAME, BOOK_AUTHOR, BOOK_PUBLISHER, BOOK_NOTE, BOOK_BOUGHT_DATE, BOOK_CLASS_ID, BOOK_STATUS, BOOK_KEEPER) 
                         Values(@BOOK_NAME, @BOOK_AUTHOR, @BOOK_PUBLISHER, @BOOK_NOTE, @BOOK_BOUGHT_DATE, @BOOK_CLASS_ID, @BOOK_STATUS, @BOOK_KEEPER)";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", bookdata.BOOK_NAME));
                cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", bookdata.BOOK_AUTHOR));
                cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", bookdata.BOOK_PUBLISHER));
                cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", bookdata.BOOK_STATUS));
                cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", bookdata.BOOK_KEEPER));
                cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", bookdata.BOOK_BOUGHT_DATE));
                cmd.Parameters.Add(new SqlParameter("@BOOK_STATUS", bookdata.BOOK_STATUS));
                cmd.Parameters.Add(new SqlParameter("@BOOK_KEEPER", bookdata.BOOK_KEEPER));
                conn.Close();
            }
        }

        public void UpdateBook(Models.BookData bookdata)
        {
            string sql = @" Update dbo.BOOK_DATA Set BOOK_NAME=@BOOK_NAME, BOOK_AUTHOR=@BOOK_AUTHOR, BOOK_PUBLISHER=@BOOK_PUBLISHER,
                           BOOK_NOTE=@BOOK_NOTE, BOOK_BOUGHT_DATE=@BOOK_BOUGHT_DATE, BOOK_CLASS_ID=@BOOK_CLASS_ID, BOOK_STATUS=@BOOK_STATUS
                           , BOOK_KEEPER=@BOOK_KEEPER Where BOOK_ID=@BOOK_ID";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", bookdata.BOOK_NAME));
                cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", bookdata.BOOK_AUTHOR));
                cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", bookdata.BOOK_PUBLISHER));
                cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", bookdata.BOOK_STATUS));
                cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", bookdata.BOOK_KEEPER));
                cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", bookdata.BOOK_BOUGHT_DATE));
                cmd.Parameters.Add(new SqlParameter("@BOOK_STATUS", bookdata.BOOK_STATUS));
                cmd.Parameters.Add(new SqlParameter("@BOOK_KEEPER", bookdata.BOOK_KEEPER));
                cmd.Parameters.Add(new SqlParameter("@BOOK_ID", bookdata.BOOK_ID));
                conn.Close();
            }
        }

        public void DeleteBook(string bookId)
        {
            try
            {
                string sql = "Delete FROM dbo.BOOK_DATA Where BOOK_ID=@BOOK_ID";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@BOOK_ID", bookId));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}