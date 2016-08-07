<img src="https://github.com/dn32/Fluent.Infrastructure/blob/master/Docs/logo/logo.png" alt="Fluent Infrastructure">
================================

<img src="http://proximo.pro:8080/app/rest/builds/buildType:(id:FluentInfrastructure_Build)/statusIcon"/>

[<img src="https://github.com/dn32/Fluent.Infrastructure/blob/master/Docs/Flowchart%20activity%20of%20basic%20implementation.png" alt="Flowchart activity of basic implementation">](https://raw.githubusercontent.com/dn32/Fluent.Infrastructure/master/Docs/Flowchart%20activity%20of%20basic%20implementation.png)

What is Fluent Infrastructure?
--------------------------------
Fluent.Infrastructure is an Open source infrastructure that unites **Controller**, **Service**, **Repository**, **Validation** and automation integration testing with the aim of accelerating the development of organized systems, causing major operations become simple and quick to implement.

Cache control and logic exclusion are supported simply.

Find, Add, Update and Remove are the basic operations that do not require addition to files to run on your system.

Where can I get it?
--------------------------------
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [Fluent.Infrastructure](https://www.nuget.org/packages/Fluent.Infrastructure/) from the package manager console:

    PM> Install-Package Fluent.Infrastructure

Why use Fluent Infrastructure?
--------------------------------
If you need to make a small CRUD, or a great application that involves **data access layer**, **service**, **validation**, **business rules** and **registration forms**, this is the right infrastructure, For it simplifies what should be simple and flexes to meet what is complex, so you can let it take care of various operations and override other simple, effective and high-performance manner.

How do I get started?
--------------------------------
Please note that this package must be installed with projects that use .Net framework 4.6.1

<h4>1 step: Get the package by nuget</h4>

    PM> Install-Package Fluent.Infrastructure
    
<h4>2 step: Signing your project</h4>

1. Open Solution Explorer.
2. Right-click on the project.
3. Click Signing.
4. Click Sign the assembly.
5. Click the dropdown box, and then select New....
6. Enter the name you want and click OK.

<h4>3 step: Create one or more models</h4>

    using System;
    using Fluent.Infrastructure.FluentModel;
    using System.ComponentModel.DataAnnotations;

    public class Forum : BaseEntityClass
    {
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
    
All entities should inherit from BaseEntityClass.
    
<h4>4 step: Create a context inherited from DbContext to add the entities that will be saved in the database</h4>

    public class DbContextLocal : DBContext
    {
        public DbContextLocal() : base("DefaultConnection") { }

        public DbSet<Forum> Forum { get; set; }
    }
    
<h4>5 step: Ad the connection string to the database in the web.config</h4>

    <connectionStrings>
        <add name="DefaultConnection" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=[NAME OF YOUR DATABASE];User Id=[YOURD USERNAME]; Password=[YOUR PASSWORD]; MultipleActiveResultSets=True;" providerName="System.Data.SqlClient" />
    </connectionStrings>
      
The connectionStrings tag must be added within the tag configuration. 
  
<h4>6 step: Create controllers of your models</h4>

    using Fluent.Infrastructure.FluentController;
    using [your project].Models;
    public class ForumController : ControllerBase<Forum, Forum>
    {
    }

The parameters of ControllerBase are: Entity type and entity type for handling and consultations. The type for manipulation can be a derivative of the parent entity, or own. It will be seen below how to map.

--
<h4>web.config View</h4>
If you do not have a web.config file in the Views directory, create a file with content equivalent to:
[web.config](https://raw.githubusercontent.com/dn32/Fluent.Infrastructure/master/Sample/Fluent-Infrastructure-Example/Views/web.config).


<h4>RouteConfig</h4>
If you do not have the RouteConfig class, create the App_Start folder in the root of the project and add the class:
    
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
    
<h4>7 step: Add the Global.asax on your project if you have not already</h4>
1. Open Solution Explorer.
2. Right-click on the project.
3. Add New Item.
4. VB or C#
5. Web.
6. General.
7. Global Application Class.

<h4>8 step: Add the initialization call in your Global.asax</h4>

    protected void Application_Start(object sender, EventArgs e)
    {
        AreaRegistration.RegisterAllAreas();
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        FluentStartup.Initialize(typeof(DbContextLocal));
    }
    
 You will need to add reference to Fluent.Infrastructure.Fluent.Tools and context that you created
 
    using Fluent.Infrastructure.FluentTools;
    
--------------------------------

<h4>Using specific services</h4>

    using Fluent.Infrastructure.FluentAttribute;
    using Fluent.Infrastructure.FluentService;
    using Fluent.Infrastructure.FluentDBContext;
    using [your project].Models;

    [FluentServiceOf(typeof(Forum))]
    public class ForumService : ServiceBase<Forum>
    {
        public ForumService(DBContext Context) : base(Context) { }
    }

<h4>Using specific validations</h4>

    using Fluent.Infrastructure.FluentAttribute;
    using Fluent.Infrastructure.FluentService;
    using Fluent.Infrastructure.FluentValidation;
    using Fluent.Infrastructure.FluentDBContext;
    using Fluent.Infrastructure.FluentContract;
    using [your project].Models;
    
    [FluentValidationOf(typeof(Forum))]
    public class ForumValidation : ValidationBase<Forum>
    {
        public ForumValidation(IServiceBase<Forum> service) : base(service) { }
    }

<h4>Using specific repositories</h4>

    using Fluent.Infrastructure.FluentAttribute;
    using Fluent.Infrastructure.FluentRepository;
    using Fluent.Infrastructure.FluentDBContext;
    using [your project].Models;
    
    [FluentRepositoryOf(typeof(Forum))]
    public class ForumRepository : RepositoryBase<Forum>
    {
        public ForumRepository(DBContext Contexto) : base(Contexto) { }
    }
If the model in use contains composition, the repository must inform the items to the framework entity make inclusion '*Context.User.Include(nameForInclusion)*'. To do this, override the Get Inclusions method passing the names to be included as the code below

    [FluentRepositoryOf(typeof(User))]
    public class UserRepository : RepositoryBase<User>
    {
        public ForumRepository(DBContext Contexto) : base(Contexto) { }
        
        protected override string[] GetInclusions()
        {
            return new string[]
            {
                nameof(User.Profile),
                nameof(User.Address)
            };
        }
    }
      
--------------------------------
<h4>Using AutoMapper on models</h4>
Use the attribute FluentMapTo on with the main model specifying the type mapping for Automatic links AutoMapper
    using Fluent.Infrastructure.FluentAttribute;

    [FluentMapTo(typeof(ForumOut), typeof(ForumIn))]
    public class Forum : BaseEntityClass
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

--
Create a class that inherits from FluentMap to map the set model. Customizations in the mapping can be done in the Setup method as explained in [AutoMapper](https://github.com/AutoMapper/AutoMapper/wiki/).


    using AutoMapper;
    using Fluent.Infrastructure;
    using Fluent.Infrastructure.FluentTools;

    public class ForumMap : IFluentMap
    {
        public void Setup(IMapperConfiguration configure)
        {
            Utilities.MapAllTypes(configure, typeof(Forum));
        }
    }

Change your controller to inform the output type in the second parameter    

    using Fluent.Infrastructure.FluentController;
    using [your project].Models;
    public class ForumController : ControllerBase<Forum, ForumOut>
    {
    }
   
--------------
Once this is done, all operations will be available for overwriting in your controller, service, validation and repository.
Just submit a view to **Add(T entity)** that information will be trafficked by the relevant departments and if successfully validated, will be saved in the database.

[<img src="https://github.com/dn32/Fluent.Infrastructure/blob/master/Docs/Flowchart%20activity%20of%20advanced%20implementation.png" alt="Flowchart activity of advanced implementation">](https://raw.githubusercontent.com/dn32/Fluent.Infrastructure/master/Docs/Flowchart%20activity%20of%20advanced%20implementation.png)
