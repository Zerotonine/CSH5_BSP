using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace CSH5_BSP
{
    class RegExinator : IEnumerable
    {
        public string Text { get; set; }
        public string Pattern { get; set; }
        MatchCollection mc;

        public RegExinator(string text, string pattern)
        {
            Text = text;
            Pattern = pattern;
            Regex rx = new Regex(pattern);
            mc = rx.Matches(text);
        }

        public bool IsMatch()
        {
            return Regex.IsMatch(Text, Pattern);
        }

        public List<string> GetTreffer()
        {
            List<string> treffer = new List<string>();
            foreach (Match m in mc)
                treffer.Add(m.Value);
            return treffer;
        }

        public Match this[int index]
        {
            get => mc[index];
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Match m in mc)
                yield return m.Value;
        }
    }
}
