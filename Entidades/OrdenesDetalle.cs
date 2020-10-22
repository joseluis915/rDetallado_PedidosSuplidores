using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace rDetallado_PedidosSuplidores.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int OrdenDetalle { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int SuplidorId { get; set; }

        [ForeignKey("ProductoId")]
        public Productos productos { get; set; } = new Productos();
    }
}