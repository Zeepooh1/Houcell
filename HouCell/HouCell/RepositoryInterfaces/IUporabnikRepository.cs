﻿using HouCell.Models;
using HouCell.Models.ExtendedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.RepositoryInterfaces
{
    public interface IUporabnikRepository
    {
        IEnumerable<Uporabnik> GetAllUporabnik();
        Uporabnik GetUporabnikById(int uporabnikId);
        int UporabnikExists(string user, string pass);
        void CreateUporabnik(Uporabnik uporabnik);
    }
}
