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
            List<VOVeterinaria> veterinarias = new List<VOVeterinaria>();
            VOVeterinaria vo = new VOVeterinaria(1, "Veterinaria 1", "ya sabes 1", "098898898");
            vo.Clientes.Add(new VOCliente(1, "pepe", "54345", 1, "yuyu",  "yuyu@gmail", "tretttt", true));
            veterinarias.Add(vo);
            veterinarias.Add(new VOVeterinaria(2, "Veterinaria 2", "ya sabes 2", "098898898"));
            veterinarias.Add(new VOVeterinaria(1, "Veterinaria 3", "ya sabes 3", "098898898"));

            return veterinarias;
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
    }
}
