﻿// <auto-generated />
using System;
using Damselfly.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Damselfly.Core.Migrations
{
    [DbContext(typeof(ImageContext))]
    [Migration("20210507083555_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Damselfly.Core.Models.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("BasketId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Damselfly.Core.Models.BasketEntry", b =>
                {
                    b.Property<int>("BasketEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BasketId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.HasKey("BasketEntryId");

                    b.HasIndex("BasketId");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("ImageId", "BasketId")
                        .IsUnique();

                    b.ToTable("BasketEntries");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Camera", b =>
                {
                    b.Property<int>("CameraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Make")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Serial")
                        .HasColumnType("text");

                    b.HasKey("CameraId");

                    b.ToTable("Cameras");
                });

            modelBuilder.Entity("Damselfly.Core.Models.ConfigSetting", b =>
                {
                    b.Property<int>("ConfigSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("ConfigSettingId");

                    b.ToTable("ConfigSettings");
                });

            modelBuilder.Entity("Damselfly.Core.Models.ExifOperation", b =>
                {
                    b.Property<int>("ExifOperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<int>("Operation")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("ExifOperationId");

                    b.HasIndex("TimeStamp");

                    b.HasIndex("ImageId", "Text");

                    b.ToTable("KeywordOperations");
                });

            modelBuilder.Entity("Damselfly.Core.Models.ExportConfig", b =>
                {
                    b.Property<int>("ExportConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("WatermarkText")
                        .HasColumnType("text");

                    b.HasKey("ExportConfigId");

                    b.ToTable("DownloadConfigs");
                });

            modelBuilder.Entity("Damselfly.Core.Models.FTSTag", b =>
                {
                    b.Property<int>("FTSTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Keyword")
                        .HasColumnType("text");

                    b.HasKey("FTSTagId");

                    b.ToTable("FTSTags");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Folder", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("FolderScanDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ParentFolderId")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.HasKey("FolderId");

                    b.HasIndex("FolderScanDate");

                    b.HasIndex("Path");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("FileCreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FileLastModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<decimal>("FileSizeBytes")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("FolderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("SortDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ImageId");

                    b.HasIndex("FileLastModDate");

                    b.HasIndex("FileName");

                    b.HasIndex("FolderId");

                    b.HasIndex("LastUpdated");

                    b.HasIndex("SortDate");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Damselfly.Core.Models.ImageMetaData", b =>
                {
                    b.Property<int>("MetaDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CameraId")
                        .HasColumnType("integer");

                    b.Property<string>("Caption")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTaken")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Exposure")
                        .HasColumnType("text");

                    b.Property<string>("FNum")
                        .HasColumnType("text");

                    b.Property<bool>("FlashFired")
                        .HasColumnType("boolean");

                    b.Property<string>("Hash")
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("ISO")
                        .HasColumnType("text");

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("LensId")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ThumbLastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("MetaDataId");

                    b.HasIndex("CameraId");

                    b.HasIndex("DateTaken");

                    b.HasIndex("Hash");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("LensId");

                    b.HasIndex("ThumbLastUpdated");

                    b.ToTable("ImageMetaData");
                });

            modelBuilder.Entity("Damselfly.Core.Models.ImageTag", b =>
                {
                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("ImageId", "TagId");

                    b.HasIndex("TagId");

                    b.HasIndex("ImageId", "TagId")
                        .IsUnique();

                    b.ToTable("ImageTags");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Lens", b =>
                {
                    b.Property<int>("LensId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Make")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Serial")
                        .HasColumnType("text");

                    b.HasKey("LensId");

                    b.ToTable("Lenses");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Favourite")
                        .HasColumnType("boolean");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.HasIndex("Keyword")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Damselfly.Core.Models.BasketEntry", b =>
                {
                    b.HasOne("Damselfly.Core.Models.Basket", "Basket")
                        .WithMany("BasketEntries")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Damselfly.Core.Models.Image", "Image")
                        .WithOne("BasketEntry")
                        .HasForeignKey("Damselfly.Core.Models.BasketEntry", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Damselfly.Core.Models.ExifOperation", b =>
                {
                    b.HasOne("Damselfly.Core.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Image", b =>
                {
                    b.HasOne("Damselfly.Core.Models.Folder", "Folder")
                        .WithMany("Images")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("Damselfly.Core.Models.ImageMetaData", b =>
                {
                    b.HasOne("Damselfly.Core.Models.Camera", "Camera")
                        .WithMany()
                        .HasForeignKey("CameraId");

                    b.HasOne("Damselfly.Core.Models.Image", "Image")
                        .WithOne("MetaData")
                        .HasForeignKey("Damselfly.Core.Models.ImageMetaData", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Damselfly.Core.Models.Lens", "Lens")
                        .WithMany()
                        .HasForeignKey("LensId");

                    b.Navigation("Camera");

                    b.Navigation("Image");

                    b.Navigation("Lens");
                });

            modelBuilder.Entity("Damselfly.Core.Models.ImageTag", b =>
                {
                    b.HasOne("Damselfly.Core.Models.Image", "Image")
                        .WithMany("ImageTags")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Damselfly.Core.Models.Tag", "Tag")
                        .WithMany("ImageTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Basket", b =>
                {
                    b.Navigation("BasketEntries");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Folder", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Image", b =>
                {
                    b.Navigation("BasketEntry");

                    b.Navigation("ImageTags");

                    b.Navigation("MetaData");
                });

            modelBuilder.Entity("Damselfly.Core.Models.Tag", b =>
                {
                    b.Navigation("ImageTags");
                });
#pragma warning restore 612, 618
        }
    }
}
