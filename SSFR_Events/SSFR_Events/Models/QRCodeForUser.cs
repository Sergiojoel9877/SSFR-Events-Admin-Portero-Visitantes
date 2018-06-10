using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSFR_Events.Models
{
    public class QRCodeForUser
    {

        [Key]
        public int Id { get; set; }

        public string EventSubscribed { get; set; }

        public byte[] ImageStream { get; set; }
        
    }
}
