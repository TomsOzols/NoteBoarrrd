using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBoarrd.Models;
using System.Data.Entity;
using NoteBoarrd.EntityMappings;

namespace NoteBoarrd
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BoardModel> Boards { get; set; }
        public DbSet<UserBoards> UserBoards { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<Culture> Cultures { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BoardModelConfiguration());
            modelBuilder.Configurations.Add(new UserBoardsConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new NoteModelConfiguration());
            modelBuilder.Configurations.Add(new CommentModelConfiguration());
        }
    }
}
