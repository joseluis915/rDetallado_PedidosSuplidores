using rDetallado_PedidosSuplidores.DAL;
using rDetallado_PedidosSuplidores.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rDetallado_PedidosSuplidores.BLL
{
    public class SuplidoresBLL
    {
        public static List<Suplidores> GetList()
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