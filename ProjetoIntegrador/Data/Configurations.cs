using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador.Data
{
    internal sealed class Configuration : DbMigrationsConfiguration<DrugBsiDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}