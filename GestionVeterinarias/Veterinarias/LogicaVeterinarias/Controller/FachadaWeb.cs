using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelosVeterinarias.ExceptionClasses;
using ModelosVeterinarias.ValueObject;
using PersistenciaVeterinarias.DAOS;

namespace LogicaVeterinarias.Controller
{
    public class FachadaWeb
    {
        private DAOCarnetInscripcion daoCarnetInscripcion;
        private DAOVeterinarias daoVeterinarias;
        private DAOClientes daoClientes;
        private DAOMascotas daoMascotas;
        private DAOVeterinarios daoVeterinarios;
        private DAOSistema daoSistema;
        private ManejadorConexion manejadorConexion;
        private DAOConsultas daoConsultas;
        private static FachadaWeb instance;

        private FachadaWeb() {
            daoCarnetInscripcion = new DAOCarnetInscripcion();
            daoVeterinarias = new DAOVeterinarias();
            daoClientes = new DAOClientes();
            daoMascotas = new DAOMascotas();
            daoVeterinarios = new DAOVeterinarios();
            daoSistema = new DAOSistema();
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
                List<VOConsulta> listConsultas = daoConsultas.ListByVeterinaria(connection, idVeterinaria);
                return listConsultas;
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

        public void SetCalificacion(int numero, int calificacion)
        {
            SqlConnection connection = null;
            try
            {
                connection = manejadorConexion.GetConnection();
                connection.Open();
                daoConsultas.SetCalification(connection, numero, calificacion);
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
    }
}
