namespace DotNet;

public static class ObjectHelper {
    private static readonly Random _random = new ();

    public static string RandomString() {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
        return new string(Enumerable.Repeat(chars, 100)
            .Select(s => s[_random.Next(s.Length)])
            .ToArray());
    }

    public static DateTime RandomDay() {
        var start = new DateTime(2024,1,1);
        var range = (DateTime.Today - start).Days;
        return start.AddDays(_random.Next(range));
    }

    public static decimal RandomDecimal() {
        return _random.Next() / _random.Next();
    }
}