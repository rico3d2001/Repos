using System;
using Brass.Materiais.BIM.Entities.EFEntitiesPiping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Brass.Materiais.EFSQLServer_Plant3d.Data
{
    public partial class Plant3d_PipingContext : DbContext
    {
        public Plant3d_PipingContext()
        {
        }

        public Plant3d_PipingContext(DbContextOptions<Plant3d_PipingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agitador> Agitador { get; set; }
        public virtual DbSet<Amostrador> Amostrador { get; set; }
        public virtual DbSet<AssetOwnership> AssetOwnership { get; set; }
        public virtual DbSet<Balança> Balança { get; set; }
        public virtual DbSet<BleedRing> BleedRing { get; set; }
        public virtual DbSet<BlindFlange> BlindFlange { get; set; }
        public virtual DbSet<BoltSet> BoltSet { get; set; }
        public virtual DbSet<Britador> Britador { get; set; }
        public virtual DbSet<Buttweld> Buttweld { get; set; }
        public virtual DbSet<CaixaDePolpa> CaixaDePolpa { get; set; }
        public virtual DbSet<Caldeira> Caldeira { get; set; }
        public virtual DbSet<Calha> Calha { get; set; }
        public virtual DbSet<Cap> Cap { get; set; }
        public virtual DbSet<Chute> Chute { get; set; }
        public virtual DbSet<Ciclone> Ciclone { get; set; }
        public virtual DbSet<ColorSettings> ColorSettings { get; set; }
        public virtual DbSet<Compactador> Compactador { get; set; }
        public virtual DbSet<Compressor> Compressor { get; set; }
        public virtual DbSet<Coupling> Coupling { get; set; }
        public virtual DbSet<Distribuidor> Distribuidor { get; set; }
        public virtual DbSet<Elbow> Elbow { get; set; }
        public virtual DbSet<Elevador> Elevador { get; set; }
        public virtual DbSet<Empilhadeira> Empilhadeira { get; set; }
        public virtual DbSet<EngineeringItemsBIM> EngineeringItems { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Espessador> Espessador { get; set; }
        public virtual DbSet<Fasteners> Fasteners { get; set; }
        public virtual DbSet<Filtro> Filtro { get; set; }
        public virtual DbSet<Flange> Flange { get; set; }
        public virtual DbSet<Forno> Forno { get; set; }
        public virtual DbSet<Gasket> Gasket { get; set; }
        public virtual DbSet<GlobalEquipment> GlobalEquipment { get; set; }
        public virtual DbSet<Grelha> Grelha { get; set; }
        public virtual DbSet<Instrument> Instrument { get; set; }
        public virtual DbSet<LayerColorGlobalSettings> LayerColorGlobalSettings { get; set; }
        public virtual DbSet<LayerColorSchemeAssignment> LayerColorSchemeAssignment { get; set; }
        public virtual DbSet<Moega> Moega { get; set; }
        public virtual DbSet<Moinho> Moinho { get; set; }
        public virtual DbSet<Motor> Motor { get; set; }
        public virtual DbSet<Nipple> Nipple { get; set; }
        public virtual DbSet<Nozzle> Nozzle { get; set; }
        public virtual DbSet<Olet> Olet { get; set; }
        public virtual DbSet<OrificePlate> OrificePlate { get; set; }
        public virtual DbSet<P3dConnector> P3dConnector { get; set; }
        public virtual DbSet<P3dDrawingLineGroupRelationship> P3dDrawingLineGroupRelationship { get; set; }
        public virtual DbSet<P3dLineGroup> P3dLineGroup { get; set; }
        public virtual DbSet<P3dLineGroupPartRelationship> P3dLineGroupPartRelationship { get; set; }
        public virtual DbSet<P3dPartConnection> P3dPartConnection { get; set; }
        public virtual DbSet<PartPort> PartPort { get; set; }
        public virtual DbSet<Peneira> Peneira { get; set; }
        public virtual DbSet<Pipe> Pipe { get; set; }
        public virtual DbSet<PipeBend> PipeBend { get; set; }
        public virtual DbSet<PipeRunComponent> PipeRunComponent { get; set; }
        public virtual DbSet<PnPbase> PnPbase { get; set; }
        public virtual DbSet<PnPcolumnAttributes> PnPcolumnAttributes { get; set; }
        public virtual DbSet<PnPdataLinks> PnPdataLinks { get; set; }
        public virtual DbSet<PnPdrawingCategories> PnPdrawingCategories { get; set; }
        public virtual DbSet<PnPdrawings> PnPdrawings { get; set; }
        public virtual DbSet<PnPindexColumns> PnPindexColumns { get; set; }
        public virtual DbSet<PnPindexes> PnPindexes { get; set; }
        public virtual DbSet<PnPpicklists> PnPpicklists { get; set; }
        public virtual DbSet<PnPpicklistValues> PnPpicklistValues { get; set; }
        public virtual DbSet<PnPproject> PnPproject { get; set; }
        public virtual DbSet<PnPprojectCategories> PnPprojectCategories { get; set; }
        public virtual DbSet<PnPprojectVariables> PnPprojectVariables { get; set; }
        public virtual DbSet<PnPproperties> PnPproperties { get; set; }
        public virtual DbSet<PnPrelationshipProperties> PnPrelationshipProperties { get; set; }
        public virtual DbSet<PnPrelationshipTypes> PnPrelationshipTypes { get; set; }
        public virtual DbSet<PnProleTypes> PnProleTypes { get; set; }
        public virtual DbSet<PnProwRelations> PnProwRelations { get; set; }
        public virtual DbSet<PnPtableAttributes> PnPtableAttributes { get; set; }
        public virtual DbSet<PnPtables> PnPtables { get; set; }
        public virtual DbSet<PnPtagEnlistedColumns> PnPtagEnlistedColumns { get; set; }
        public virtual DbSet<PnPtagFormat> PnPtagFormat { get; set; }
        public virtual DbSet<PnPtagRegistries> PnPtagRegistries { get; set; }
        public virtual DbSet<PnPtagRegistry> PnPtagRegistry { get; set; }
        public virtual DbSet<PnPtombstone> PnPtombstone { get; set; }
        public virtual DbSet<PnPworkHistory> PnPworkHistory { get; set; }
        public virtual DbSet<Port> Port { get; set; }
        public virtual DbSet<Prensa> Prensa { get; set; }
        public virtual DbSet<Pump> Pump { get; set; }
        public virtual DbSet<QuadroPneumatico> QuadroPneumatico { get; set; }
        public virtual DbSet<Raspador> Raspador { get; set; }
        public virtual DbSet<Recuperadora> Recuperadora { get; set; }
        public virtual DbSet<Reducer> Reducer { get; set; }
        public virtual DbSet<Secador> Secador { get; set; }
        public virtual DbSet<Separador> Separador { get; set; }
        public virtual DbSet<Silo> Silo { get; set; }
        public virtual DbSet<SingleBranchFitting> SingleBranchFitting { get; set; }
        public virtual DbSet<SlipOn> SlipOn { get; set; }
        public virtual DbSet<Socketweld> Socketweld { get; set; }
        public virtual DbSet<SteelStructure> SteelStructure { get; set; }
        public virtual DbSet<Strainer> Strainer { get; set; }
        public virtual DbSet<StructureLadder> StructureLadder { get; set; }
        public virtual DbSet<StructureMember> StructureMember { get; set; }
        public virtual DbSet<StructureRailing> StructureRailing { get; set; }
        public virtual DbSet<StructureStair> StructureStair { get; set; }
        public virtual DbSet<StubEnd> StubEnd { get; set; }
        public virtual DbSet<Support> Support { get; set; }
        public virtual DbSet<Swage> Swage { get; set; }
        public virtual DbSet<Tambor> Tambor { get; set; }
        public virtual DbSet<Tank> Tank { get; set; }
        public virtual DbSet<Tanque> Tanque { get; set; }
        public virtual DbSet<TapWeld> TapWeld { get; set; }
        public virtual DbSet<Tee> Tee { get; set; }
        public virtual DbSet<Thread> Thread { get; set; }
        public virtual DbSet<Transportador> Transportador { get; set; }
        public virtual DbSet<TrocadorDeCalor> TrocadorDeCalor { get; set; }
        public virtual DbSet<Turbina> Turbina { get; set; }
        public virtual DbSet<Universal> Universal { get; set; }
        public virtual DbSet<Valve> Valve { get; set; }
        public virtual DbSet<Vaso> Vaso { get; set; }
        public virtual DbSet<Ventilador> Ventilador { get; set; }
        public virtual DbSet<Vessel> Vessel { get; set; }

        // Unable to generate entity type for table 'dbo.PnPSys_RelationshipSystem_PnPID'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PnPDatabase'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PnPSys_PnPBase_PnPID'. Please see the warning messages.

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agitador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("AGITADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Amostrador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("AMOSTRADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<AssetOwnership>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.HasIndex(e => e.Owned)
                    .HasName("AssetOwnership_0");

                entity.HasIndex(e => e.Owner)
                    .HasName("AssetOwnership_1");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PnPguid).HasColumnName("PnPGuid");

                entity.Property(e => e.PnPtimestamp).HasColumnName("PnPTimestamp");
            });

            modelBuilder.Entity<Balança>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("BALANÇA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<BleedRing>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<BlindFlange>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<BoltSet>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoltCompatibleStd).HasMaxLength(255);

                entity.Property(e => e.BoltSize).HasMaxLength(255);

                entity.Property(e => e.NumberInSet).HasMaxLength(255);

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Britador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("BRITADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Buttweld>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CaixaDePolpa>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("CAIXA_DE_POLPA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Caldeira>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("CALDEIRA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Calha>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("CALHA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Cap>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Chute>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("CHUTE");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Ciclone>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("CICLONE");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ColorSettings>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Compactador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("COMPACTADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Compressor>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("COMPRESSOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Coupling>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Distribuidor>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("DISTRIBUIDOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Elbow>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Elevador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("ELEVADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Empilhadeira>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("EMPILHADEIRA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<EngineeringItemsBIM>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcquisitionProperties).HasMaxLength(512);

                entity.Property(e => e.CogX).HasColumnName("COG X");

                entity.Property(e => e.CogY).HasColumnName("COG Y");

                entity.Property(e => e.CogZ).HasColumnName("COG Z");

                entity.Property(e => e.CompatibleStandard).HasMaxLength(255);

                entity.Property(e => e.ComponentDesignation).HasMaxLength(255);

                entity.Property(e => e.ContentIsoSymbolDefinition).HasMaxLength(255);

                entity.Property(e => e.DesignPressureFactor).HasMaxLength(255);

                entity.Property(e => e.DesignStd).HasMaxLength(255);

                entity.Property(e => e.EndType).HasMaxLength(255);

                entity.Property(e => e.Facing).HasMaxLength(255);

                entity.Property(e => e.FlangeStd).HasMaxLength(255);

                entity.Property(e => e.GasketStd).HasMaxLength(255);

                entity.Property(e => e.ItemCode).HasMaxLength(255);

                entity.Property(e => e.LengthUnit).HasMaxLength(255);

                entity.Property(e => e.Manufacturer).HasMaxLength(255);

                entity.Property(e => e.Material).HasMaxLength(255);

                entity.Property(e => e.MaterialCode).HasMaxLength(255);

                entity.Property(e => e.NominalUnit).HasMaxLength(255);

                entity.Property(e => e.PartCategory).HasMaxLength(255);

                entity.Property(e => e.PartFamilyLongDesc).HasMaxLength(255);

                entity.Property(e => e.PartSizeLongDesc).HasMaxLength(255);

                entity.Property(e => e.PortName).HasMaxLength(255);

                entity.Property(e => e.PositionX).HasColumnName("Position X");

                entity.Property(e => e.PositionY).HasColumnName("Position Y");

                entity.Property(e => e.PositionZ).HasColumnName("Position Z");

                entity.Property(e => e.PressureClass).HasMaxLength(255);

                entity.Property(e => e.Schedule).HasMaxLength(255);

                entity.Property(e => e.ShortDescription).HasMaxLength(255);

                entity.Property(e => e.Spec).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.WeightUnit).HasMaxLength(255);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.Number).HasMaxLength(255);

                entity.Property(e => e.Tag).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<Espessador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("ESPESSADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Fasteners>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.InsulationSpec).HasMaxLength(255);

                entity.Property(e => e.InsulationThickness).HasMaxLength(255);

                entity.Property(e => e.InsulationType).HasMaxLength(255);

                entity.Property(e => e.LineNumberTag).HasMaxLength(255);

                entity.Property(e => e.RequiredSpec)
                    .HasColumnName("Required Spec")
                    .HasMaxLength(255);

                entity.Property(e => e.Service).HasMaxLength(255);

                entity.Property(e => e.SpoolNumber).HasMaxLength(255);

                entity.Property(e => e.TracingSpec).HasMaxLength(255);

                entity.Property(e => e.TracingType).HasMaxLength(255);

                entity.Property(e => e.Unit).HasMaxLength(255);
            });

            modelBuilder.Entity<Filtro>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("FILTRO");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Flange>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Forno>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("FORNO");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Gasket>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<GlobalEquipment>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Grelha>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("GRELHA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.LoopNumber).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<LayerColorGlobalSettings>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<LayerColorSchemeAssignment>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Moega>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("MOEGA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Moinho>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("MOINHO");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Motor>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("MOTOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Nipple>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Nozzle>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Number).HasMaxLength(255);

                entity.Property(e => e.PartSubType).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<Olet>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartSubType).HasMaxLength(255);
            });

            modelBuilder.Entity<OrificePlate>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<P3dConnector>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcquisitionProperties).HasMaxLength(512);

                entity.Property(e => e.JointType).HasMaxLength(255);
            });

            modelBuilder.Entity<P3dDrawingLineGroupRelationship>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.HasIndex(e => e.Drawing)
                    .HasName("P3dDrawingLineGroupRelationship_0");

                entity.HasIndex(e => e.LineGroup)
                    .HasName("P3dDrawingLineGroupRelationship_1");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PnPguid).HasColumnName("PnPGuid");

                entity.Property(e => e.PnPtimestamp).HasColumnName("PnPTimestamp");
            });

            modelBuilder.Entity<P3dLineGroup>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcquisitionProperties).HasMaxLength(512);

                entity.Property(e => e.Area)
                    .HasColumnName("AREA")
                    .HasMaxLength(255);

                entity.Property(e => e.CogX).HasColumnName("COG X");

                entity.Property(e => e.CogY).HasColumnName("COG Y");

                entity.Property(e => e.CogZ).HasColumnName("COG Z");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.InsulationSpec).HasMaxLength(255);

                entity.Property(e => e.InsulationThickness).HasMaxLength(255);

                entity.Property(e => e.InsulationType).HasMaxLength(255);

                entity.Property(e => e.LockedBy).HasMaxLength(255);

                entity.Property(e => e.NominalSize).HasMaxLength(255);

                entity.Property(e => e.NominalSpec).HasMaxLength(255);

                entity.Property(e => e.Number).HasMaxLength(255);

                entity.Property(e => e.Service).HasMaxLength(255);

                entity.Property(e => e.Tag).HasMaxLength(255);

                entity.Property(e => e.TracingSpec).HasMaxLength(255);

                entity.Property(e => e.TracingType).HasMaxLength(255);

                entity.Property(e => e.WeightUnit).HasMaxLength(255);
            });

            modelBuilder.Entity<P3dLineGroupPartRelationship>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.HasIndex(e => e.LineGroup)
                    .HasName("P3dLineGroupPartRelationship_0");

                entity.HasIndex(e => e.Part)
                    .HasName("P3dLineGroupPartRelationship_1");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PnPguid).HasColumnName("PnPGuid");

                entity.Property(e => e.PnPtimestamp).HasColumnName("PnPTimestamp");
            });

            modelBuilder.Entity<P3dPartConnection>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.HasIndex(e => e.Part1)
                    .HasName("P3dPartConnection_0");

                entity.HasIndex(e => e.Part2)
                    .HasName("P3dPartConnection_1");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PnPguid).HasColumnName("PnPGuid");

                entity.Property(e => e.PnPtimestamp).HasColumnName("PnPTimestamp");

                entity.Property(e => e.Port1).HasMaxLength(4000);

                entity.Property(e => e.Port2).HasMaxLength(4000);
            });

            modelBuilder.Entity<PartPort>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.HasIndex(e => e.Part)
                    .HasName("PartPort_0");

                entity.HasIndex(e => e.Port)
                    .HasName("PartPort_1");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.PnPguid).HasColumnName("PnPGuid");

                entity.Property(e => e.PnPtimestamp).HasColumnName("PnPTimestamp");
            });

            modelBuilder.Entity<Peneira>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PENEIRA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Pipe>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LinearWeightUnit).HasMaxLength(255);
            });

            modelBuilder.Entity<PipeBend>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LinearWeightUnit).HasMaxLength(255);
            });

            modelBuilder.Entity<PipeRunComponent>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area2)
                    .HasColumnName("AREA_2")
                    .HasMaxLength(255);

                entity.Property(e => e.InsulationSpec).HasMaxLength(255);

                entity.Property(e => e.InsulationThickness).HasMaxLength(255);

                entity.Property(e => e.InsulationType).HasMaxLength(255);

                entity.Property(e => e.LineNumberTag).HasMaxLength(255);

                entity.Property(e => e.PressaoProjeto)
                    .HasColumnName("PRESSAO_PROJETO")
                    .HasMaxLength(255);

                entity.Property(e => e.RequiredSpec)
                    .HasColumnName("Required Spec")
                    .HasMaxLength(255);

                entity.Property(e => e.Service).HasMaxLength(255);

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);

                entity.Property(e => e.SpoolNumber).HasMaxLength(255);

                entity.Property(e => e.Tag).HasMaxLength(255);

                entity.Property(e => e.TieInNumber).HasMaxLength(255);

                entity.Property(e => e.TracingSpec).HasMaxLength(255);

                entity.Property(e => e.TracingType).HasMaxLength(255);

                entity.Property(e => e.Unit).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPbase>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPBase");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PnPclassName)
                    .HasColumnName("PnPClassName")
                    .HasMaxLength(255);

                entity.Property(e => e.PnPguid).HasColumnName("PnPGuid");

                entity.Property(e => e.PnPrevision).HasColumnName("PnPRevision");

                entity.Property(e => e.PnPstatus).HasColumnName("PnPStatus");

                entity.Property(e => e.PnPtimestamp).HasColumnName("PnPTimestamp");
            });

            modelBuilder.Entity<PnPcolumnAttributes>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.ColumnName, e.AttributeName });

                entity.ToTable("PnPColumnAttributes");

                entity.Property(e => e.TableName).HasMaxLength(255);

                entity.Property(e => e.ColumnName).HasMaxLength(255);

                entity.Property(e => e.AttributeName).HasMaxLength(255);

                entity.Property(e => e.AttributeValue).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPdataLinks>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPDataLinks");

                entity.HasIndex(e => e.RowId)
                    .HasName("DL_RowId");

                entity.HasIndex(e => new { e.DwgHandleHigh, e.DwgHandleLow, e.DwgId })
                    .HasName("DL_DwgHandle");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RowClassName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPdrawingCategories>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPDrawingCategories");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasMaxLength(255);

                entity.Property(e => e.DisplayName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPdrawings>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPDrawings");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.Author).HasMaxLength(255);

                entity.Property(e => e.CarimboEscala)
                    .HasColumnName("Carimbo_Escala")
                    .HasMaxLength(255);

                entity.Property(e => e.CarimboNºBrass)
                    .HasColumnName("Carimbo_Nº Brass")
                    .HasMaxLength(255);

                entity.Property(e => e.CarimboNºCliente)
                    .HasColumnName("Carimbo_Nº Cliente")
                    .HasMaxLength(255);

                entity.Property(e => e.CarimboRevisão)
                    .HasColumnName("Carimbo_Revisão")
                    .HasMaxLength(255);

                entity.Property(e => e.CarimboSubtítulo1)
                    .HasColumnName("Carimbo_Subtítulo 1")
                    .HasMaxLength(255);

                entity.Property(e => e.CarimboSubtítulo2)
                    .HasColumnName("Carimbo_Subtítulo 2")
                    .HasMaxLength(255);

                entity.Property(e => e.CarimboÁreaDoDesenho)
                    .HasColumnName("Carimbo_Área do Desenho")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DwgName)
                    .HasColumnName("Dwg Name")
                    .HasMaxLength(255);

                entity.Property(e => e.Path).HasMaxLength(512);

                entity.Property(e => e.PnId)
                    .HasColumnName("PnID")
                    .HasMaxLength(255);

                entity.Property(e => e.PnPdrawingGuid)
                    .HasColumnName("PnPDrawingGuid")
                    .HasMaxLength(40);

                entity.Property(e => e.PnPdwgOutOfSync).HasColumnName("PnPDwgOutOfSync");

                entity.Property(e => e.PnPparentGuid)
                    .HasColumnName("PnPParentGuid")
                    .HasMaxLength(40);

                entity.Property(e => e.PnPpromptForTemplate).HasColumnName("PnPPromptForTemplate");

                entity.Property(e => e.PnPrelativePath)
                    .HasColumnName("PnPRelativePath")
                    .HasMaxLength(512);

                entity.Property(e => e.PnPtemplateFile)
                    .HasColumnName("PnPTemplateFile")
                    .HasMaxLength(512);

                entity.Property(e => e.PnPtemplateFileRelative)
                    .HasColumnName("PnPTemplateFileRelative")
                    .HasMaxLength(512);

                entity.Property(e => e.PnPtemplateFileUnc)
                    .HasColumnName("PnPTemplateFileUnc")
                    .HasMaxLength(512);

                entity.Property(e => e.PnPtimestampGuid).HasColumnName("PnPTimestampGuid");

                entity.Property(e => e.PnPtype)
                    .HasColumnName("PnPType")
                    .HasMaxLength(40);

                entity.Property(e => e.PnPunc)
                    .HasColumnName("PnPUnc")
                    .HasMaxLength(512);

                entity.Property(e => e.Revision).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPindexColumns>(entity =>
            {
                entity.HasKey(e => new { e.IndexName, e.ColumnName });

                entity.ToTable("PnPIndexColumns");

                entity.Property(e => e.IndexName).HasMaxLength(255);

                entity.Property(e => e.ColumnName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPindexes>(entity =>
            {
                entity.HasKey(e => e.IndexName);

                entity.ToTable("PnPIndexes");

                entity.Property(e => e.IndexName)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsUnique).HasMaxLength(255);

                entity.Property(e => e.TableName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPpicklists>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPPicklists");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DisplayName).HasMaxLength(255);

                entity.Property(e => e.PicklistName).HasMaxLength(255);

                entity.Property(e => e.PicklistType).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPpicklistValues>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPPicklistValues");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PicklistValue).HasMaxLength(255);

                entity.Property(e => e.PicklistValueDescription).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPproject>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPProject");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientInformationCompanyName).HasColumnName("Client_Information_Company_Name");

                entity.Property(e => e.ClientInformationPrimaryContact).HasColumnName("Client_Information_Primary_Contact");

                entity.Property(e => e.ProjectDataAddress).HasColumnName("Project_Data_Address");

                entity.Property(e => e.ProjectDataCity).HasColumnName("Project_Data_City");

                entity.Property(e => e.ProjectDataProjectManager).HasColumnName("Project_Data_Project_Manager");

                entity.Property(e => e.ProjectDataState).HasColumnName("Project_Data_State");

                entity.Property(e => e.ProjectDataTelephone).HasColumnName("Project_Data_Telephone");

                entity.Property(e => e.ProjectDataZip).HasColumnName("Project_Data_Zip");

                entity.Property(e => e.ProjectDescription).HasColumnName("Project_Description");

                entity.Property(e => e.ProjectName).HasColumnName("Project_Name");

                entity.Property(e => e.ProjectNumber).HasColumnName("Project_Number");

                entity.Property(e => e.ProjectStandard).HasColumnName("Project_Standard");
            });

            modelBuilder.Entity<PnPprojectCategories>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPProjectCategories");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasMaxLength(255);

                entity.Property(e => e.DisplayName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPprojectVariables>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPProjectVariables");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Value).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPproperties>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.PropertyName });

                entity.ToTable("PnPProperties");

                entity.Property(e => e.TableName).HasMaxLength(255);

                entity.Property(e => e.PropertyName).HasMaxLength(255);

                entity.Property(e => e.CheckConstraint).HasMaxLength(255);

                entity.Property(e => e.DefaultValue).HasMaxLength(255);

                entity.Property(e => e.Expression).HasMaxLength(1024);

                entity.Property(e => e.IsCounter).HasMaxLength(16);

                entity.Property(e => e.IsExpression).HasMaxLength(16);

                entity.Property(e => e.IsObjectId).HasMaxLength(16);

                entity.Property(e => e.IsSystem).HasMaxLength(16);

                entity.Property(e => e.IsUnique).HasMaxLength(16);

                entity.Property(e => e.PropertyType).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPrelationshipProperties>(entity =>
            {
                entity.HasKey(e => new { e.RelationshipTypeName, e.PropertyName });

                entity.ToTable("PnPRelationshipProperties");

                entity.Property(e => e.RelationshipTypeName).HasMaxLength(255);

                entity.Property(e => e.PropertyName).HasMaxLength(255);

                entity.Property(e => e.PropertyType).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPrelationshipTypes>(entity =>
            {
                entity.HasKey(e => e.RelationshipTypeName);

                entity.ToTable("PnPRelationshipTypes");

                entity.Property(e => e.RelationshipTypeName)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.PhysicalName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnProleTypes>(entity =>
            {
                entity.HasKey(e => new { e.RelationshipTypeName, e.RoletypeName });

                entity.ToTable("PnPRoleTypes");

                entity.Property(e => e.RelationshipTypeName).HasMaxLength(255);

                entity.Property(e => e.RoletypeName).HasMaxLength(255);

                entity.Property(e => e.Cardinality).HasMaxLength(16);

                entity.Property(e => e.TableInRole).HasMaxLength(255);
            });

            modelBuilder.Entity<PnProwRelations>(entity =>
            {
                entity.HasKey(e => new { e.Rowid, e.Relid });

                entity.ToTable("PnPRowRelations");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.Relid).HasColumnName("RELID");

                entity.Property(e => e.RelationshipTypeName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPtableAttributes>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.AttributeName });

                entity.ToTable("PnPTableAttributes");

                entity.Property(e => e.TableName).HasMaxLength(255);

                entity.Property(e => e.AttributeName).HasMaxLength(255);

                entity.Property(e => e.AttributeType).HasMaxLength(255);

                entity.Property(e => e.AttributeValue).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPtables>(entity =>
            {
                entity.HasKey(e => e.TableName);

                entity.ToTable("PnPTables");

                entity.Property(e => e.TableName)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.Abstract).HasMaxLength(16);

                entity.Property(e => e.BaseTable).HasMaxLength(255);

                entity.Property(e => e.PhysicalName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPtagEnlistedColumns>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPTagEnlistedColumns");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColumnName).HasMaxLength(255);

                entity.Property(e => e.TableName).HasMaxLength(255);

                entity.Property(e => e.TagRegistyName).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPtagFormat>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPTagFormat");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassName).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Value).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPtagRegistries>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPTagRegistries");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPtagRegistry>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPTagRegistry");

                entity.HasIndex(e => e.RowId)
                    .HasName("PnPTagRegistry_RowId_UNQ")
                    .IsUnique();

                entity.HasIndex(e => e.Tag)
                    .HasName("PnPTagRegistry_Tag_UNQ")
                    .IsUnique();

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tag).HasMaxLength(255);
            });

            modelBuilder.Entity<PnPtombstone>(entity =>
            {
                entity.HasKey(e => e.PnPguid);

                entity.ToTable("PnPTombstone");

                entity.Property(e => e.PnPguid)
                    .HasColumnName("PnPGuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.PnPclassName)
                    .HasColumnName("PnPClassName")
                    .HasMaxLength(255);

                entity.Property(e => e.PnPtimestamp).HasColumnName("PnPTimestamp");
            });

            modelBuilder.Entity<PnPworkHistory>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PnPWorkHistory");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Author).HasMaxLength(255);

                entity.Property(e => e.DwgGuid).HasMaxLength(255);

                entity.Property(e => e.Enddate).HasMaxLength(255);

                entity.Property(e => e.HistoryGuid).HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.Startdate).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);
            });

            modelBuilder.Entity<Port>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndType).HasMaxLength(255);

                entity.Property(e => e.Facing).HasMaxLength(255);

                entity.Property(e => e.FlangeStd).HasMaxLength(255);

                entity.Property(e => e.GasketStd).HasMaxLength(255);

                entity.Property(e => e.LengthUnit).HasMaxLength(255);

                entity.Property(e => e.NominalUnit).HasMaxLength(255);

                entity.Property(e => e.PortName).HasMaxLength(255);

                entity.Property(e => e.PressureClass).HasMaxLength(255);

                entity.Property(e => e.Schedule).HasMaxLength(255);
            });

            modelBuilder.Entity<Prensa>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("PRENSA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Pump>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartSubType).HasMaxLength(255);
            });

            modelBuilder.Entity<QuadroPneumatico>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("QUADRO_PNEUMATICO");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Raspador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("RASPADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Recuperadora>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("RECUPERADORA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Reducer>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Secador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("SECADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Separador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("SEPARADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Silo>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("SILO");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<SingleBranchFitting>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<SlipOn>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Socketweld>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SteelStructure>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcquisitionProperties).HasMaxLength(512);

                entity.Property(e => e.Bos).HasColumnName("BOS");

                entity.Property(e => e.CogX).HasColumnName("COG X");

                entity.Property(e => e.CogY).HasColumnName("COG Y");

                entity.Property(e => e.CogZ).HasColumnName("COG Z");

                entity.Property(e => e.LengthUnit).HasMaxLength(255);

                entity.Property(e => e.PartSizeLongDesc).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.Tos).HasColumnName("TOS");

                entity.Property(e => e.WeightUnit).HasMaxLength(255);
            });

            modelBuilder.Entity<Strainer>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<StructureLadder>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cage).HasMaxLength(255);
            });

            modelBuilder.Entity<StructureMember>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColumnId)
                    .HasColumnName("ColumnID")
                    .HasMaxLength(255);

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.EndX).HasColumnName("End X");

                entity.Property(e => e.EndY).HasColumnName("End Y");

                entity.Property(e => e.EndZ).HasColumnName("End Z");

                entity.Property(e => e.LinearWeightUnit).HasMaxLength(255);

                entity.Property(e => e.MaterialStandard).HasMaxLength(255);

                entity.Property(e => e.Materialcode).HasMaxLength(255);

                entity.Property(e => e.Size).HasMaxLength(255);

                entity.Property(e => e.StartX).HasColumnName("Start X");

                entity.Property(e => e.StartY).HasColumnName("Start Y");

                entity.Property(e => e.StartZ).HasColumnName("Start Z");
            });

            modelBuilder.Entity<StructureRailing>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<StructureStair>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FromHeight).HasColumnName("From Height");

                entity.Property(e => e.ShapeSize)
                    .HasColumnName("Shape Size")
                    .HasMaxLength(255);

                entity.Property(e => e.StepSize)
                    .HasColumnName("Step Size")
                    .HasMaxLength(255);

                entity.Property(e => e.ToHeight).HasColumnName("To Height");
            });

            modelBuilder.Entity<StubEnd>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Support>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.LinearWeightUnit).HasMaxLength(255);

                entity.Property(e => e.PartSubType).HasMaxLength(255);

                entity.Property(e => e.Reference).HasMaxLength(255);

                entity.Property(e => e.SupportDetail).HasMaxLength(255);

                entity.Property(e => e.SupportType).HasMaxLength(255);
            });

            modelBuilder.Entity<Swage>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Tambor>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("TAMBOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Tank>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartSubType).HasMaxLength(255);
            });

            modelBuilder.Entity<Tanque>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("TANQUE");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TapWeld>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tee>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Thread>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Transportador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("TRANSPORTADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TrocadorDeCalor>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("TROCADOR_DE_CALOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Turbina>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("TURBINA");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Universal>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShopField)
                    .HasColumnName("Shop_Field")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Valve>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActuatorType).HasMaxLength(255);

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.EndConnections).HasMaxLength(255);

                entity.Property(e => e.Failure).HasMaxLength(255);

                entity.Property(e => e.Normally).HasMaxLength(255);

                entity.Property(e => e.Number).HasMaxLength(255);

                entity.Property(e => e.OperatorType).HasMaxLength(255);

                entity.Property(e => e.ValveAlignment).HasMaxLength(255);

                entity.Property(e => e.ValveBodyType).HasMaxLength(255);

                entity.Property(e => e.ValveCode).HasMaxLength(255);

                entity.Property(e => e.ValveDetail).HasMaxLength(255);
            });

            modelBuilder.Entity<Vaso>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("VASO");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Ventilador>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.ToTable("VENTILADOR");

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Vessel>(entity =>
            {
                entity.HasKey(e => e.PnPid);

                entity.Property(e => e.PnPid)
                    .HasColumnName("PnPID")
                    .ValueGeneratedNever();
            });
        }
    }
}
