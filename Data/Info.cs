using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBaseApp.Data
{
    public class Info
    {
        [Required]
        [Key]
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

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

    }
}
