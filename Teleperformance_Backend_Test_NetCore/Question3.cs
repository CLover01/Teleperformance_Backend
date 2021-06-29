using System;

namespace Teleperformance_Backend_Test_NetCore
{
    public class Question3
    {
        public static char[] Reverse(char[] inputString)
        {
            if (inputString == null) throw new ArgumentNullException(nameof(inputString));
            if (inputString.Length == 0 || inputString.Length == 1) return inputString;

            var tempChars = inputString;
            char tempChar;
            for (int headIdx = 0, tailIdx = inputString.Length - 1; headIdx < tailIdx; headIdx++, tailIdx--)
            {
                tempChar = tempChars[headIdx];
                tempChars[headIdx] = tempChars[tailIdx];
                tempChars[tailIdx] = tempChar;
            }

            return tempChars;
        }
    }
}
