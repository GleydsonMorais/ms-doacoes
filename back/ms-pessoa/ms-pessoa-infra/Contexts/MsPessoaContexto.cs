using Microsoft.EntityFrameworkCore;
using ms_pessoa_infra.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ms_pessoa_infra.Contexts
{
    public class MsPessoaContexto : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }

        public MsPessoaContexto(DbContextOptions<MsPessoaContexto> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Pessoa
            modelBuilder.Entity<Pessoa>(i =>
            {
                i.ToTable("pessoa");
                i.HasKey(x => x.CPF);

                i.Property(x => x.CPF).HasMaxLength(11); 
                i.Property(x => x.Nome).HasMaxLength(250).IsRequired();                
                i.Property(x => x.Senha).HasMaxLength(50).IsRequired();
                i.Property(x => x.Email).HasMaxLength(150).IsRequired();
                i.Property(x => x.DtaInclusao).IsRequired();
                i.Property(x => x.DtaAlteracao);
            });
            #endregion
        }
    }
}
