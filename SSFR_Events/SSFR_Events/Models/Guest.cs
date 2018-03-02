using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSFR_Events.Models
{
    public class Guest
    {
        [Key]
        private int Id { get; set; }
        [Required]
        [StringLength(30)]
        private string Name { get; set; }
        [Required]
        [StringLength(30)]
        private string LastName { get; set; }
        [Required]
        [StringLength(30)]
        private string Telephone { get; set; }
        [Required]
        [StringLength(100)]
        private string Address { get; set; }
        [Required]
        [StringLength(100)]
        private string Email{ get; set; }
        [Required]
        [StringLength(1)]
        private string Gender { get; set; }

        public Guest()
        {

        }
    }
}
