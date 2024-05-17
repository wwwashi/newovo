using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace newOvo.Data
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .Property(e => e.NameGender)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Gender)
                .HasForeignKey(e => e.GenderID);

            modelBuilder.Entity<Users>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Midname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UsersRole>()
                .Property(e => e.NameRole)
                .IsUnicode(false);

            modelBuilder.Entity<UsersRole>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UsersRole)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);
        }
    }
}
