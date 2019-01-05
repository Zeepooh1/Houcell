using HouCell.RepositoryInterfaces;
using HouCell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.Repositories
{
    public class TipsenzorjaRepository : RepositoryBase<Tipsenzorja>, ITipSenzorjaRepository
    {
        public TipsenzorjaRepository(HoucellContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
