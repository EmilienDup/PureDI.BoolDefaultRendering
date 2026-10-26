# Pure.DI: optional `bool` default emitted as `True`

Minimal repro for a code generation error in Pure.DI 2.5.6: an unbound `bool` constructor parameter with a default value is emitted as `True`, which is not a C# literal.

[`ISSUE.md`](ISSUE.md) is the text to paste into a Pure.DI GitHub issue.

```
dotnet build
```

fails with `CS0103: The name 'True' does not exist in the current context` in the generated `Composition.g.cs` (emitted under `obj/Debug/net10.0/generated/Pure.DI`).
