using System.Text.RegularExpressions;

Console.WriteLine("Day 3");
string input = File.ReadAllText("./input.txt");

MatchCollection muls = Regex.Matches(input, @"mul\(\d{1,3},\d{1,3}\)");

//part 1
int sum = 0;
foreach (Match match in muls)
{
    var numbers = Regex.Matches(match.Value, @"\d+").Select(x => int.Parse(x.Value)).ToList();

    sum += numbers[0] * numbers[1];
}
Console.WriteLine(sum);

//part 2
List<int> dosIdexes = Regex.Matches(input, @"do\(\)").Select(x => x.Index).Order().ToList();
List<int> dontsIndexes = Regex.Matches(input, @"don't\(\)").Select(x => x.Index).Order().ToList();

int sumP2 = 0;
foreach (Match match in muls)
{
    int lastDoIndex = dosIdexes.Where(x => x < match.Index).LastOrDefault();
    int lastDontIndex = dontsIndexes.Where(x => x < match.Index).LastOrDefault();
   
    if (lastDoIndex >= lastDontIndex)
    {
        var numbers = Regex.Matches(match.Value, @"\d+").Select(x => int.Parse(x.Value)).ToList();
        sumP2 += numbers[0] * numbers[1];
    }
}

Console.WriteLine(sumP2);