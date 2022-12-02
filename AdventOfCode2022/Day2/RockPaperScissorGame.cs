using System;
namespace AdventOfCode2022.Day2
{
	public class RockPaperScissorGame
	{
        private readonly string opponent;
        private readonly string me;

        public RockPaperScissorGame(string opponent, string me)
        {
            this.opponent = opponent;
            this.me = me;
        }

        public int Outcome
        {
            get
            {
                return RockPaperScissorsMatchOutcome(opponent, me);
            }
        }

        private int RockPaperScissorsMatchOutcome(string opp, string me)
        {
            var matchResult = GetRockPaperScissorGameOutcome(opp, me);

            // now add the score for my play to the match result
            switch (me)
            {
                case "X":
                    return matchResult + 1;
                case "Y":
                    return matchResult + 2;
                case "Z":
                    return matchResult + 3;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        /// <summary>
        /// Only get the outcome of the RPS game
        /// </summary>
        /// <param name="opp"></param>
        /// <param name="me"></param>
        /// <returns></returns>
        private int GetRockPaperScissorGameOutcome(string opp, string me)
        {
            switch (opp)
            {
                case "A":
                    if (me == "X") // tie
                    {
                        return 3;
                    }
                    if (me == "Z") // loss
                    {
                        return 0;
                    }
                    return 6; //win

                case "B":
                    if (me == "Y") // tie
                    {
                        return 3;
                    }
                    if (me == "X") // loss
                    {
                        return 0;
                    }
                    return 6; //win
                case "C":
                    if (me == "Z") // tie
                    {
                        return 3;
                    }
                    if (me == "Y") // loss
                    {
                        return 0;
                    }
                    return 6; //win
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

