using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace remNamer.Class
{
    internal class PatternFinder
    {
        const int LENGTH_CRITERIA = 3;
        const int MIN_CRITERIA = 3;
        public const string TextForAnyInParenthesis = "(% Any %)";
        public const string TextForAnyInBrackets = "[% Any %]";

        public Dictionary<string, int> SearchPatterns(List<FileToRename> files)
        {
            if (files == null)
            {
                throw new ArgumentException("FilesToRename is null, be sure to call this class constructor with a valid collection.");
            }

            List<FileToRename> exampleItems = GetRandomItemsAsExample(files);

            List<string> namesWithoutExt = exampleItems.Select(o => o.NameWithoutExtension).ToList();
            string joinedNames = String.Join(" ", namesWithoutExt);

            Dictionary<string, int> patterns = CountPatterns(joinedNames);

            return patterns;
        }

        private Dictionary<string, int> CountPatterns(string text)
        {
            var dict = new Dictionary<string, int>();
            var regexItem = new Regex("[^a-zA-Z0-9_.]+");

            //Just cleaning up a bit
            text = text.Replace(",", "");

            //Create an array of words
            string[] splitedText = text.Split(new string[] { " ", "-", "[", "(", ")", "]" }, StringSplitOptions.RemoveEmptyEntries);

            // Sort the array by alphabetical order
            Array.Sort(splitedText);

            foreach (string word in splitedText)
            {
                if (word.Length >= LENGTH_CRITERIA || regexItem.IsMatch(word))
                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }
                    else
                    {
                        dict[word] = 1;
                    }
                }
            }

            //if (dict.Values.Count > 0)
            //{
            //    //Remove less common matches
            //    var maxValue = dict.Values.Max() / MIN_CRITERIA;
            //    var itemsToRemove = dict.Where(o => o.Value <= maxValue).ToList();
            //    foreach (var item in itemsToRemove)
            //    {
            //        dict.Remove(item.Key);
            //    }

            //    // Limit the dictionary to the top 10 elements
            //    dict = dict.OrderByDescending(o => o.Value).Take(10).ToDictionary(o => o.Key, o => o.Value);
            //}

            // Limit the dictionary to the top 10 elements
            dict = dict.OrderByDescending(o => o.Value).Take(10).ToDictionary(o => o.Key, o => o.Value);

            //Add standard for brackets and parenthesis
            dict.Add(TextForAnyInBrackets, 0);
            dict.Add(TextForAnyInParenthesis, 0);

            return dict;
        }

        private List<FileToRename> GetRandomItemsAsExample(List<FileToRename> files)
        {
            int numberOfItemsToPick = 5;
            if (files.Count > 50)
            {
                numberOfItemsToPick = Convert.ToInt32(files.Count / 5);
            }
            else if (files.Count > 80)
            {            
                numberOfItemsToPick = Convert.ToInt32(files.Count / 8);
            }
            else if (files.Count > 150)
            {
                numberOfItemsToPick = Convert.ToInt32(files.Count / 10);
            }
            else if (files.Count > 400)
            {
                numberOfItemsToPick = Convert.ToInt32(files.Count / 15);
            }

            //Pick X random items
            Random rnd = new Random();
            var exampleItems = new List<FileToRename>();
            for (int i = 0; i < numberOfItemsToPick; i++)
            {
                exampleItems.Add(files[rnd.Next(0, files.Count)]);
            }

            return exampleItems;
        }

    }
}
