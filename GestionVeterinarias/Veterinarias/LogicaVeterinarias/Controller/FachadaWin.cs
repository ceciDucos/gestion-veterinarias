
using System;
using ModelosVeterinarias.ValueObject;
using ModelosVeterinarias.Classes;
using ModelosVeterinarias.ExceptionClasses;
using PersistenciaVeterinarias.DAOS;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Web.Services;

namespace LogicaVeterinarias.Controller
{
    //class FachadaWin : System.Web.Services.WebService
    public class FachadaWin
    {
        private DAOClientes daoClientes;
        private DAOVeterinarios daoVeterinarios;
        private DAOSistema daoSistema;
        private ManejadorConexion manejadorConexion;

        public FachadaWin() 
        {
            daoClientes = new DAOClientes();
            daoVeterinarios = new DAOVeterinarios();
            daoSistema = new DAOSistema();
            manejadorConexion = ManejadorConexion.GetInstance();
        }

        public void CrearDB()
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                daoSistema.CrearDB(connection);

            }
            catch (SqlException ex)
            {
                string error = String.Format("Ocurrió un error al crear las tablas. El error recibido fue {0}", ex.Message);
                throw new PersistenciaException(error);
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al ....");
            }
            finally
            {
                if (connection.State.Equals("Open"))
                {
                    connection.Close();
                }
            }
        }

        public void CrearTablas()
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                daoSistema.CrearTablas(connection);

            }
            catch (SqlException ex)
            {
                string error = String.Format("Ocurrió un error al crear las tablas. El error recibido fue {0}", ex.Message);
                throw new PersistenciaException(error);
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al ....");
            }
            finally
            {
                if (connection.State.Equals("Open"))
                {
                    connection.Close();
                }
            }
        }

        public void CargarDatos()
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                daoSistema.CargarDatos(connection);

            }
            catch (SqlException ex)
            {
                string error = String.Format("Ocurrió un error al crear las tablas. El error recibido fue {0}", ex.Message);
                throw new PersistenciaException(error);
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al ....");
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


        public List<VOVeterinario> ObtenerVeterinarios() {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                List<VOVeterinario> listVeterinarios = daoVeterinarios.List(connection);
                return listVeterinarios;


            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw new PersistenciaException("Ocurrió un error al obtener los datos");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al ....");
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
        public void CrearVeterinario(VOVeterinario voveterinario)
        {
            long cedula = voveterinario.Cedula;
            string nombre = voveterinario.Nombre;
            string telefono = voveterinario.Telefono;
            string horario = voveterinario.Horario;
            
            SqlConnection connection = null;
            try 
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (!daoVeterinarios.Member(connection, cedula))
                {
                    Veterinario veterinario = new Veterinario(cedula, nombre, telefono, horario);
                    daoVeterinarios.Add(connection, veterinario);
                }
                else {
                    throw new PersistenciaException("La cedula que intenta dar de alta ya está registrada");
                }
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error agregando un nuevo veterinario");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al crear el veterinario");
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
        public void  EditarVeterinario(VOVeterinario voveterinario)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoVeterinarios.Member(connection, voveterinario.Cedula))
                {
                    Veterinario veterinario = new Veterinario(voveterinario.Cedula, voveterinario.Nombre,
                        voveterinario.Telefono, voveterinario.Horario);

                    daoVeterinarios.Edit(connection, veterinario);
                    
                }
                else { 
                    string error = String.Format("La persona con cedula {0} no existe en el sistema", voveterinario.Cedula);
                    throw new PersistenciaException(error);
                    // Aca iria esta ex, no se porque no me la reconoce. capaz me falta importarla o algo?
                    //throw new PersonaNoExisteException(error);
                }
            }
            catch (SqlException ex)
            {
                string error_tecnico = ex.Message; 
                string error = String.Format("Error al intentar modificar el veterinario con cedula {0} ", voveterinario.Cedula);
                throw new PersistenciaException(error);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw new GeneralException("Ocurrió un error al modificar el cliente");
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
        public void  EliminarVeterinario(long cedula)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoVeterinarios.Member(connection, cedula))
                {
                    daoVeterinarios.Remove(connection, cedula);
                    
                }
                else { 
                    string error = String.Format("La persona con cedula {0} no existe en el sistema", cedula);
                    throw new PersistenciaException(error);
                    //throw new PersonaNoExisteException(error);
                }
            }
            catch (SqlException)
            {
                string error = String.Format("Error al intentar eliminar el veterinario con cedula {0} ", cedula);
                throw new PersistenciaException(error);
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

        public VOVeterinario ObtenerVeterinario(long cedula)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                VOVeterinario voveterinario = daoVeterinarios.Get(connection, cedula);
                return voveterinario;


            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw new PersistenciaException("Ocurrió un error al obtener los datos");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al ....");
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
                    Cliente cliente = new Cliente(cedula, nombre, telefono, direccion, correo, clave, activo);
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
