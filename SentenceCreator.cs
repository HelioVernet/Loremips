using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exo
{
    internal class SentenceCreator
    {
        WordCreator wc = new WordCreator();
        Random random = new Random();

        
        public Tuple<int, string> CreateSentenceChar(int remainingChar)
        {
            int charCounter = remainingChar;

            string sentence = wc.GenerateWord(charCounter);
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);

            charCounter -= sentence.Length;

            int sentenceLength = random.Next(3, 14);

            for (int i = 0; i < sentenceLength; i++)
            {
                if(charCounter == 0)
                {
                    break;
                }
                sentence += " ";
                string newWord = wc.GenerateWord(charCounter);
                sentence += newWord;
                charCounter -= newWord.Length;
            }
            sentence += ". ";
            return Tuple.Create(charCounter, sentence);
        }

        public Tuple<int, string> CreateSentence(int remainingWords)
        {
            int wordCounter = 1;

            string sentence = wc.GenerateWord();
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);

            int sentenceLength = 0;
            if (remainingWords < 13)
            {
                sentenceLength = remainingWords - 1;
            }
            else
            {
                sentenceLength = random.Next(3, 14);
            }
            for (int i = 0; i < sentenceLength; i++)
            {

                sentence += " ";
                string newWord = wc.GenerateWord();
                sentence += newWord;
                wordCounter++;
            }
            sentence += ". ";
            return Tuple.Create(wordCounter, sentence);
        }

    }
}
