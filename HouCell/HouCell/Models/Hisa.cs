using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouCell.Models
{
    [Table("hisa")]
    public partial class Hisa
    {
        public Hisa()
        {
            Soba = new HashSet<Soba>();
        }

        [Key]
        public int HisaId { get; set; }

        public int UserId { get; set; }
        public string Naslov { get; set; }
        public float Lng { get; set; }
        public float Lat { get; set; }

        public Uporabnik User { get; set; }
        public ICollection<Soba> Soba { get; set; }
    }
}
