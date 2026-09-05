using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Prog.session_04.dice_game
{
    public class PairOfDice
    {
        private Die die1;
        private Die die2;

        public PairOfDice()
        {
            die1 = new Die();
            die2 = new Die();
        }

        public void Roll()
        {
            die1.roll();
            die2.roll();
        }
        /// <summary>
        /// Get the total points of the pair of dice
        /// </summary>
        /// <returns></returns>
        public int GetPoints()
        {
            return die1.Face + die2.Face;
        }

        public bool IsBothOne()
        {
            return die1.Face == 1 && die2.Face == 1;
        }

        public bool IsBothSix()
        {
            return die1.Face == 6 && die2.Face == 6;
        }

        public override string ToString()
        {
            return $"[{die1}, {die2}]";
        }
    }
}