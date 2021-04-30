using MVCStudenClassAssinment.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCStudenClassAssinment.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ApplicationDBContext_5")
        {
        }

        public DbSet<SchoolClass> SchoolClasss { get; set; }
        public DbSet<ParentStudent> ParentStudents { get; set; }
        public DbSet<StudentClass> StudentClasss { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static implicit operator List<object>(ApplicationDBContext v)
        {
            throw new NotImplementedException();
        }

    }
}
