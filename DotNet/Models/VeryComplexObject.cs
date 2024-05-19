namespace DotNet.Models;

public class VeryComplexObject : BaseObject {
    public VeryComplexObject() : base() {
        var _random = new Random();
        ComplexObjects = [];
        Guids = [];
        OtherNames = [];
        
        var num = _random.Next(1,10);
        for (int i=0; i <= num; i++) {
            ComplexObjects.Add(new ComplexObject());
            Guids.Add(Guid.NewGuid());
            OtherNames.Add(ObjectHelper.RandomString());
        }
    }

    public List<ComplexObject> ComplexObjects { get; set; }
    public List<Guid> Guids { get; set; }
    public List<string> OtherNames { get; set; }

    public override string ToString() {
        return $"{nameof(VeryComplexObject)}";
    }
}