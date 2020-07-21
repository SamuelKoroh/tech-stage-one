using System;
using System.Collections.Generic;
using System.Linq;

namespace SocksLaundryLib
{
    public class ClassLib
    {

        //Do not delete or edit this method, you can only modify the block

        public int GetMaximumPairOfSocks(int noOfWashes, int[] cleanPile, int[] dirtyPile)
        {
            ValidateSocks(noOfWashes, cleanPile, dirtyPile);

            Array.Sort(cleanPile);
            Array.Sort(dirtyPile);

            var cleanPileList = cleanPile.ToList();
            var dirtyPileList = dirtyPile.ToList();
            var dictionary = new Dictionary<int, int>();
            var cleanPairs = 0;

            foreach (var item in cleanPileList)
            {
                if (dictionary.ContainsKey(item))
                    dictionary[item]++;
                else
                    dictionary.Add(item, 1);
            }

            if (noOfWashes > 0)
            {
                for (var i = 0; i < dirtyPileList.Count; i++)
                {
                    if (noOfWashes == 0)
                        break;

                    if (dictionary.Any(x => x.Key == dirtyPileList[i] && x.Value % 2 == 1))
                    {
                        dictionary[dirtyPileList[i]]++;
                    }
                    else
                    {
                        if (dictionary.ContainsKey(dirtyPileList[i]))
                            dictionary[dirtyPileList[i]]++;
                        else
                            dictionary.Add(dirtyPileList[i], 1);
                    }

                    noOfWashes -= 1;
                }
            }


            foreach (var item in dictionary)
                cleanPairs += Convert.ToInt32(Math.Floor((double)item.Value / 2));

            return cleanPairs;
        }

        private void ValidateSocks(int noOfWashes, int[] cleanPile, int[] dirtyPile)
        {
            if (noOfWashes < 0 || noOfWashes > 50)
                throw new ArgumentException("no sock must be between 0 to 50");

            if (cleanPile.Length < 1 || cleanPile.Length > 50)
                throw new ArgumentException("clean sock's most be between 1 to 50");

            if (dirtyPile.Length < 1 || dirtyPile.Length > 50)
                throw new ArgumentException("clean sock's most be between 1 to 50");

        }
            /**
             * You can create various helper methods
             * */
        }
}
