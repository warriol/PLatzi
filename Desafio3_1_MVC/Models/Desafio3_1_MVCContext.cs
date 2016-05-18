using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Desafio3_1_MVC.Models
{
    public class Desafio3_1_MVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Desafio3_1_MVCContext() : base("name=Desafio3_1_MVCContext")
        {
        }

        public System.Data.Entity.DbSet<Desafio3_1_MVC.Models.Imagen> Imagens { get; set; }

        public System.Data.Entity.DbSet<Desafio3_1_MVC.Models.Video> Videos { get; set; }
    }
}
