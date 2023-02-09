using Microsoft.EntityFrameworkCore;
using ITRI_Project.Model;
using ITRI_Project.Data;
using System.Text.Json;
using System.Text.Unicode;

namespace ITRI_Project.Model
{
    public class ITRIContext : DbContext
    {
        public ITRIContext() { }
        public ITRIContext(DbContextOptions<ITRIContext> options) : base(options) { }

        public DbSet<Record> Records { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Map> Map { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Finish> Finish { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Map>()
                .Property(b => b.TriggerDistance)
                .HasDefaultValue(10.0f);

            modelBuilder.Entity<UserInfo>()
                .Property(b => b.NowMapType)
                .HasDefaultValue(1);

            modelBuilder.Entity<UserInfo>()
                .Property(b => b.PassNode)
                .HasDefaultValueSql("'[]'");

            modelBuilder.Entity<Record>()
                .Property(b => b.CreateTime)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Node>()
                .Property(b => b.response)
                .HasDefaultValueSql("'[]'");

            modelBuilder.Entity<Node>()
                .Property(b => b.isGenerate)
                .HasDefaultValue(false);

            modelBuilder.Entity<Node>()
                .Property(b => b.responseAudio)
                .HasDefaultValueSql("'[]'");

            modelBuilder.Entity<Node>()
               .Property(b => b.variableKey)
               .HasDefaultValueSql("'[]'");

            modelBuilder.Entity<Finish>()
                .Property(b => b.CreateTime)
                .HasDefaultValueSql("getdate()");
            //SeedingTestNode(ref modelBuilder);
        }

        private void SeedingTestNode(ref ModelBuilder modelBuilder)
        {
            JsonSerializerOptions jsonOpt = new JsonSerializerOptions();
            jsonOpt.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All);

            //Type 01
            SDisplaySetting displayParam = new SDisplaySetting();
            modelBuilder.Entity<Node>().HasData(
                new Node
                {
                    Id = 1,
                    nodeID = 99,
                    orderID = 1,
                    key = "n99-1",
                    type = (byte)ConstParameter.ScriptType.eDisplay,
                    question = "測試問題01",
                    hasFixedRep = true,
                    scriptParameter = JsonSerializer.Serialize(displayParam, jsonOpt)
                });

            //Type 02
            SMultiOption optionParam = new SMultiOption();
            optionParam.Options.Add("選項01");
            optionParam.Options.Add("選項02");
            optionParam.Options.Add("選項03");
            modelBuilder.Entity<Node>().HasData(
                new Node
                {
                    Id = 2,
                    nodeID = 99,
                    orderID = 2,
                    key = "n99-2",
                    type = (byte)ConstParameter.ScriptType.eOption,
                    question = "測試選項",
                    hasFixedRep = true,
                    response = "['回覆01', '回覆02', '回覆03']",
                    scriptParameter = JsonSerializer.Serialize(optionParam, jsonOpt)
                });

            //Type 03
            modelBuilder.Entity<Node>().HasData(
                new Node
                {
                    Id = 3,
                    nodeID = 99,
                    orderID = 3,
                    key = "n99-3",
                    type = (byte)ConstParameter.ScriptType.eText,
                    question = "測試文字輸入{0}",
                    hasFixedRep = true,
                    variableKey = "['n1-2']",
                });

            //Type 04
            SMultiTextInput multiInputParam = new SMultiTextInput();
            multiInputParam.Field.Add(new MultiTextUnit("n99-4_A", "測試01"));
            multiInputParam.Field.Add(new MultiTextUnit("n99-4_B", "測試02"));
            multiInputParam.Field.Add(new MultiTextUnit("n99-4_C", "測試03"));
            multiInputParam.Field.Add(new MultiTextUnit("n99-4_D", "測試04"));
            multiInputParam.Field.Add(new MultiTextUnit("n99-4_E", "測試05"));
            modelBuilder.Entity<Node>().HasData(
                new Node
                {
                    Id = 4,
                    nodeID = 99,
                    orderID = 4,
                    key = "n99-4",
                    type = (byte)ConstParameter.ScriptType.eMultiText,
                    question = "測試多文字輸入",
                    hasFixedRep = true,
                    response = "['測試回覆']",
                    scriptParameter = JsonSerializer.Serialize(multiInputParam, jsonOpt)
                });

            //Type 05
            modelBuilder.Entity<Node>().HasData(
                new Node
                {
                    Id = 5,
                    nodeID = 99,
                    orderID = 5,
                    key = "n99-5",
                    type = (byte)ConstParameter.ScriptType.eRecode,
                    question = "測試錄音",
                    hasFixedRep = false,
                });

            //Type 06
            SRatingScale ratingParam = new SRatingScale();
            ratingParam.RatingScore.Add(new RatingUnit(0.2f, "階段01"));
            ratingParam.RatingScore.Add(new RatingUnit(0.4f, "階段02"));
            ratingParam.RatingScore.Add(new RatingUnit(0.6f, "階段03"));
            ratingParam.RatingScore.Add(new RatingUnit(0.8f, "階段04"));
            ratingParam.RatingScore.Add(new RatingUnit(1.0f, "階段05"));
            ratingParam.Tips.Add(new RatingUnit(0.33f, "提示01"));
            ratingParam.Tips.Add(new RatingUnit(0.66f, "提示02"));
            ratingParam.Tips.Add(new RatingUnit(1.00f, "提示03"));

            modelBuilder.Entity<Node>().HasData(
                new Node
                {
                    Id = 6,
                    nodeID = 99,
                    orderID = 6,
                    key = "n99-6",
                    type = (byte)ConstParameter.ScriptType.eRating,
                    question = "測試評分",
                    hasFixedRep = true,
                    response = "['測試回覆']",
                    scriptParameter = JsonSerializer.Serialize(ratingParam, jsonOpt)
                });

            //Type 07
            SInfoCheckParam infoParam = new SInfoCheckParam();
            infoParam.Options.Add("選項01");
            infoParam.Options.Add("選項02");
            infoParam.Options.Add("選項03");
            infoParam.Options.Add("選項04");

            modelBuilder.Entity<Node>().HasData(
               new Node
               {
                   Id = 7,
                   nodeID = 99,
                   orderID = 7,
                   key = "n99-7",
                   type = (byte)ConstParameter.ScriptType.eInfo,
                   question = "測試資訊",
                   hasFixedRep = true,
                   response = "['回覆01','回覆02','回覆03','回覆04']",
                   scriptParameter = JsonSerializer.Serialize(infoParam, jsonOpt)
               });

            //Type 08
            modelBuilder.Entity<Node>().HasData(
               new Node
               {
                   Id = 9,
                   nodeID = 99,
                   orderID = 8,
                   key = "n99-8",
                   type = (byte)ConstParameter.ScriptType.eLongVideo,
                   question = "測試影片播放",
                   hasFixedRep = true,
                   response = "[]"
               });

            //Type 09
            modelBuilder.Entity<Node>().HasData(
               new Node
               {
                   Id = 10,
                   nodeID = 99,
                   orderID = 9,
                   key = "n99-9",
                   type = (byte)ConstParameter.ScriptType.eAudioPlay,
                   question = "測試音檔播放",
                   questionAudio = "",
                   hasFixedRep = true,
                   response = "[]"
               });
        }
    }
}
