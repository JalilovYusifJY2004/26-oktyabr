internal static class ProgramHelpers
{
    public static void Delete(string name)
    {
        List<string> names = DeserializeData();
        names.Remove(name);
        SerializeData(names);
    }
    public static bool Search(string name, Predicate<string> condition)
    {
        List<string> names = DeserializeData();
        return names.Any(condition);
    }
}