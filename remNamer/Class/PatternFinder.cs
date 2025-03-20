using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace remNamer.Class
{
    internal class PatternFinder
    {
        const int LENGTH_CRITERIA = 3;
        const double thresholdPercentage = 0.1;
        public const string TextForAnyInParenthesis = "(% Any %)";
        public const string TextForAnyInBrackets = "[% Any %]";

        public Dictionary<string, int> SearchPatterns(List<FileToRename> files)
        {
            if (files == null)
            {
                throw new ArgumentException("files is null, be sure to call this class constructor with a valid collection.");
            }

            List<FileToRename> exampleItems = GetRandomItemsAsExample(files);

            List<string> namesWithoutExt = exampleItems.Select(o => o.NameWithoutExtension).ToList();
            string joinedNames = String.Join(" ", namesWithoutExt);

            Dictionary<string, int> patterns = CountPatterns(joinedNames);

            return patterns;
        }

        private Dictionary<string, int> CountPatterns(string text)
        {
            var patternsFound = new Dictionary<string, int>();
            var regexItem = new Regex("[^a-zA-Z0-9_.]+");

            //Just cleaning up a bit
            text = text.Replace(",", "");

            //Create an array of words
            string[] separators = text.Split(new string[] { " ", ".", "-", "[", "(", ")", "]" }, StringSplitOptions.RemoveEmptyEntries);

            // Sort the array by alphabetical order
            Array.Sort(separators);

            foreach (string word in separators)
            {
                if (word.Length >= LENGTH_CRITERIA || regexItem.IsMatch(word))
                {
                    if (patternsFound.ContainsKey(word))
                    {
                        patternsFound[word]++;
                    }
                    else
                    {
                        patternsFound[word] = 1;
                    }
                }
            }


            // Find the maximum value in the dictionary
            int maxValue = patternsFound.Values.Max();

            // Calculate the threshold as a percentage of the maximum value           
            int threshold = (int)(maxValue * thresholdPercentage);

            // Limit the dictionary to the top elements with value > threshold
            patternsFound = patternsFound.Where(o => o.Value > threshold)
                                           .OrderByDescending(o => o.Value)
                                           .Take(15)
                                   .ToDictionary(o => o.Key, o => o.Value, StringComparer.OrdinalIgnoreCase);


            //Add standard for brackets and parenthesis
            patternsFound.Add(TextForAnyInBrackets, 0);
            patternsFound.Add(TextForAnyInParenthesis, 0);

            return patternsFound;
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
