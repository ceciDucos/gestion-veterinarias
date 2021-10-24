using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOVeterinario
    {
        /*
         rp: me queda la duda con el tema de la herencia, si aca tenemos que poner tambien los atr del padre. 
         me suena que si.
         */
        public String Horario { get;}
        
        public VOVeterinario(String Horario)
        {
            this.Horario = Horario;

        }

    }
}
