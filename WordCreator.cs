using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo
{
    public class WordCreator
    {
        Random random = new Random();
        string consonants = "bbcccdddfffgghhhhjklllmmmnnnnnppqrrrrssssstttttvvwwwxz";
        string vowels = "aaaaaeeeeeeiiiiiooooouuuyyy";

        public string GenerateWord()
        {

            var word = new char[random.Next(2, 19)];

            for (int i = 0; i < word.Length; i++)
            {
                if (random.Next() % 2 == 0)
                {
                    word[i] = consonants[random.Next(consonants.Length)];
                }
                else
                {
                    word[i] = vowels[random.Next(vowels.Length)];
                }
            }
            return new String(word);
        }
        public string GenerateWord(int maxChar)
        {
            var word = new char[maxChar];
            if (maxChar > 19)
            {
                word = new char[random.Next(2, 19)];
            }
            for (int i = 0; i < word.Length; i++)
            {
                if (random.Next() % 2 == 0)
                {
                    word[i] = consonants[random.Next(consonants.Length)];
                }
                else
                {
                    word[i] = vowels[random.Next(vowels.Length)];
                }
            }
            return new String(word);

        }

    }
}
