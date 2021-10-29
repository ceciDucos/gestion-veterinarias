using LogicaVeterinarias.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Services;

namespace LogicaVeterinarias.Controller
{
    //class FachadaWin : System.Web.Services.WebService
    class FachadaWin
    {
        private DAOClientes daoClientes;
        private ManejadorConexion manejadorConexion;

        public FachadaWin() 
        {
            this.daoClientes = new DAOClientes();
            this.manejadorConexion = ManejadorConexion.Instance;
        }

        //[WebMethod]
        public void CrearVeterianaria(VOVeterinaria voveterinaria)
        {
        }

        //[WebMethod]
        public void EditarVeterianaria(VOVeterinaria voveterinaria)
        {
        }

        //[WebMethod]
        public void EliminarVeterianaria(int num)
        {
        }

        //[WebMethod]
        public void CrearVeterianario(VOVeterinario voveterinario)
        {
        }

        //[WebMethod]
        public void  EditarVeterianario(VOVeterinario voveterinario)
        {
        }

        //[WebMethod]
        public void  EliminarVeterianario(long cedula)
        {
        }

        //[WebMethod]
        public void  CrearCliente(VOCliente vocliente)
        {
            string nombre = vocliente.Nombre;
            long cedula = vocliente.Cedula;
            string telefono = vocliente.Telefono;
            string direccion = vocliente.Direccion;
            string correo = vocliente.Correo;
            string clave = vocliente.Clave;
            bool activo = vocliente.Activo;

            SqlConnection connection = null;

            try 
            {
                connection = this.manejadorConexion.GetConection();
                connection.Open();

                if (!this.daoClientes.member(connection, cedula)) 
                {
                    Cliente cliente = new Cliente(nombre, cedula, telefono, direccion, correo, clave, activo);
                    this.daoClientes.addCliente(cliente);
                }
            }
            catch (SqlException error)
            { 
                throw new PersistenciaException("Ocurrió un error agregando un nuevo cliente");
            }
            catch (Exception error)
            { 
                throw new GeneralException("Ocurrió un error al crear el cliente");
            }
            finally
            {
                if(connection.ConnectionState == State.Open)
                {
                    connection.Close();
                }
            }
        }

        //[WebMethod]
        public void  EditarCliente(VOCliente vocliente)
        {
            //hacer
        }

        //[WebMethod]
        public void  EliminarCliente(long cedula)
        {
            //hacer
        }

        //[WebMethod]
        public void  CrearMascota(VOMascota vomascota)
        {
        }

        //[WebMethod]
        public void  EditarMascota(VOMascota vomascota)
        {
        }

        //[WebMethod]
        public void   EliminarMascota(int num)
        {
        }

        //[WebMethod]
        public void  CrearCarne(VOCarnetInscripcion vocarnet)
        {
        }

        //[WebMethod]
        public void  EditarCarne(VOCarnetInscripcion vocarnet)
        {
        }

        //[WebMethod]
        public void  CrearConsulta(VOConsulta voconsulta)
        {
            //hacer
        }

        //[WebMethod]
        public void  EditarConsulta(VOConsulta voconsulta)
        {
            //hacer
        }

        //[WebMethod]
        public void  EliminarConsulta(int num)
        {
            //hacer
        }
    }
}
