
using System;
using ModelosVeterinarias.ValueObject;
using ModelosVeterinarias.Classes;
using ModelosVeterinarias.ExceptionClasses;
using PersistenciaVeterinarias.DAOS;

using System.Data.SqlClient;
//using System.Web.Services;

namespace LogicaVeterinarias.Controller
{
    //class FachadaWin : System.Web.Services.WebService
    public class FachadaWin
    {
        private DAOCarnetInscripcion daoCarnetInscripcion;
        private DAOVeterinarias daoVeterinarias;
        private DAOClientes daoClientes;
        private ManejadorConexion manejadorConexion;

        public FachadaWin()
        {
            daoCarnetInscripcion = new DAOCarnetInscripcion();
            daoVeterinarias = new DAOVeterinarias();
            daoClientes = new DAOClientes();
            manejadorConexion = ManejadorConexion.GetInstance();
        }

        //[WebMethod]
        public void CrearVeterianaria(VOVeterinaria voveterinaria)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoVeterinarias.Add(connection, new Veterinaria (voveterinaria.Nombre,voveterinaria.Direccion,voveterinaria.Telefono));
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error agregando una nueva veterinaria");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al crear la veterinaria");
            }
        }

        //[WebMethod]
        public void EditarVeterianaria(VOVeterinaria voveterinaria)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoVeterinarias.Edit(connection, new Veterinaria(voveterinaria.Id, voveterinaria.Nombre, voveterinaria.Direccion, voveterinaria.Telefono));
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error editando la veterinaria");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al editar la veterinaria");
            }
        }

        //[WebMethod]
        public void EliminarVeterianaria(int num)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoVeterinarias.Delete(connection, num);
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error eliminando la veterinaria");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al eliminar la veterinaria");
            }
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
        public void CrearCliente(VOCliente vocliente)
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
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (!daoClientes.Member(connection, cedula))
                {
                    Cliente cliente = new Cliente(nombre, cedula, telefono, direccion, correo, clave, activo);
                    daoClientes.Add(connection, cliente);
                }
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error agregando un nuevo cliente");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al crear el cliente");
            }
            finally
            {
                if(connection.State.Equals("Open"))
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
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoClientes.Member(connection, cedula))
                {
                    daoClientes.Remove(connection, cedula);
                }
            }
            catch (SqlException e)
            {
                throw e;
                throw new PersistenciaException("Ocurrió un error agregando un nuevo cliente");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al crear el cliente");
            }
            finally
            {
                if (connection.State.Equals("Open"))
                {
                    connection.Close();
                }
            }
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
        public void CrearCarnet(byte[] foto)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoCarnetInscripcion.Add(connection, foto);
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error al crear el carnet");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al crear el carnet");
            }
        }

        //[WebMethod]
        public void EditarCarnet(VOCarnetInscripcion vocarnet)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoCarnetInscripcion.Edit(connection, new CarnetInscripcion(vocarnet.Numero, vocarnet.Expedido, vocarnet.Foto));
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error al crear el carnet");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al crear el carnet");
            }
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
