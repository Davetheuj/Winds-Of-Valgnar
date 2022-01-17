using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Utilities
{
    class StringGenerators
    {
       // public static string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static string[] consonants = {
            "B", "Bh", "Bl", "Br", "Bs",
            "C", "Ch", "Cl", "Cr", "Cs",
            "D", "Dh", "Ds",
            "F", "Fh", "Fl", "Fr", "Fs", "Ft", "Fb",
            "G", "Gh", "Gl", "Gr", "Gs",
            "H", 
            "J", 
            "K", "Kh", "Kl", "Kr", 
            "L", 
            "M", "Mr",
            "N", "Nr",
            "P", "Ph", 
            "R", 
            "S", "Sh", "Sv", "Sl",
            "T", "Th", "Tr",
            "V", 
            "W", 
            "Z" 
        };
        public static string[] vowels = { 
            "A", "Aa", "Ae", "Ai", "Ao", "Au", "Ay", 
            "E", "Ea", "Ee", "Ei", "Eo", "Eu", "Ey",
            "I", "Ia", "Ie", "Io", "Iu", "Iy",
            "O", "Oa", "Oe", "Oi", "Oo", "Ou", "Oy",
            "U", "Ua", "Ue", "Ui", "Uo", "Uy",
            "Y", "Ya", "Ye", "Yi", "Yo", "Yu" };


        public static string GenerateRandomName()
        {

            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            int stringLength = rand.Next(1, 5);
            bool isVowel = false;

           if(rand.Next(1,3) == 1)
            {
                isVowel = true;
                sb.Append(vowels[rand.Next(0,vowels.Length -1)]);
            }
            else
            {
                sb.Append(consonants[rand.Next(0, consonants.Length - 1)]);
            }
            
           for(int i = 0; i < stringLength; i++)
            {
                if (isVowel)
                {
                    sb.Append(consonants[rand.Next(0, consonants.Length - 1)].ToLower());
                    isVowel = false;
                }
                else
                {
                    sb.Append(vowels[rand.Next(0, vowels.Length - 1)].ToLower());

                    isVowel = true;
                }
            }

            

            return sb.ToString();

        }
    }
}
