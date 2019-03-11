using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPMedGroup.Domains
{
    public partial class SPMedGroupContext : DbContext
    {
        public SPMedGroupContext()
        {
        }

        public SPMedGroupContext(DbContextOptions<SPMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<ProntuarioPaciente> ProntuarioPaciente { get; set; }
        public virtual DbSet<TipoSituacoes> TipoSituacoes { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=SENAI_SPMEDGROUP;User id=sa;Password=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.ToTable("CLINICA");

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__CLINICA__AA57D6B4C01576BC")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial)
                    .HasName("UQ__CLINICA__10D918D9317E17E2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("RAZAO_SOCIAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.ToTable("CONSULTAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataConsulta)
                    .HasColumnName("DATA_CONSULTA")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdMedico).HasColumnName("ID_MEDICO");

                entity.Property(e => e.IdProntuario).HasColumnName("ID_PRONTUARIO");

                entity.Property(e => e.IdTipoSituacao).HasColumnName("ID_TIPO_SITUACAO");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONSULTAS__ID_ME__7C4F7684");

                entity.HasOne(d => d.IdProntuarioNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdProntuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONSULTAS__ID_PR__7B5B524B");

                entity.HasOne(d => d.IdTipoSituacaoNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdTipoSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONSULTAS__ID_TI__7D439ABD");
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.ToTable("ESPECIALIDADES");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__ESPECIAL__E2AB1FF4D35590C6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.ToTable("MEDICOS");

                entity.HasIndex(e => e.Crm)
                    .HasName("UQ__MEDICOS__C1F887FFD5C6AE59")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasColumnName("CRM")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdClinica).HasColumnName("ID_CLINICA");

                entity.Property(e => e.IdEspecialidade).HasColumnName("ID_ESPECIALIDADE");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__MEDICOS__ID_CLIN__02084FDA");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__MEDICOS__ID_ESPE__5441852A");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__MEDICOS__ID_USUA__01142BA1");
            });

            modelBuilder.Entity<ProntuarioPaciente>(entity =>
            {
                entity.ToTable("PRONTUARIO_PACIENTE");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__PRONTUAR__C1F89731C63D711A")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("UQ__PRONTUAR__91136B913CCFCF7A")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__PRONTUAR__321537C85AFC0CA2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.ProntuarioPaciente)
                    .HasForeignKey<ProntuarioPaciente>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRONTUARI__ID_US__787EE5A0");
            });

            modelBuilder.Entity<TipoSituacoes>(entity =>
            {
                entity.ToTable("TIPO_SITUACOES");

                entity.HasIndex(e => e.Situacao)
                    .HasName("UQ__TIPO_SIT__4E84C4A25322C150")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasColumnName("SITUACAO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.ToTable("TIPO_USUARIOS");

                entity.HasIndex(e => e.TipoUsuario)
                    .HasName("UQ__TIPO_USU__D13E583B770ED08A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("TIPO_USUARIO")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724F8AF69F9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__6EF57B66");
            });
        }
    }
}
