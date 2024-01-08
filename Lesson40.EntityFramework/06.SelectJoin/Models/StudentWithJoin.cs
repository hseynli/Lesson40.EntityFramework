using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.StoredProcedureNet8.Models
{
    [Keyless]
    internal class StudentWithJoin
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public int CourseId { get; set; }
    }
}