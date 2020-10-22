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
    public class SuplidoresBLL
    {
        public static List<Suplidores> GetSuplidores()
        {
            List<Suplidores> suplidores = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                suplidores = contexto.Suplidores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return suplidores;
        }
    }
}