using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S24Week12CodeFirstApproach
{
    public class Standard
    {
        // scalar properties
        public int StandardId { get; set; }
        public string? Name { get; set; }

        // navigation property
        public ICollection<Student>? Students { get; set; }
    }
}
