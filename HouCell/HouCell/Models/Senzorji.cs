using System;
using System.Collections.Generic;

namespace HouCell.Models
{
    public partial class Senzorji
    {
        public int SenzorId { get; set; }
        public int SobaId { get; set; }
        public int VrednostSenzorja { get; set; }

        public Tipsenzorja Senzor { get; set; }
        public Soba Soba { get; set; }
    }
}
