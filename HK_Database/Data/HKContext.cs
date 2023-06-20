using HK_Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HK_Database.Data
{
    public class HKContext:DbContext
    {
        public HKContext(DbContextOptions<HKContext> options):base(options) 
        { 

        }

        public DbSet<Member> Member { get; set; }
        public DbSet<Applications>Applications { get; set; }
        public DbSet<Chats> Chats { get; set; }
        public DbSet<Datas> Datas { get; set; }
        public DbSet<Embedding> Embedding { get; set; }
        public DbSet<QAHistory> QAHistory { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applications>(options =>
            {
                options.HasOne(m => m.Member).WithMany(m => m.Applications).HasForeignKey(m => m.MemberId).OnDelete(DeleteBehavior.Cascade);//刪掉後，相關聯的資料一併刪除
            });

            modelBuilder.Entity<Datas>(options =>
            {
                options.HasOne(a => a.Applications).WithMany(a => a.Datas).HasForeignKey(a => a.ApplicationId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Embedding>(options =>
            {
                options.HasOne(d => d.Datas).WithMany(d => d.Embedding).HasForeignKey(d => d.DataId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Users>(options =>
            {
                options.HasOne(a => a.Applications).WithMany(a => a.Users).HasForeignKey(a => a.ApplicationId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Chats>(options =>
            {
                options.HasOne(u => u.Users).WithMany(u => u.Chats).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<QAHistory>(options =>
            {
                options.HasOne(c => c.Chats).WithMany(c => c.QAHistory).HasForeignKey(c => c.ChatId).OnDelete(DeleteBehavior.Cascade);
            });

            //
            modelBuilder.Entity<Member>().HasData(
                new Member { MemberId = "C001", MemberName = "Althea", MemberEmail = "althea@gmail.com" , MemberPhone = "0912345678", MemberAccount = "althea", MemberPassword = "althea01", APIKey = "aa"},
                new Member { MemberId = "C002", MemberName = "Jimmy", MemberEmail = "jimmy@gmail.com", MemberPhone = "0944332211", MemberAccount = "jimmy", MemberPassword = "jimmy02" , APIKey = "aa" }
            );

            modelBuilder.Entity<Applications>().HasData(
                new Applications { ApplicationId = "A001", Model = "mm",MemberId = "C001"},
                new Applications { ApplicationId = "A002", Model = "mm",MemberId = "C002"}
            );

            modelBuilder.Entity<Datas>().HasData(
                new Datas { DataId = "D001", DataType = "dd" , DataPath = "dd", ApplicationId = "A001"},
                new Datas { DataId = "D002", DataType = "dd", DataPath = "dd" , ApplicationId = "A002" }
            );

            modelBuilder.Entity<Embedding>().HasData(
                new Embedding { Index="ii",EmbeddingQuestion="ee", EmbeddingAnswer = "ee",QA = "qq", EmbeddingVectors ="ee",DataId="D001"}

            );

            modelBuilder.Entity<Chats>().HasData(
                new Chats { ChatId = "C001",ChatData = new DateTime(2023/05/30), ChatName = "Gay",UserId="U001"}
            );

            modelBuilder.Entity<QAHistory>().HasData(
               new QAHistory { QAHistoryId = "Q001", QAHistoryQ = "qq", QAHistoryA = "qq" , QAHistoryVectors="qq",ChatId="C001"}
            );

            modelBuilder.Entity<Users>().HasData(
               new Users { UserId = "U001", UserName = "Candy", UserEmail = "candy@gmail.com", UserPhone = "0987654654" , UserAccount = "candy" , UserPassword = "candy03" ,ApplicationId="A001"}
            );
            
            base.OnModelCreating(modelBuilder);
        }


    }
}
