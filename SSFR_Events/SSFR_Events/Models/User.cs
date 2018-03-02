using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSFR_Events.Models
{
    public class User
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
        [StringLength(20)]
        private string ProfUser { get; set; }
        [Required]
        [StringLength(16)]
        private string Pass { get; set; }

        public User()
        {

        }
    }
}
