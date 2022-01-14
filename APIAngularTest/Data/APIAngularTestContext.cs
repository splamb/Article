using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIAngularTest.Models;

namespace APIAngularTest.Data
{
    public class APIAngularTestContext : DbContext
    {
        public APIAngularTestContext (DbContextOptions<APIAngularTestContext> options)
            : base(options)
        {
        }

        public DbSet<APIAngularTest.Models.Article> Article { get; set; }
    }
}
