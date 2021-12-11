namespace AdventOfCode2021;

internal class SubmarineChar
{
    internal char Close { get; }
    
    internal SubmarineChar(char close)
    {
        Close = close;
    }
}

public class DayTen : AbstractDay
{
    private const string DayTenInputPath = "Inputs\\dayten.txt";

    private static Dictionary<char, int> _charPointsPartOne = new()
    {
        [')'] = 3,
        [']'] = 57,
        ['}'] = 1197,
        ['>'] = 25137
    };

    private static Dictionary<char, int> _charPointsPartTwo = new()
    {
        [')'] = 1,
        [']'] = 2,
        ['}'] = 3,
        ['>'] = 4
    };
    
    private static Dictionary<char, char> _openToClose = new()
    {
        ['('] = ')',
        ['['] = ']',
        ['{'] = '}',
        ['<'] = '>'
    };

    public override long PartOne()
    {
        long result = 0;
        string[] input = GetInput(DayTenInputPath);

        char illegalChar = char.MinValue;

        foreach (string line in input)
        {
            Stack<SubmarineChar> openChars = new();
            foreach (char ch in line)
            {
                if (ch is '(' or '[' or '{' or '<')
                {
                    openChars.Push(new SubmarineChar(_openToClose[ch]));
                }
                else if (openChars.Peek().Close == ch)
                {
                    openChars.Pop();
                }
                else
                {
                    illegalChar = ch;
                    
                    while (openChars.TryPeek(out SubmarineChar _))
                        openChars.Pop();
                    
                    break;
                }
            }
            
            // Incomplete line.
            if (openChars.Count != 0)
                continue;
            
            result += _charPointsPartOne[illegalChar];
            
        }

        return result;
    }

    public override long PartTwo()
    {
        string[] input = GetInput(DayTenInputPath);

        List<long> scores = new();

        foreach (string line in input)
        {
            Stack<SubmarineChar> openChars = new ();
            foreach (char ch in line)
            {
                if (ch is '(' or '[' or '{' or '<')
                {
                    openChars.Push(new SubmarineChar(_openToClose[ch]));
                }
                else if (openChars.Peek().Close == ch)
                {
                    openChars.Pop();
                }
                else
                {
                    while (openChars.TryPeek(out SubmarineChar _))
                        openChars.Pop();
                    
                    break;
                }
            }
            
            // Corrupted line.
            if (openChars.Count == 0)
                continue;

            long lineScore = 0;
            
            while (openChars.TryPeek(out SubmarineChar submarineChar))
            {
                lineScore *= 5;
                lineScore += _charPointsPartTwo[submarineChar.Close];
                openChars.Pop();
            }
            
            scores.Add(lineScore);
        }

        return scores.OrderBy(o => o).ToList()[scores.Count/2];
    }
}