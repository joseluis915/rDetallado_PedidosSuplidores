using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rDetallado_PedidosSuplidores.Entidades
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public int SuplidorId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalle> Detalle { get; set; } = new List<OrdenesDetalle>();

        [ForeignKey("SuplidorId")]
        public Suplidores suplidores { get; set; }
    }
}