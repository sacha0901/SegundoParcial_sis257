using CadAmc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnAmc
{
    public class SerieCln
    {
        public static int insertar(Serie serie) // INSERT INTO Serie VALUES (..., ...)
        {
            using (var contexto = new Parcial2AmcEntities())
            {
                contexto.Serie.Add(serie);
                contexto.SaveChanges();
                return serie.id;
            }
        }

        public static int actualizar(Serie serie) // UPDATE Serie SET campo=valor,... WHERE id = id
        {
            using (var contexto = new Parcial2AmcEntities())
            {
                var existente = contexto.Serie.Find(serie.id);
                existente.titulo = serie.titulo;
                existente.sinopsis = serie.sinopsis;
                existente.director = serie.director;
                existente.duracion = serie.duracion;
                existente.fechaEstreno = serie.fechaEstreno;
                return contexto.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro) // UPDATE Serie SET registroActivo=false, usuarioRegistro=valor WHERE id=id
        {
            using (var contexto = new Parcial2AmcEntities())
            {
                var existente = contexto.Serie.Find(id);
                existente.registroActivo = false;
                existente.usuarioRegistro = usuarioRegistro;
                return contexto.SaveChanges();
            }
        }

        public static Serie get(int id) // SELECT * FROM Serie WHERE id = id
        {
            using (var contexto = new Parcial2AmcEntities())
            {
                return contexto.Serie.Find(id);
            }
        }

        public static List<Serie> listar() // SELECT * FROM Serie WHERE registroActivo=true
        {
            using (var contexto = new Parcial2AmcEntities())
            {
                return contexto.Serie.Where(x => x.registroActivo.Value).ToList();
            }
        }

        public static List<paSerieListar_Result> listarPa(string parametro) // EXEC paProductoListar 'valor'
        {
            using (var contexto = new Parcial2AmcEntities())
            {
                return contexto.paSerieListar(parametro).ToList();
            }
        }

        public static void eliminar(int id, object usuario)
        {
            throw new NotImplementedException();
        }
    }
}
