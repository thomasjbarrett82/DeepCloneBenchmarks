using DotNet.Models;

namespace DotNet;

public static class ObjectHelper {
    private static readonly Random _random = new ();

    public static SimpleObject CreateSimpleObject() {
        return new SimpleObject {
            Id = _random.NextInt64(),
            UniqueId = Guid.NewGuid(),
            Name = RandomString(),
            Description = RandomString(),
            Comment = RandomString(),
            StartDate = RandomDay(),
            EndDate = RandomDay(),
            IntValue = _random.Next(),
            DecimalValue = RandomDecimal(),
            FloatValue = _random.NextSingle(),
        };
    }

    public static ComplexObject CreateComplexObject() {
        var complexObject = new ComplexObject {
            Id = _random.NextInt64(),
            UniqueId = Guid.NewGuid(),
            Name = RandomString(),
            Description = RandomString(),
            Comment = RandomString(),
            Object = CreateSimpleObject(),
            DateTimes = []
        };
        var num = _random.Next(1,10);
        for (int i=0; i <= num; i++) {
            complexObject.DateTimes.Add(RandomDay());
        }
        return complexObject;
    }

    public static VeryComplexObject CreateVeryComplexObject() {
        var veryComplexObject = new VeryComplexObject {
            Id = _random.NextInt64(),
            UniqueId = Guid.NewGuid(),
            Name = RandomString(),
            Description = RandomString(),
            Comment = RandomString(),
            ComplexObjects = new List<ComplexObject>(),
            Guids = new List<Guid>(),
            OtherNames = new List<string>()

        };
        var num = _random.Next(1,10);
        for (int i=0; i <= num; i++) {
            veryComplexObject.ComplexObjects.Add(CreateComplexObject());
            veryComplexObject.Guids.Add(Guid.NewGuid());
            veryComplexObject.OtherNames.Add(RandomString());
        }
        return veryComplexObject;
    }

    private static string RandomString() {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
        return new string(Enumerable.Repeat(chars, 100)
            .Select(s => s[_random.Next(s.Length)])
            .ToArray());
    }

    private static DateTime RandomDay() {
        var start = new DateTime(2024,1,1);
        var range = (DateTime.Today - start).Days;
        return start.AddDays(_random.Next(range));
    }

    private static decimal RandomDecimal() {
        return _random.Next() / _random.Next();
    }
}