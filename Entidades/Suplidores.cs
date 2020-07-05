using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rDetallado_PedidosSuplidores.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidoresId { get; set; }
        public string Nombres { get; set; }
    }
}
