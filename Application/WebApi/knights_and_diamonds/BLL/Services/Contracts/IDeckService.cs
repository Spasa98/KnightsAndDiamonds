﻿using DAL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
    public interface IDeckService
    {
        Task<Deck> AddDeck(Deck deck);
        Task<User> SetMainDeckID(int userID, int deckID);
        public Task<List<CardDisplayDTO>> GetCardsFromDeck(int userID);
        Task AddCardToDeck(int cardID, int deckID);
        Task RemoveCardFromDeck(int cardID, int deckID);
        Task<CardCounter> CardCounter(int deckID, int userID);
    }
}
