using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using NoteBoarrd.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBoarrd.EntityMappings
{
    public class BoardModelConfiguration : EntityTypeConfiguration<BoardModel>
    {
        public BoardModelConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".BoardModels");

            HasKey(x => x.Id);

            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsRequired();
            Property(x => x.Password).IsOptional();
            Property(x => x.Created).IsRequired();
            Property(x => x.LastChanged).IsRequired();
            Property(x => x.IsPrivate).IsRequired();
            Property(x => x.CreatedBy_Id).IsRequired();

            HasRequired(x => x.CreatedBy).WithMany(u => u.MyBoards).HasForeignKey(x => x.CreatedBy_Id).WillCascadeOnDelete(false);
        }
    }
}