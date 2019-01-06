using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouCell.Models
{
    [Table("tipSenzorja")]
    public partial class Tipsenzorja
    {
        //public Tipsenzorja()
        //{
        //    Senzorji = new HashSet<Senzorji>();
        //}

        [Key]
        public int SenzorId { get; set; }
        public string ImeSenzorja { get; set; }

        //public ICollection<Senzorji> Senzorji { get; set; }
    }
}
