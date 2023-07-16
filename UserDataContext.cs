using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Group_Project
{
    public class UserDataContext : DbContext
    {
        public readonly string path = @"C:\Users\Malshan\Desktop\Group_Project\LMSDataBase.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource ={path} ");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Module> Modules { get; set; }
       public DbSet<Student> Students { get; set; }

        public DbSet<Result> Results { get; set; }



    }

    public partial class CreateInitialSchema : DbMigration
    {
        public override void Up()
        {
            // Code to create tables, relationships, and other necessary schema

            // Create the admin user with default credentials
            Sql("INSERT INTO Admins (Admin_Name, Admin_Password) VALUES ('admin', 'admin')");
        }

    }
}
