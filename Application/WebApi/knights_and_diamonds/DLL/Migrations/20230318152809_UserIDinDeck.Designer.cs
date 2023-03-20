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
    [Migration("20230318152809_UserIDinDeck")]
    partial class UserIDinDeck
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

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EffectID")
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerHandID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardTypeID");

                    b.HasIndex("EffectID");

                    b.HasIndex("PlayerHandID");

                    b.ToTable("Cards");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Card");
                });

            modelBuilder.Entity("DAL.Models.CardInDeck", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CardID")
                        .HasColumnType("int");

                    b.Property<int>("DeckID")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardID");

                    b.HasIndex("DeckID");

                    b.HasIndex("PlayerID");

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

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("DAL.Models.Effect", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EffectTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("NumOfCardsAffected")
                        .HasColumnType("int");

                    b.Property<int?>("PointsAddedLost")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EffectTypeID");

                    b.ToTable("Effects");
                });

            modelBuilder.Entity("DAL.Models.EffectType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EffectTypes");
                });

            modelBuilder.Entity("DAL.Models.ElementType", b =>
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

                    b.ToTable("ElementTypes");
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

            modelBuilder.Entity("DAL.Models.MonsterType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MonsterTypes");
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("GameID")
                        .HasColumnType("int");

                    b.Property<int?>("HandID")
                        .HasColumnType("int");

                    b.Property<int>("LifePoints")
                        .HasColumnType("int");

                    b.Property<int?>("Play")
                        .HasColumnType("int");

                    b.Property<int>("RPSGameID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("HandID");

                    b.HasIndex("RPSGameID");

                    b.HasIndex("UserID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DAL.Models.PlayerHand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.HasKey("ID");

                    b.ToTable("PlayerHands");
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

            modelBuilder.Entity("DAL.Models.Turn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("BattlePhase")
                        .HasColumnType("bit");

                    b.Property<bool>("DrawPhase")
                        .HasColumnType("bit");

                    b.Property<bool>("EndPhase")
                        .HasColumnType("bit");

                    b.Property<int?>("GameID")
                        .HasColumnType("int");

                    b.Property<bool>("MainPhase")
                        .HasColumnType("bit");

                    b.Property<bool>("MonsterSummoned")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerOnTurn")
                        .HasColumnType("int");

                    b.Property<int>("TurnNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainDeckID")
                        .HasColumnType("int");

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

            modelBuilder.Entity("DAL.Models.MonsterCard", b =>
                {
                    b.HasBaseType("DAL.Models.Card");

                    b.Property<int>("AttackPoints")
                        .HasColumnType("int");

                    b.Property<int>("DefencePoints")
                        .HasColumnType("int");

                    b.Property<int>("ElementTypeID")
                        .HasColumnType("int");

                    b.Property<int>("MonsterTypeID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfStars")
                        .HasColumnType("int");

                    b.HasIndex("ElementTypeID");

                    b.HasIndex("MonsterTypeID");

                    b.HasDiscriminator().HasValue("MonsterCard");
                });

            modelBuilder.Entity("DAL.Models.Card", b =>
                {
                    b.HasOne("DAL.Models.CardType", "CardType")
                        .WithMany("Cards")
                        .HasForeignKey("CardTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Effect", "Effect")
                        .WithMany("Cards")
                        .HasForeignKey("EffectID");

                    b.HasOne("DAL.Models.PlayerHand", null)
                        .WithMany("CardsInHand")
                        .HasForeignKey("PlayerHandID");

                    b.Navigation("CardType");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("DAL.Models.CardInDeck", b =>
                {
                    b.HasOne("DAL.Models.Card", "Card")
                        .WithMany("CardInDecks")
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Deck", "Deck")
                        .WithMany("CardsInDeck")
                        .HasForeignKey("DeckID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Player", null)
                        .WithMany("Deck")
                        .HasForeignKey("PlayerID");

                    b.Navigation("Card");

                    b.Navigation("Deck");
                });

            modelBuilder.Entity("DAL.Models.Deck", b =>
                {
                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Decks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Effect", b =>
                {
                    b.HasOne("DAL.Models.EffectType", "EffectType")
                        .WithMany()
                        .HasForeignKey("EffectTypeID");

                    b.Navigation("EffectType");
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.HasOne("DAL.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameID");

                    b.HasOne("DAL.Models.PlayerHand", "Hand")
                        .WithMany()
                        .HasForeignKey("HandID");

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

                    b.Navigation("Hand");

                    b.Navigation("RPSGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Turn", b =>
                {
                    b.HasOne("DAL.Models.Game", "Game")
                        .WithMany("Turns")
                        .HasForeignKey("GameID");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("DAL.Models.MonsterCard", b =>
                {
                    b.HasOne("DAL.Models.ElementType", "ElementType")
                        .WithMany("MonsterCards")
                        .HasForeignKey("ElementTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.MonsterType", "MonsterType")
                        .WithMany("MonsterCards")
                        .HasForeignKey("MonsterTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElementType");

                    b.Navigation("MonsterType");
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

            modelBuilder.Entity("DAL.Models.Effect", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("DAL.Models.ElementType", b =>
                {
                    b.Navigation("MonsterCards");
                });

            modelBuilder.Entity("DAL.Models.Game", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("Turns");
                });

            modelBuilder.Entity("DAL.Models.MonsterType", b =>
                {
                    b.Navigation("MonsterCards");
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.Navigation("Deck");
                });

            modelBuilder.Entity("DAL.Models.PlayerHand", b =>
                {
                    b.Navigation("CardsInHand");
                });

            modelBuilder.Entity("DAL.Models.RockPaperScissorsGame", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("Decks");
                });
#pragma warning restore 612, 618
        }
    }
}
