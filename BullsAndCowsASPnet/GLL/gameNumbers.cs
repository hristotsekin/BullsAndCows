using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BullsAndCowsASPnet.ViewModels;

namespace BullsAndCowsASPnet.GLL
{
    public class GameNumbers
    {
        
        public int Cows(string pcNumber, string userNumber)
        {
            int cowsCout = 0;
            for (int i = 0; i < pcNumber.Length; i++)
            {
                if (pcNumber.Contains(userNumber.ElementAt(i)) && pcNumber.IndexOf(userNumber.ElementAt(i)) != i)
                {
                    cowsCout++;
                }
            }


            return cowsCout;
        }

        public static bool isContainingWrightAnswer(List<GamePlayViewModel> rounds)
        {

            var answer = rounds.Where(round => round.IsWantedNumber == true).FirstOrDefault();
            return answer != null ? false : true;

        }

        public int Bulls(string pcNumber, string userNumber)
        {
            int bullsCout = 0;
            if (pcNumber.Length == userNumber.Length)
            {
                for (int i = 0; i < pcNumber.Length; i++)
                {
                    if (pcNumber.ElementAt(i) == userNumber.ElementAt(i))
                    {
                        bullsCout++;
                    }
                }
            }

            return bullsCout;
        }


        public bool isValidUserNumber(string number, int numLength)
        {
            Dictionary<char, int> dupllicateList = new Dictionary<char, int>();

            if (Int32.TryParse(number, out _) && number.Length == numLength)
            {
                for (int i = 0; i < numLength; i++)
                {
                    if (!dupllicateList.ContainsKey(number.ElementAt(i)))
                    {
                        dupllicateList.Add(number.ElementAt(i), 1);
                    }
                    else
                    {
                        dupllicateList[number.ElementAt(i)]++;
                    }
                }
            }
            else
            {
                return false;
            }

            foreach (var item in dupllicateList)
            {
                if (item.Value != 1) 
                    return false;
            }

            return true;


        }


        public string UniqueNumberGenerator(int size, int raunds = 0)
        {
            StringBuilder numbers = new StringBuilder();
            int itr = 0;

            
            while (itr < size)
            {
                Random r = new Random();
                int tmpNumber;
                if (itr == 0)
                {
                    tmpNumber = r.Next(1, 9);
                }
                else
                {
                    tmpNumber = r.Next(0, 9);
                }

                if (!numbers.ToString().Contains(Convert.ToString(tmpNumber)))
                {
                    numbers.Append(tmpNumber.ToString());
                    itr++;
                }
            }
            return numbers.ToString();
        }
    }
}