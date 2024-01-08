using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.StoredProcedures.Models
{
    [Keyless]
    internal class StudentWithOnlyName
    {
        public string Name { get; set; }
        public int Mark { get; set; }
    }
}