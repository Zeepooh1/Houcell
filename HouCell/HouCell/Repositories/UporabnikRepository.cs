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
        int lastId;
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

        public int UporabnikExists(string user, string pass)
        {
            foreach(var u in RepositoryContext.Uporabnik)
            {
                if(u.UserName == user && u.Pass == pass)
                {
                    return u.UserId;
                }
            }

            return -1;
        }

        public void CreateUporabnik(Uporabnik uporabnik)
        {
            Create(uporabnik);
            Save();
        }
    }
}
