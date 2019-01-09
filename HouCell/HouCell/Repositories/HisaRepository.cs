using HouCell.RepositoryInterfaces;
using HouCell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.Repositories
{
    public class HisaRepository : RepositoryBase<Hisa>, IHisaRepository
    {
        public HisaRepository(HoucellContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateHisa(Hisa hisa)
        {
            Create(hisa);
            Save();
        }
    }
}
