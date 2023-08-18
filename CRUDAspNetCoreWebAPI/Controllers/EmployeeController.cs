using CRUDAspNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDAspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetAllEmployees()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response=dal.GetAllEmployees(con);
            return response;
        }

        [HttpGet]
        [Route("GetEmployeebyId/{id}")]
        public Response GetEmployeebyId(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetEmployeebyId(con,id);
            return response;
        }
        [HttpPost]
        [Route("PostData")]
        public Response PostData(Employee emp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.PostData(con, emp);
            return response;
        }
        [HttpPut]
        [Route("UpdateData")]
        public Response UpdateData(Employee emp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateData(con, emp);
            return response;
        }
        [HttpDelete]
        [Route("DeleteData")]
        public Response DeleteData(Employee emp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteData(con, emp);
            return response;
        }
    }
}
