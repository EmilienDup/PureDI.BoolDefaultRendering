using Pure.DI;

var composition = new Composition();
Console.WriteLine($"Service.Verbose = {composition.Service.Verbose}");   // expected: True (the parameter's default value)

// "bool" has no binding, so the generator falls back to the parameter's default value
public sealed class Service(bool verbose = true) { public bool Verbose { get; } = verbose; }

partial class Composition
{
    private static void Setup() => DI.Setup(nameof(Composition))
        .Bind<Service>().To<Service>()
        .Root<Service>("Service");
}
