using ProyectoAbstractFactory.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PABSFAC.Controllers
{

    //Método para poder llamar las listas de los clientes DTO's 
    public class IndexViewModel
    {
        public List<ClienteDTOX> RegistrosX { get; set; }
        public List<ClienteDTOTikTok> RegistrosT { get; set; }
        public List<DTOReporter> ResgistrosTX { get; set; }
        public Dictionary<string, int> CantHashtagsTX { get; set; }

    }
}