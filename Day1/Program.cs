Console.WriteLine("Day 1");

List<string> inputLines = [.. File.ReadAllLines("./input.txt")];

List<int> left = inputLines.Select(x => int.Parse(new string([.. x.TakeWhile(y => !char.IsWhiteSpace(y))]))).Order().ToList();
List<int> right = inputLines.Select(x => int.Parse(new string([.. x.SkipWhile(y => !char.IsWhiteSpace(y))]))).Order().ToList();

//part 1
int difsSum = 0;
for (int i = 0; i < left.Count; i++)
{
    difsSum += Math.Abs(left[i] - right[i]);
}
Console.WriteLine(difsSum);

//part 2
int similarityScoresSum = 0;
Dictionary<int, int> rightDistinctNumsCounts = right.GroupBy(x => x).ToDictionary( x => x.Key, x => x.Count());
for (int i = 0; i < left.Count; i++)
{
    if (rightDistinctNumsCounts.TryGetValue(left[i], out int value))
    {
        similarityScoresSum += left[i] * value;
    }
}
Console.WriteLine(similarityScoresSum);