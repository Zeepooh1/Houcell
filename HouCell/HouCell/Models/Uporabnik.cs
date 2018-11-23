using System;
using System.Collections.Generic;

namespace HouCell.Models
{
    public partial class Uporabnik
    {
        public Uporabnik()
        {
            Hisa = new HashSet<Hisa>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Hisa> Hisa { get; set; }
    }
}
