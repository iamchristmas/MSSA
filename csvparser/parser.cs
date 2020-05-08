using System.Collections.Generic;

namespace CSVParser
{
    public class Parser
    {
        public static List<string> GetCSV(string s)
        {
            var output = new List<string>();
            var temp = "";
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '\"')
                    while (s[++i] != '\"')
                        temp += s[i];
                else if (s[i] != ',') temp += s[i];
                if (s[i] == ',')
                {
                    output.Add(temp);
                    temp = "";
                }
            }
            output.Add(temp);
            return output;
        }
    }
}