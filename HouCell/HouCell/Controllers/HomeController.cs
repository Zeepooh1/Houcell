using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HouCell.Models;

namespace HouCell.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            //če je TempData["logID"] prazen pomeni da ni bil uspešen login - client nima svojega id-ja
            if (HttpContext.Session.GetInt32("logID") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            // uID je  userID od prijavljenga uporabnika. Ga shranim za lažjo uporabo kasneje
            int uID = (int)HttpContext.Session.GetInt32("logID");

            //nov HoucellContext (pravino bi blo z dependency injectionom ampak mi ni jasno kako haha)
            var context = new HoucellContext();

            //inicializacija novega HiseModel modela
            HiseModel hiseModel = new HiseModel();

            /*
             * HiseSeznam je atribut od modela (IList) in vanj shranimo vse hiše
             * ki jih prijavljeni uporabnik ima v lasti.
             * 
             * identični SQL querry bi bil:
             * SELECT * FROM hisa h, uporabnik u 
             * 
             * INNER JOIN soba s ON s.hisaID = h.hisaID
             * INNER JOIN senzorji sens ON sens.sobaID = s.sobaID
             * WHERE u.userID =  h.userID;
             */ 
             hiseModel.HiseSeznam = (from hisa in context.Hisa
                         join sobe in context.Soba
                         on hisa.HisaId equals sobe.HisaId
                         join senzorji in context.Senzorji
                         on sobe.SobaId equals senzorji.SobaId
                         where hisa.UserId == uID
                         select new Hisa()
                         {
                             HisaId = hisa.HisaId,
                             UserId = hisa.UserId,
                             Naslov = hisa.Naslov,
                             Soba = hisa.Soba,
                             User = hisa.User
                             
                         }).ToList();

            /*
             * hiseModel.Senzorji je IList iz modela hiseModel v katerega
             * shranim vse senzorje v bazi (lahko bi bolje naredil, sam se mi neda haha)
             */ 
            hiseModel.Senzorji = (from senzor in context.Senzorji
                                  select new Senzorji()
                                  {
                                      SenzorId = senzor.SenzorId,
                                      SobaId = senzor.SobaId,
                                      VrednostSenzorja = senzor.VrednostSenzorja,
                                      Senzor = senzor.Senzor,
                                      Soba = senzor.Soba
                                  }).ToList();

            //v View(Index.cshtml) pošljem hiseModel
            return View(hiseModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
    
}
