﻿// <auto-generated />
using System;
using CMSWebPageCreator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMSWebPageCreator.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20190418045152_cmstry2")]
    partial class cmstry2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("CMSWebPageCreator.Models.BodyInfo", b =>
                {
                    b.Property<Guid>("BodyItem")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BodyContent");

                    b.Property<int>("ContentType");

                    b.Property<Guid>("PageCreateParentId");

                    b.HasKey("BodyItem");

                    b.ToTable("BodyInfo");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.FooterInfo", b =>
                {
                    b.Property<Guid>("FooterItem")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContentType");

                    b.Property<string>("FooterContent");

                    b.Property<Guid>("PageCreateParentId");

                    b.HasKey("FooterItem");

                    b.ToTable("FooterInfo");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.HeaderInfo", b =>
                {
                    b.Property<Guid>("HeaderItem")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContentType");

                    b.Property<string>("HeaderContent");

                    b.Property<Guid>("PageCreateParentId");

                    b.HasKey("HeaderItem");

                    b.ToTable("HeaderInfo");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.PageCreate", b =>
                {
                    b.Property<Guid>("pageId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MyBodyBodyItem");

                    b.Property<Guid?>("MyFooterFooterItem");

                    b.Property<Guid?>("MyHeaderHeaderItem");

                    b.Property<string>("Title");

                    b.HasKey("pageId");

                    b.HasIndex("MyBodyBodyItem");

                    b.HasIndex("MyFooterFooterItem");

                    b.HasIndex("MyHeaderHeaderItem");

                    b.ToTable("PageCreate");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.PageCreate", b =>
                {
                    b.HasOne("CMSWebPageCreator.Models.BodyInfo", "MyBody")
                        .WithMany()
                        .HasForeignKey("MyBodyBodyItem");

                    b.HasOne("CMSWebPageCreator.Models.FooterInfo", "MyFooter")
                        .WithMany()
                        .HasForeignKey("MyFooterFooterItem");

                    b.HasOne("CMSWebPageCreator.Models.HeaderInfo", "MyHeader")
                        .WithMany()
                        .HasForeignKey("MyHeaderHeaderItem");
                });
#pragma warning restore 612, 618
        }
    }
}
