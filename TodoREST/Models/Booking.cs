using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TodoREST.Models
{
    public class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int BookingNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name should not be empty")]
        public string CustomerName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail id.")]
        public string CustomerMail { get; set; }
        public Show BookedShow { get; set; }
    }
}
