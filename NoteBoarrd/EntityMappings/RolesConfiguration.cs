//using System;
//using System.Collections.Generic;
//using System.Data.Entity.ModelConfiguration;
//using System.Linq;
//using System.Web;
//using NoteBoarrd.Models;

//namespace NoteBoarrd.EntityMappings
//{
//    public class RolesConfiguration : EntityTypeConfiguration<>     //Dunno
//    {
//        public UserBoardsConfiguration(string schema = "dbo")
//        {
//            ToTable(schema + ".UserBoards");

//            HasKey(x => x.Id);

//            Property(x => x.Id).IsRequired();
//            Property(x => x.LastVisited);
//            Property(x => x.BoardId).IsRequired();
//            Property(x => x.UserId).IsRequired();

//            HasRequired(u => u.User).WithMany(r => r.UserBoards).HasForeignKey(u => u.UserId);
//            HasRequired(u => u.Board).WithMany(r => r.UserBoards).HasForeignKey(u => u.BoardId);
//        }
//    }
//}