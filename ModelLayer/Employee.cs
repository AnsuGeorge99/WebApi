
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
    }
}
