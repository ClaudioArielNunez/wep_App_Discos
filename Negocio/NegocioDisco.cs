using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioDisco
    {
        public List<Disco> Listar()
        {
            List<Disco> ListaDiscos = new List<Disco>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT D.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, Estado, D.IdEstilo ,E.Descripcion AS Estilo, D.IdTipoEdicion,T.Descripcion as TipoEdicion FROM DISCOS D , ESTILOS E, TIPOSEDICION T WHERE D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id and D.Estado = 1");
                datos.leerTabla();

                while (datos.Lector.Read())
                {
                    Disco nuevoDisco = new Disco();
                    nuevoDisco.Id = (int)datos.Lector["id"]; //El nombre entre [] tiene q ser igual a la BD
                    nuevoDisco.Titulo = (string)datos.Lector["titulo"];
                    nuevoDisco.FechaLanzamiento = (DateTime)(datos.Lector["fechaLanzamiento"]);
                    nuevoDisco.CantCanciones = (int)datos.Lector["cantidadCanciones"];
                    nuevoDisco.UrlImagen = (string)datos.Lector["urlImagenTapa"];
                    nuevoDisco.Estado = (bool)datos.Lector["Estado"];//

                    nuevoDisco.Estilo = new Estilo();
                    nuevoDisco.Estilo.Id = (int)datos.Lector["IdEstilo"];//necesario para el frm modificar
                    nuevoDisco.Estilo.Descripcion = (string)datos.Lector["Estilo"];

                    nuevoDisco.TipoEdicion = new TipoEdicion();
                    nuevoDisco.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];//necesario para el frm modificar
                    nuevoDisco.TipoEdicion.Descripcion = (string)datos.Lector["TipoEdicion"];
                    

                    ListaDiscos.Add(nuevoDisco);
                }
                return ListaDiscos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrar();
            }

        }

        public Disco ListarDisco(string id)
        {
            
            AccesoDatos datos = new AccesoDatos();
            Disco nuevoDisco = new Disco();

            try
            {
                datos.setearConsulta("SELECT D.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, Estado, D.IdEstilo ,E.Descripcion AS Estilo, D.IdTipoEdicion,T.Descripcion as TipoEdicion FROM DISCOS D , ESTILOS E, TIPOSEDICION T WHERE D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id and D.Id = "+ id);               
                datos.leerTabla();

                while (datos.Lector.Read())
                {
                    
                    nuevoDisco.Id = (int)datos.Lector["id"]; 
                    nuevoDisco.Titulo = (string)datos.Lector["titulo"];
                    //Se debe pasar a toString antes de parsear a DateTime
                    nuevoDisco.FechaLanzamiento = DateTime.Parse(datos.Lector["fechaLanzamiento"].ToString());
                    nuevoDisco.CantCanciones = (int)datos.Lector["cantidadCanciones"];
                    nuevoDisco.UrlImagen = (string)datos.Lector["urlImagenTapa"];
                    nuevoDisco.Estado = (bool)datos.Lector["Estado"];

                    nuevoDisco.Estilo = new Estilo();
                    nuevoDisco.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    nuevoDisco.Estilo.Descripcion = (string)datos.Lector["Estilo"];

                    nuevoDisco.TipoEdicion = new TipoEdicion();
                    nuevoDisco.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    nuevoDisco.TipoEdicion.Descripcion = (string)datos.Lector["TipoEdicion"];
                   
                }
                return nuevoDisco;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
        }

        //Para traer las cards (solo los activos)
        public List<Disco> ListarDiscosActivosSp()
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedimiento("storedListarSoloActivos");
                datos.leerTabla();
                while (datos.Lector.Read())
                {
                    Disco nuevo = new Disco();
                    nuevo.Id = (int)datos.Lector["id"];
                    nuevo.Titulo = (string)datos.Lector["titulo"];
                    nuevo.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    nuevo.CantCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                    {
                        nuevo.UrlImagen = (string)datos.Lector["UrlImagenTapa"];
                    }
                    else
                    {
                        nuevo.UrlImagen = "https://img.freepik.com/vector-premium/silueta-cantante-pie-sosteniendo-microfono-elegante-gritando-cantando-cancion-banda-musicos_561465-1102.jpg";
                    }                    
                    nuevo.Estilo = new Estilo();
                    nuevo.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    nuevo.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    nuevo.TipoEdicion = new TipoEdicion();
                    nuevo.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    nuevo.TipoEdicion.Descripcion = (string)datos.Lector["Edicion"];
                    //nuevo.Estado = bool.Parse(datos.Lector["Estado"].ToString());
                    nuevo.Estado = (bool)datos.Lector["Estado"];

                    lista.Add(nuevo);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.Lector.Close();
                datos.cerrar();
            }
        }

        //Para listar la grid(trae todos)
        public List<Disco> ListarSp()
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedimiento("storedListarDiscos");
                datos.leerTabla();
                while (datos.Lector.Read())
                {
                    Disco nuevo = new Disco();
                    nuevo.Id = (int)datos.Lector["id"];
                    nuevo.Titulo = (string)datos.Lector["titulo"];
                    nuevo.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    nuevo.CantCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull)) 
                    {
                        nuevo.UrlImagen = (string)datos.Lector["UrlImagenTapa"];
                    }
                    else
                    {
                        nuevo.UrlImagen = "https://img.freepik.com/vector-premium/silueta-cantante-pie-sosteniendo-microfono-elegante-gritando-cantando-cancion-banda-musicos_561465-1102.jpg";
                    }                    
                    nuevo.Estilo = new Estilo();
                    nuevo.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    nuevo.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    nuevo.TipoEdicion = new TipoEdicion();
                    nuevo.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    nuevo.TipoEdicion.Descripcion = (string)datos.Lector["Edicion"];
                    //nuevo.Estado = bool.Parse(datos.Lector["Estado"].ToString());
                    nuevo.Estado = (bool)datos.Lector["Estado"];

                    lista.Add(nuevo);

                }
                return lista;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                datos.Lector.Close();
                datos.cerrar();
            }
        }

        //Todos los discos que se agregan , inician con estado = 1 , para mostrarse en la grid

        public void agregarConSp(Disco nuevo)
        {
            AccesoDatos nuevoAcceso = new AccesoDatos();
            try
            {
                nuevoAcceso.setearProcedimiento("storedAltaDisco");
                nuevoAcceso.setearParametros("@titulo", nuevo.Titulo);
                nuevoAcceso.setearParametros("@fecha", nuevo.FechaLanzamiento);
                nuevoAcceso.setearParametros("@canciones", nuevo.CantCanciones);
                nuevoAcceso.setearParametros("@imagen", nuevo.UrlImagen);
                nuevoAcceso.setearParametros("@estilo", nuevo.Estilo.Id);
                nuevoAcceso.setearParametros("@edicion", nuevo.TipoEdicion.Id);

                nuevoAcceso.ejecutarAccion();

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

        public void modificarConSp(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarDisco");
                datos.setearParametros("@titulo", disco.Titulo);
                datos.setearParametros("@fecha", disco.FechaLanzamiento);
                datos.setearParametros("@canciones", disco.CantCanciones);
                datos.setearParametros("@imagen", disco.UrlImagen);
                datos.setearParametros("@estilo", disco.Estilo.Id);
                datos.setearParametros("@edicion", disco.TipoEdicion.Id);
                datos.setearParametros("@id", disco.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
        }
        public void agregar(Disco nuevoDisco)
        {
             AccesoDatos nuevoAcceso = new AccesoDatos();
            try
            {   //Agregamos el Estado, ya q nos va a servir para la eliminacion Logica 
                nuevoAcceso.setearConsulta("INSERT INTO DISCOS(Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, Estado,IdEstilo, IdTipoEdicion) VALUES(@Titulo, @FechaLanzamiento, @CantidadCanciones, @UrlImagenTapa, 1,@IdEstilo, @IdTipoEdicion)");
                
                nuevoAcceso.setearParametros("@Titulo", nuevoDisco.Titulo);
                nuevoAcceso.setearParametros("@FechaLanzamiento", nuevoDisco.FechaLanzamiento);
                nuevoAcceso.setearParametros("@CantidadCanciones", nuevoDisco.CantCanciones);
                nuevoAcceso.setearParametros("@UrlImagenTapa", nuevoDisco.UrlImagen);
                nuevoAcceso.setearParametros("@IdEstilo", nuevoDisco.Estilo.Id);
                nuevoAcceso.setearParametros("@IdTipoEdicion", nuevoDisco.TipoEdicion.Id);


                nuevoAcceso.ejecutarAccion();
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
        public void modificar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE DISCOS SET Titulo = @titulo, FechaLanzamiento = @fechaLanzamiento, CantidadCanciones=@cantidadCanciones, UrlImagenTapa=@urlImagenTapa, Estado=@estado,IdEstilo=@idEstilo, IdTipoEdicion=@idTipoEdicion WHERE Id = @id"); //
                datos.setearParametros("@titulo", disco.Titulo);
                datos.setearParametros("@fechaLanzamiento",disco.FechaLanzamiento);
                datos.setearParametros("@cantidadCanciones",disco.CantCanciones);
                datos.setearParametros("@urlImagenTapa",disco.UrlImagen);
                datos.setearParametros("@idEstilo",disco.Estilo.Id);
                datos.setearParametros("@idTipoEdicion",disco.TipoEdicion.Id);
                datos.setearParametros("@id",disco.Id);
                datos.setearParametros("@estado", disco.Estado);//para cambiar el estado de listaPapelera
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
        }
        public void eliminar(int idDisco)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("DELETE from DISCOS WHERE Id = @idDisco");
            try
            {
                datos.setearParametros("@idDisco",idDisco);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
        }
        public void enviarPapelera(int idDisco, bool EstadoDisco = false)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE DISCOS SET Estado = @EstadoDisco WHERE Id = @id");
                datos.setearParametros("@id", idDisco);
                datos.setearParametros("@EstadoDisco", EstadoDisco);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
            
            
        }
        public List<Disco> mostrarPapelera()
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT D.Id, Titulo,FechaLanzamiento, CantidadCanciones,UrlImagenTapa, Estado ,IdEstilo,E.Descripcion AS Estilo ,IdTipoEdicion, T.Descripcion AS TipoEdicion FROM DISCOS D inner join Estilos as E on D.IdEstilo = E.Id inner join TIPOSEDICION as T on D.IdTipoEdicion = T.Id AND Estado = 0");
                datos.leerTabla();
                while (datos.Lector.Read())
                {
                    Disco disco = new Disco();
                    disco.Id = (int)datos.Lector["id"];
                    disco.Titulo = (string)datos.Lector["titulo"];
                    disco.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    disco.CantCanciones = (int)datos.Lector["cantidadCanciones"];
                    disco.UrlImagen = (string)datos.Lector["urlImagenTapa"];

                    disco.Estilo = new Estilo();
                    disco.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    disco.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    
                    disco.TipoEdicion = new TipoEdicion();
                    disco.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    disco.TipoEdicion.Descripcion = (string)datos.Lector["TipoEdicion"];

                    lista.Add(disco);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
        }
        public List<Disco> filtrar(string campo, string criterio, string txtCombo)
        {
            List<Disco>lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            
            
            try
            {
                
                string consultaFiltro = "SELECT  D.Id, Titulo,FechaLanzamiento,CantidadCanciones, UrlImagenTapa,IdEstilo,IdTipoEdicion,E.Descripcion as Estilo,T.Descripcion as Edicion FROM DISCOS D INNER JOIN ESTILOS E ON D.IdEstilo = E.Id INNER JOIN TIPOSEDICION T ON D.IdTipoEdicion = T.Id WHERE ";
                if(campo == "Cantidad Canciones")
                {
                    switch(criterio)
                    {
                        case "Mayor a":
                            consultaFiltro += "CantidadCanciones > " + txtCombo;
                            break;
                        case "Menor a":
                            consultaFiltro += "CantidadCanciones < " + txtCombo;
                            break;
                        default:
                            consultaFiltro += "CantidadCanciones = " + txtCombo;
                            break;
                    }
                }
                else if(campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consultaFiltro += " Titulo LIKE " + "'" + txtCombo + "%'";
                            break;
                        case "Termina con":
                            consultaFiltro += " Titulo LIKE " + "'%" + txtCombo + "'";
                            break;
                        default:
                            consultaFiltro += " Titulo LIKE " + "'%" + txtCombo + "%'";
                            break;
                    }
                }
                else if (campo == "Tipo Edición")
                {                                      

                    switch (criterio)
                    {
                        case "Vinilo":
                            txtCombo = criterio; //otra variante
                            consultaFiltro += " T.Descripcion = '" + txtCombo + "'";
                            break;                                    
                        case "CD":                            
                            consultaFiltro += " T.Descripcion = '" +  (txtCombo = criterio)  + "'";
                            break;                                    
                        case "Tape":                                  
                            consultaFiltro += " T.Descripcion = '" + (txtCombo=criterio)  + "'";
                            break;                                    
                        default:                                      
                            consultaFiltro += " T.Descripcion = '" + (txtCombo = criterio) + "'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Pop":
                            consultaFiltro += " E.Descripcion = '" + (txtCombo = criterio) + "'";
                            break;
                        case "Pop Punk":
                            consultaFiltro += " E.Descripcion = '" + (txtCombo = criterio) + "'";
                            break;
                        case "Rock":
                            consultaFiltro += " E.Descripcion = '" + (txtCombo = criterio) + "'";
                            break;
                        case "Reggae":
                            consultaFiltro += " E.Descripcion = '" + (txtCombo= criterio) + "'";
                            break;
                        case "Country":
                            consultaFiltro += " E.Descripcion = '" + (txtCombo = criterio) + "'";
                            break;
                        case "Electrónica":
                            consultaFiltro += " E.Descripcion = '" + (txtCombo = criterio) + "'";
                            break;
                        default:
                            consultaFiltro += " E.Descripcion = '" + (txtCombo = criterio) + "'";
                            break;
                    }
                }

                //consultaFiltro += " AND Estado = 1 "; //evita que se vean los discos en Papelera
                datos.setearConsulta(consultaFiltro);
                datos.leerTabla();
                while (datos.Lector.Read())
                {
                    Disco nuevo = new Disco();
                    nuevo.Id = (int)datos.Lector["id"];
                    nuevo.Titulo = (string)datos.Lector["titulo"];
                    nuevo.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    nuevo.CantCanciones = (int)datos.Lector["CantidadCanciones"];
                    nuevo.UrlImagen = (string)datos.Lector["UrlImagenTapa"];
                    nuevo.Estilo = new Estilo();
                    nuevo.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    nuevo.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    nuevo.TipoEdicion = new TipoEdicion();
                    nuevo.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    nuevo.TipoEdicion.Descripcion = (string)datos.Lector["Edicion"];

                    lista.Add(nuevo);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;                
            }
            finally
            {
                datos.Lector.Close();
                datos.cerrar();
            }
        }
    }
}
