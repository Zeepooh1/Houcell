using HouCell.Models;
using HouCell.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private HoucellContext _repoContext;
        private IHisaRepository _hisa;
        private ISobaRepository _soba;
        private ISenzorjiRepository _senzorji;
        private ITipSenzorjaRepository _tipSenzorja;
        private IUporabnikRepository _uporabnik;


        public RepositoryWrapper(HoucellContext repositoryContext)
        {
            _repoContext = repositoryContext;
            SetUsers();
        }


        public IHisaRepository Hisa
        {
            get
            {
                if (_hisa == null)
                {
                    _hisa = new HisaRepository(_repoContext);
                }

                return _hisa;
            }
        }

        public IUporabnikRepository Uporabnik
        {
            get
            {
                if (_uporabnik == null)
                {
                    _uporabnik = new UporabnikRepository(_repoContext);
                }

                return _uporabnik;
            }
        }

        public ISenzorjiRepository Senzorji
        {
            get
            {
                if (_senzorji == null)
                {
                    _senzorji = new SenzorjiRepository(_repoContext);
                }

                return _senzorji;
            }
        }

        public ITipSenzorjaRepository Tipsenzorja
        {
            get
            {
                if (_tipSenzorja == null)
                {
                    _tipSenzorja = new TipsenzorjaRepository(_repoContext);
                }

                return _tipSenzorja;
            }
        }

        public ISobaRepository Soba
        {
            get
            {
                if (_soba == null)
                {
                    _soba = new SobaRepository(_repoContext);
                }

                return _soba;
            }
        }

        private void SetUsers()
        {
            foreach (var i in _repoContext.Hisa)
            {
                i.User = _repoContext.Uporabnik.Find(i.UserId);
            }
        }

    }
}
