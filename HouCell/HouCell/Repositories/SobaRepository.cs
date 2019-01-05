using HouCell.RepositoryInterfaces;
using HouCell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.Repositories
{
    public class SobaRepository : RepositoryBase<Soba>, ISobaRepository
    {
        public SobaRepository(HoucellContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
