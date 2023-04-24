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
        public void WritePageChar(int askedChar)
        {
            numberOfChars = askedChar;
            Console.WriteLine("Creating html page with " + askedChar + " words");
            using (StreamWriter sw = new StreamWriter("Export.html"))
            {
                sw.Write(WriteCss());

                var title = sc.CreateSentenceChar(numberOfChars);
                numberOfChars = title.Item1;
                sw.Write(WriteTitle(title.Item2));
                sw.Write(JumpLine());

                while (numberOfChars > 0)
                {
                    if (random.Next(0, 50) == 1)
                    {
                        var _title = sc.CreateSentenceChar(numberOfChars);
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
        public void WritePage(int askedWords)
        {
            numberOfWords = askedWords;
            Console.WriteLine("Creating html page with " + askedWords + " words");
            using (StreamWriter sw = new StreamWriter("Export.html"))
            {
                sw.Write(WriteCss());
                var title = sc.CreateSentence(numberOfWords);
                numberOfWords -= title.Item1;   
                sw.Write(WriteTitle(title.Item2));
                sw.Write(JumpLine());

                while (numberOfWords > 0)
                {
                    if (random.Next(0, 50) == 1)
                    {
                        var _title = sc.CreateSentence(numberOfWords);
                        numberOfWords -= _title.Item1;
                        sw.Write(WriteTitle(_title.Item2));
                        sw.Write(JumpLine());
                    }
                    else
                    {
                        sw.Write(WriteParagraph(random.Next(3, 50)));

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
                var result = sc.CreateSentenceChar(numberOfChars);
                if (result.Item1 <= 0)
                {
                    numberOfChars = 0;
                    break;
                }
                numberOfChars = result.Item1;
                paragraph += result.Item2;
            }
            return paragraph + "</p>";
        }
        private string WriteParagraph(int numberOfSentences)
        {
            string paragraph = "<p>";
            for (int i = 0; i < numberOfSentences; i++)
            {
                if(numberOfWords <= 0)
                {
                    break;
                }
                var result = sc.CreateSentence(numberOfWords);
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
                "body   {text-align: justify;}\r\n" +
                "</style>";
        }

    }
}
