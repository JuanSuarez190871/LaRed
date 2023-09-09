using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRed.Shared.Models
{
    public class Mantenimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ActivoID { get; set; }
        public DateTime FechaMantenimiento { get; set; }
        public string DescripcionMantenimiento { get; set; }
    }
}
