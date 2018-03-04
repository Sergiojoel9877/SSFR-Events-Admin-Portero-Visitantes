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
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Date { get; set; }

        [Required]
        [StringLength(25)]
        public string Location { get; set; }

        [Required]
        [StringLength(20)]
        public string EventType { get; set; }

    }
}
