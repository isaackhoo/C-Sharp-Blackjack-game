using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using testCsharp.Model.Decks;

namespace UnitTest.Decks
{
    public class DiscardDeckUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializesDiscardDeck_ReturnsVoid()
        {
            // Arrange
            DiscardDeck discardDeck = new DiscardDeck();

            // Act

            // Assert
            Assert.AreEqual(0, discardDeck.getCount());
        }

        [Test]
        public void AddsToDiscardDeck_ReturnsVoid()
        {
            // Arrange
            Card card = new Card(
                new Hashtable()
                {
                    {"display", "A" },
                    {"value", 11 },
                    {"alternativeValue", 1 },
                },
                new Hashtable()
                {
                    {"suit", "Hearts" },
                    {"color", "Red" },
                }
            );
            DiscardDeck discardDeck = new DiscardDeck();

            // Act
            discardDeck.addCard(card);

            // Assert
            Assert.AreEqual(1, discardDeck.getCount());
        }

        [Test]
        public void DiscardDeckIsEmptied_ReturnsListOfCards()
        {
            // Arrange
            const int NumberOfCards = 5;
            Card card = new Card(
                new Hashtable()
                {
                    {"display", "A" },
                    {"value", 11 },
                    {"alternativeValue", 1 },
                },
                new Hashtable()
                {
                    {"suit", "Hearts" },
                    {"color", "Red" },
                }
            );
            DiscardDeck discardDeck = new DiscardDeck();
            List<Card> emptiedCards;

            // Act
            for (int i = 0; i < NumberOfCards; i++)
                discardDeck.addCard(card);
            emptiedCards = discardDeck.clearDiscardPile();

            // Assert
            Assert.AreEqual(0, discardDeck.getCount());
            Assert.AreEqual(NumberOfCards, emptiedCards.Count);
        }
    }
}
