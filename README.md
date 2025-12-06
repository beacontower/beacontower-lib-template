# MyLib - .NET Library Template

A modern .NET 10 library template for creating reusable NuGet packages with best practices built-in.

## Features

- **.NET 10** with **C# 14**
- **NuGet packaging** with semantic versioning
- **XML documentation** generation
- **SourceLink** for debugging
- **Symbol packages** (.snupkg)
- **XUnit** tests with FluentAssertions
- **Code coverage** with Coverlet
- **GitHub Actions** CI/CD
- **Semantic versioning** with conventional commits
- **CodeQL** security scanning
- **Dependabot** for automated updates

## Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2022 17.14+ or JetBrains Rider 2025.1+

### Build & Test

```bash
# Restore dependencies
dotnet restore

# Build
dotnet build

# Run tests
dotnet test

# Run tests with coverage
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Pack NuGet package
dotnet pack --configuration Release
```

## Project Structure

```
MyLib/
├── src/
│   └── MyLib/                    # Library source code
│       ├── Calculator.cs         # Example class
│       └── MyLib.csproj          # Project with packaging config
├── tests/
│   └── MyLib.Tests/              # Unit tests
│       ├── CalculatorTests.cs
│       └── MyLib.Tests.csproj
├── .github/workflows/
│   ├── pr.yml                    # PR validation
│   ├── main.yml                  # Release & publish
│   └── dependabot.yml            # Dependency updates
├── Directory.Build.props         # Shared project properties
├── Directory.Packages.props      # Central Package Management
├── .editorconfig                 # Code style rules
├── .releaserc.json               # Semantic release config
├── MyLib.sln
└── README.md
```

## NuGet Package Configuration

The library is configured for NuGet packaging with:

### Package Metadata

Configured in `Directory.Build.props`:
- Package ID, description, tags
- Author and company information
- License (MIT)
- Repository URL
- Copyright

### SourceLink

Enables debugging into your library from consuming applications:
- Source files embedded in symbols
- Step-through debugging support
- Links to GitHub source

### Symbol Packages

Separate `.snupkg` files for debugging symbols.

## Development

### Adding New Classes

1. Create new class in `src/MyLib/`:
```csharp
namespace MyLib;

/// <summary>
/// Description of your class.
/// </summary>
public class MyClass
{
    /// <summary>
    /// Description of your method.
    /// </summary>
    public void MyMethod()
    {
        // Implementation
    }
}
```

2. Add tests in `tests/MyLib.Tests/`:
```csharp
using FluentAssertions;
using Xunit;

namespace MyLib.Tests;

public class MyClassTests
{
    [Fact]
    public void MyMethod_Should_Do_Something()
    {
        // Arrange
        var sut = new MyClass();

        // Act
        sut.MyMethod();

        // Assert
        // Assertions here
    }
}
```

### XML Documentation

Always add XML documentation comments:
```csharp
/// <summary>
/// Brief description.
/// </summary>
/// <param name="paramName">Parameter description.</param>
/// <returns>Return value description.</returns>
/// <exception cref="ExceptionType">When this exception is thrown.</exception>
public int MyMethod(string paramName)
{
    // Implementation
}
```

## Testing

### Unit Tests

All public APIs should have unit tests:
```bash
# Run all tests
dotnet test

# Run specific test
dotnet test --filter "FullyQualifiedName~CalculatorTests"

# Run with code coverage
dotnet test /p:CollectCoverage=true
```

### Code Coverage

Coverlet is configured for code coverage:
```bash
# Generate coverage report
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# View coverage (install reportgenerator globally)
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:coverage.opencover.xml -targetdir:coverage
```

## CI/CD

### GitHub Actions Workflows

**PR Validation (`.github/workflows/pr.yml`):**
- Build solution
- Run tests with coverage
- CodeQL security scanning
- Pack validation (test package creation)

