using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace rDetallado_PedidosSuplidores.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        
        [ForeignKey("ProductoId")]
        public Productos Producto { get; set; } = new Productos();

        public int Cantidad { get; set; }
        public int SuplidorId { get; set; }
        
        //[ForeignKey("SuplidorId")]
        //public Suplidores Suplidor { get; set; } = new Suplidores();
    }
}
