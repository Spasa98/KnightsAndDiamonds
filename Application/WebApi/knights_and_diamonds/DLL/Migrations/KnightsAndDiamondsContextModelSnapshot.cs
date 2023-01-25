﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(KnightsAndDiamondsContext))]
    partial class KnightsAndDiamondsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Models.Card", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AttackPoints")
                        .HasColumnType("int");

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DefencePoints")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElementType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonsterType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfStars")
                        .HasColumnType("int");

                    b.Property<int?>("UserHandID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserHandID");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("DAL.Models.CardInDeck", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int?>("DeckID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardId");

                    b.HasIndex("DeckID");

                    b.ToTable("CardInDecks");
                });

            modelBuilder.Entity("DAL.Models.Connection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("isStillLogeniIn")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("DAL.Models.Deck", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("DAL.Models.PreGameSession", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("Play")
                        .HasColumnType("int");

                    b.Property<int?>("RPSGameID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RPSGameID");

                    b.HasIndex("UserID");

                    b.ToTable("PreGameSessions");
                });

            modelBuilder.Entity("DAL.Models.RockPaperScissorsGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.HasKey("ID");

                    b.ToTable("RockPaperScissorsGames");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Models.UserHand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("DeckID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DeckID");

                    b.HasIndex("UserID");

                    b.ToTable("Hands");
                });

            modelBuilder.Entity("DAL.Models.Card", b =>
                {
                    b.HasOne("DAL.Models.UserHand", null)
                        .WithMany("Cards")
                        .HasForeignKey("UserHandID");
                });

            modelBuilder.Entity("DAL.Models.CardInDeck", b =>
                {
                    b.HasOne("DAL.Models.Card", "Card")
                        .WithMany("CardInDecks")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Deck", "Deck")
                        .WithMany("CardsInDeck")
                        .HasForeignKey("DeckID");

                    b.Navigation("Card");

                    b.Navigation("Deck");
                });

            modelBuilder.Entity("DAL.Models.Deck", b =>
                {
                    b.HasOne("DAL.Models.User", null)
                        .WithMany("Decks")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("DAL.Models.PreGameSession", b =>
                {
                    b.HasOne("DAL.Models.RockPaperScissorsGame", "RPSGame")
                        .WithMany("Players")
                        .HasForeignKey("RPSGameID");

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("RPSGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.UserHand", b =>
                {
                    b.HasOne("DAL.Models.Deck", "Deck")
                        .WithMany()
                        .HasForeignKey("DeckID");

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Deck");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Card", b =>
                {
                    b.Navigation("CardInDecks");
                });

            modelBuilder.Entity("DAL.Models.Deck", b =>
                {
                    b.Navigation("CardsInDeck");
                });

            modelBuilder.Entity("DAL.Models.RockPaperScissorsGame", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("Decks");
                });

            modelBuilder.Entity("DAL.Models.UserHand", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
