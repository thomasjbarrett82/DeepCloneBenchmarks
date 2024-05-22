using DotNet.Models;
using Force.DeepCloner;
using Json = System.Text.Json;
using Newton = Newtonsoft.Json;
using Omu.ValueInjecter;

namespace DotNet;

public static class CloneExtensions {
    /// <summary>
    /// Private method for manually cloning base objects
    /// </summary>
    /// <param name="target"></param>
    /// <param name="source"></param>
    private static void BaseClone(this BaseObject target, BaseObject source) {
        target.Comment = source.Comment;
        target.Description = source.Description;
        target.Id = source.Id;
        target.Name = source.Name;
        target.UniqueId = source.UniqueId;
    }

    /// <summary>
    /// Manual clone for simple objects
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static SimpleObject ManualClone(this SimpleObject obj) {
        var result = new SimpleObject();
        result.BaseClone(obj);
        result.DecimalValue = obj.DecimalValue;
        result.FloatValue = obj.FloatValue;
        result.IntValue = obj.IntValue;
        result.EndDate = obj.EndDate;
        result.StartDate = obj.StartDate;
        return result;
    }

    /// <summary>
    /// Manual clone for complex objects
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static ComplexObject ManualClone(this ComplexObject obj) {
        var result = new ComplexObject();
        result.BaseClone(obj);
        result.DateTimes = [.. obj.DateTimes];
        result.Object = obj.Object.ManualClone();
        return result;
    }

    /// <summary>
    /// Manual clone for very complex objects
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static VeryComplexObject ManualClone(this VeryComplexObject obj) {
        var result = new VeryComplexObject();
        result.BaseClone(obj);
        result.ComplexObjects = [];
        foreach (var co in obj.ComplexObjects) {
            result.ComplexObjects.Add(co.ManualClone());
        }
        result.OtherNames = [.. obj.OtherNames];
        result.Guids = [.. obj.Guids];
        return result;
    }

    /// <summary>
    /// Generic deep clone method using Value Injecter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T InjectionClone<T>(this T obj) where T: new() {
        var result = new T();
        result.InjectFrom<CloneInjection>(obj);
        return result;
    }

    /// <summary>
    /// Generic deep clone method using Newtonsoft.Json serialization.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T NewtonsoftJsonClone<T>(this T obj) where T : new() {
        var str = Newton.JsonConvert.SerializeObject(obj);
        return Newton.JsonConvert.DeserializeObject<T>(str);
    }

    /// <summary>
    /// Generic deep clone method using System.Text.Json serialization.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T SystemTextJsonClone<T>(this T obj) where T : new() {
        var str = Json.JsonSerializer.Serialize(obj);
        return Json.JsonSerializer.Deserialize<T>(str);
    }

    /// <summary>
    /// Generic deep clone using DeepCloner and Expressions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T ExpressionClone<T>(this T obj) where T : new() {
        return obj.DeepClone();
    }
}
