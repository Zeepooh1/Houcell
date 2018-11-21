using System;
using System.Collections.Generic;

namespace HouCell.Models
{
    public partial class Senzorji
    {
        public int IdSenzor { get; set; }
        public int IdSobe { get; set; }
        public int IdTip { get; set; }
        public int Vrednost { get; set; }

        public Sobe IdSobeNavigation { get; set; }
        public TipiSenzorjev IdTipNavigation { get; set; }
    }
}
