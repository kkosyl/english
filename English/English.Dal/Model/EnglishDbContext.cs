using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal.Model
{
    public class EnglishDbContext : DbContext
    {
        public EnglishDbContext()
            : base("name=EnglishDbContext")
        {
            Database.SetInitializer(new EnglishDbInitializer());
        }

        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<ExerciseType> ExerciseTypes { get; set; }
        public virtual DbSet<Introduction> Introductions { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostReply> PostReplies { get; set; }
        public virtual DbSet<PostReplyUserVote> PostReplyUserVotes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserExercise> UserExercises { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasRequired(p => p.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostReply>()
                .HasRequired(p => p.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostReplyUserVote>()
                .HasRequired(p => p.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

    public class EnglishDbInitializer : CreateDatabaseIfNotExists<EnglishDbContext>
    {
        protected override void Seed(EnglishDbContext context)
        {
            base.Seed(context);
        }
    }
}
