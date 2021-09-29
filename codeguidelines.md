# Code Quality Fundamentals

## 1. Remove dead code
Dead code is code that has no callers. 

1. Dead code is a maintenance cost; this is because changes to any code that the dead code references must accomodate the dead code.
2. Dead code makes builds and tests take longer with no value, since the code being compiled and tested is not run anywhere
3. Dead code also makes binaries large, which makes deployments take longer unnecessarily

Dead code can always be brought back into the repo using the history of source control if it is found that the code can be useful for a new scenario and will actually be called.

## 2. Remove unused references in projects
The more references that a project has, the more likely it is that the project will become part of a circular dependency. It is imperative to reduce the number of references each project has to only those required for the code in that project in order to faciliate code re-use. Projects that become part of circular dependencies become impossible to share code from. 

## 3. Do not exclude files from stylecop
Files should not be excluded from stylecop (or Roslyn). Stylecop and Roslyn errors should be addressed for consistency, quality, and maintainability purposes. 

## 4. Use ```<inheritdoc />``` wherever possible
Any derived implementation should use the ```<inheritdoc />``` XML documentation element. This lets the caller know that the behavior of the method is the same as the base type. This should always be the expectation. The implementation of an interface should adhere to the contract that the interface proposes, and so the documentation for the method that implements the interface should be the same as the documentation for the interface itself. The same is true for ```abstract``` and base classes. The behavior of the derived type should not deviate from the behavior expected from the base type. Doing so can cause unexpected issues for callers of the base type who instead receive an instance of the derived type. ```<remarks>``` sections can be included in addition to the ```<inheritdoc />``` element if there is pertinent non-functional documentation that is needed (such as information about time and space complexity of the implementation). This let's the caller know that a particular implementation better suites their needs without needing to read the code of the implementation. 

## 5. Document all exceptions thrown by a method
All exceptions thrown by a method should be documented with the ```<exception>``` element. Doing so let's callers know what exceptions can be expected from the method so that the caller can properly handle them. From [this article](https://ericlippert.com/2008/09/10/vexing-exceptions/) by Eric Lippert, there are 4 kinds of exceptions:

1. Fatal
2. Boneheaded
3. Vexing
4. Exogenous

Ensuring that all exceptions are documented lets us write code that prevents boneheaded exceptions altogether, notice that we are introducing vexing exceptions, handle properly exogenous exceptions with correct control-flow logic, and catch, log, and move on from fatal exceptions. Without this documentation, the caller has to dig into the entire call chain for the method to derive this information if they wish to properly handle error cases. This is time consuming and often difficult for the caller, whereas the developer who wrote the code initially will have a better grasp on the code and the possible ways that it can fail; that developer will have an easier time properly documenting the exceptions than the caller will have trying to determine what exceptions to handle. 

## 6. Document all uses of ```null``` being returned, as well as uses where ```null``` may be passed as an argument to mean something specific
```NullReferenceException```s would be easily avoided if we did not use ```null```. However, there are many cases where ```null``` is useful, so it often creeps up. In order to prevent ```NullReferenceException```s, we need to properly handle the uses of ```null```. To do so, we need accurate documentation on when ```null``` is returned from a method, or when it is used to indicate something specific (like when a parameter is allowed to be ```null``` to indicate that a default value should be used, or when a field being ```null``` indicates that an object has not yet been initialized even though it has been created). This documentation, like exception documentation, is better created by the original developer rather than by the caller since the original developer is more familiar with the cases where ```null``` has some special meaning or indicates some failure case. 

## 7. Validate all method preconditions for non-```private``` methods
Method parameters should be validated for all preconditions necessary for the method to run. These validations should be the first thing that the method does during execution. There are two reasons for this:

1. A parameter is being dereferenced. In this case, it is important to ensure that the paramter is not ```null``` or it will result in a ```NullReferenceException```. An ```ArgumentNullException``` is more appropriate, since it informs the caller which argument was invalid, and at exactly where in the callstack the issue first began.
2. A parameter is being passed to another method that validates it. We should validate that parameter before calling the subsequent method even though the subsequent method will do validation later. This is because we want to fail as quickly as possible. Take, for example, this method:

```
public static string DoWork(IEnumerable<string> data, int startIndex)
{
    foreach (var element in data)
    {
        var result = element.Substring(startIndex);
        if (result.Length < 10)
        {
            return result;
        }
    }
}
```

It finds the first string in a sequence that has a length of less than 10 after removing the first several characters from each string in the sequence. However, ```Substring``` will throw if ```startIndex``` is less than 0. We know this before we even begin enumerating ```data```, so we should go ahead an validate it before enumerating so that we don't do any unnecessary enumerations when we are going to fail anyway. The code should instead look like this:

```
public static string DoWork(IEnumerable<string> data, int startIndex)
{
    if (data == null)
    {
        throw new ArgumentNullException(nameof(data));
    }

    if (startIndex < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(startIndex));
    }

    foreach (var element in data)
    {
        var result = element.Substring(startIndex);
        if (result.Length < 10)
        {
            return result;
        }
    }
}
``` 

## 8. Use ```private``` iterator methods when leveraging ```yield return``` or ```yield break```
Methods that leverage ```yield return``` or ```yield break``` use deferred execution. This applies to the entire method implementation, which means that precondition checks will also not be executed until the result is enumerated. For example:

```
public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
{
  if (source == null)
  {
    throw new ArgumentNullException(nameof(source));
  }
  
  if (predicate == null)
  {
    throw new ArgumentNullException(nameof(predicate));
  }
  
  foreach (var element in source)
  {
    if (predicate(element))
    {
      yield return element;
    }
  }
}

public static void DoWork()
{
  Where<string>(null, val => true);
}
```

