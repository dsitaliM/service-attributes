# Service Attributes

Register ASP.NET  services using attributes

## How to use

1. Register the service attributes in the ```Startup.cs```

```csharp
builder.Services.AutoRegisterServices();
```

2. Add the attribute to the service you want to register

```csharp
[ScopedService]
public class MyScopedService : IMyScopedService
{
    
}
```

You can, as well, register services that don't implement an interface

```csharp
[ScopedService]
public class MyScopedService
{
    
}
```


## Available attributes
```csharp
[ScopedService] // Registers service as scoped
```

```csharp
[TransientService] // Registers service as transient
```

```csharp
[SingletonService] // Registers service as singleton
```
