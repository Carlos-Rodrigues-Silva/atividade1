using Estacione.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacione.Data
{
    public class ApplicationDataContext : DbContext
    {

        public DbSet<Estacionamento> Estacionamentos { get; set; }

        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }
    }
}
