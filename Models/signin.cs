using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CauseLink.Models
{
    public class signin
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CauseLink;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        /*       SqlConnection conn = new SqlConnection(
         "Data Source=(localdb)\\MSSQLLocalDB;" +
         "Initial Catalog=MyAppDB;" +
         "Integrated Security=SSPI;";
       conn.Open(); */
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        public List<signin> getData()
        {
            List<signin> lstEmp = new List<signin>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from tbl_login", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new signin
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),

                });
            }
            return lstEmp;
        }
        //Retrieve single record from a table
        public signin getData(string Id)
        {
            signin emp = new signin();
            SqlCommand cmd = new SqlCommand("select * from tbl_login where id='" + Id +
           "'", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["Id"].ToString());
                    emp.Email = dr["Email"].ToString();
                    emp.Password = dr["Password"].ToString();

                }
            }
            con.Close();
            return emp;
        }

        public bool insert(signin Emp)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_login values(@Email, @Password)", con);

            cmd.Parameters.AddWithValue("@Email", Emp.Email);
            cmd.Parameters.AddWithValue("@Password", Emp.Password);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
    }
}