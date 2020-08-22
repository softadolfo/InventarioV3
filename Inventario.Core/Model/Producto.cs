using Inventario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Model
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string DescripcionProducto { get; set; }
        public string NombreProducto { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public int Disponibilidad { get; set; }
        public bool Activo { get; set; }
        public decimal PrecioVenta { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
    }
}
