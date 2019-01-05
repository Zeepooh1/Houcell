using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.RepositoryInterfaces
{
    public interface IRepositoryWrapper
    {
        IHisaRepository Hisa { get; }
        IUporabnikRepository Uporabnik { get; }
        ISenzorjiRepository Senzorji { get; }
        ITipSenzorjaRepository Tipsenzorja { get; }
        ISobaRepository Soba { get; }
    }
}
