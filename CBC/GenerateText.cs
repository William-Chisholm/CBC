using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBC
{
    public class GenerateText
    {
        public static string GenerateUserText()
        {
            var rand = new Random();
            var result = "";
            var characters = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@$&*";
            var charactersLength = characters.Length;
            for (var i = 0; i < 256; i++)
            {
                result += characters[(int)Math.Floor(Convert.ToDecimal(rand.Next(0, charactersLength)))];
            }
            return result;
        }
    }
}
