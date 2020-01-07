using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Task_6.DAL.Awards;
using Task_6.Interfaces;

namespace Task_6.DAL.Users
{
    class UserParser
    {
        private Regex record_regex;
        private Regex awards_regex;
        private Regex fields_regex;

        public UserParser()
        {
            record_regex = new Regex("<<[^<>]+>>");
            awards_regex = new Regex("{[^{}]+}");
            fields_regex = new Regex("\"[^\"]+\"");
        }

        public User Parse(string input, IAwardKeeper award_keeper)
        {
            if (input[0] != input[1] && input[0] != '<')
            {
                throw new FormatException();
            }

            if (input[input.Length - 1] != input[input.Length - 2]
                && input[input.Length - 1] != '>')
            {
                throw new FormatException();
            }

            MatchCollection fields = fields_regex.Matches(input);

            if (fields.Count != 4)
            {
                throw new FormatException();
            }

            if (!int.TryParse(fields[0].Value.Replace("\"", ""), out var id))
            {
                throw new FormatException();
            }

            string name = fields[1].Value.Replace("\"", "");

            if (!DateTime.TryParse(fields[2].Value.Replace("\"", ""), out var dob))
            {
                throw new FormatException();
            }

            if (!int.TryParse(fields[3].Value.Replace("\"", ""), out var age))
            {
                throw new FormatException();
            }

            MatchCollection awards_match = awards_regex.Matches(input);

            string[] awards_str = new string[awards_match.Count];

            for (int i = 0; i < awards_match.Count; i++)
            {
                awards_str[i] = awards_match[i].Value.Replace("{", "").Replace("}", "");
            }

            IAward[] awards = awards_str.Select(
                (x) => (award_keeper.GetAward(x)))
                .ToArray();

            return new User(id, name, dob, age, awards);
        }

        public User[] ParseArray(string input, IAwardKeeper award_keeper)
        {
            MatchCollection records = record_regex.Matches(input);

            User[] res = new User[records.Count];

            for(int i = 0; i < records.Count; i++)
            {
                res[i] = Parse(records[i].Value, award_keeper);
            }

            return res;
        }
    }
}
