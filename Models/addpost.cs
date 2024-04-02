using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CauseLink.Models
{
    public class addpost
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CauseLink;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        /*       SqlConnection conn = new SqlConnection(
         "Data Source=(localdb)\\MSSQLLocalDB;" +
         "Initial Catalog=MyAppDB;" +
         "Integrated Security=SSPI;";
       conn.Open(); */
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Please enter Commitement")]
        public string Commitment { get; set; }

        [Required(ErrorMessage = "Please enter IR")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Duration")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Please enter about")]
        public string Frequency { get; set; }

        [Required(ErrorMessage = "Please enter Mode")]
        public string Mode { get; set; }

        [Required(ErrorMessage = "Please enter Note")]
        public string Note { get; set; }


        public List<addpost> getData()
        {
            List<addpost> lstEmp = new List<addpost>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from post", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new addpost
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Title = dr["Title"].ToString(),
                    Date = dr["Date"].ToString(),
                    Commitment = dr["Commitment"].ToString(),
                    Location = dr["Location"].ToString(),
                    Address = dr["Address"].ToString(),
                    Duration = dr["Duration"].ToString(),
                    Frequency = dr["Frequency"].ToString(),
                    Mode = dr["Mode"].ToString(),
                    Note = dr["Note"].ToString(),





                });
            }
            return lstEmp;
        }
        //Retrieve single record from a table
        public addpost getData(string Id)
        {
            addpost emp2 = new addpost();
            SqlCommand cmd = new SqlCommand("select * from post where id='" + Id +
           "'", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp2.Id = Convert.ToInt32(dr["Id"].ToString());
                    emp2.Title = dr["Title"].ToString();
                    emp2.Date = dr["Date"].ToString();
                    emp2.Commitment = dr["Commitment"].ToString();
                    emp2.Location = dr["Location"].ToString();
                    emp2.Address = dr["Address"].ToString();
                    emp2.Duration = dr["Duration"].ToString();
                    emp2.Frequency = dr["Frequency"].ToString();
                    emp2.Mode = dr["Mode"].ToString();
                    emp2.Note = dr["Note"].ToString();
                }
            }
            con.Close();
            return emp2;
        }

        public bool insert(addpost Emp)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO post  VALUES (@Title, @Date, @Commitment, @Location, @Address, @Duration, @Frequency, @Mode, @Note)", con);
            {
                cmd.Parameters.AddWithValue("@Title", Emp.Title);
                cmd.Parameters.AddWithValue("@Date", Emp.Date);
                cmd.Parameters.AddWithValue("@Commitment", Emp.Commitment);
                cmd.Parameters.AddWithValue("@Location", Emp.Location);
                cmd.Parameters.AddWithValue("@Address", Emp.Address);
                cmd.Parameters.AddWithValue("@Duration", Emp.Duration);
                cmd.Parameters.AddWithValue("@Frequency", Emp.Frequency);
                cmd.Parameters.AddWithValue("@Mode", Emp.Mode);
                cmd.Parameters.AddWithValue("@Note", Emp.Note);
                con.Open(); // Open connection
                int i = cmd.ExecuteNonQuery(); // Execute the non-query command
                if (i >= 1)
                {
                    return true;
                }
                return false;
            }
        }
        public bool update(addpost Emp)
        {
            SqlCommand cmd = new SqlCommand("update post set Title=@Title, Date=@Date, Commitment=@Commitment, Location=@Location, Address=@Address, Duration=@Duration, Frequency=@Frequency, Mode=@Mode, Note=@Note where Id=@id", con);
            cmd.Parameters.AddWithValue("@Title", Emp.Title);
            cmd.Parameters.AddWithValue("@Date", Emp.Date);
            cmd.Parameters.AddWithValue("@Commitment", Emp.Commitment);
            cmd.Parameters.AddWithValue("@Location", Emp.Location);
            cmd.Parameters.AddWithValue("@Address", Emp.Address);
            cmd.Parameters.AddWithValue("@Duration", Emp.Duration);
            cmd.Parameters.AddWithValue("@Frequency", Emp.Frequency);
            cmd.Parameters.AddWithValue("@Mode", Emp.Mode);
            cmd.Parameters.AddWithValue("@Note", Emp.Note);
            cmd.Parameters.AddWithValue("@Id", Emp.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        public bool delete(addpost Emp)
        {
            SqlCommand cmd = new SqlCommand("delete post where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", Emp.Id);
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
    
