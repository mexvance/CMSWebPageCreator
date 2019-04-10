﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSWebPageCreator.Migrations
{
    public partial class CMSMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyInfo",
                columns: table => new
                {
                    BodyItem = table.Column<Guid>(nullable: false),
                    PageCreateParentId = table.Column<Guid>(nullable: false),
                    BodyContent = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyInfo", x => x.BodyItem);
                });

            migrationBuilder.CreateTable(
                name: "FooterInfo",
                columns: table => new
                {
                    FooterItem = table.Column<Guid>(nullable: false),
                    PageCreateParentId = table.Column<Guid>(nullable: false),
                    FooterContent = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterInfo", x => x.FooterItem);
                });

            migrationBuilder.CreateTable(
                name: "HeaderInfo",
                columns: table => new
                {
                    HeaderItem = table.Column<Guid>(nullable: false),
                    PageCreateParentId = table.Column<Guid>(nullable: false),
                    HeaderContent = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderInfo", x => x.HeaderItem);
                });

            migrationBuilder.CreateTable(
                name: "PageCreate",
                columns: table => new
                {
                    pageId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    MyHeaderHeaderItem = table.Column<Guid>(nullable: true),
                    MyBodyBodyItem = table.Column<Guid>(nullable: true),
                    MyFooterFooterItem = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageCreate", x => x.pageId);
                    table.ForeignKey(
                        name: "FK_PageCreate_BodyInfo_MyBodyBodyItem",
                        column: x => x.MyBodyBodyItem,
                        principalTable: "BodyInfo",
                        principalColumn: "BodyItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageCreate_FooterInfo_MyFooterFooterItem",
                        column: x => x.MyFooterFooterItem,
                        principalTable: "FooterInfo",
                        principalColumn: "FooterItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageCreate_HeaderInfo_MyHeaderHeaderItem",
                        column: x => x.MyHeaderHeaderItem,
                        principalTable: "HeaderInfo",
                        principalColumn: "HeaderItem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageCreate_MyBodyBodyItem",
                table: "PageCreate",
                column: "MyBodyBodyItem");

            migrationBuilder.CreateIndex(
                name: "IX_PageCreate_MyFooterFooterItem",
                table: "PageCreate",
                column: "MyFooterFooterItem");

            migrationBuilder.CreateIndex(
                name: "IX_PageCreate_MyHeaderHeaderItem",
                table: "PageCreate",
                column: "MyHeaderHeaderItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageCreate");

            migrationBuilder.DropTable(
                name: "BodyInfo");

            migrationBuilder.DropTable(
                name: "FooterInfo");

            migrationBuilder.DropTable(
                name: "HeaderInfo");
        }
    }
}
