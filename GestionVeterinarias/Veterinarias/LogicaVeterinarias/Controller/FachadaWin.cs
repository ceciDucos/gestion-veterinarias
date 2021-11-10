
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
        private DAOMascotas daoMascotas;
        private DAOVeterinarios daoVeterinarios;
        private ManejadorConexion manejadorConexion;
        private DAOConsultas daoConsultas;


        public FachadaWin()
        {
            daoCarnetInscripcion = new DAOCarnetInscripcion();
            daoVeterinarias = new DAOVeterinarias();
            daoClientes = new DAOClientes();
            daoMascotas = new DAOMascotas();
            daoVeterinarios = new DAOVeterinarios();
            manejadorConexion = ManejadorConexion.GetInstance();
            daoConsultas = new DAOConsultas();

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
                else
                {
                    string error = string.Format("Ya existe una persona con cedula {0} en el sistema", vocliente.Cedula);
                    throw new PersonaException(error);
                }
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error agregando un nuevo cliente");
            }
            catch (Exception ex)
            {
                if (ex is PersonaException)
                {
                    throw ex;
                }
                else
                {
                    throw new GeneralException("Ocurrió un error al crear el cliente");
                }
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
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoClientes.Member(connection, vocliente.Cedula))
                {
                    Cliente cliente = new Cliente(vocliente.Cedula, vocliente.Nombre, vocliente.Telefono,
                        vocliente.Direccion, vocliente.Correo, vocliente.Clave, vocliente.Activo);

                    daoClientes.Edit(connection, cliente);
                }
                else
                {
                    string error = string.Format("La persona con cedula {0} no existe en el sistema", vocliente.Cedula);
                    throw new PersonaException(error);
                }
            }
            catch (SqlException)
            {
                string error = string.Format("Error al intentar modificar el cliente con cedula {0} ", vocliente.Cedula);
                throw new PersistenciaException(error);
            }
            catch (Exception ex)
            {
                if (ex is PersistenciaException || ex is PersonaException)
                {
                    throw ex;
                }
                else
                {
                    throw new GeneralException("Ocurrió un error al modificar el cliente");
                }
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
        public void  EliminarCliente(long cedula)
        {
            SqlConnection connection = null;
            string error;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoClientes.Member(connection, cedula))
                {
                    daoClientes.Remove(connection, cedula);
                }
                else
                {
                    error = string.Format("No existe un cliente con la cédula {0}.", cedula);
                    throw new PersonaException(error);
                }
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error agregando un nuevo cliente");
            }
            catch (Exception ex)
            {
                if (ex is PersistenciaException || ex is PersonaException)
                {
                    throw ex;
                }
                else
                {
                    throw new GeneralException("Ocurrió un error al eliminar el cliente.");
                }
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
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoMascotas.Add(connection, new Mascota(vomascota.Animal, vomascota.Nombre, vomascota.Raza, vomascota.Edad, vomascota.VacunaAlDia, 
                    new CarnetInscripcion(vomascota.CarnetInscripcion.Foto)));
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error agregando una nueva mascota");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al crear la mascota");
            }
        }

        //[WebMethod]
        public void  EditarMascota(VOMascota vomascota)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoMascotas.Edit(connection, new Mascota(vomascota.Id, vomascota.Animal, vomascota.Nombre, vomascota.Raza, vomascota.Edad, vomascota.VacunaAlDia, new CarnetInscripcion(vomascota.CarnetInscripcion.Numero, vomascota.CarnetInscripcion.Expedido, vomascota.CarnetInscripcion.Foto)));
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error editando la mascota");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al editar la mascota");
            }
        }

        //[WebMethod]
        public void   EliminarMascota(int num)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoMascotas.Delete(connection, num);
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error eliminando la mascota");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al eliminar la mascota");
            }
        }

        //[WebMethod]
        public bool MemberMascota(int num)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                return daoMascotas.Member(connection, num);
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error buscando la mascota");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al buscando la mascota");
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
        public void CrearCarnet(byte[] foto, int idMascota)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                daoCarnetInscripcion.Add(connection, foto, idMascota);
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
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (!daoConsultas.Member(connection, voconsulta.Mascota.Id, voconsulta.Fecha))
                {
                    VOMascota voMascota = voconsulta.Mascota;
                    Mascota mascota = new Mascota(voMascota.Id, voMascota.Animal, voMascota.Nombre, voMascota.Raza, voMascota.Edad,
                        voMascota.VacunaAlDia, new CarnetInscripcion(voMascota.CarnetInscripcion.Numero,
                        voMascota.CarnetInscripcion.Expedido, voMascota.CarnetInscripcion.Foto));
                    Consulta consulta = new Consulta(voconsulta.Numero, voconsulta.Calificacion, voconsulta.Fecha,
                        voconsulta.Descripcion, mascota);
                    daoConsultas.Add(connection, consulta);
                }
                else
                {
                    string error = string.Format("Ya existe una consulta agendada para la fecha {0}", voconsulta.Fecha);
                    throw new ConsultaException(error);
                }
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error agregando una consulta");
            }
            catch (Exception ex)
            {
                if (ex is ConsultaException)
                {
                    throw ex;
                }
                else
                {
                    throw new GeneralException("Ocurrió un error al crear la consulta");
                }
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
        public void  EditarConsulta(VOConsulta voconsulta)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoConsultas.MemberId(connection, voconsulta.Numero))
                {
                    Mascota mascota = new Mascota(voconsulta.Mascota.Id, voconsulta.Mascota.Animal, voconsulta.Mascota.Nombre, 
                        voconsulta.Mascota.Raza, voconsulta.Mascota.Edad, voconsulta.Mascota.VacunaAlDia,
                        new CarnetInscripcion(voconsulta.Mascota.CarnetInscripcion.Numero,
                        voconsulta.Mascota.CarnetInscripcion.Expedido, voconsulta.Mascota.CarnetInscripcion.Foto));

                    Consulta consulta = new Consulta(voconsulta.Numero, voconsulta.Calificacion, voconsulta.Fecha,
                        voconsulta.Descripcion, mascota);

                    daoConsultas.Edit(connection, consulta);
                }
                else
                {
                    string error = string.Format("No se encontron consultas agendadas para la mascota {0} en la fecha {1}",
                        voconsulta.Mascota.Nombre, voconsulta.Fecha);
                    throw new ConsultaException(error);
                }
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Error al intentar modificar la consulta");
            }
            catch (Exception ex)
            {
                if (ex is PersistenciaException || ex is ConsultaException)
                {
                    throw ex;
                }
                else
                {
                    throw new GeneralException("Ocurrió un error al modificarla consulta");
                }
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
        public void  EliminarConsulta(int numero)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoConsultas.MemberId(connection, numero))
                {
                    daoConsultas.Remove(connection, numero);
                }
            }
            catch (SqlException)
            {
                throw new PersistenciaException("Ocurrió un error eliminando la consulta");
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
    }
}