**Main Branch Release (`.github/workflows/main.yml`):**
- Build and test
- Semantic versioning (automatic)
- Pack NuGet package
- Publish to GitHub Packages
- Create GitHub release

### Semantic Versioning

Uses conventional commits for automatic versioning:

```bash
# New feature (minor version bump)
git commit -m "feat: add new calculation method"

# Bug fix (patch version bump)
git commit -m "fix: resolve division by zero edge case"

# Breaking change (major version bump)
git commit -m "feat!: redesign Calculator API

BREAKING CHANGE: Calculator constructor now requires ILogger parameter."

# No release
git commit -m "docs: update README"
git commit -m "chore: update dependencies"
```

## Publishing

### GitHub Packages

Packages are automatically published to GitHub Packages on release.

**Consuming the package:**
1. Add GitHub Packages source to `nuget.config`:
```xml
<packageSources>
  <add key="github" value="https://nuget.pkg.github.com/beacontower/index.json" />
</packageSources>
```

2. Authenticate (if private):
```bash
dotnet nuget add source https://nuget.pkg.github.com/beacontower/index.json \
  --name github \
  --username YOUR_GITHUB_USERNAME \
  --password YOUR_GITHUB_PAT
```

3. Install package:
```bash
dotnet add package BeaconTower.MyLib
```

### NuGet.org (Optional)

To publish to NuGet.org:
1. Create account at nuget.org
2. Generate API key
3. Add `NUGET_API_KEY` secret to GitHub
4. Update workflow to push to NuGet.org

## Configuration

### Package Version

Version is managed automatically by semantic-release based on commit messages.

### Package ID

Update in `src/MyLib/MyLib.csproj`:
```xml
<PackageId>BeaconTower.MyLib</PackageId>
```

### Package Description

Update in `src/MyLib/MyLib.csproj`:
```xml
<Description>Your library description here</Description>
```

### Package Tags

Update in `Directory.Build.props`:
```xml
<PackageTags>beacontower;yourtags;here</PackageTags>
```

## Best Practices

### 1. Public API Design

- Keep public surface area minimal
- Use clear, descriptive names
- Follow .NET naming conventions
- Add XML documentation to all public members

### 2. Versioning

- Use semantic versioning (major.minor.patch)
- Document breaking changes clearly
- Maintain CHANGELOG.md (auto-generated)

### 3. Testing

- Test all public APIs
- Use descriptive test names
- Follow Arrange-Act-Assert pattern
- Aim for high code coverage

### 4. Documentation

- Add XML comments to all public APIs
- Keep README up to date
- Include usage examples
- Document breaking changes

### 5. Dependencies

- Minimize external dependencies
- Keep dependencies up to date (Dependabot helps)
- Only reference what you need

## Multi-Targeting (Optional)

To support multiple .NET versions, update `Directory.Build.props`:
```xml
<TargetFrameworks>net10.0;net8.0</TargetFrameworks>
```

Use conditional compilation for version-specific code:
```csharp
#if NET10_0_OR_GREATER
// .NET 10+ specific code
#elif NET8_0_OR_GREATER
// .NET 8 specific code
#endif
```

## Troubleshooting

### Package Not Found

Ensure GitHub Packages is configured in `nuget.config` and you're authenticated.

### Tests Failing

```bash
# Run tests with verbose output
dotnet test --logger "console;verbosity=detailed"
```

### Build Warnings

Warnings are treated as errors. Fix them or suppress specific warnings in `.editorconfig`.

## Example Usage

After installing the package:

```csharp
using MyLib;

var calculator = new Calculator();

var sum = calculator.Add(5, 3);        // 8
var diff = calculator.Subtract(10, 4); // 6
var product = calculator.Multiply(6, 7); // 42
var quotient = calculator.Divide(15, 3); // 5.0
```

## License

Internal use only - Beacon Tower Platform

## Support

For issues or questions:
- Create an issue in this repository
- Contact the Backend Team
