using Brass.Materiais.DominioPQ.BIM.TabelasPlant;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Brass.Materiais.RepositorioAppEFSQLite.Model
{

    public class BIM360DataContext : DbContext
    {
        string _modelo;
        string _tipo;

        public BIM360DataContext(string modelo, string tipo,string pnPClassName)
        {
            _modelo = modelo;
            _tipo = tipo;
            PnPClassName = pnPClassName;
        }

        public string PnPClassName { get; set; }

        
        public DbSet<PnPTables> PnPTables { get; set; }
        public DbSet<BlancPipe> BlancPipe { get; set; }
        public DbSet<UnidadePipe> UnidadePipe { get; set; }

        //public DbSet<Pipe_PNP> Pipe_PNP { get; set; }
        //public DbSet<Valve_PNP> Valve_PNP { get; set; }
        public DbSet<Pipe> Pipe { get; set; }
        public DbSet<PipeLine> PipeLines { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_tipo)
            {
                case "BIM360":
                    {
                        optionsBuilder.UseSqlite($"Filename={_modelo}",
                            options =>
                            {
                                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                            })
                            .ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
                    }
                    break;
                case "VPN":
                    {
                        //string conexao = $"data source=192.168.20.240;initial catalog={_modelo};persist security info=True;"
                        //        + "user id=BrassDataBase;password=brass2019;MultipleActiveResultSets=True";

                        string conexao = $"Data Source=P00940\\SQLEXPRESS;Initial Catalog={_modelo};Integrated Security=True";

                        optionsBuilder.UseSqlServer(conexao,
                             options =>
                             {
                                 options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                             });
                    }
                    break;
                default:
                    {
                        optionsBuilder.UseSqlite($"Filename={_modelo}",
                            options =>
                            {
                                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                            });
                    }
                    break;
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlancPipe>(b =>
            {
                b.ToTable("Pipe_PNP");
                b.HasKey(p => p.PnPID);
            });

            switch (PnPClassName)
            {
                case "Pipe_PNP":
                    modelBuilder.Entity<UnidadePipe>(b =>
                    {
                        b.ToTable("Valve_PNP");
                        b.HasKey(p => p.PnPID);
                    });
                    break;

                case "":
                    modelBuilder.Entity<UnidadePipe>(b =>
                    {
                        b.ToTable("Valve_PNP");
                        b.HasKey(p => p.PnPID);
                    });
                    break;

                default:
                    modelBuilder.Entity<UnidadePipe>(b =>
                    {
                        b.ToTable(PnPClassName);
                        b.HasKey(p => p.PnPID);
                    });
                    break;
            }




            

            modelBuilder.Entity<PnPTables>().HasKey(m => m.TableName);
            modelBuilder.Entity<Pipe>().HasKey(m => m.PnPID);
            modelBuilder.Entity<PipeLine>().HasKey(m => m.PnPID);
            modelBuilder.Entity<BlancPipe>().HasKey(m => m.PnPID);
            //modelBuilder.Entity<Valve_PNP>().HasKey(m => m.PnPID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
