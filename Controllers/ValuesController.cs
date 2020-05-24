using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Http.Description;
using System.Web;
using System.ComponentModel;
using Newtonsoft.Json;
using StoreApp.Models;
using System.Data;

namespace StoreApp.Controllers
{
     
    public class ValuesController : ApiController
    {
        private string strcon = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
       

        [HttpGet]
        [Route("~/api/values/GuestInfo")]
        [ResponseType(typeof(GuestInfo))]
        public IHttpActionResult GetGuestDetails()
        {
            string SqlCmd;
            try
            {
                SqlCmd = "spGetEmployees";
                List<GuestInfo> responses = new List<GuestInfo>();
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd, DbConnection);
                DbConnection.Open();
                dynamic rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {

                    GuestInfo GuestInfo = new GuestInfo();

                    GuestInfo.ID = Convert.ToInt32(rdr["id"]);
                    GuestInfo.UserName = rdr["username"].ToString();
                    GuestInfo.UserFirstName = rdr["UserFirstName"].ToString();
                    GuestInfo.USerLastName = rdr["USerLastName"].ToString();
                    GuestInfo.UserPassword = rdr["UserPassword"].ToString();
                    GuestInfo.UserMobileNo = rdr["UserMobileNo"].ToString();
                    GuestInfo.UserDBO = rdr["UserDBO"].ToString();
                    GuestInfo.UserEmailAddress = rdr["UserEmailAddress"].ToString();
                    GuestInfo.UserGender = rdr["UserGender"].ToString();
                    GuestInfo.UserAddress = rdr["UserAddress"].ToString();

                    responses.Add(GuestInfo);
                    
                }

                DbConnection.Close();
                //string JSONresult = JsonConvert.SerializeObject(responses);
                //return Ok(JSONresult);
                return Ok(responses);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("~/api/values/GuestInfo/{username}")]
        [ResponseType(typeof(GuestInfo))]
        public IHttpActionResult GetGuestDetails(string username)
        {
            string SqlCmd;
            try
            {
                SqlCmd = "spGetSpecificEmployee" + " '" + username + "'";
                List<GuestInfo> responses = new List<GuestInfo>();
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd, DbConnection);
                DbConnection.Open();
                dynamic rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    GuestInfo GuestInfo = new GuestInfo();
                    GuestInfo.ID = Convert.ToInt32(rdr["id"]);
                    GuestInfo.UserName = rdr["username"].ToString();
                    GuestInfo.UserFirstName = rdr["UserFirstName"].ToString();
                    GuestInfo.USerLastName = rdr["USerLastName"].ToString();
                    GuestInfo.UserPassword = rdr["UserPassword"].ToString();
                    GuestInfo.UserMobileNo = rdr["UserMobileNo"].ToString();
                    GuestInfo.UserDBO = rdr["UserDBO"].ToString();
                    GuestInfo.UserEmailAddress = rdr["UserEmailAddress"].ToString();
                    GuestInfo.UserGender = rdr["UserGender"].ToString();
                    GuestInfo.UserAddress = rdr["UserAddress"].ToString();
                    responses.Add(GuestInfo);
                }

