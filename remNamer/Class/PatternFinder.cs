using System;
using System.Collections.Generic;
using System.Linq;

namespace remNamer.Class
{
    internal class PatternFinder
    {
        const int LENGTH_CRITERIA = 3;
        const int MIN_CRITERIA = 3;

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
            Dictionary<string, int> dict = new Dictionary<string, int>();

            //Just cleaning up a bit
            text = text.Replace(",", "");

            //Create an array of words
            string[] arr = text.Split(' ');

            foreach (string word in arr)
            {
                if (word.Length >= LENGTH_CRITERIA)
                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word] = dict[word] + 1;
                    }
                    else
                    {
                        dict[word] = 1;
                    }
                }
            }

            //Remove less common matches
            var maxValue = dict.Values.Max() / MIN_CRITERIA;
            var itemsToRemove = dict.Where(o => o.Value <= maxValue).ToList();
            foreach (var item in itemsToRemove)
            {
                dict.Remove(item.Key);
            }

            return dict;
        }

        private List<FileToRename> GetRandomItemsAsExample(List<FileToRename> files)
        {
            int numberOfItemsToPick = Convert.ToInt32(files.Count / 8);

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
