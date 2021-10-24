using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOCliente
    {
        /*
         rp: me queda la duda con el tema de la herencia, si aca tenemos que poner tambien los atr del padre. 
         me suena que si.
         */
        public String Direccion { get;}
        public String Correo { get; }
        public String Clave { get; }
        public bool Activo{ get; }
        public List<VOMascota> Mascotas{ get; }


        public VOCliente(String Direccion, String Correo, String Clave, bool Activo)
        {
            this.Direccion = Direccion;
            this.Correo = Correo;
            this.Clave = Clave;
            this.Activo = activo;
            this.Mascotas = new List<VOMascota>;
        
        }

    }
}
