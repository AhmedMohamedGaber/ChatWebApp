using Chat.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Contexts
{
    public class ChattingDbContext : DbContext
    {
        public ChattingDbContext(DbContextOptions<ChattingDbContext> options) : base(options)
        {
        }

        public ChattingDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=Chat; integrated security=true;");
        }

        public DbSet<Message> Messages { get; set; }
    }
}
