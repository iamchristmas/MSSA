using System.Collections.Generic;

namespace CSVParser
{
    public class Parser
    {
        public static List<string> GetCSV(string s)
        {
            List<string> output = new List<string>();
            string temp = "";
            for (int i = 0; i < s.Length; i++)                     
            {
                if (s[i] == '\"')
                {
                    while (s[++i] != '\"')
                    {
                        temp += s[i];
                    }
                    
                }
                else if(s[i] != ',')
                {
                    temp += s[i];
                }
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
