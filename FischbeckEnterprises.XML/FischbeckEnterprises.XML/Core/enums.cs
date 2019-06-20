using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.XML.Core
{
    public enum Attribute
    {
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
    }

    public enum School
    { A = 1, C, D, EN, EV, I, N, T }

    public enum ItemType
    { LA, MA, HA, S, M, R, A, RD, ST, WD, RG, P, SC, W, G, MO }

    public enum DamageType
    { P, S, B }

    public enum ItemProperty
    {
        A, F, H, L, LD, R, S, T, HH, V, M
    }

    public enum Dice
    {
        d0, d4, d6, d8, d10, d12, d20, d100
    }

    public enum Component
    {
        V = 1, S, M
    }

}
