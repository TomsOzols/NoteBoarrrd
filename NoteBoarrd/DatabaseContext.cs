using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBoarrd.Models;
using System.Data.Entity;

namespace NoteBoarrd
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BoardModel> Boards { get; set; }
        public DbSet<UserBoards> UserBoards { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
