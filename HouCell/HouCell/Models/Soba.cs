using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouCell.Models
{
    [Table("soba")]
    public partial class Soba
    {
        public Soba()
        {
            Senzorji = new HashSet<Senzorji>();
        }

        [Key]
        public int SobaId { get; set; }

        public int HisaId { get; set; }
        public string ImeSobe { get; set; }

        public Hisa Hisa { get; set; }
        public ICollection<Senzorji> Senzorji { get; set; }
    }
}
