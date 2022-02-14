using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVideoclubNC.Models
{
    [Table("VISTA_CLIENTE_PELICULAS_PEDIDOS")]
    public class ClientesPeliculasPedido
    {
        [Key]
        [Column("IDPEDIDO")]
        public int IdPedido { get; set; }
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("TITULO")]
        public String Titulo { get; set; }
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
        [Column("PRECIO")]
        public int Precio { get; set; }
    }
}
