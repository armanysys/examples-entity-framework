using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Species Species { get; set; }
        public int SpeciesId { get; set; }
    }
}