                DbConnection.Close();
                return Ok(responses);
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpPost]
        [Route("~/api/values/GuestInfo")]
        public IHttpActionResult PostGuestDetails([FromBody]GuestInfo request)
        {
            string SqlCmd;
            try
            {
                SqlCmd = "spPostEmployees" + " " + request.ID + ",'" + request.UserName + "','" + request.UserFirstName + "','" + request.USerLastName + "','" + request.UserPassword + "','" + request.UserMobileNo + "','" + request.UserDBO + "','" + request.UserEmailAddress + "','" + request.UserGender + "','" + request.UserAddress + "'";
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd.ToString(), DbConnection);
                DbConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DbConnection.Close();
                return Ok();
            }
            catch
            {
              return BadRequest();
            }
        }

        [HttpPut]
        [Route("~/api/values/UpdateGuest")]
        public IHttpActionResult UpdateGuestDetails([FromBody]GuestInfo request)
        {
            string SqlCmd;
            try
            {
                SqlCmd = "spUpdateEmployeeDetails" + " '" + request.UserName + "','" + request.UserFirstName + "','" + request.USerLastName + "','" + request.UserPassword + "','" + request.UserMobileNo + "','" + request.UserDBO + "','" + request.UserEmailAddress + "','" + request.UserGender + "','" + request.UserAddress + "','"+ request.ID + "'";
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd.ToString(), DbConnection);
                DbConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DbConnection.Close();
                return Ok();  
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("~/api/values/DeleteGuest/{username}")]
        public IHttpActionResult DeleteGuestDetails(string username)
        {
            string SqlCmd;
            try
            {
                SqlCmd = "spDeleteSpecificEmployee" + " '" + username + "'";
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd.ToString(), DbConnection);
                DbConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DbConnection.Close();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("~/api/values/GuestFormInfo/{username}")]
        [ResponseType(typeof(FormData))]
        public IHttpActionResult GetGuestFormDetails(string username)
        {
            string SqlCmd;
            try
            {
                SqlCmd = "spGetGuestFormDetails" + " '" + username + "'";
                List<FormData> responses = new List<FormData>();
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd, DbConnection);
                DbConnection.Open();
                dynamic rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    FormData FormInfo = new FormData();
                    FormInfo.FormName = rdr["FormName"].ToString();
                    responses.Add(FormInfo);
                }

                DbConnection.Close();
                return Ok(responses);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("~/api/values/FormDuplicate/{UserName}/{FormName}")]
        [ResponseType(typeof(FormData))]
        public IHttpActionResult IdentifyDuplicateForms(string username, string FormName)
         {
          // dynamic ReturnValue = 0;
          //  int order_id = -1;

            string SqlCmd;
            try
            {    

                SqlCmd = "spIdentifyDuplicateForms" + " '" + username + "','" + FormName + "'";
                List<FormData> responses = new List<FormData>();
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd, DbConnection);
                DbConnection.Open();
                dynamic rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    FormData FormInfo = new FormData();
                    FormInfo.FormName = rdr["FormName"].ToString();
                    FormInfo.CreationDate = rdr["FormCreationDate"].ToString();
                    responses.Add(FormInfo);

                }
                 
                DbConnection.Close();
                return Ok(responses);

            }
            catch 
            {
                return BadRequest();
            }

        }

         
        [HttpPost]
        [Route("~/api/values/PostForm")]
        public IHttpActionResult PostGuestForm([FromBody]FormData request)
        {
            string SqlCmd;
            try
            {
                //HttpUtility.HtmlDecode
             
                SqlCmd = "spPostGuestForm" + " '" + request.UserName + "','" + HttpUtility.HtmlEncode(request.GuestFormData) + "','" + request.FormName + "','" + request.CreationDate + "','" + request.UpdatedDate + "'";
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd.ToString(), DbConnection);
                DbConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DbConnection.Close();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("~/api/values/GuestFormCode/{FormName}")]
        [ResponseType(typeof(GuestInfo))]    
        public IHttpActionResult GetGuestSelectedFormCode(string FormName)
        {
            string SqlCmd;
            try
            {
                SqlCmd = "spGetGuestselectedFormData" + " '" + FormName + "'";
                List<FormData> responses = new List<FormData>();
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd, DbConnection);
                DbConnection.Open();
                dynamic rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    FormData FormInfo = new FormData();
                         
                    FormInfo.GuestFormData = HttpUtility.HtmlDecode(rdr["FormData"]);

                    responses.Add(FormInfo);
                }

                DbConnection.Close();
                return Ok(responses);
            }
            catch
            {
                return BadRequest();
            }

        }     



        [HttpPut]
        [Route("~/api/values/UpdateGuestFormCode")]
        public IHttpActionResult UpdateGuestFormCode([FromBody]FormData request)
        {
            string SqlCmd;
            try
            {
                SqlCmd = "spUpdateGuestselectedFormData" + " '" + request.FormName + "','" + request.UserName + "','" + HttpUtility.HtmlEncode(request.GuestFormData) + "'";
                SqlConnection DbConnection = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(SqlCmd.ToString(), DbConnection);
                DbConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DbConnection.Close();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}

