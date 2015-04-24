using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }


    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
	//     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
	//     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
	//     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
	//         discard pile	
    // 
    // A deck knows the following information about itself:
	//     int CardsRemaining -- number of cards left in the deck
	//     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played
    class Deck
    {
        //create a random
        Random rng = new Random();
        //set properties
        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }
        /// <summary>
        /// Shuffles deck
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();
            DeckOfCards.Concat(DiscardedCards);
            List<Card> tempShuffleList = new List<Card> { };
            while (DeckOfCards.Count() > 0)
            {
                Card currentCard = DeckOfCards[rng.Next(0,DeckOfCards.Count())];
                tempShuffleList.Add(currentCard);
                DeckOfCards.Remove(currentCard);
            }
            DeckOfCards = tempShuffleList;
        }
        /// <summary>
        /// deals number of cards
        /// </summary>
        /// <param name="numberOfCards">number of cards</param>
        /// <returns></returns>
        public List<Card> Deal(int numberOfCards)
        {
            List<Card> tempDeal = new List<Card> { };
            for (int i = 0; i < numberOfCards; i++)
            {
                tempDeal.Add(DeckOfCards[i]);
                DeckOfCards.Remove(DeckOfCards[i]);
                
            }
            return tempDeal;
        }
        /// <summary>
        /// discard one card
        /// </summary>
        /// <param name="card">a card</param>
        /// <returns></returns>
        public List<Card> Discard(Card card)
        {
             DiscardedCards.Add(card);
             return DiscardedCards;
        }
        /// <summary>
        /// discards multiple cards
        /// </summary>
        /// <param name="cards">liist of cards</param>
        /// <returns></returns>
        public List<Card> Discard(List<Card> cards)
        {
            foreach (Card card in cards )
            {
                DiscardedCards.Add(card);
            }
            return DiscardedCards;
        }

        public Deck()
        {
            this.DeckOfCards = new List<Card> { };
            //set discarded to empty
            this.DiscardedCards = new List<Card> { }; 
            //set standard 
            for (int i = 2; i < 15; i++)
            {
                for (int x = 1; x < 5; x++)
                {
                    Card newCard = new Card(i,x);
                    DeckOfCards.Add(newCard);
                    
                } 
            }
        }
    }

    
    // What makes a card?
	//     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"
    class Card
    {
        //make properties
        public Rank CardRank { get; set;}
        public SuitType Suit { get; set; }




        
        //make list of rank
        public enum Rank
        {
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }
       //make suits
        public enum SuitType
        {
            Club = 1,
            Diamond,
            Heart,
            Spade
        }
        public Card()
        {

        }
        public Card(int rank, int suit)
        {
            this.CardRank = (Rank) rank;
            this.Suit = (SuitType) suit;
        }
        public override string ToString()
        {
            return string.Format("{0} of {1}",CardRank ,Suit);
        }
    }
}
