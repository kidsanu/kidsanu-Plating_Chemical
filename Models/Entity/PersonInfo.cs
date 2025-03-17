using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class PersonInfo
    {
        public PersonInfo()
        {
            this.PersonList = new List<PersonInfo>();
        }
        public List<PersonInfo> PersonList { get; set; }
        public string PERSON_ID { get; set; }
        public string NAME { get; set; }
        public string COUNTRY { get; set; }

    }
}