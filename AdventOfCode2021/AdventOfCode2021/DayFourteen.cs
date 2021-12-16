namespace AdventOfCode2021
{
    public class DayFourteen : AbstractDay
    {
        private const string DayFourteenInputPath = "Inputs\\dayfourteen.txt";

        public override long PartOne() 
        {
            (string temp, List<string> rules) = GetInput();
            List<char> pairs = temp.ToList();

            int steps = 1;

            while (steps <= 10)
            {
                List<char> newPair = new();
                // N, N -> C | NC (while the other N gets carried over)
                // N, C -> B | NB (while C gets carried over)
                // C, B -> H | CH (while B gets carried over)
                // B
                // NCNBCHB

                for (int i = 1; i < pairs.Count; i++)
                {
                     char el1 = pairs[i - 1];
                     char el2 = pairs[i];

                     newPair.Add(el1);
                     newPair.Add(GetValueFromRule(el1, el2, rules));
                     if (i == pairs.Count - 1)
                         newPair.Add(el2);
                }

                pairs = newPair;
                steps++;
            }

            (long max, long min) = GetMaxAndMinOccurrences(pairs);

            return max - min;
        }

        public override long PartTwo() 
        {
            (string temp, List<string> rules) = GetInput();
            Dictionary<string, long> pairsAndCount = GetInitialPairsWithCountFromTemplate(temp);
            Dictionary<string, string> parsedRules = ParseRules(rules);

            int steps = 1;
            long result = 0;

            while (steps <= 41)
            {
                if (steps == 41)
                {
                    Dictionary<char, long> charCount = new();
                    foreach (var pair in pairsAndCount)
                    {
                        if (charCount.ContainsKey(pair.Key[0]))
                        {
                            charCount[pair.Key[0]] += pairsAndCount[pair.Key];
                        }
                        else
                        {
                            charCount.Add(pair.Key[0], pairsAndCount[pair.Key]);
                        }
                    }

                    char a = temp[^1];

                    if (charCount.ContainsKey(a))
                    {
                        charCount[a] += 1;
                    }
                    else
                    {
                        charCount.Add(a, 1);
                    }
                    
                    result = charCount.Values.Max() - charCount.Values.Min();
                }

                Dictionary<string, long> C2 = new();

                foreach (var pair in pairsAndCount)
                {
                    if (C2.ContainsKey(pair.Key[0] + parsedRules[pair.Key]))
                    {
                        C2[pair.Key[0] + parsedRules[pair.Key]] += pairsAndCount[pair.Key];
                    }
                    else
                    {
                        C2.Add(pair.Key[0] + parsedRules[pair.Key], pairsAndCount[pair.Key]);
                    }

                    if (C2.ContainsKey(parsedRules[pair.Key] + pair.Key[1]))
                    {
                        C2[parsedRules[pair.Key] + pair.Key[1]] += pairsAndCount[pair.Key];
                    }
                    else
                    {
                        C2.Add(parsedRules[pair.Key] + pair.Key[1], pairsAndCount[pair.Key]);
                    }
                }

                pairsAndCount = C2;

                steps++;
            }

            return result;
        }

        private static (string, List<string>) GetInput() 
        {
            string[] lines = GetInput(DayFourteenInputPath); 

            string template = string.Empty;

            List<string> rules = new();

            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0)
                {
                    template = lines[i];
                    // the next line is empty in the input.
                    i++;
                }
                else
                {
                    rules.Add(lines[i]);
                }
            }

            return (template, rules);
        }

        private static (long, long) GetMaxAndMinOccurrences(List<char> pairs)
        {
            Dictionary<char, long> occurrences = new();

            foreach (char ch in pairs)
            {
                if (occurrences.ContainsKey(ch))
                {
                    occurrences[ch]++;
                }
                else
                {
                    occurrences.Add(ch, 1);
                }
            }

            Console.WriteLine(string.Join(", ", occurrences.Select(s => $"{s.Key} - {s.Value}")));

            return (occurrences.Max(m => m.Value), occurrences.Min(m => m.Value));
        }

        private static char GetValueFromRule(char el1, char el2, List<string> rules)
        {
            foreach (var rule in rules)
            {
                string[] split = rule.Split(" -> ");

                if (split[0][0] == el1 && split[0][1] == el2)
                    return split[1][0];
            }

            // Should never happen.
            return char.MinValue;
        }

        private static Dictionary<string, string> ParseRules(List<string> rules)
        {
            Dictionary<string, string> pairsOfRules = new();

            foreach (var line in rules)
            {
                string[] split = line.Split(" -> ");

                pairsOfRules.Add(split[0], split[1]);
            }

            return pairsOfRules;
        }

        private static Dictionary<string, long> GetInitialPairsWithCountFromTemplate(string template)
        {
            Dictionary<string, long> pairsWithCount = new();

            for (int i = 1; i < template.Length; i++)
            {
                string pair = $"{template[i - 1]}{template[i]}";

                if (pairsWithCount.ContainsKey(pair))
                {
                    pairsWithCount[pair]++;
                }
                else
                {
                    pairsWithCount.Add(pair, 1);
                }
            }
            
            return pairsWithCount;
        }
    }
}
