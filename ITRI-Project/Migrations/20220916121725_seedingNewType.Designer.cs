﻿// <auto-generated />
using System;
using ITRI_Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITRI_Project.Migrations
{
    [DbContext(typeof(ITRIContext))]
    [Migration("20220916121725_seedingNewType")]
    partial class seedingNewType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ITRI_Project.Model.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Contact")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Message")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TitleEN")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("TriggerDistance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Map");
                });

            modelBuilder.Entity("ITRI_Project.Model.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("hasFixedRep")
                        .HasColumnType("bit");

                    b.Property<string>("hints")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isGenerate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("key")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("nodeID")
                        .HasColumnType("int");

                    b.Property<int>("orderID")
                        .HasColumnType("int");

                    b.Property<string>("question")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("questionAudio")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("response")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("'[]'");

                    b.Property<string>("responseAudio")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasDefaultValueSql("'[]'");

                    b.Property<string>("scriptParameter")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("type")
                        .HasColumnType("tinyint");

                    b.Property<string>("variableKey")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasDefaultValueSql("'[]'");

                    b.HasKey("Id");

                    b.ToTable("Nodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            hasFixedRep = true,
                            isGenerate = false,
                            key = "n99-1",
                            nodeID = 99,
                            orderID = 1,
                            question = "測試問題01",
                            scriptParameter = "{\"AutoNext\":true}",
                            type = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            hasFixedRep = true,
                            isGenerate = false,
                            key = "n99-2",
                            nodeID = 99,
                            orderID = 2,
                            question = "測試選項",
                            response = "['回覆01', '回覆02', '回覆03']",
                            scriptParameter = "{\"Options\":[\"選項01\",\"選項02\",\"選項03\"]}",
                            type = (byte)2
                        },
                        new
                        {
                            Id = 3,
                            hasFixedRep = true,
                            isGenerate = false,
                            key = "n99-3",
                            nodeID = 99,
                            orderID = 3,
                            question = "測試文字輸入{0}",
                            type = (byte)3,
                            variableKey = "['n1-2']"
                        },
                        new
                        {
                            Id = 4,
                            hasFixedRep = true,
                            isGenerate = false,
                            key = "n99-4",
                            nodeID = 99,
                            orderID = 4,
                            question = "測試多文字輸入",
                            response = "['測試回覆']",
                            scriptParameter = "{\"Field\":[{\"key\":\"n99-4_A\",\"placeholder\":\"測試01\"},{\"key\":\"n99-4_B\",\"placeholder\":\"測試02\"},{\"key\":\"n99-4_C\",\"placeholder\":\"測試03\"},{\"key\":\"n99-4_D\",\"placeholder\":\"測試04\"},{\"key\":\"n99-4_E\",\"placeholder\":\"測試05\"}]}",
                            type = (byte)4
                        },
                        new
                        {
                            Id = 5,
                            hasFixedRep = false,
                            isGenerate = false,
                            key = "n99-5",
                            nodeID = 99,
                            orderID = 5,
                            question = "測試錄音",
                            type = (byte)5
                        },
                        new
                        {
                            Id = 6,
                            hasFixedRep = true,
                            isGenerate = false,
                            key = "n99-6",
                            nodeID = 99,
                            orderID = 6,
                            question = "測試評分",
                            response = "['測試回覆']",
                            scriptParameter = "{\"RatingScore\":[{\"Value\":0.2,\"Message\":\"階段01\"},{\"Value\":0.4,\"Message\":\"階段02\"},{\"Value\":0.6,\"Message\":\"階段03\"},{\"Value\":0.8,\"Message\":\"階段04\"},{\"Value\":1,\"Message\":\"階段05\"}],\"Tips\":[{\"Value\":0.33,\"Message\":\"提示01\"},{\"Value\":0.66,\"Message\":\"提示02\"},{\"Value\":1,\"Message\":\"提示03\"}]}",
                            type = (byte)6
                        },
                        new
                        {
                            Id = 7,
                            hasFixedRep = true,
                            isGenerate = false,
                            key = "n99-7",
                            nodeID = 99,
                            orderID = 7,
                            question = "測試資訊",
                            response = "['回覆01','回覆02','回覆03','回覆04']",
                            scriptParameter = "{\"Options\":[\"選項01\",\"選項02\",\"選項03\",\"選項04\"]}",
                            type = (byte)7
                        },
                        new
                        {
                            Id = 9,
                            hasFixedRep = true,
                            isGenerate = false,
                            key = "n99-8",
                            nodeID = 99,
                            orderID = 8,
                            question = "測試影片播放",
                            response = "[]",
                            type = (byte)8
                        },
                        new
                        {
                            Id = 10,
                            hasFixedRep = true,
                            isGenerate = false,
                            key = "n99-9",
                            nodeID = 99,
                            orderID = 9,
                            question = "測試音檔播放",
                            questionAudio = "",
                            response = "[]",
                            type = (byte)9
                        });
                });

            modelBuilder.Entity("ITRI_Project.Model.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<string>("Value")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("ITRI_Project.Model.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("NowMapType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

                    b.Property<string>("PassNode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("'[]'");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Zodiac")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.ToTable("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
