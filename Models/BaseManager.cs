using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace WebApplication2.Models
{
    public class BaseManager
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CMK_ConnectionString"].ToString();
            }
        }
    }
}