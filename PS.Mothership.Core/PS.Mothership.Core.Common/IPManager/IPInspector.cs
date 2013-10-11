using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using PS.Mothership.Core.Common.Constants;
using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Core.Common.IPManager
{
    public sealed class IPInspector
    {
        /// <summary>
        ///     Is IP Address valid
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns></returns>
        public static bool IsValid(string ipString)
        {                      
            // Create an instance of IPAddress for the specified address string (in  
            // dotted-quad, or colon-hexadecimal notation).
            IPAddress ipAddress;
            return IPAddress.TryParse(RemoveLeadingZero(ipString), out ipAddress);                                    
        }

        /// <summary>
        ///     Checks and gives back an ip address
        /// </summary>
        /// <param name="ipString"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool IsValid(string ipString, out IPAddress ipAddress)
        {                     
            return IPAddress.TryParse(RemoveLeadingZero(ipString), out ipAddress);
        }

        /// <summary>
        ///     Check two IpAddress are equal
        /// </summary>
        /// <param name="ipStringA"></param>
        /// <param name="ipStringB"></param>
        /// <returns></returns>
        public static bool Equal(string ipStringA, string ipStringB)
        {
            IPAddress a;
            IPAddress b;

            // if both are vaid
            if (IsValid(RemoveLeadingZero(ipStringA), out a) && IsValid(RemoveLeadingZero(ipStringB), out b))
            {
                return a.Equals(b);
            }

            // return
            return false;
        }

        /// <summary>
        ///     Compare wild card ipaddress
        ///     This builds the required rule and compare against
        ///     the data source
        /// </summary>
        /// <returns></returns>
        public static bool WildCardCompare(string ipString, List<string> ipList, char replaceCard = GlobalConstants.Star)
        {
            // if a dot comes throug as replace card, switch to '*'
            char replaceCardLocal = replaceCard == GlobalConstants.Dot ? GlobalConstants.Star : replaceCard;
           

            IPAddress ipAddress;
            if (!IsValid(ipString, out ipAddress)) return false;

            // ipString Loader
            // if we are we know the ipAddress is valid
            // lets build a list of ipaddress string with replace card
            // to check against the ipList
            // The ipList may contains values with replaceCard
            List<string> ipStringList = AppendOctal(ipString, replaceCardLocal);
            ipStringList.AddRange(CustomOctal(ipString, replaceCardLocal));

            // if we can find one combination in the iplist
            // set it to true
            return ipList.Intersect(ipStringList).Any();            
        }
        
        /// <summary>
        ///     Remove leading zeros from ip address
        /// </summary>
        /// <param name="ipString"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static string RemoveLeadingZero(string ipString, bool regex=false)
        {
            // validation
            if (string.IsNullOrWhiteSpace(ipString)) return ipString;        

            string result;
            if (!regex)
            {
                var dList = ipString.Split(GlobalConstants.Dot);
                var data = dList.Select(s =>
                {
                    int oresult;
                    if (int.TryParse(s, out oresult) && oresult != 0) return s.TrimStart('0');
                    return s;
                }).ToList();
                result = string.Join(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture), data);                
            }
            else
            {
                result = Regex.Replace(ipString, "0*([0-9]+)", "${1}");               
            }

            // return
            return result;
        }

        /// <summary>
        ///     octal/start appender
        /// </summary>
        /// <param name="ipString"></param>
        /// <param name="replaceCard"></param>
        /// <returns></returns>
        public static List<string> AppendOctal(string ipString,
            char replaceCard = GlobalConstants.Star)
        {
            var sb = new StringBuilder();
            string[] ipStringList = ipString.Split(GlobalConstants.Dot);
            int strLength = ipStringList.Length;
            var returnVal = new List<string>();

            for (int i = 0; i < strLength; i++)
            {
                // append the data
                for (int j = 0; j <= i; j++)
                {
                    sb.Append(ipStringList[j]);
                    if (j < strLength - 1) sb.Append(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture));
                }

                // loop and append the dot and replacecard data
                int charLength = strLength - (i + 1);
                for (int k = 0; k < charLength; k++)
                {
                    sb.Append(replaceCard.ToString(CultureInfo.InvariantCulture));
                    if (k != charLength - 1) sb.Append(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture));
                }

                // add to list
                // and clear the string builder
                returnVal.Add(sb.ToString());
                sb.Clear();
            }

            // return
            return returnVal;
        }

        /// <summary>
        ///     Add custom octal
        /// </summary>
        /// <param name="ipString"></param>
        /// <param name="replaceCard"></param>
        /// <returns></returns>
        public static List<string> CustomOctal(string ipString,
            char replaceCard = GlobalConstants.Star)
        {
            var sb = new StringBuilder();
            string[] ipStringList = ipString.Split(GlobalConstants.Dot);
            int strLength = ipStringList.Length;            

            // Add a single star
            var returnVal = new List<string> { replaceCard.ToString(CultureInfo.InvariantCulture) };

            // Add common star
            for (int i = 0; i < strLength; i++)
            {
                // loop and append the dot and replacecard data                
                sb.Append(replaceCard.ToString(CultureInfo.InvariantCulture));
                if (i != strLength - 1) sb.Append(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture));
            }

            // add to list
            // and clear the string builder
            returnVal.Add(sb.ToString());
            sb.Clear();

            // Add country star
            sb.Append(ipStringList[0] + GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture) +
                      replaceCard.ToString(CultureInfo.InvariantCulture));
            // add
            returnVal.Add(sb.ToString());
            sb.Clear();

            // Add two level
            sb.Append(ipStringList[0] + GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture) +
                      (strLength > 1 ? ipStringList[1] + GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture) +
                      replaceCard.ToString(CultureInfo.InvariantCulture):string.Empty));

            // add and clear
            returnVal.Add(sb.ToString());
            sb.Clear();

            // return
            return returnVal;
        }

        /// <summary>
        ///     Find whether a matching IP address exists        
        /// </summary>
        /// <remarks>
        ///     Compares character by character against the data source
        ///     Inital Match Logic - match the first 3 character, its mandatory, number starts at 0;
        /// </remarks>
        /// <param name="ipString">in coming ip address</param>
        /// <param name="ipList">list of ip address to check</param>
        /// <param name="isMatch">whether a match is found</param>
        /// <param name="firstMatch">give all the matching or the first one</param>
        /// <returns></returns>
        public static Dictionary<string,int> Find(string ipString,
            List<string> ipList, out bool isMatch, bool firstMatch = true)
        {
            var matchStore = new Dictionary<string, int>();
            isMatch = false;
                  
            #region validation & filtering
            
            // valid the incoming ip address first
            IPAddress ipAddress;
            if (!IsValid(ipString, out ipAddress)) return matchStore;            

            // valid ipList string
            if (ipList == null || ipList.Count == 0) return matchStore;
            

            #region sorting commented
            // order by length, to find the strongest match
            // first, also filter the ip based on the first
            // octal of the incoming ipaddress
            //int whereIsDot = ipString.IndexOf(GlobalConstants.Dot);
            //string startString = whereIsDot >= 0
            //    ? ipString.Substring(0, whereIsDot)
            //    : ipString;
            //var sortedlistIpString = (from s in ipList.ToList()
            //                          where s.StartsWith(startString) 
            //                          orderby s.Length descending
            //                          select s).ToList();

            //var sortedlistIpString = (from s in ipList.ToList()                                      
            //                          orderby s.Length descending
            //                          select s).ToList();
            #endregion

            var sortedlistIpString = ipList;


            // if we don't have sortedlist ipstring return
            if (sortedlistIpString.Count == 0) return matchStore;         

            #endregion                                              

            // do the padding for the in coming ip string
            ipString = PadIpString(ipString);            

            #region compare and do the scoring

            foreach (var dipData in sortedlistIpString)
            {
                var dip = PadIpString(dipData);
                int matchScore = 0;
                int dipLength = dip.Length;
                bool scoreGiven = false;

                #region built score

                for (int i = 0; i < dipLength; i++)
                {
                    // if a dot continue to the next match
                    if (dip[i] == GlobalConstants.Dot) continue;

                    // if an exact match
                    if (dip[i] == ipString[i])
                    {
                        matchScore += GlobalConstants.ExactMatchScore;
                        scoreGiven = true;
                    }

                    // if a star encountered
                    // "some time the first/second character
                    //  might be a star so the scoring 
                    //  would be done at the exact match"
                    if (dip[i] == GlobalConstants.Star &&
                        scoreGiven == false)
                    {
                        matchScore += GlobalConstants.WildCardMatchScore;
                        scoreGiven = true;
                    }

                    // if a score is not give then we should break
                    if (scoreGiven == false)
                    {
                        matchScore = 0;
                        break;
                    }

                    // we know at this point the first 3 octal is not a match
                    // 'InitalMatch' which is '2' should be equal to 'i' value of '2'
                    // and the matchScore should be 15, as the first 3 character
                    // should be exact match
                    if (GlobalConstants.InitalMatch == i &&
                        matchScore != (GlobalConstants.ExactMatchScore * (GlobalConstants.InitalMatch + 1)))
                    {
                        matchScore = 0;
                        break;
                    }

                    // reset scoreGiven
                    scoreGiven = false;
                }

                #endregion

                // if already in dictonary or no match score continue
                if (matchStore.ContainsKey(dipData) || matchScore <= 0) continue;

                // load into dictionary
                matchStore.Add(dipData, matchScore);
                
                if (!firstMatch || matchStore.Count <= 0) continue;

                // if we just have the first match break here
                isMatch = true;
                return matchStore;
            }

            #endregion
            
            // if no data retrun
            if (matchStore.Count <= 0) return matchStore;

            // set up isMatch
            // if we are here to true
            isMatch = true;

            // top score at first, if the firsMatch is set then don't need to
            // order it
            var ordered = matchStore.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return ordered;            
        }

        /// <summary>
        ///     Pad IP address
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns></returns>
        public static string PadIpString(string ipString)
        {            
            var dList = ipString.Split(GlobalConstants.Dot);
            var data = dList.Select(s => s.PadLeft(GlobalConstants.IPAddressPadding, GlobalConstants.Star)).ToList();
            return string.Join(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture), data);            
        }

        /// <summary>
        ///     NOT TESTED DON'T USE IT
        ///     Find whether a matching IP address exists        
        /// </summary>
        /// <remarks>
        ///     Compares character by character against the data source
        ///     Inital Match Logic - match the first 3 character, its mandatory, number starts at 0;
        /// </remarks>
        /// <param name="ipString">in coming ip address</param>
        /// <param name="ipList">list of ip address to check</param>
        /// <param name="isMatch">whether a match is found</param>
        /// <param name="firstMatch">give all the matching or the first one</param>
        /// <returns></returns>
        public static Dictionary<string, int> FindFaster(string ipString,
            List<string> ipList, out bool isMatch, bool firstMatch = true)
        {
            var matchStore = new Dictionary<string, int>();
            isMatch = false;

            #region validation & filtering

            // valid the incoming ip address first
            IPAddress ipAddress;
            if (!IsValid(ipString, out ipAddress)) return matchStore;

            // valid ipList string
            if (ipList == null || ipList.Count == 0) return matchStore;                                    

            #endregion            

            #region compare and do the scoring
            
            foreach (var dip in ipList)
            {                
                int matchScore = 0;
                int dipLength = dip.Length;
                bool scoreGiven = false;

                #region built score

                int j = 0;                
                for (int i = 0; i < dipLength; i++)
                {                    
                    // if a dot continue to the next match
                    if (dip[i] == GlobalConstants.Dot)
                    {
                        j++;
                        continue;
                    }
                                                            
                    // if an exact match
                    if (dip[i] == ipString[j])
                    {
                        matchScore += GlobalConstants.ExactMatchScore;
                        scoreGiven = true;                        
                    }

                    // if a star encountered
                    // "some time the first/second character
                    //  might be a star so the scoring 
                    //  would be done at the exact match"
                    if (dip[i] == GlobalConstants.Star &&
                        scoreGiven == false)
                    {
                        matchScore += GlobalConstants.WildCardMatchScore;
                        scoreGiven = true;                       
                    }

                    // if a score is not give then we should break
                    if (scoreGiven == false)
                    {
                        matchScore = 0;
                        break;
                    }

                    // we know at this point the first 3 octal is not a match
                    // 'InitalMatch' which is '2' should be equal to 'i' value of '2'
                    // and the matchScore should be 15, as the first 3 character
                    // should be exact match
                    if (GlobalConstants.InitalMatch == i &&
                        matchScore != (GlobalConstants.ExactMatchScore * (GlobalConstants.InitalMatch + 1)))
                    {
                        matchScore = 0;
                        break;
                    }

                    // reset scoreGiven
                    scoreGiven = false;

                    // also move the ipString pointer to 
                    // the next number, if we encounter a '*'
                    if (dip[i] == GlobalConstants.Star)
                    {                        
                        j = ipString.IndexOf(GlobalConstants.Dot, j) + 1;
                    }
                    else
                    {
                        j++;    
                    }
                    
                }

                #endregion

                // if already in dictonary or no match score continue
                if (matchStore.ContainsKey(dip) || matchScore <= 0) continue;

                // load into dictionary
                matchStore.Add(dip, matchScore);

                if (!firstMatch || matchStore.Count <= 0) continue;

                // if we just have the first match break here
                isMatch = true;
                return matchStore;
            }

            #endregion

            // if no data retrun
            if (matchStore.Count <= 0) return matchStore;

            // set up isMatch
            // if we are here to true
            isMatch = true;

            // top score at first, if the firsMatch is set then don't need to
            // order it
            var ordered = matchStore.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return ordered;
        }

        /// <summary>
        ///     Pad IP address
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns></returns>
        public static string PadIpString_DebugStopwatch_Usage(string ipString)
        {
            Stopwatch stopwatch = null;
            DebugStopwatch.Start(ref stopwatch);

            var dList = ipString.Split(GlobalConstants.Dot);
            var data = dList.Select(s => s.PadLeft(GlobalConstants.IPAddressPadding, GlobalConstants.Star)).ToList();
            var result = string.Join(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture), data);

            DebugStopwatch.Stop(ref stopwatch);
            DebugStopwatch.DurationInMilliseconds("PadIPString:", ref stopwatch);

            // return
            return result;
        }
    }
}