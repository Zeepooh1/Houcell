using System;
using System.Collections.Generic;

namespace HouCell.Models
{
    public partial class Tipsenzorja
    {
        public Tipsenzorja()
        {
            Senzorji = new HashSet<Senzorji>();
        }

        public int SenzorId { get; set; }
        public string ImeSenzorja { get; set; }

        public ICollection<Senzorji> Senzorji { get; set; }
    }
}
