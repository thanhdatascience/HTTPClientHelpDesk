using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HTTPClientDemo.Models
{
    public class Ticket
    {
        //[Key]
        //public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactAddress { get; set; }
        public string ContactCompanyName { get; set; }
        public Tag Tags { get; set; }
        public Attribute Attributes { get; set; }



    }
}
