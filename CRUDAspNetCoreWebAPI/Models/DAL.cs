using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CRUDAspNetCoreWebAPI.Models
{
    public class DAL
    {
        //Get All Employee Data
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter sda = new SqlDataAdapter("SpselTblCrudNetCore", connection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            List<Employee> emplist = new List<Employee>();

            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Employee objemp = new Employee();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objemp.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objemp.Name = dt.Rows[0]["Name"].ToString();
                    objemp.Email = dt.Rows[0]["Email"].ToString();
                    objemp.IsActive = Convert.ToInt32(dt.Rows[0]["ID"]);
                    emplist.Add(objemp);
                }
            }
            if (emplist.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.Listemployee = emplist;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Data Not found";
                response.Listemployee = null;
            }

            return response;
        }
        //Get Employee Data By Id
        public Response GetEmployeebyId(SqlConnection connection,int id)
        {
            Response response = new Response();
            SqlDataAdapter sda = new SqlDataAdapter("SpselGetByIdTblCrudNetCore ", connection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            Employee objemp = new Employee();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                     
               
                    objemp.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objemp.Name = dt.Rows[0]["Name"].ToString();
                    objemp.Email = dt.Rows[0]["Email"].ToString();
                    objemp.IsActive = Convert.ToInt32(dt.Rows[0]["ID"]);
                    
            }
            if (objemp !=null)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.Employee = objemp;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Data Not found";
                response.Employee = null;
            }

            return response;
        }
        //Post Data
        public Response PostData(SqlConnection connection, Employee emp)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("SpInsTblCrudNetCore ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Inserted successfully"; 
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Data not Inserted";
               
            }

            return response;
        }
        //Update
        public Response UpdateData(SqlConnection connection, Employee emp)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("SpUpdatedTblCrudNetCore ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", emp.ID);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Data not Updated";

            }

            return response;
        }
        //Delete
        public Response DeleteData(SqlConnection connection, Employee emp)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("SpDeleteTblCrudNetCore ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", emp.ID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Deleted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Data not Deleted";

            }

            return response;
        }

    }
}
