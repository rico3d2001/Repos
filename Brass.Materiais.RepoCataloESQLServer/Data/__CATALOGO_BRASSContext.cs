using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class __CATALOGO_BRASSContext : DbContext
    {
        public __CATALOGO_BRASSContext()
        {
        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=P00940\\SQLEXPRESS;Initial Catalog=__CATALOGO_BRASS;Integrated Security=True;",
                options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            base.OnConfiguring(optionsBuilder);


            //optionsBuilder.UseSqlServer("data source=192.168.20.240;initial catalog=__CATALOGO_BRASS;persist security info=True;user id=BrassDataBase;password=brass2019;",
            //     options =>
            //     {
            //         options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            //     });
            //base.OnConfiguring(optionsBuilder);
        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("data source=192.168.20.240;initial catalog=__CATALOGO_BRASS;persist security info=True;user id=BrassDataBase;password=brass2019;");
//            }
//        }

        public virtual DbSet<CatalogoPlant3d> CatalogoPlant3d { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<CategoriasCatalogo> CategoriasCatalogo { get; set; }
        public virtual DbSet<Codificacoes> Codificacoes { get; set; }
        public virtual DbSet<CompatibleStandard> CompatibleStandard { get; set; }
        public virtual DbSet<CtCodigoDiametro> CtCodigoDiametro { get; set; }
        public virtual DbSet<CtExtremidade> CtExtremidade { get; set; }
        public virtual DbSet<CtFabricacao> CtFabricacao { get; set; }
        public virtual DbSet<CtIdioma> CtIdioma { get; set; }
        public virtual DbSet<CtMateriais> CtMateriais { get; set; }
        public virtual DbSet<CtPnPtables> CtPnPtables { get; set; }
        public virtual DbSet<CtRevestimento> CtRevestimento { get; set; }
        public virtual DbSet<CtSchedule> CtSchedule { get; set; }
        public virtual DbSet<ItemEngenharia> ItemEngenharia { get; set; }
        public virtual DbSet<ItemEngenhariaPlant3d> ItemEngenhariaPlant3d { get; set; }
        public virtual DbSet<PropriedadeEng> PropriedadeEng { get; set; }
        public virtual DbSet<PropriedadeItemEng> PropriedadeItemEng { get; set; }
        public virtual DbSet<PrpiedadesRelacionadas> PrpiedadesRelacionadas { get; set; }
        public virtual DbSet<SiglaCodigo> SiglaCodigo { get; set; }
        public virtual DbSet<Tarefas> Tarefas { get; set; }
        public virtual DbSet<Teste> Teste { get; set; }
        public virtual DbSet<TipoItem> TipoItem { get; set; }
        public virtual DbSet<TipoPropriedade> TipoPropriedade { get; set; }
        public virtual DbSet<Tubo> Tubo { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Valores> Valores { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CatalogoPlant3d>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.GuidIdioma)
                    .HasColumnName("GUID_IDIOMA")
                    .HasMaxLength(60);

                entity.Property(e => e.Nome).HasColumnName("NOME");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome).HasColumnName("NOME");
            });

            modelBuilder.Entity<CategoriasCatalogo>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Categorias_Catalogo");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.GuidCatalogo)
                    .HasColumnName("GUID_CATALOGO")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidCategoria)
                    .HasColumnName("GUID_CATEGORIA")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Codificacoes>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CODIFICACOES");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome).HasColumnName("NOME");
            });

            modelBuilder.Entity<CompatibleStandard>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<CtCodigoDiametro>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CT_CodigoDiametro");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nominal).HasColumnName("NOMINAL");

                entity.Property(e => e.SiglaBrass)
                    .HasColumnName("Sigla_BRASS")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<CtExtremidade>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CT_Extremidade");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

                entity.Property(e => e.Nome).HasColumnName("NOME");

                entity.Property(e => e.SiglaBrass)
                    .HasColumnName("Sigla_BRASS")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<CtFabricacao>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CT_Fabricacao");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome).HasColumnName("NOME");

                entity.Property(e => e.SiglaBrass)
                    .HasColumnName("Sigla_BRASS")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<CtIdioma>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CT_Idioma");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Idioma).HasColumnName("IDIOMA");

                entity.Property(e => e.Pais).HasColumnName("PAIS");
            });

            modelBuilder.Entity<CtMateriais>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CT_Materiais");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome).HasColumnName("NOME");

                entity.Property(e => e.SiglaBrass)
                    .HasColumnName("Sigla_BRASS")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<CtPnPtables>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CT_PnPTables");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Abstract).HasMaxLength(16);

                entity.Property(e => e.SiglaBrass)
                    .HasColumnName("Sigla_BRASS")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<CtRevestimento>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CT_Revestimento");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome).HasColumnName("NOME");

                entity.Property(e => e.SiglaBrass)
                    .HasColumnName("Sigla_BRASS")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<CtSchedule>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("CT_Schedule");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome).HasColumnName("NOME");

                entity.Property(e => e.SiglaBrass)
                    .HasColumnName("Sigla_BRASS")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<ItemEngenharia>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.GuidCatalogo)
                    .HasColumnName("GUID_CATALOGO")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidItemPai)
                    .HasColumnName("GUID_ITEM_PAI")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidTipoItem)
                    .HasColumnName("GUID_TIPO_ITEM")
                    .HasMaxLength(60);

                entity.Property(e => e.PnPid).HasColumnName("PnPID");
            });

            modelBuilder.Entity<ItemEngenhariaPlant3d>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.CatalogPartFamilyId)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

                entity.Property(e => e.ContentGeometryParamDefinition)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoCurta)
                    .HasColumnName("Descricao_curta")
                    .HasColumnType("text");

                entity.Property(e => e.DescricaoLml)
                    .HasColumnName("Descricao_LML")
                    .HasColumnType("text");

                entity.Property(e => e.Idioma)
                    .HasColumnName("IDIOMA")
                    .HasMaxLength(60);

                entity.Property(e => e.PartFamilyId).HasMaxLength(60);

                entity.Property(e => e.PnPid).HasColumnName("PnPID");

                entity.Property(e => e.SizeRecordId).HasMaxLength(60);
            });

            modelBuilder.Entity<PropriedadeEng>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.GuidTipo)
                    .HasColumnName("GUID_TIPO")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidValor).HasColumnName("GUID_VALOR");
            });

            modelBuilder.Entity<PropriedadeItemEng>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.GuidItemEng)
                    .HasColumnName("GUID_ITEM_ENG")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidPropriedade)
                    .HasColumnName("GUID_PROPRIEDADE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<PrpiedadesRelacionadas>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.GuidPnptable)
                    .HasColumnName("GUID_PNPTABLE")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidPropiedade)
                    .HasColumnName("GUID_PROPIEDADE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<SiglaCodigo>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("SIGLA_CODIGO");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.DimensaoMm).HasColumnName("DIMENSAO_MM");

                entity.Property(e => e.GuidNorma)
                    .HasColumnName("GUID_NORMA")
                    .HasMaxLength(60);

                entity.Property(e => e.Sigla)
                    .HasColumnName("SIGLA")
                    .HasMaxLength(10);

                entity.Property(e => e.SiglaPai)
                    .HasColumnName("SIGLA_PAI")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Tarefas>(entity =>
            {
                entity.Property(e => e.Nome).HasMaxLength(200);
            });

            modelBuilder.Entity<Teste>(entity =>
            {
                entity.ToTable("TESTE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TipoItem>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome).HasColumnName("NOME");
            });

            modelBuilder.Entity<TipoPropriedade>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.GuidPai)
                    .HasColumnName("GUID_PAI")
                    .HasMaxLength(60);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME");
            });

            modelBuilder.Entity<Tubo>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("TUBO");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.GuidDiametro)
                    .HasColumnName("GUID_DIAMETRO")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidExtremidade)
                    .HasColumnName("GUID_EXTREMIDADE")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidFabricacao)
                    .HasColumnName("GUID_FABRICACAO")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidMaterial)
                    .HasColumnName("GUID_MATERIAL")
                    .HasMaxLength(60);

                entity.Property(e => e.GuidSchedule)
                    .HasColumnName("GUID_SCHEDULE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.Property(e => e.Senha).IsRequired();
            });

            modelBuilder.Entity<Valores>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(60)
                    .ValueGeneratedNever();

                entity.Property(e => e.SiglaBrass).HasColumnName("Sigla_BRASS");

                entity.Property(e => e.Valor).HasColumnName("VALOR");
            });
        }
    }
}
