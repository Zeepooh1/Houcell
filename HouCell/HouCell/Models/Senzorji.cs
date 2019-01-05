using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouCell.Models
{
    [Table("senzorji")]
    public partial class Senzorji
    {
        [Key]
        public int SenzorId { get; set; }
        public int SobaId { get; set; }
        public int VrednostSenzorja { get; set; }

        public Tipsenzorja Senzor { get; set; }
        public Soba Soba { get; set; }
    }
}
