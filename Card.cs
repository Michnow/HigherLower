﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLower
{
    enum Suit
    {
        Clubs,
        Hearts,
        Diamonds,
        Spades
    }
    class Card
    {
        public Suit Suit { get; set; }
        public int Value { get; set; }

        public string Name { get; set; }

        public Card(Suit suit, int value, string name)
        {
            Suit = suit;
            Value = value;
            Name = name;
        }

    }

}
