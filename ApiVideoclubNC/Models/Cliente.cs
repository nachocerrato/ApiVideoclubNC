using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVideoclubNC.Models
{
    [Table("CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("EMAIL")]
        public String Mail { get; set; }
        [Column("IMAGEN_CLIENTE")]
        public String Imagen { get; set; }
    }
}
