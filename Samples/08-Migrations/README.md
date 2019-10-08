### 01 - Install tools
````dotnet
dotnet tool install -g dotnet-ef --version 3.0.0
````

### 02 - Add initial migration
````dotnet
dotnet ef migrations add InitialCreate
````

### 05 - Update database
````dotnet
dotnet ef database update
````


### 03 - Add new model

```C#
public class Custom : FluentEntity
{
    [Key]
    public long Code { get; set; }

    public string Name { get; set; }
}
````

### 04 - Add new migration

````dotnet
dotnet ef migrations add AddCustom
````

### 05 - Update database
````dotnet
dotnet ef database update
````