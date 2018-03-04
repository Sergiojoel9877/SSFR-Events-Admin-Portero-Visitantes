using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSFR_Events.Models
{
    public class Doorman
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string ProfUser { get; set; }

        [Required]
        [StringLength(16)]
        public string Pass { get; set; }
       
    }
}
