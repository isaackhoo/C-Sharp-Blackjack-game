using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using testCsharp.Model.Decks;

namespace UnitTest.Decks
{
    public class CardUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatesCardWithInputValues_ReturnsCard()
        {
            try
            {
                // Arrange
                Hashtable suitDetails = new Hashtable()
            {
                {"suit", "Hearts" },
                {"color", "Red" },
            };
                Hashtable cardDetails = new Hashtable()
            {
                {"display", "A" },
                {"value", 11 },
                {"alternativeValue", 1},
            };

                // Act
                Card card = new Card(cardDetails, suitDetails);

                // Assert
                Assert.AreEqual("Hearts", card.Suit);
                Assert.AreEqual("Red", card.Color);
                Assert.AreEqual("A", card.Display);
                Assert.AreEqual(11, card.Value);
                Assert.AreEqual(1, card.AlternativeValue);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        [Test]
        public void CreatesTwoCardsWithDifferentUuId_ReturnsCard()
        {
            try
            {
                // Arrange
                Hashtable suitDetails = new Hashtable()
            {
                {"suit", "Hearts" },
                {"color", "Red" },
            };
                Hashtable cardDetails = new Hashtable()
            {
                {"display", "A" },
                {"value", 11 },
                {"alternativeValue", 1},
            };

                // Act
                Card card1 = new Card(cardDetails, suitDetails);
                Card card2 = new Card(cardDetails, suitDetails);

                // Assert
                Assert.AreNotEqual(card1._id, card2._id);
            } 
            catch (Exception ex) { Console.WriteLine(ex);  }
        }

        [Test]
        public void CreateCard_ReturnsCardId()
        {
            try
            {
                // Arrange
                Hashtable suitDetails = new Hashtable()
            {
                {"suit", "Hearts" },
                {"color", "Red" },
            };
                Hashtable cardDetails = new Hashtable()
            {
                {"display", "A" },
                {"value", 11 },
                {"alternativeValue", 1},
            };

                // Act
                Card card = new Card(cardDetails, suitDetails);

                // Assert
                Assert.AreEqual($"{cardDetails["display"]}_{suitDetails["suit"]}", card.getId());
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        [Test]
        public void CreatesCardWithoutSuit_ExpectException()
        {
            try
            {
                // Arrange
                Hashtable suitDetails = new Hashtable()
                {
                    {"color", "Red" },
                };
                Hashtable cardDetails = new Hashtable()
                {
                    {"display", "A" },
                    {"value", 11 },
                    {"alternativeValue", 1},
                };

                // Act
                Card card = new Card(cardDetails, suitDetails);

                // Assert
                Assert.Fail();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        [Test]
        public void CreatesCardWithoutColor_ExpectException()
        {
            try
            {
                // Arrange
                Hashtable suitDetails = new Hashtable()
                {
                    {"suit", "Hearts" },
                };
                Hashtable cardDetails = new Hashtable()
                {
                    {"display", "A" },
                    {"value", 11 },
                    {"alternativeValue", 1},
                };

                // Act
                Card card = new Card(cardDetails, suitDetails);

                // Assert
                Assert.Fail();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        [Test]
        public void CreatesCardWithoutDisplay_ExpectException()
        {
            try
            {
                // Arrange
                Hashtable suitDetails = new Hashtable()
                {
                    {"suit", "Hearts" },
                    {"color", "Red" },
                };
                Hashtable cardDetails = new Hashtable()
                {
                    {"value", 11 },
                    {"alternativeValue", 1},
                };

                // Act
                Card card = new Card(cardDetails, suitDetails);

                // Assert
                Assert.Fail();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        [Test]
        public void CreatesCardWithoutValue_ExpectException()
        {
            try
            {
                // Arrange
                Hashtable suitDetails = new Hashtable()
                {
                    {"color", "Red" },
                };
                Hashtable cardDetails = new Hashtable()
                {
                    {"display", "A" },
                    {"alternativeValue", 1},
                };

                // Act
                Card card = new Card(cardDetails, suitDetails);

                // Assert
                Assert.Fail();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        [Test]
        public void CreatesCardWithoutAlternativeValue_ExpectException()
        {
            try
            {
                // Arrange
                Hashtable suitDetails = new Hashtable()
                {
                    {"color", "Red" },
                };
                Hashtable cardDetails = new Hashtable()
                {
                    {"display", "A" },
                    {"value", 11 },
                };

                // Act
                Card card = new Card(cardDetails, suitDetails);

                // Assert
                Assert.Fail();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}
