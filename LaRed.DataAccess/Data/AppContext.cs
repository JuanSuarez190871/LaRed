using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaRed.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LaRed.DataAccess.Data
{
    public partial class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public virtual DbSet<Activos> Activos { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Mantenimiento> Mantenimiento { get; set; }
        public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }
    }
}
