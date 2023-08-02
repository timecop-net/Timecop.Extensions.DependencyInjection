# Timecop.Extensions.DependencyInjection

Register [Timecop's](https://github.com/timecop-net/Timecop) `IClock` with `Microsoft.DependencyInjection` in one line of code.

Supports .NET 6 and 7.

## Installation

You can install [Timecop.Extensions.DependencyInjection](https://www.nuget.org/packages/Timecop.Extensions.DependencyInjection/) from NuGet using your IDE or the .NET CLI:

```
dotnet add package Timecop.Extensions.DependencyInjection
```

## Usage

The following code registers the implementation of `IClock` that always returns the current time. The instance is registered as a singletone.

```csharp
using TCop.Extensions.DependencyInjection;

services.AddTimecop();
```

## License

Timecop.Extensions.DependencyInjection was created by [Dmytro Khmara](https://dmytrokhmara.com) and is licensed under the [MIT license](LICENSE.txt).
