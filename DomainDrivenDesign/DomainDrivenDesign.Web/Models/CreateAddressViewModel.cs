using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DomainDrivenDesign.Web.Models
{
    public class CreateAddressViewModel
    {
        [Display(Name = "Customer ID")]
        public int ID { get; set; }

        [Display(ResourceType = typeof(DomainDrivenDesign.Core.Resources.NameResources), Name = "FirstName")]
        public string FirstName { get; set; }

      
        public string Address1 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int PIN { get; set; }

        public IEnumerable<SelectListItem> Countrys { get; set; }
    }
}