In the above code, ```DoWork``` will not throw an exception. This can be mitigated by using a ```private``` "iterator" method, like so:

```
public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
{
  if (source == null)
  {
    throw new ArgumentNullException(nameof(source));
  }
  
  if (predicate == null)
  {
    throw new ArgumentNullException(nameof(predicate));
  }
  
  return WhereIterator(source, predicate);
}

private static IEnumerable<T> WhereIterator<T>(IEnumerable<T> source, Func<T, bool> predicate)
{
  foreach (var element in source)
  {
    if (predicate(element))
    {
      yield return element;
    }
  }
}

public static void DoWork()
{
  Where<string>(null, val => true);
}
```

In this case, ```DoWork``` will throw an ```ArgumentNullException``` because ```Where``` does not use deferred execution: it immediately executes, performing the precondition checks. Once those precondition checks pass, it then delegates to ```WhereIterator``` which *does* use deferred execution, and so returns without enumerating ```source``` until the return value itself is enumerated. 

## 9. Use the settings + builder pattern where appropriate

The builder pattern is used as a solution to the telescoping constructor antipattern. This occurs when a type has several default parameters in its constructor. One or two such parameters is not a problem, but the number of needed constructor overloads grows exponentially with each new parameter. For example, with just one parameter, we have:

```
public class MyClass
{
  public MyClass()
    : this(defaultFoo)
  {
  }

  public MyClass(Foo foo)
  {
  }
}
```

No problem, only two constructors. But once a second default parameter is added, we have:

```
public class MyClass
{
  public MyClass()
    : this(defaultFoo, defaultBar)
  {
  }

  public MyClass(Foo foo)
   : this(foo, defaultBar)
  {
  }

  public MyClass(Bar bar)
    : this(defaultFoo, bar)
  {
  }

  public MyClass(Foo foo, Bar bar)
  {
  }
}
```

With each new default parameter we double the number of constructors. The builder pattern solves this by allowing the caller to provide only the defaults desired, while filling in the remaining defaults for the caller. It would look something like this:

```
public class MyClass
{
  public MyClass(Foo foo, Bar bar)
  {
  }
}

public class MyClassBuilder
{
  public Foo Foo { get; set; } = defaultFoo;

  public Bar Bar { get; set; } = defaultBar;

  public MyClass Build()
  {
    return new MyClass(Foo, Bar);
  }
}
```

Now, to get a default instance of `MyClass` you can say `new MyClassBuilder().Build()`. The other two constructors can also be mimiced with `new MyClassBuilder() { Foo = foo }.Build()` and `new MyClassBuilder() { Bar = bar }.Build()`. 

The settings pattern comes into play when we want to try to configure a `MyClass` from some source like a configuration file or deserialing a JSON blob. A settings class can be used as an abstraction between the source of the configuration and the configured instance. A settings class for `MyClass` would look something like:

```
public class MyClassSettings
{
  public MyClassSettings(Foo foo, Bar bar)
  {
    this.Foo = foo;
    this.Bar = bar;
  }

  public Foo Foo { get; }

  public Bar Bar { get; }
}
```

Then, `MyClass` can have a single constructor that takes in the settings:

```
public class MyClass
{
  public MyClass(MyClassSettings settings)
  {
  }
}
```

and `MyClassSettings` can have a builder to again avoid the telescoping constructor antipattern:

```
public class MyClassSettingsBuilder
{
  public Foo Foo { get; set; } = defaultFoo;

  public Bar Bar { get; set; } = defaultBar;

  public MyClassSettings Build()
  {
    return new MyClassSettings(Foo, Bar);
  }
}
```

An example of this exists already with [ColoredConsole](Source/Core/System/ColoredConsole.cs) and [ColoredConsoleSettings](Source/Core/System/ColoredConsoleSettings.cs).

## 10. Extension methods should follow a consistent pattern and should be placed in the same namespace as the type being extended

Using a consistent pattern for extension methods allows for better separation of concerns as well as a familiar format for finding and modifying code. Placing the extension methods in the same namespace as the type being extended facilitates code discoverability, which promotes code re-use. The pattern for extensions methods is:

```
namespace MyNamespace
{
  public class MyClass
  {
  }
}

namespace MyNamespace
{
  /// <summary>
  /// Extension methods for the <see cref="MyClass"/> class
  /// </summary>
  /// <threadsafety static="true"/>
  public static class MyClassExtensions
  {
    public static void MyExtension(this MyClass myClass)
    {
    }
  }
}
```

## 11. Implement `IDisposable` according to [MSDN guidelines](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose)

The MSDN guidelines are the best practice for implementing the disposition pattern to avoid memory leaks and performance hits, while maintaining proper inheritance hierarchies and single-concern standards.

## 12. Method signatures should take in parameters that use the least restrictive type

All method signatures should take in the type that is least descendant in the inheritance hierarchy and that contains the fewest members as required by the method implementation. Doing so avoids unnecessary calls to conversion operations, for example requiring a `ToList()` call when only an `IEnumerable<T>` is required. It also allows for maximnum code re-use, since more objects will be able to be passed to each method. Finally, it avoids unexpected behavior changes caused by [explicit interface implementations](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation#:~:text=Explicit%20Interface%20Implementation%20%28C%23%20Programming%20Guide%29%20If%20a,interfaces%20to%20use%20that%20member%20as%20their%20implementation) when a method signature is changed to a less restrictive type, for example `Dictionary<TKey, TValue>` having a different implementation for `IDictionary<TKey, TValue>.GetEnumerator()` than what it does for `IDictionary.GetEnumerat()`.
