using DotNet.Models;
using Newton = Newtonsoft.Json;
using Omu.ValueInjecter;
using Json = System.Text.Json;
using System.Reflection.Emit;
using System.Reflection;
using Force.DeepCloner;

namespace DotNet;

public static class CloneExtensions {
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
    /// Delegate handler that's used to compile the IL to.
    /// (This delegate is standard in .net 3.5)
    /// </summary>
    /// <typeparam name="T1">Parameter Type</typeparam>
    /// <typeparam name="TResult">Return Type</typeparam>
    /// <param name="arg1">Argument</param>
    /// <returns>Result</returns>
    public delegate TResult Func<T1, TResult>(T1 arg1);
    
    /// <summary>
    /// This dictionary caches the delegates for each 'to-clone' type.
    /// </summary>
    readonly static Dictionary<Type, Delegate> _cachedIL = new();

    /// <summary>
    /// Generic cloning method that clones an object using IL.
    /// Only the first call of a certain type will hold back performance.
    /// After the first call, the compiled IL is executed.
    /// </summary>
    /// <typeparam name="T">Type of object to clone</typeparam>
    /// <param name="obj">Object to clone</param>
    /// <returns>Cloned object</returns>
    public static T IntermediateLanguageClone<T>(this T obj) where T : new() {
        Delegate myExec = null;
        if (!_cachedIL.TryGetValue(typeof(T), out myExec)) {
            // Create ILGenerator
            DynamicMethod dymMethod = new DynamicMethod("DoClone", typeof(T), new Type[] { typeof(T) }, true);
            ConstructorInfo cInfo = obj.GetType().GetConstructor(new Type[] { });

            ILGenerator generator = dymMethod.GetILGenerator();

            LocalBuilder lbf = generator.DeclareLocal(typeof(T));
            //lbf.SetLocalSymInfo("_temp");

            generator.Emit(OpCodes.Newobj, cInfo);
            generator.Emit(OpCodes.Stloc_0);
            foreach (FieldInfo field in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
                // Load the new object on the eval stack... (currently 1 item on eval stack)
                generator.Emit(OpCodes.Ldloc_0);
                // Load initial object (parameter)          (currently 2 items on eval stack)
                generator.Emit(OpCodes.Ldarg_0);
                // Replace value by field value             (still currently 2 items on eval stack)
                generator.Emit(OpCodes.Ldfld, field);
                // Store the value of the top on the eval stack into the object underneath that value on the value stack.
                //  (0 items on eval stack)
                generator.Emit(OpCodes.Stfld, field);
            }
            
            // Load new constructed obj on eval stack -> 1 item on stack
            generator.Emit(OpCodes.Ldloc_0);
            // Return constructed object.   --> 0 items on stack
            generator.Emit(OpCodes.Ret);

            myExec = dymMethod.CreateDelegate(typeof(Func<T, T>));
            _cachedIL.Add(typeof(T), myExec);
        }
        return ((Func<T, T>)myExec)(obj);
    }

    /// <summary>
    /// Generic deep clone using DeepCloner and Expresions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T ExpressionClone<T>(this T obj) where T : new() {
        return obj.DeepClone();
    }
}
