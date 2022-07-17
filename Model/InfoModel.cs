﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BlazorBaseApp.Model
{
    public class InfoModel
    {
        [Required]
        public int PersonId { get; set; }
        public string TelNo { get; set; }
        public string CellNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressCode { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalCode { get; set; }              
        public virtual PersonModel Person { get; set; }
    }
}
