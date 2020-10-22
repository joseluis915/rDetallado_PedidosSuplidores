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
    public class ProductosBLL
    {
        public static List<Productos> GetProductos()
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