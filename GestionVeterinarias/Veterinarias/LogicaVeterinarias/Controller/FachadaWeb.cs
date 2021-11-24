using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelosVeterinarias.Classes;
using ModelosVeterinarias.ExceptionClasses;
using ModelosVeterinarias.ValueObject;
using PersistenciaVeterinarias.DAOS;
using System.Security.Cryptography;

namespace LogicaVeterinarias.Controller
{
    public class FachadaWeb
    {
        private DAOCarnetInscripcion daoCarnetInscripcion;
        private DAOVeterinarias daoVeterinarias;
        private DAOClientes daoClientes;
        private DAOMascotas daoMascotas;
        private DAOVeterinarios daoVeterinarios;
        private ManejadorConexion manejadorConexion;
        private DAOConsultas daoConsultas;
        private static FachadaWeb instance;

        private FachadaWeb() {
            daoCarnetInscripcion = new DAOCarnetInscripcion();
            daoVeterinarias = new DAOVeterinarias();
            daoClientes = new DAOClientes();
            daoMascotas = new DAOMascotas();
            daoVeterinarios = new DAOVeterinarios();
            manejadorConexion = ManejadorConexion.GetInstance();
            daoConsultas = new DAOConsultas();
        }

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
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                List<VOVeterinaria> listVeterinarias = daoVeterinarias.List(connection);
                return listVeterinarias;
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

        public List<VOConsulta> GetConsultas(int idVeterinaria)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                List<VOConsulta> listConsultas = daoConsultas.ListByCliente(connection, idVeterinaria);
                return listConsultas;
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw new PersistenciaException("Ocurrió un error al obtener los datos");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al obtener las consultas");
            }
            finally
            {
                if (connection.State.Equals("Open"))
                {
                    connection.Close();
                }
            }
        }

        public void SetCalificacion(long cedula, int numero, int calificacion)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                daoConsultas.SetCalification(connection, cedula, numero, calificacion);
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

        public List<VOCliente> ListClientes(int idVeterinaria)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                List<VOCliente> listClientes = daoClientes.List(connection, idVeterinaria);
                return listClientes;


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

        public VOCliente GetCliente(long cedula)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                VOCliente vocliente = daoClientes.Get(connection, cedula);
                return vocliente;
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw new PersistenciaException("Ocurrió un error al obtener los datos");
            }
            catch (Exception e)
            {
                throw e;
                //throw new GeneralException("Ocurrió un error al ....");
            }
            finally
            {
                if (connection.State.Equals("Open"))
                {
                    connection.Close();
                }
            }
        }

        public void CrearCliente(VOCliente vocliente)
        {
            string nombre = vocliente.Nombre;
            long cedula = vocliente.Cedula;
            string telefono = vocliente.Telefono;
            int idVeterinaria = vocliente.IdVeterinaria;
            string direccion = vocliente.Direccion;
            string correo = vocliente.Correo;
            bool activo = true;

            SqlConnection connection = null;
            try
            {
                RNGCryptoServiceProvider saltCellar = new RNGCryptoServiceProvider();
                byte[] salt = new byte[24];
                saltCellar.GetBytes(salt);

                Rfc2898DeriveBytes hashTool = new Rfc2898DeriveBytes(vocliente.Pass, salt);
                hashTool.IterationCount = 1000;
                byte[] hash = hashTool.GetBytes(24);
                string pass = "1000:" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);

                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (!daoClientes.Member(connection, cedula))
                {
                    Cliente cliente = new Cliente(cedula, nombre, telefono, idVeterinaria, direccion, correo, pass, activo);
                    daoClientes.Add(connection, cliente);
                }
                else
                {
                    string error = string.Format("Ya existe una persona con cedula {0} en el sistema", vocliente.Cedula);
                    throw new PersonaException(error);
                }
            }
            catch (SqlException e)
            {
                throw e;
                //throw new PersistenciaException("Ocurrió un error agregando un nuevo cliente");
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
                if (connection.State.Equals("Open"))
                {
                    connection.Close();
                }
            }
        }

        public void EditarCliente(VOCliente vocliente)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoClientes.Member(connection, vocliente.Cedula))
                {
                    Cliente cliente = new Cliente(vocliente.Cedula, vocliente.Nombre, vocliente.Telefono, vocliente.IdVeterinaria,
                        vocliente.Direccion, vocliente.Correo, vocliente.Pass, vocliente.Activo);

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

        public bool Login(VOLogin login)
        {
            SqlConnection connection = null;
            try
            {
                bool passwordMatches = false;
                connection = manejadorConexion.GetConnection();
                connection.Open();
                string pass = daoClientes.GetHash(connection, Convert.ToInt32(login.Username));

                if (pass != "")
                {
                    string[] hashParts = pass.Split(':');
                    int iterations = Int32.Parse(hashParts[0]);
                    byte[] originalSalt = Convert.FromBase64String(hashParts[1]);
                    byte[] originalHash = Convert.FromBase64String(hashParts[2]);

                    Rfc2898DeriveBytes hashTool = new Rfc2898DeriveBytes(login.Password, originalSalt);
                    hashTool.IterationCount = iterations;
                    byte[] testHash = hashTool.GetBytes(originalHash.Length);

                    uint differences = (uint)originalHash.Length ^ (uint)testHash.Length;
                    for (int position = 0; position < Math.Min(originalHash.Length,
                      testHash.Length); position++)
                        differences |= (uint)(originalHash[position] ^ testHash[position]);
                    passwordMatches = (differences == 0);
                }

                return passwordMatches;
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw new PersistenciaException("Ocurrió un error al obtener los datos");
            }
            catch (Exception)
            {
                throw new GeneralException("Ocurrió un error al loguearse");
            }
            finally
            {
                if (connection.State.Equals("Open"))
                {
                    connection.Close();
                }
            }
        }

        public void EditarPassword(string cedula, VOPassword voPassword)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                if (daoClientes.Member(connection, Convert.ToInt32(cedula)))
                {
                    if (Login(new VOLogin(cedula, voPassword.CurrentPassword))) {
                        RNGCryptoServiceProvider saltCellar = new RNGCryptoServiceProvider();
                        byte[] salt = new byte[24];
                        saltCellar.GetBytes(salt);

                        Rfc2898DeriveBytes hashTool = new Rfc2898DeriveBytes(voPassword.NewPassword, salt);
                        hashTool.IterationCount = 1000;
                        byte[] hash = hashTool.GetBytes(24);
                        string pass = "1000:" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);

                        daoClientes.EditPassword(connection, Convert.ToInt32(cedula), pass);
                    } else throw new PasswordException("Contraseña actual no coincide");
                }
                else
                {
                    string error = string.Format("La persona con cedula {0} no existe en el sistema", cedula);
                    throw new PersonaException(error);
                }
            }
            catch (SqlException)
            {
                string error = string.Format("Error al intentar modificar el cliente con cedula {0} ", cedula);
                throw new PersistenciaException(error);
            }
            catch (Exception ex)
            {
                if (ex is PersistenciaException || ex is PersonaException || ex is PasswordException)
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
    }
}
