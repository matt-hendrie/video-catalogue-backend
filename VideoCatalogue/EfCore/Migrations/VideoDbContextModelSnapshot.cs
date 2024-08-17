﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoCatalogue.EfCore;

#nullable disable

namespace VideoCatalogue.EfCore.Migrations
{
    [DbContext(typeof(VideoDbContext))]
    partial class VideoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("VideoCatalogue.Models.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("VideoCatalogue.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VideoId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("VideoCatalogue.Models.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("Runtime")
                        .HasColumnType("REAL");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UploadDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.ToTable("VideoData");
                });

            modelBuilder.Entity("VideoCatalogue.Models.Tag", b =>
                {
                    b.HasOne("VideoCatalogue.Models.Video", null)
                        .WithMany("Tags")
                        .HasForeignKey("VideoId");
                });

            modelBuilder.Entity("VideoCatalogue.Models.Video", b =>
                {
                    b.HasOne("VideoCatalogue.Models.Channel", "Channel")
                        .WithMany("Videos")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");
                });

            modelBuilder.Entity("VideoCatalogue.Models.Channel", b =>
                {
                    b.Navigation("Videos");
                });

            modelBuilder.Entity("VideoCatalogue.Models.Video", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
