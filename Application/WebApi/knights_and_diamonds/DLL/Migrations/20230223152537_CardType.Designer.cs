﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(KnightsAndDiamondsContext))]
    [Migration("20230223152537_CardType")]
    partial class CardType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("AttackPoints")
                        .HasColumnType("int");

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardTypeID")
                        .HasColumnType("int");

                    b.Property<int>("DefencePoints")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElementType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonsterType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfStars")
                        .HasColumnType("int");

                    b.Property<int?>("UserHandID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardTypeID");

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

            modelBuilder.Entity("DAL.Models.CardType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CardTypes");
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

            modelBuilder.Entity("DAL.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("GameID")
                        .HasColumnType("int");

                    b.Property<int?>("Play")
                        .HasColumnType("int");

                    b.Property<int>("RPSGameID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("RPSGameID");

                    b.HasIndex("UserID");

                    b.ToTable("Players");
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
                    b.HasOne("DAL.Models.CardType", "CardType")
                        .WithMany("Cards")
                        .HasForeignKey("CardTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.UserHand", null)
                        .WithMany("Cards")
                        .HasForeignKey("UserHandID");

                    b.Navigation("CardType");
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

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.HasOne("DAL.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameID");

                    b.HasOne("DAL.Models.RockPaperScissorsGame", "RPSGame")
                        .WithMany("Players")
                        .HasForeignKey("RPSGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

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

            modelBuilder.Entity("DAL.Models.CardType", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("DAL.Models.Deck", b =>
                {
                    b.Navigation("CardsInDeck");
                });

            modelBuilder.Entity("DAL.Models.Game", b =>
                {
                    b.Navigation("Players");
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
