using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;

namespace StoreApp.Models
{

    public class GuestInfo
    {
        public int ID { get; set; } 
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string USerLastName { get; set; }
        public string UserPassword { get; set; }
        public string UserMobileNo { get; set; }
        public string UserDBO { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserGender { get; set; }
        public string UserAddress { get; set; }

      



        //public GuestInfo(SqlDataReader  rdr)
        //{

        //   while(rdr.Read())
        //    {
        //        GuestInfo Obj = new GuestInfo();
        //        Obj.ID = Convert.ToInt32(rdr["Id"]);
        //        Obj.Username = rdr["UserName"].ToString();

        //    }
        //}

        //public GuestInfo()
        //{

        //}

    }

    public class FormData
    {
        public string FormName { get; set; }
        public string GuestFormData { get; set; }
        public string UserName { get; set; }
        public string CreationDate { get; set; }
        public string UpdatedDate { get; set; }

        public int Count { get; set; }
         
    }
     
}