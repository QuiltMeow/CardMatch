using System;
using System.Collections.Generic;

namespace Homework_7
{
    internal class MatchGenerator
    {
        private readonly IList<int> symbolList;

        public MatchGenerator()
        {
            symbolList = new List<int>();
            int total = (int)Math.Pow(Board.GENERATE_SEQURE, 2);
            initMatchCard(total);
        }

        private void initMatchCard(int total)
        {
            int matchCount = total / 2;
            int[] frequency = new int[matchCount];
            for (int i = 0; i < total; ++i)
            {
                int card = MainForm.random.Next(matchCount);
                if (frequency[card] >= 2)
                {
                    --i;
                    continue;
                }
                symbolList.Add(card);
                ++frequency[card];
            }
        }

        public IList<int> getSymbolList()
        {
            return symbolList;
        }
    }
}