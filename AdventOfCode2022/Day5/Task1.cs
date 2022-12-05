using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day5
{
	public class Task1 : AdventOfCodeTaskBase
	{
        private CrateStacks stacks;
        private List<CrateMove> moves;

        public override void Run()
        {
            stacks = new CrateStacks(this.GetInput());
            moves = CrateMove.ParseMoves(this.GetInput());


            foreach(var move in moves)
            {
                MoveCrates(move);
            }


            var topOfStacks = stacks.GetLastItemsInStacks();
            Console.WriteLine("The top of each stack => " + topOfStacks);
        }


        private void MoveCrates(CrateMove move)
        {            
            for(int i=0;i<move.NumberToMove;i++)
            {
                // get the last item
                var itemToMove = stacks.TheStacks[move.From-1].Last();
                // remove from old stack
                stacks.TheStacks[move.From-1].RemoveLast();
                //add to new stck
                stacks.TheStacks[move.To-1].AddLast(itemToMove);
            }
        }


    }
}

