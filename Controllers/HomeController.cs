using ProyectoAbstractFactory.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PABSFAC.Models;

namespace PABSFAC.Controllers
{
    public class HomeController : Controller
    {

        //Se muestra en la página principal los registros de la red social X
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel();

            ClienteDAOX clienteDAOX = new ClienteDAOX();
            viewModel.RegistrosX = clienteDAOX.VerRegistrosX();            

            return View(viewModel);
        }

        //Método para mostrar los registros de la red social Tik Tok
        public ActionResult RegistrosT()
        {            
            var viewModel = new IndexViewModel();
            ClienteDAOTikTok clienteDAOTikTok = new ClienteDAOTikTok();
            viewModel.RegistrosT = clienteDAOTikTok.VerRegistrosT();
            return View(viewModel);
        }

        //Gráfico circular de las redes sociales de X y Tik Tok
        public ActionResult GcircularTX()
        {
            ////Se imprimen los hashtags de ambas redes sociales pero por separado en un mismo gráfico            
            var viewModel = new IndexViewModel();
            DAOReporter dAOReporter = new DAOReporter();            
            var cantHashtgas = dAOReporter.CantHashtagsTX();
            return View(cantHashtgas);
            
        }

        //Gráfico de barras de las redes sociales de X y Tik Tok
        public ActionResult GbarrasTX()
        {
            ViewBag.Message = "Diagrama de barras";
            var viewModel = new IndexViewModel();
            DAOReporter dAOReporter = new DAOReporter();
            viewModel.ResgistrosTX = dAOReporter.VerHashtagsTX();
            return View(viewModel);
        }
    }
}