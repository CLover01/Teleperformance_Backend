using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance_Backend_Test_NetCore
{
    public class Question1
    {
        public static int Restock(List<int> itemCount, int target)
        {
            if (itemCount == null || !itemCount.Any())
                throw new ArgumentException($"{nameof(itemCount)} cannot be null or empty!");
            if (target <= 0) throw new ArgumentException($"{nameof(target)} must be greater than 0! Now the value is {target}!");                   

            int tempInt = target;
            for (int index = 0; index < itemCount.Count; index++)
            {
                if (itemCount[index] > 0)
                {
                    tempInt -= itemCount[index];
                    if (tempInt <= 0) break;
                }
            }

            if (tempInt > 0) Console.WriteLine($"The remaining number of units need to buy: {tempInt}.");
            else if (tempInt < 0) Console.WriteLine($"The number of units needs to sell: {Math.Abs(tempInt)}.");


            return (-1 * tempInt);
        }
    }
}
