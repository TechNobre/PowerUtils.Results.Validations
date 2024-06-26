# PowerUtils.Results.Validations

# :warning: DEPRECATED

This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary or if you prefer, you can use a good projects like [FluentValidation](https://www.nuget.org/packages/FluentValidation) and [Flunt](https://www.nuget.org/packages/Flunt).

![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.Results.Validations/main/assets/logo/logo_128x128.png)

***Utils to help validation of the objects***

[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.Results.Validations.svg)](https://github.com/TechNobre/PowerUtils.Results.Validations/blob/main/LICENSE)


- [Support to ](#support-to-)
- [Dependencies ](#dependencies-)
- [How to use ](#how-to-use-)
  - [Install NuGet package ](#install-nuget-package-)
  - [Direct validations ](#direct-validations-)
  - [Validations multiple properties ](#validations-multiple-properties-)
  - [Multiple validations ](#multiple-validations-)
  - [Custom error ](#custom-error-)
  - [Validations ](#validations-)
  - [Conversions ](#conversions-)
- [Contribution ](#contribution-)



## Support to <a name="support-to"></a>
- .NET 6.0
- .NET 5.0



## Dependencies <a name="dependencies"></a>

- PowerUtils.Results [NuGet](https://www.nuget.org/packages/PowerUtils.Results/)


## How to use <a name="how-to-use"></a>

### Install NuGet package <a name="Installation"></a>
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.Results.Validations

**Nuget**
```bash
Install-Package PowerUtils.Results.Validations
```

**.NET CLI**
```
dotnet add package PowerUtils.Results.Validations
```



### Direct validations <a name="doc-direct-validations"></a>
```csharp
var address = "";
IError error = address.IfNull();
```


### Validations multiple properties <a name="doc-validations-multiple-properties"></a>
```csharp
string firstName = null;
string lastName = null;

var errors = new List<IError>();
firstName.Validate(errors).IfNullOrWhiteSpace();
lastName.Validate(errors).IfNullOrWhiteSpace();
```


### Multiple validations <a name="doc-multiple-validations"></a>
```csharp
string address = "";

var errors = address.Validate()
    .IfNullOrEmpty()
    .IfLongerThan(5);
```


### Custom error <a name="doc-custom-error"></a>
```csharp
var validation = dateOfBirth
    .Validate()
    .IfLessThanUtcToday(
        property => Error.Forbidden(
            "DateOfBirth",
            "DateOfBirth.Invalid",
            "Invalid date"
        )
    );
```


### Validations <a name="doc-validations"></a>

> When a rule starts of `If***`, the error is returned when the condition matches

> When a rule starts from `Should***`, the error is returned when the condition doesn't match

**E.g:**
```csharp
var email1 = "email";
// Returns an error
var error1 = email1.IfNotEmail();

// Returns an error
var error2 = email1.ShouldBeEmail();


var email2 = "email@fake.fk";
// Returns null
var error3 = email2.IfNotEmail();

// Returns null
var error4 = email2.ShouldBeEmail();
```

- __Collections:__
  - `IfEmpty();`
  - `IfNullOrEmpty();`
  - `IfCountGreaterThan();`
  - `IfCountLessThan();`
  - `IfCountOutOfRange();`
- __Globalization:__
  - `IfLatitudeOutOfRange();`
  - `IfLongitudeOutOfRange();`
  - `IfNotISO2();` or `ShouldBeISO2();`
- __Guids:__
  - `IfEmpty();`
  - `IfEquals();`
  - `IfDifferent();`
- __Numerics:__
  - `IfZero();`
  - `IfGreaterThan();`
  - `IfLessThan();`
  - `IfEquals();`
  - `IfDifferent();`
  - `IfOutOfRange();`
- __Strings:__
  - `IfEmpty();`
  - `IfNullOrEmpty();`
  - `IfNullOrWhiteSpace();`
  - `IfLongerThan();`
  - `IfShorterThan();`
  - `IfLengthEquals();`
  - `IfLengthDifferent();`
  - `IfLengthOutOfRange();`
  - `IfEquals();`
  - `IfDifferent();`
- __DateTimes/DateOnly/TimeOnly:__
  - `IfGreaterThan();`
  - `IfLessThan();`
  - `IfOutOfRange();`
  - `IfEquals();`
  - `IfDifferent();`
  - `IfGreaterThanUtcNow();`
  - `IfLessThanUtcNow();`
  - `IfGreaterThanUtcToday();`
  - `IfLessThanUtcToday();`
- __Objects:__
  - `IfNull();`
  - `IfEquals();`
  - `IfDifferent();`
- __Streams:__
  - `IfNull();`
  - `IfEmpty();`
  - `IfNullOrEmpty();`
- __Human:__
  - `IfNotGender();` or `ShouldBeGender();`
  - `IfNotGenderOrOther();` or `ShouldBeGenderOrOther();`
- __Network:__
  - `IfNotEmail();` or `ShouldBeEmail();`
- __Financial:__
  - `ShouldBeCVV();`
  - `ShouldBeCardNumber();`
  - `ShouldBeValidCardExpiryDate();`



### Conversions <a name="doc-conversions"></a>
```csharp
var dateTime = "2022-12-31 12:15:46";

var errors = dateTime
    .Validate()
    .IfNull() // Validate if the string is null
    .ToDateTime() // Convert to DateTime
    .IfLessThanUtcNow(); // Validate as a DateTime
```

> In case you want to use the conversion extensions with a sugar syntax and still enjoy the resulted value, you can use the overload with `out result`
```csharp
var value = "12:15:46";
DateTime dateTime;

var errors = value
    .Validate()
    .ToDateTime(out dateTime) // Convert to DateTime
    .IfLessThanUtcNow(); // Validate as a DateTime
```

- __DateTimes:__
  - `ToDateTime();`
  - `ToDateTimeNullable();`
  - `ToDate();` (Only available for `.NET 6.0` or greater)
  - `ToDateNullable();` (Only available for `.NET 6.0` or greater)
  - `ToTime();` (Only available for `.NET 6.0` or greater)
  - `ToTimeNullable();` (Only available for `.NET 6.0` or greater)
- __Numerics:__
  - `ToNumber<TValue>();` [ short | ushort | int | uint | long | ulong | float | double | decimal ]



## Contribution <a name="contribution"></a>

If you have any questions, comments, or suggestions, please open an [issue](https://github.com/TechNobre/PowerUtils.Results.Validations/issues/new/choose) or create a [pull request](https://github.com/TechNobre/PowerUtils.Results.Validations/compare)
