using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace codeBlox.Models
{
    public class DescontroladaContext : DbContext
    {
        public DescontroladaContext() : base("descontroladaBD")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Descontrolada> descontroladaBD { get; set; }
    }
}
