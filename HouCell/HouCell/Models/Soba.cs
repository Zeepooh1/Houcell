using System;
using System.Collections.Generic;

namespace HouCell.Models
{
    public partial class Soba
    {
        public Soba()
        {
            Senzorji = new HashSet<Senzorji>();
        }

        public int SobaId { get; set; }
        public int HisaId { get; set; }
        public string ImeSobe { get; set; }

        public Hisa Hisa { get; set; }
        public ICollection<Senzorji> Senzorji { get; set; }
    }
}
