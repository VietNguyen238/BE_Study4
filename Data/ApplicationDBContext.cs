using be_study4.Models;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Advise> Advises { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ExamSection> ExamSections { get; set; }
        public DbSet<ExamTopic> ExamTopics { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}