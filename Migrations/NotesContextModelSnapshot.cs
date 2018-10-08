﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nerdable.NotesApi.NotesAppEntities;

namespace Nerdable.NotesApi.Migrations
{
    [DbContext(typeof(NotesAppContext))]
    partial class NotesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotesApp.Api.Entities.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int?>("CreatedByUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<bool>("Public");

                    b.Property<string>("Title");

                    b.HasKey("NoteId");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("NotesApp.Api.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title");

                    b.HasKey("TagId");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("NotesApp.Api.Entities.TagAlwaysIncludeRelationship", b =>
                {
                    b.Property<int>("AlwaysIncludeTagId");

                    b.Property<int>("ChildTagId");

                    b.HasKey("AlwaysIncludeTagId", "ChildTagId");

                    b.HasIndex("ChildTagId");

                    b.ToTable("TagAlwaysIncludeRelationships");
                });

            modelBuilder.Entity("NotesApp.Api.Entities.TagNoteRelationship", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("NoteId");

                    b.HasKey("TagId", "NoteId");

                    b.HasIndex("NoteId");

                    b.ToTable("TagNoteRelationships");
                });

            modelBuilder.Entity("NotesApp.Api.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Lastname");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NotesApp.Api.Entities.Note", b =>
                {
                    b.HasOne("NotesApp.Api.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");
                });

            modelBuilder.Entity("NotesApp.Api.Entities.Tag", b =>
                {
                    b.HasOne("NotesApp.Api.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");
                });

            modelBuilder.Entity("NotesApp.Api.Entities.TagAlwaysIncludeRelationship", b =>
                {
                    b.HasOne("NotesApp.Api.Entities.Tag", "AlwaysIncludeTag")
                        .WithMany("AlwaysIncludeTags")
                        .HasForeignKey("AlwaysIncludeTagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NotesApp.Api.Entities.Tag", "ChildTag")
                        .WithMany("ChildTags")
                        .HasForeignKey("ChildTagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NotesApp.Api.Entities.TagNoteRelationship", b =>
                {
                    b.HasOne("NotesApp.Api.Entities.Note", "Note")
                        .WithMany("Tags")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NotesApp.Api.Entities.Tag", "Tag")
                        .WithMany("Notes")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
