Exemplificamos por meio desse projeto, uma api simples.

Fazendo uso de uma única entidade e tendo acesso a vários end-points.

Seguem os passos para o desenvolvimento desse projeto:

#### 1. Criação de um novo projeto do tipo Asp.Net Core - API
#### 2. Instalação dos pacotes da arquitetura
````Nuget
Install-Package Fluent.Architecture.Core
Install-Package Fluent.Architecture.Core.Doc
Install-Package Fluent.Architecture.EntityFramework
Install-Package Fluent.Architecture.EntityFramework.SqLite
````
| Pacote| Recurso|
| ------------- |-------------|
|**Core** | O núcleo da arquitetura|
|**Core.Doc** | O pacote de documentação da API|
|**EntityFramework** | O pacote de dependências do Entity Framework|
|**EntityFramework.SqLite** | O pacote de dependências do Entity Framework para SqLite|

___

#### 3. Inicialização da arquitetura
````CSharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddMvc()
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
            .AddFluentArchitecture(jsonSerializerSettings)
            .UseEntityFramework()
            .AddConnectionString("Data Source=Composition.db;", createDatabaseIfNotExists: true, typeof(EfContextSqLite))
            .Build()
            .AddFluentDoc();

            (...)
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        (...)
        app.UseFluentDoc();
        (...)
    }
}
````

| Método| Recurso|
| ------------- |-------------|
| **AddFluentArchitecture**|Indica o início da arquitetura|
| **UseEntityFramework**       |  Indica o uso de Entity Framework pela arquitetura|
| **AddConnectionString** | Adiciona uma conexão de banco de dados à arquitetura. Vaja as opções de conexão em [Conexões de banco de dados](conexoes)|
|**Build** | Valida a arquitetura e inicializa os tipos dinâmicos|
|**AddFluentDoc** | Indica o início da documentação para API|
|**UseFluentDoc** | Inicializa a documentação de API|

___

#### 4. Criação de uma entidade
````CSharp
public class User : FluentEntity
{
    [Key]
    public long Code { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }
}
````

**FluentEntity** Indica que essa é uma entidade real para a arquitetura.
Entidades reais são automaticamente mapeadas para o banco de dados e API. Veja mais sobre entidades em [Entidade](entidade).

Ao executar essa aplicação, um end-point é disponibilizado no endereço: http://localhost:5000/FluentDoc

Ao acessar o end-point, percebe-se que um serviço do tipo User se torna disponível, 
de forma a permitir acesso a vários endpoints dessa entidade.

Segue alguns exemplos de end-points disponíveis:

http://localhost:5000/api/User/ExampleData

http://localhost:5000/api/User/Count

http://localhost:5000/api/User/List

Ao acessar pela primeira ver um end-point que necessida de acesso ao banco de dados, um banco de dados é criado de acordo com a string de conexão fornecida