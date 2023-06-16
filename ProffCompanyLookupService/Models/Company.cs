﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProffCompanyLookupService.Models
{
    public class CompanyData
    {
        public string Name { get; set; }
        public string CompanyTypeName { get; set; }
        public string OrganisationNumber { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public string MobilePhone { get; set; }
        public string TelephoneNumber { get; set; }
        public string AddressLine { get; set; }
        public string BoxAddressLine { get; set; }
        public string PostPlace { get; set; }
        public string ZipCode { get; set; }
        public string NumberOfEmployees { get; set; }
        public string[] NaceCategories { get; set; }
  }
}
