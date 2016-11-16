using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Login
{
    public class PasswordResetModel
    {
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string OldPassword { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// ConfirmPassword
        /// </summary>
        [Required]
        public string ConfirmPassword { get; set; }
    }
}