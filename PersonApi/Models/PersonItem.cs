using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonApi.Models
{
    public class PersonItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }
    }
}
