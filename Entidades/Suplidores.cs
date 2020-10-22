using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rDetallado_PedidosSuplidores.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        public string Nombres { get; set; }
    }
}