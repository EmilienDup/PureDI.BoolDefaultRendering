# Default value of an optional `bool` constructor parameter is emitted as `True` (CS0103)

**Pure.DI 2.5.6**, .NET SDK 10.0.402, macOS. Repro project attached (`dotnet build`).

When a constructor parameter has no binding and the generator falls back to its default value, a `bool` default is written with its `ToString()` form (`True` / `False`) instead of the C# literal, and the generated composition does not compile.

## Minimal code

```csharp
using Pure.DI;

public sealed class Service(bool verbose = true) { public bool Verbose { get; } = verbose; }

partial class Composition
{
    private static void Setup() => DI.Setup(nameof(Composition))
        .Bind<Service>().To<Service>()
        .Root<Service>("Service");
}
```

## Expected

The composition compiles and `Service.Verbose` is `true`, i.e. the generated code contains `new Service(true)`.

## Actual

```
obj/Debug/net10.0/generated/Pure.DI/Pure.DI.SourceGenerator/Composition.g.cs(70,31): error CS0103: The name 'True' does not exist in the current context
```

Generated line:

```csharp
return new global::Service(True);
```
