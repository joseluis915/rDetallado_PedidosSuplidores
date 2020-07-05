﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rDetallado_PedidosSuplidores.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double Inventario { get; set; }
    }
}
