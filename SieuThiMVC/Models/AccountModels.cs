using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace SieuThiMVC.Models
{
    public class FullUserProfile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Birth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }

    public class SecretQuestion
    {
        public string ID{get;set;}
        public string Q{get;set;}
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        //Usernanem
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        //Password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //re-password
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //Email
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //Address
        [Required]
        [Display (Name = "Address")]
        public string Address{get;set;}

        //Phone number
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string Phonenum{get;set;}

        //identity card
        [Required]
        [StringLength(10,MinimumLength = 9)]
        [Display(Name = "Identity number")]
        public string Identitynum{get;set;}

        //birthday
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday{get;set;}

        //sex
        [Required]
        [Display(Name = "Gender")]
        public string Gender{get;set;}

        //Secret Question
        [Required]
        [Display(Name = "Secret Question")]
        public string SQuestion { get; set; }

        //Secret Anwser
        [Required]
        [Display(Name = "Secret Answer")]
        public string SAnswer { get; set; }
    }

    public class UpdateModel
    {
        public int ID;
        //Email
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //Address
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        //Phone number
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string Phonenum { get; set; }

        //identity card
        [Required]
        [StringLength(10, MinimumLength = 9)]
        [Display(Name = "Identity number")]
        public string Identitynum { get; set; }

        //birthday
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        //sex
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
