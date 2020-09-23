using System;
using System.Reflection;
using Brass.Materiais.DominioPQ.BIM.TabelasPlant;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Brass.Materiais.RepoModelosVPNPlant.Data
{
    public partial class VPN_PipingContext : DbContext
    {

        string _modelo;

        public VPN_PipingContext(string modelo)
        {
            _modelo = modelo.ToLower();
        }

        public DbSet<Pipe_PNP> Pipe_PNP { get; set; }
        public DbSet<Valve_PNP> Valve_PNP { get; set; }
        public DbSet<Pipe> Pipe { get; set; }
        public DbSet<PipeLine> PipeLines { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string conexao = $"data source=192.168.20.240;initial catalog=_{_modelo}_Piping;persist security info=True;"
                //+ "user id=BrassDataBase;password=brass2019;MultipleActiveResultSets=True";

            string conexao = $"data source=P00940\\SQLEXPRESS;Initial Catalog=_{_modelo}_Piping;Integrated Security=True";

            optionsBuilder.UseSqlServer(conexao,
                 options =>
                 {
                     options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                 });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pipe>().HasKey(m => m.PnPID);
            modelBuilder.Entity<PipeLine>().HasKey(m => m.PnPID);
            modelBuilder.Entity<Pipe_PNP>().HasKey(m => m.PnPID);
            //modelBuilder.Entity<Valve_PNP>().HasKey(m => m.PnPID);

            base.OnModelCreating(modelBuilder);
        }



    }
}
