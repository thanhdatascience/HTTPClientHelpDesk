using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HTTPClientDemo.Models
{
    public class Attribute
    {
        [Key]
        string name { get; set; }
        string value { get; set; }
    }
}
