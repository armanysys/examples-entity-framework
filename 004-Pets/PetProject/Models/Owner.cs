using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Pet> Pets { get; set; } = [];
    }
}
