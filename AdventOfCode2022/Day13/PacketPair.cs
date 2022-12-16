using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day13
{
	public class PacketPair
	{
		public PacketPair(Packet left, Packet right)
		{
			Left = left;
			Right = right;
		}

		public Packet Left { get; set; }
		public Packet Right { get; set; }


		public bool IsInOrder()
		{
			if(Left.Value.Items.Count() > Right.Value.Items.Count)
			{
				return false;
			}


			var valueChecks = new List<bool>();
			for(var i=0;i< Left.Value.Items.Count();i++)
			{
				var leftVal = Left.Value.Items.ElementAt(i);
				var rightVal = Right.Value.Items.ElementAt(i);
                if(!ItemsAreInOrder(leftVal, rightVal))
				{
					return false;
				}
            }

			return true;
		}

		private bool ItemsAreInOrder(object left, object right)
		{
			// make sure there are ints
			var leftString = left.ToString();
			var rightString = right.ToString();

			if(!leftString.Any(c => Char.IsDigit(c))  && rightString.Any(Char.IsDigit))
			{
				// left has no ints but right does
				return true;
			}

            if (!rightString.Any(c => Char.IsDigit(c)) && leftString.Any(Char.IsDigit))
            {
                // right has no ints but left does
                return false;
            }

            if (!leftString.Any(c => Char.IsDigit(c)) && !rightString.Any(c => Char.IsDigit(c)))
            {
				// no digits in either, right should have more braces
				return leftString.Count(c => c == '[') < rightString.Count(c => c == '[');
            }

            var leftNum = Regex.Replace(leftString, @"[^\d]", "");
            var rightNum = Regex.Replace(rightString, @"[^\d]", "");

            // if the values are numbers
            long x = 0;
			if(long.TryParse(leftNum, out x) && long.TryParse(rightString,out x))
			{
				return Convert.ToInt64(leftString) <= Convert.ToInt64(rightString);
			}

			// if the values aren't numbers they are lists

			throw new ArgumentException();


   //         // convert to ints and compare number by number
   //         var leftNum = Regex.Replace(leftString, @"[^\d]", "");
   //         var rightNum = Regex.Replace(rightString, @"[^\d]", "");

			//if(leftNum.Length != rightNum.Length)
			//{
			//	if(leftNum.Length > rightNum.Length)
			//	{
   //                 rightNum = rightNum.PadRight(leftNum.Length, '0');
			//	}
			//	else
			//	{
   //                 leftNum = leftNum.PadRight(rightNum.Length, '0');
   //             }
			//}

			//try
			//{
			//	return Convert.ToInt64(leftNum) <= Convert.ToInt64(rightNum);
			//}
			//catch(OverflowException)
			//{
			//	return BigInteger.Parse(leftNum) < BigInteger.Parse(rightNum);
			//}
		}
	}
}

