using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<TitleM> TitleMs { get; set; }
        public DbSet<StatusU> StatusUs { get; set; }
        public DbSet<Sex> Sexs { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Workhistory> WorkHistories { get; set; }
        public DbSet<Arrest> Arrests { get; set; }
        public DbSet<FatherAndMother> FatherAndMothers { get; set; }
        public DbSet<Marriage> Marriages { get; set; }
        public DbSet<Child> Childrens { get; set; }
        public DbSet<StatusA> StatusAs { get; set; }
        public DbSet<Address> Addresss { get; set; }

        internal Task ToListAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<Travel> Travels { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TypeS> TypeS { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Managementposition> Managementpositions { get; set; }
        public DbSet<Academicposition> Academicpositions { get; set; }
        public DbSet<Insignia> Insignias { get; set; }
        public DbSet<Petition> Petitions { get; set; }
        public DbSet<StatusM> StatusMs { get; set; }
        public DbSet<StatusPC> StatusPCs { get; set; }
        public DbSet<ReportLeave> ReportLeaves { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Title>().HasData(
                new Title { Id = 1, Title_name = "เด็กชาย" },
                new Title { Id = 2, Title_name = "เด็กหญิง" },
                new Title { Id = 3, Title_name = "นาย" },
                new Title { Id = 4, Title_name = "นาง" },
                new Title { Id = 5, Title_name = "นางสาว" }
                );
            builder.Entity<TitleM>().HasData(
                new TitleM { Id = 1, Title = "นาง" },
                new TitleM { Id = 2, Title = "นางสาว" }
               
                );
            builder.Entity<Sex>().HasData(
                new Sex { Id = 1, Sex_name = "ชาย" },
                new Sex { Id = 2, Sex_name = "หญิง" }
                );
            builder.Entity<Level>().HasData(
                new Level { Id = 1, Level_name = "ประถมศึกษา 6" },
                new Level { Id = 2, Level_name = "มัธยมศึกษา 3" },
                new Level { Id = 3, Level_name = "มัธยมศึกษา 6" },
                new Level { Id = 4, Level_name = "ปริญญาตรี" },
                new Level { Id = 5, Level_name = "ปริญญาโทร" },
                new Level { Id = 6, Level_name = "ปริญญาเอก" }
                );
            builder.Entity<StatusPC>().HasData(
               new StatusPC { Id = 1, statusPC_name = "ครั้งก่อน" },
               new StatusPC { Id = 2, statusPC_name = "ปัจจุบัน" }
               );
            builder.Entity<StatusU>().HasData(
                new StatusU { Id = 1, StatusU_name = "ข้าราชการ" },
                new StatusU { Id = 2, StatusU_name = "พนักงานข้าราชการ" },
                new StatusU { Id = 3, StatusU_name = "เจ้าหน้าที่" }
                );
            builder.Entity<StatusA>().HasData(
                new StatusA { Id = 1, Name = "เคยอาศัย" },
                new StatusA { Id = 2, Name = "อาศัยในปัจจุบัน" }
                );
            builder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "ครั้งก่อน" },
                new Status { Id = 2, Name = "ปัจจุบัน" }
                );
            builder.Entity<TypeS>().HasData(
                new TypeS { Id = 1, Name = "เลื่อนขั้นเงินเดือนปกติ" },
                new TypeS { Id = 2, Name = "เลื่อนขั้นเงินเดือนพิเศษ" }
                );
            base.OnModelCreating(builder);
            builder.Entity<Petition>().HasOne(a => a.Author).WithMany(a => a.Petitions).OnDelete(DeleteBehavior.Cascade);

        }



    }
}
