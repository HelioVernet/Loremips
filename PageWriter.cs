using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exo
{
    internal class PageWriter
    {
        Random random = new Random();
        SentenceCreator sc = new SentenceCreator();
        int numberOfChars = 0;
        int numberOfWords = 0;
        public void WritePageMaxChar(int askedChar)
        {
            numberOfChars = askedChar;
            Console.WriteLine("Creating html page with " + askedChar + " words");
            using (StreamWriter sw = new StreamWriter("Export.html"))
            {
                sw.Write(WriteCss());

                var title = sc.CreateSentenceWithChar(numberOfChars);
                numberOfChars = title.Item1;
                sw.Write(WriteTitle(title.Item2));
                sw.Write(JumpLine());

                while (numberOfChars > 0)
                {
                    if (random.Next(0, 50) == 1)
                    {
                        var _title = sc.CreateSentenceWithChar(numberOfChars);
                        numberOfChars -= _title.Item1;
                        sw.Write(WriteTitle(_title.Item2));
                        sw.Write(JumpLine());
                    }
                    else
                    {
                        sw.Write(WriteParagraphChar(random.Next(3, 50)));
                    }
                }

            }
        }
        public void WritePageMaxWord(int askedWords)
        {
            numberOfWords = askedWords;
            Console.WriteLine("Creating html page with " + askedWords + " words");
            using (StreamWriter sw = new StreamWriter("Export.html"))
            {
                sw.Write(WriteCss());
                var title = sc.CreateSentenceWithWord(numberOfWords);
                numberOfWords -= title.Item1;
                sw.Write(WriteTitle(title.Item2));
                sw.Write(JumpLine());

                while (numberOfWords > 0)
                {
                    if (random.Next(0, 50) == 1)
                    {
                        var _title = sc.CreateSentenceWithWord(numberOfWords);
                        numberOfWords -= _title.Item1;
                        sw.Write(WriteTitle(_title.Item2));
                        sw.Write(JumpLine());
                    }
                    else
                    {
                        sw.Write(WriteParagraphWord(random.Next(3, 50)));
                    }
                }

            }
        }
        private string JumpLine()
        {
            return "<br />";
        }
        private string WriteParagraphChar(int numberOfSentences)
        {
            string paragraph = "<p>";
            for (int i = 0; i < numberOfSentences; i++)
            {
                if (numberOfChars <= 0)
                {
                    break;
                }
                var result = sc.CreateSentenceWithChar(numberOfChars);
                if (result.Item1 <= 0)
                {
                    numberOfChars = 0;
                    paragraph += result.Item2;
                    break;
                }
                numberOfChars = result.Item1;
                paragraph += result.Item2;
            }
            return paragraph + "</p>";
        }
        private string WriteParagraphWord(int numberOfSentences)
        {
            string paragraph = "<p>";
            for (int i = 0; i < numberOfSentences; i++)
            {
                if (numberOfWords <= 0)
                {
                    break;
                }
                var result = sc.CreateSentenceWithWord(numberOfWords);
                numberOfWords -= result.Item1;
                paragraph += result.Item2;
            }
            return paragraph + "</p>";
        }
        private string WriteTitle(string sentence)
        {
            return "<h1>" + sentence + "</h1>";
        }
        private string WriteCustom(string sentence, string openingTag, string closingTag)
        {
            return openingTag + sentence + closingTag;
        }
        private string WriteCss()
        {
            return "<style>\r\n" +
                "body {background-color: white;}\r\n" +
                "body {text-align: justify; margin-right: 10%; margin-left: 10%;}\r\n" +
                "h1 {text-align: center; text-decoration: underline;}\r\n" +
                "</style>";
        }


    }
}
