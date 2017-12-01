using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMVC.Models
{

    public class UserDetails
    {
        [StringLength(7, MinimumLength = 2, ErrorMessage = "UserName length should be between 2 and 7")]
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public class UserEntities
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string Password { get; set; }        
        public int Id { get; set; }

    }
}