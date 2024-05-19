namespace DotNet.Models;

public class ComplexObject : BaseObject {
    public ComplexObject() : base() {
        var _random = new Random();
        Object = new SimpleObject();
        DateTimes = [];

        var num = _random.Next(1,10);
        for (int i=0; i <= num; i++) {
            DateTimes.Add(ObjectHelper.RandomDay());
        }
    }

    public SimpleObject Object { get; set; }
    public List<DateTime> DateTimes { get; set; }

    public override string ToString() {
        return $"{nameof(ComplexObject)}";
    }
}
