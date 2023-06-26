using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CURDOPERTION.Model;
using System.Data.SqlClient;

namespace CURDOPERTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HOSPITALController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HOSPITALController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllDetails")]

        public Responce GetAllDetails()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Responce responce = new Responce();
            DataAcessLayer responceLayer = new DataAcessLayer();
            responce = responceLayer.GetAllDetails(connection);


            return responce;
        }

        [HttpGet]
        [Route("GetAllDetailsByid/{id}")]

        public Responce GetAllDetailsByid(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Responce responce = new Responce();
            DataAcessLayer responceLayer = new DataAcessLayer();
            responce = responceLayer.GetAllDetailsByid(connection, id);


            return responce;
        }


        [HttpPost]
        [Route("AddHOSPITAL")]

        public Responce AddHospital(HOSPITAL hospital)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Responce responce = new Responce();
            DataAcessLayer responceLayer = new DataAcessLayer();
            responce = responceLayer.AddHOSPITAL(connection, hospital);


            return responce;




        }
    }
}
