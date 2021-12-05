using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingDeckOfCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortingController : ControllerBase
    {
        [HttpPost]
        public List<string> DoSorting([FromBody]List<string> cardsList)
        {
            try
            {
                for (int j = 0; j <= cardsList.Count - 2; j++)
                {
                    for (int i = 0; i <= cardsList.Count - 2; i++)
                    {
                        var c1 = cardsList[i].ToCharArray();
                        var c2 = cardsList[i + 1].ToCharArray();
                        string k1, k2, s1, s2;
                        if (c1.Length == 3)
                        {
                            k1 = "10";
                            s1 = c1[2].ToString();
                        }
                        else
                        {
                            k1 = c1[0].ToString();
                            s1 = c1[1].ToString();
                        }

                        if (c2.Length == 3)
                        {
                            k2 = "10";
                            s2 = c2[2].ToString();
                        }
                        else
                        {
                            k2 = c2[0].ToString();
                            s2 = c2[1].ToString();
                        }

                        if (s1 != s2)
                        {
                            var d = (int)(Suit)Enum.Parse(typeof(Suit), s1);
                            var e = (int)(Suit)Enum.Parse(typeof(Suit), s2);

                            if (d > e)
                            {
                                var temp = cardsList[i + 1];
                                cardsList[i + 1] = cardsList[i];
                                cardsList[i] = temp;
                            }
                        }

                        if (k1 != k2 && s1 == s2)
                        {
                            var firstCardName = GetStringName(k1);
                            var secondCardName = GetStringName(k2);
                            var d = (int)(Kind)Enum.Parse(typeof(Kind), firstCardName);
                            var e = (int)(Kind)Enum.Parse(typeof(Kind), secondCardName);

                            if (d > e)
                            {
                                var temp = cardsList[i + 1];
                                cardsList[i + 1] = cardsList[i];
                                cardsList[i] = temp;
                            }
                        }


                    }
                }


                return cardsList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private  string GetStringName(string ch)
        {
            switch (ch)
            {
                case "2":
                    return "Two";
                    break;
                case "3":
                    return "Three";
                    break;
                case "4":
                    return "Four";
                    break;
                case "5":
                    return "Five";
                    break;
                case "6":
                    return "Six";
                    break;
                case "7":
                    return "Seven";
                    break;
                case "8":
                    return "Eight";
                    break;
                case "9":
                    return "Nine";
                    break;

                case "10":
                    return "Ten";
                    break;
                case "J":
                    return "Jack";
                    break;
                case "Q":
                    return "Queen";
                    break;
                case "K":
                    return "King";
                    break;
                case "A":
                    return "Ace";
                    break;
                default: return String.Empty;
            }
        }
    }
    enum Kind
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    enum Suit
    {
        d,
        s,
        c,
        h,
    }
}
