using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication4.Attribut;

namespace WebApplication4.Models
{
    //model danych
    public class InviteModel
    {

        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } 
        public bool? WillaAttend { get; set; }
    }
}