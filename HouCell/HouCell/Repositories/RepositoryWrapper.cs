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
            SetSoba();
            SetSenzor();
            SetTipSenzorja();
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
            set { }
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

        private void SetSoba()
        {
            foreach (var i in _repoContext.Soba)
            {
                i.Hisa = _repoContext.Hisa.Find(i.HisaId);
            }
        }

        private void SetSenzor()
        {
            foreach (var i in _repoContext.Senzorji)
            {
                i.Soba = _repoContext.Soba.Find(i.SobaId);
            }
        }

        private void SetTipSenzorja()
        {
            foreach (var i in _repoContext.Senzorji)
            {
                i.Senzor = _repoContext.Tipsenzorja.Find(i.SenzorId);
            }
        }

        //private void SetTipSenzorja()
        //{
        //    foreach (var i in _repoContext.Tipsenzorja)
        //    {
        //        //foreach (var j in i.Senzorji)
        //        //{

        //        //i.Senzorji = _repoContext.Senzorji.Where(a => i.SenzorId == a.SenzorId).ToList();
        //        i.Senzorji = _repoContext.Senzorji.Where(a => i == a.Senzor).ToList();

        //        //}

        //    }
        //}

    }
}
