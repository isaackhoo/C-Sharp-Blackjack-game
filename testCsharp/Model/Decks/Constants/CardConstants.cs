using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace testCsharp.Model.Decks.Constants
{
    public static class CardConstants
    {
        public static readonly List<Hashtable> cardSuits = new List<Hashtable>()
        {
            new Hashtable()
            {
                {"suit", "Hearts" },
                {"color", "Red" },
            },
            new Hashtable()
            {
                {"suit", "Spades" },
                {"color", "Black" },
            },
            new Hashtable()
            {
                {"suit", "Diamonds" },
                {"color", "Red" },
            },
            new Hashtable()
            {
                {"suit", "Clubs" },
                {"color", "Black" },
            },
        };
        public static readonly List<Hashtable> cardTypes = new List<Hashtable>()
        {
            new Hashtable()
            {
                {"display", "A" },
                {"value", 11 },
                {"alternativeValue", 1 },
            },
            new Hashtable()
            {
                {"display", "2" },
                {"value", 2 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "3" },
                {"value", 3 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "4" },
                {"value", 4 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "5" },
                {"value", 5 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "6" },
                {"value", 6 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "7" },
                {"value", 7 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "8" },
                {"value", 8 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "9" },
                {"value", 9 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "10" },
                {"value", 1 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "J" },
                {"value", 10 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "Q" },
                {"value", 10 },
                {"alternativeValue", 0 },
            },
            new Hashtable()
            {
                {"display", "K" },
                {"value", 10 },
                {"alternativeValue", 0 },
            },
        };
    }
}
