using rDetallado_PedidosSuplidores.DAL;
using rDetallado_PedidosSuplidores.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rDetallado_PedidosSuplidores.BLL
{
    public class ProductosBLL
    {
        public static List<Productos> GetList()
        {
            List<Productos> productos = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                productos = contexto.Productos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return productos;
        }
    }
}