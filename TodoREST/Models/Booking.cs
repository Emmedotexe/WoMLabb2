using System;
using System.Collections.Generic;
using System.Text;

namespace TodoREST.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int BookingNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMail { get; set; }
       
    }
}
