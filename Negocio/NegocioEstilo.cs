using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioEstilo
    {

        public List<Estilo> listar()
        {
                List<Estilo> listaEstilosMusicales = new List<Estilo>();
                AccesoDatos nuevoAcceso = new AccesoDatos();
            try
            {
                nuevoAcceso.setearConsulta("SELECT Id, Descripcion FROM ESTILOS");
                nuevoAcceso.leerTabla();

                while (nuevoAcceso.Lector.Read())
                {
                    Estilo estilo = new Estilo();
                    estilo.Id = (int)nuevoAcceso.Lector["Id"];
                    estilo.Descripcion = (string)nuevoAcceso.Lector["Descripcion"];

                    listaEstilosMusicales.Add(estilo);
                }
                return listaEstilosMusicales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nuevoAcceso.cerrar();
            }            

        }
    }
}
