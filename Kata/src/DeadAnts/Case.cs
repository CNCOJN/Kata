namespace DeadAnts;

public class Case
{
    public int GetDeadAntCount(string ants)
    {
        if (HaveNoAnts(ants)) return default;
        var deadAntBodies = GetDeadAntBodies(ants);
        if (HaveNoDeadAntBodies(deadAntBodies)) return default;
        var totalDeadAntCount = GetTotalDeadAntCount(deadAntBodies);
        return totalDeadAntCount;
    }

    private static bool HaveNoAnts(string ants) => string.IsNullOrEmpty(ants?.Trim());

    private static bool HaveNoDeadAntBodies(string deadAntBodies) => deadAntBodies == string.Empty;

    private static string GetDeadAntBodies(string ants)
    {
        var foundDeadAntBodies = ants
            .Replace("ant", String.Empty, StringComparison.OrdinalIgnoreCase)
            .Split(new[] {' ', '.'}, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(string.Empty, foundDeadAntBodies);
    }

    private static int GetTotalDeadAntCount(string deadAntBodies) => deadAntBodies
        .ToLowerInvariant()
        .GroupBy(x => x)
        .Max(x => x.Count());
}