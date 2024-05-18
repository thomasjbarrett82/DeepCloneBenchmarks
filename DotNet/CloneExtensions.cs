using Newton = Newtonsoft.Json;
using Omu.ValueInjecter;
using Json = System.Text.Json;
using DotNet.Models;

namespace DotNet;

public static class CloneExtensions { 
    public static T InjectionClone<T>(this T obj) where T: new() {
        var result = new T();
        result.InjectFrom<CloneInjection>(obj);
        return result;
    }

    public static T NewtonsoftJsonClone<T>(this T obj) where T : new() {
        var str = Newton.JsonConvert.SerializeObject(obj);
        return Newton.JsonConvert.DeserializeObject<T>(str);
    }

    public static T SystemTextJsonClone<T>(this T obj) where T : new() {
        var str = Json.JsonSerializer.Serialize(obj);
        return Json.JsonSerializer.Deserialize<T>(str);
    }
}
