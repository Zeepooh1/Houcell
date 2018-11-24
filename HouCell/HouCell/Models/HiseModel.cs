using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.Models
{
    /************************************************************************************************************************************************************************
     * Model HiseModel                                                                                                                                                      *
     * naredu sm 2 ILista: HiseSeznam v katerga v HomeController dam use hiše od vpisanga uporabnika                                                                        *
     *                     Senzorji v katerga grejo vsi senzorji iz baze. Lahko bi dau samo senzorje od uporabnika sam se mi ni dal in to preverjam kasnej v Index Viewu    *
     ************************************************************************************************************************************************************************/
    public partial class HiseModel
    {
        public IList<Hisa> HiseSeznam { get; set; }
        public IList<Senzorji> Senzorji { get; set; }
    }
}
