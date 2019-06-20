using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.XML.Core
{

    partial class Attributes
    {
        public Attribute Attribute { get; set; }
        public int Score { get; set; }
        public int Modifier { get; private set; }

        public Attributes() { }

        public Attributes(Attribute attribute, int score)
        {
            this.Attribute = attribute;
            this.Score = score;
            this.Modifier = SetModifier(this.Score);
        }

        public void Update()
        {
            this.Modifier = SetModifier(this.Score);
        }
        public void Update(int newScore)
        {
            this.Score = newScore;
            this.Modifier = SetModifier(this.Score);
        }

        private int SetModifier(int score)
        {
            int modifier = -5;
            switch (score)
            {
                case 1: { modifier = -5; break; }
                case int n when (score > 1 && score < 4): { modifier = -4; break; }
                case int n when (score > 3 && score < 6): { modifier = -3; break; }
                case int n when (score > 5 && score < 8): { modifier = -2; break; }
                case int n when (score > 7 && score < 10): { modifier = -1; break; }
                case int n when (score > 9 && score < 12): { modifier = 0; break; }
                case int n when (score > 11 && score < 14): { modifier = 1; break; }
                case int n when (score > 13 && score < 16): { modifier = 2; break; }
                case int n when (score > 15 && score < 18): { modifier = 3; break; }
                case int n when (score > 17 && score < 20): { modifier = 4; break; }
                case int n when (score > 19 && score < 22): { modifier = 5; break; }
                case int n when (score > 21 && score < 24): { modifier = 6; break; }
                case int n when (score > 23 && score < 26): { modifier = 7; break; }
                case int n when (score > 25 && score < 28): { modifier = 8; break; }
                case int n when (score > 27 && score < 30): { modifier = 9; break; }
                case int n when (score < 31): { modifier = 10; break; }
                default:
                    break;
            }
            return modifier;
        }
    }
}
