using HouCell.RepositoryInterfaces;
using HouCell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.Repositories
{
    public class SenzorjiRepository : RepositoryBase<Senzorji>, ISenzorjiRepository
    {
        public SenzorjiRepository(HoucellContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
