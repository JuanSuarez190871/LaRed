using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRed.Shared.Models
{
    public class Activos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string NumeroActivo { get; set; }
        public string TipoActivo { get; set; }
        public int UbicacionID { get; set; }
        public int EstadoID { get; set; }
        public DateTime FechaCompra { get; set; }
        public double Costo { get; set; }
    }
}
