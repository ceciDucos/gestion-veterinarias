using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelosVeterinarias.ValueObject;

namespace LogicaVeterinarias.Controller
{
    public class FachadaWeb
    {
        private static FachadaWeb instance;

        private FachadaWeb() {}

        public static FachadaWeb GetInstance()
        {
            if (instance == null)
            {
                instance = new FachadaWeb();
            }
            return instance;
        }

        public List<VOVeterinaria> GetVeterinarias()
        {
            List<VOVeterinaria> veterinarias = new List<VOVeterinaria>();
            VOVeterinaria vo = new VOVeterinaria(1, "Veterinaria 1", "ya sabes 1", "098898898");
            vo.Clientes.Add(new VOCliente(1, "pepe", "54345", "yuyu",  "yuyu@gmail", "tretttt", true));
            veterinarias.Add(vo);
            veterinarias.Add(new VOVeterinaria(2, "Veterinaria 2", "ya sabes 2", "098898898"));
            veterinarias.Add(new VOVeterinaria(1, "Veterinaria 3", "ya sabes 3", "098898898"));

            return veterinarias;
        }
    }
}
