using HouCell.RepositoryInterfaces;
using HouCell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouCell.Models.ExtendedModels;

namespace HouCell.Repositories
{
    public class UporabnikRepository : RepositoryBase<Uporabnik>, IUporabnikRepository
    {
        public UporabnikRepository(HoucellContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Uporabnik> GetAllUporabnik()
        {
            return FindAll().OrderBy(ow => ow.UserId);
        }

        public Uporabnik GetUporabnikById(int uporabnikId)
        {
            return FindByCondition(uporabnik => uporabnik.UserId.Equals(uporabnikId)).DefaultIfEmpty(new Uporabnik()).FirstOrDefault();
        }

        public UporabnikExtended GetUporabnikWithDetails(int userId)
        {
            return new UporabnikExtended(GetUporabnikById(userId))
            {
                
         //      Hise = HoucellContext.Hisa.Where(a => a.UserId == userId)

            };
        }
    }
}
