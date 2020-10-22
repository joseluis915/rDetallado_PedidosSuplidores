using System;
using System.Collections.Generic;
using System.Text;
//Using agregados
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using rDetallado_PedidosSuplidores.DAL;
using rDetallado_PedidosSuplidores.Entidades;

namespace rDetallado_PedidosSuplidores.BLL
{
    public class OrdenesBLL
    {
        //—————————————————————————————————————————————————————[ GUARDAR ]—————————————————————————————————————————————————————
        public static bool Guardar(Ordenes ordenes)
        {
            bool paso;

            if (!Existe(ordenes.OrdenId))
                paso = Insertar(ordenes);
            else
                paso = Modificar(ordenes);

            return paso;
        }
        //—————————————————————————————————————————————————————[ INSERTAR ]—————————————————————————————————————————————————————
        public static bool Insertar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Ordenes.Add(ordenes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        //—————————————————————————————————————————————————————[ MODIFICAR ]—————————————————————————————————————————————————————
        public static bool Modificar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM OrdenesDetalle WHERE OrdenId={ordenes.OrdenId}");

                foreach (var item in ordenes.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(ordenes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        //—————————————————————————————————————————————————————[ ELIMINAR ]—————————————————————————————————————————————————————
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var devolucion = OrdenesBLL.Buscar(id);
                if (devolucion != null)
                {
                    contexto.Ordenes.Remove(devolucion);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        //—————————————————————————————————————————————————————[ GETLIST ]—————————————————————————————————————————————————————
        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Ordenes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
        //—————————————————————————————————————————————————————[ EXISTE ]—————————————————————————————————————————————————————
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Ordenes.Any(o => o.OrdenId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        //—————————————————————————————————————————————————————[ BUSCAR ]————————————————————————————————————————————————————
        public static Ordenes Buscar(int id)
        {
            Ordenes ordenes = new Ordenes();
            Contexto contexto = new Contexto();

            try
            {
                ordenes = contexto.Ordenes
                    .Where(d => d.OrdenId == id)
                    .Include(d => d.Detalle)
                    .ThenInclude(p => p.productos)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ordenes;
        }
    }
}
