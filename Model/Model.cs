using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    class LoginModel
    {
        public string FullName { get; set; }
        public string AccessType {get; set;}
        public int TotalAlerts {get; set;}
        public int HandledAlerts {get;set;}
        public int MissedAlerts {get;set;}
        public string Language {get;set;}
    }

    class PersonnelModel
    {
        public string Name {get;set;}
        public string Role {get;set;}
        public string Email {get;set;}
        public string Phone {get;set;}
        public string filepath {get;set;}
    }
}