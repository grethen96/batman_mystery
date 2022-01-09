using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatmanTask.Services
{
    public class HelpService
    {
        /// <summary>
        /// This is the entry method responding to the controller.
        /// </summary>
        /// <param name="countOfNumbers"></param>
        /// <param name="startNumber"></param>
        /// <returns></returns>
        public int CalculateSum(int countOfNumbers, int startNumber)
        {
            List<int> pairSum = new List<int>();
            List<int> pairSumTemp = new List<int>();

            if (countOfNumbers == 1)
            {
                return startNumber;
            }

            InitializePairSum(countOfNumbers, startNumber, pairSum);
            pairSum = CalculateFinalSum(pairSum);
            return pairSum[0];
        }

        /// <summary>
        /// This method initializes the first calculated row containing pairs from the initial input.
        /// </summary>
        /// <param name="countOfNumbers"></param>
        /// <param name="startNumber"></param>
        /// <param name="pairSum"></param>
        private static void InitializePairSum(int countOfNumbers, int startNumber, List<int> pairSum)
        {
            for (int i = 0; i < countOfNumbers - 1; i++)
            {
                int currentNum = startNumber + i;
                int sumPair = currentNum + (currentNum + 1);
                pairSum.Add(sumPair);
            }
        }

        /// <summary>
        /// This method produces the final sum.
        /// </summary>
        /// <param name="pairSum"></param>
        /// <returns></returns>
        private static List<int> CalculateFinalSum(List<int> pairSum)
        {
            List<int> pairSumTemp = new List<int>();

            while (pairSum.Count > 1)
            {
                for (int i = 0; i < pairSum.Count - 1; i++)
                {
                    pairSumTemp.Add(pairSum[i] + pairSum[i + 1]);
                }
                pairSum = pairSumTemp.ToList();
                pairSumTemp.Clear();
            }

            return pairSum;
        }
    }
}
