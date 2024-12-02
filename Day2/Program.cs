Console.WriteLine("Day 2");

List<string> inputLines = [.. File.ReadAllLines("./input.txt")];

//part 1
int safeReportsCount = 0;
foreach (string line in inputLines)
{
    List<int> report = line.Split(' ').Select(int.Parse).ToList();

    List<int> diffs = new();
    for (int i = 0; i < report.Count - 1; i++)
    {
        diffs.Add(report[i] - report[i + 1]);
    }

    if (!diffs.Any(x => Math.Abs(x) > 3))
    {
        if (diffs.All(x => x > 0) || diffs.All(x => x < 0))
        {
            safeReportsCount++;
        }
    }
}
Console.WriteLine(safeReportsCount);

//part 2
int safeReportsCountP2 = 0;
foreach (string line in inputLines)
{
    List<int> report = line.Split(' ').Select(int.Parse).ToList();

    int removeAt = -1;
    do
    {
        List<int> pico = report.ToList();
        if (removeAt > -1)
        {
            pico.RemoveAt(removeAt);
        }

        List<int> diffs = new();
        for (int i = 0; i < pico.Count - 1; i++)
        {
            diffs.Add(pico[i] - pico[i + 1]);
        }

        if (!diffs.Any(x => Math.Abs(x) > 3) &&
          (diffs.All(x => x > 0) || diffs.All(x => x < 0)))
        {
            safeReportsCountP2++;
            break;
        }
        else
        {
            removeAt++;
        }
    }
    while (removeAt < report.Count);

}
Console.WriteLine(safeReportsCountP2);