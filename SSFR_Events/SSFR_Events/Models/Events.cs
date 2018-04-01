using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSFR_Events.Models
{
    public class Events
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        [StringLength(250)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string EventType { get; set; }

    }
}
