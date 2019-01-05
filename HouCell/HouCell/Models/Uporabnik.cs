using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouCell.Models
{
    [Table("uporabnik")]
    public partial class Uporabnik
    {
        public Uporabnik()
        {
            Hisa = new HashSet<Hisa>();
        }

        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string Pass { get; set; }

        public ICollection<Hisa> Hisa { get; set; }
    }
}
