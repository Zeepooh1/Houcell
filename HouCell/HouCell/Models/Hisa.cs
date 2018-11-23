using System;
using System.Collections.Generic;

namespace HouCell.Models
{
    public partial class Hisa
    {
        public Hisa()
        {
            Soba = new HashSet<Soba>();
        }

        public int HisaId { get; set; }
        public int UserId { get; set; }
        public string Naslov { get; set; }

        public Uporabnik User { get; set; }
        public ICollection<Soba> Soba { get; set; }
    }
}
