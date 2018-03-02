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
        private int Id { get; set; }
        [Required]
        [StringLength(30)]
        private string Name { get; set; }
        [Required]
        [StringLength(25)]
        private string Date { get; set; }
        [Required]
        [StringLength(25)]
        private string Location { get; set; }
        [Required]
        [StringLength(20)]
        private string EventType { get; set; }

        public Events()
        {

        }

    }
}
