using EntityFrameWork.Extend;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Model
{
   public class S_DbContext:MyDbContext
    {
        public S_DbContext() : base("name=Scyts.Shopping_Db") { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //创建表 
         // Database.SetInitializer(new DropCreateDatabaseAlways<S_DbContext>());
            //去除表明后缀
            modelBuilder.Conventions.Remove<System.Data.Entity.
            ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }

     

        public DbSet<Model.Article> Article { get; set; }

        public DbSet<Model.Attribute> Attribute { get; set; }

        public DbSet<Model.Brand> Brand { get; set; }

        public DbSet<Model.Category> Category { get; set; }

        public DbSet<Model.Category_Brand> Category_Brand { get; set; }

        public DbSet<Model.Channel> Channel { get; set; }

        public DbSet<Model.Country> Country { get; set; }

        public DbSet<Model.Good> Good { get; set; }

        public DbSet<Model.Good_Article> Good_Article { get; set; }

        public DbSet<Model.Good_Attribute> Good_Attribute { get; set; }

        public DbSet<Model.Keyword> Keyword { get; set; }

        public DbSet<Model.User> User { get; set; }

        public DbSet<Model.Category_Attribute> Category_Attribute { get; set; }

        public DbSet<Model.File> File { get; set; }

        public DbSet<Model.Good_File> Good_File { get; set; } 
    }
}
