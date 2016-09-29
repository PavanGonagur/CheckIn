using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Login
{
    public class LoginModel
    {
        /// <summary>
        /// Login user's user name
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Login user's password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}