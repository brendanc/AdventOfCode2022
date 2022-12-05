using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day5
{
	public class Task2 : AdventOfCodeTaskBase
	{
        private CrateStacks stacks;
        private List<CrateMove> moves;

        public override void Run()
        {
            stacks = new CrateStacks(this.GetInput());
            moves = CrateMove.ParseMoves(this.GetInput());


            foreach (var move in moves)
            {
                MoveCrates(move);
            }


            var topOfStacks = stacks.GetLastItemsInStacks();
            Console.WriteLine("The top of each stack => " + topOfStacks);
        }


        private void MoveCrates(CrateMove move)
        {
            var moveList = new List<string>();
            for (int i = move.NumberToMove; i>0; i--)
            {
                moveList.Add(stacks.TheStacks[move.From - 1].ElementAt(stacks.TheStacks[move.From - 1].Count() - i));
            }

            for (int i = 0; i < move.NumberToMove; i++)
            {
                // remove an from old stack
                stacks.TheStacks[move.From - 1].RemoveLast();

                //add to new stack
                stacks.TheStacks[move.To - 1].AddLast(moveList[i]);
            }
        }
    }
}

