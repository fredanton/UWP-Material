using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UWP_Material.Models
{
    class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role(int id = -1, string name = null)
        {
            Id = id;
            Name = name;
        }
    }
}
