using System;
using System.Collections.Generic;

namespace HouCell.Models
{
    public partial class Sobe
    {
        public Sobe()
        {
            Senzorji = new HashSet<Senzorji>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }

        public ICollection<Senzorji> Senzorji { get; set; }
    }
}
