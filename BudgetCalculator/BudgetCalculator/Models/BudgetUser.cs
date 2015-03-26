﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjectYear4.Models
{
    public class BudgetUser
    {
        public int BudgetUserId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Concatenate last & first name to display users full name
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "D.O.B")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address Line 1 is Mandatory")]
        [StringLength(50, ErrorMessage = "Address Line 1 cannot be more than 50 characters.")]
        [Display(Name = "Address Line 1")]
        public String AddressLine1 { get; set; }

        [StringLength(50, ErrorMessage = "Address Line 2 cannot be more than 50 characters.")]
        [Display(Name = "Address Line 2")]
        public String AddressLine2 { get; set; }

        [StringLength(50, ErrorMessage = "Town cannot be more than 50 characters.")]
        [Display(Name = "Town")]
        public String Town { get; set; }

        [StringLength(50, ErrorMessage = "County cannot be more than 50 characters.")]
        [Display(Name = "County")]
        public String County { get; set; }

        [StringLength(50, ErrorMessage = "Country cannot be more than 50 characters.")]
        [Display(Name = "Country")]
        public String Country { get; set; }

        [Display(Name = "Post Code")]
        public String PostCode { get; set; }

        [Required(ErrorMessage = "Contact Number is Mandatory")]
        [Display(Name = "Contact No.")]
        public String ContactNo { get; set; }

        // check that the e-mail address is of the correct form (not it that actually exists)
        private bool isEmail(string inputEmail)
        {
            Regex re = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$",
                          RegexOptions.IgnoreCase);
            return re.IsMatch(inputEmail);
        }

        public virtual ICollection<Budget> Budgets { get; set; }
    }
}