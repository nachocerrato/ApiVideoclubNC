using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVideoclubNC.Models
{
    [Table("ADMINISTRADORES")]
    public class Administrador
    {
        [Key]
        [Column("IDADMIN")]
        public int IdAdmin { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
    }
}
