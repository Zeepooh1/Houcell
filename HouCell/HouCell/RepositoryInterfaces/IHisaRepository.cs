using HouCell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.RepositoryInterfaces
{
    public interface IHisaRepository : IRepositoryBase<Hisa>
    {
        void CreateHisa(Hisa hisa);
    }
}
