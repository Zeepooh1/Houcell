using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.Models.ExtendedModels
{
    public class UporabnikExtended
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string pass { get; set; }

        public IEnumerable<Hisa> Hise { get; set; }

        public UporabnikExtended()
        {
        }

        public UporabnikExtended(Uporabnik uporabnik)
        {
            Id = uporabnik.UserId;
            UserName = uporabnik.UserName;
            pass = uporabnik.Pass;
        }
    }
}
