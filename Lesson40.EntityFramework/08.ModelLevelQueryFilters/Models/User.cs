using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ModelLevelQueryFilters.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
