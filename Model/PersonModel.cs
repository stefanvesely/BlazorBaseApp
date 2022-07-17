using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorBaseApp.Model
{
    public class PersonModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Surname { get; set; }
        
        [Required]
        public string Password { get; set; }

        public DateTime LastLogin { get; set; }

        public virtual InfoModel Info { get; set; }
    }
}
