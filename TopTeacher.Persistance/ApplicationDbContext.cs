using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Entites;
using TopTeacher.Entites.ExamsModel;
using TopTeacher.Entites.MaterialsModel;
using TopTeacher.Entites.NotificationsModel;

namespace TopTeacher.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Material>().HasKey(x => x.MaterialId);
            builder.Entity<AcademicYear>().HasKey(x => x.AcademicYearId);
            builder.Entity<TypeOfMaterial>().HasKey(x => x.TypeOfMaterialId);
            builder.Entity<Exam>().HasKey(x => x.ExamId);
            // Choose
            builder.Entity<ChooseQuestion>().HasKey(x => x.ChooseQuestionId);
            builder.Entity<Exam>().HasMany<ExamAndChooseQuestion>().WithOne()
                .HasPrincipalKey(x => x.ExamId).HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ChooseQuestion>().HasMany<ExamAndChooseQuestion>().WithOne()
                .HasPrincipalKey(x => x.ChooseQuestionId).HasForeignKey(x => x.ChooseQuestionId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // True & False

            builder.Entity<TrueAndFalseQuestion>().HasKey(x => x.TrueAndFalseQuestionId);
            builder.Entity<Exam>().HasMany<ExamAndTFQuestion>().WithOne()
               .HasPrincipalKey(x => x.ExamId).HasForeignKey(x => x.ExamId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TrueAndFalseQuestion>().HasMany<ExamAndTFQuestion>().WithOne()
                .HasPrincipalKey(x => x.TrueAndFalseQuestionId).HasForeignKey(x => x.TrueAndFalseQuestionId)
                .OnDelete(DeleteBehavior.Restrict);


            // Pk composet
            builder.Entity<ExamAndChooseQuestion>().HasKey(x => new {x.ExamId,x.ChooseQuestionId});
            builder.Entity<ExamAndTFQuestion>().HasKey(x => new { x.ExamId, x.TrueAndFalseQuestionId });
            // builder.Entity<AcademicYears>().Ignore(x=>x.AcademicYearId);
        }


        public DbSet<AcademicYear> academicYears { get; set; }
        public DbSet<Material> materials { get; set; }
        public DbSet<TypeOfMaterial> typesOfMaterials { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Exam> exams { get; set; }
        public DbSet<ChooseQuestion> chooseQuestions { get; set; }
        public DbSet<TrueAndFalseQuestion> trueAndFalseQuestions { get; set; }
    }
}
