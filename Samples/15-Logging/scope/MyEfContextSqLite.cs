using Fluent.Architecture.Core.Attributes;
using Fluent.Architecture.Core.Enumerator;
using Fluent.Architecture.Core.Extensions;
using Fluent.Architecture.Core.Models;
using Fluent.Architecture.EntityFramework.SqLite;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleHelloWorld
{
    public class MyEfContextSqLite : EfContextSqLite
    {
        public ILogger Logger { get; set; }

        public MyEfContextSqLite(string connectionString) : base(connectionString)
        {
            Logger = ContextLogFactory.CreateLogger("MyLog");
            EntityChangedEventEvent += EntityChangedEventEventMethod;
        }

        [FluentLogging(EnumFluentDisplay.Hidden)]
        public class Log
        {
            public DateTime Date { get; set; }
            public string User { get; set; }
            public string EntityName { get; set; }
            public string EntityFullName { get; set; }
            public List<Property> Properties { get; set; }
        }

        [FluentLogging(EnumFluentDisplay.Hidden)]
        public class Property
        {
            public string PropertyName { get; set; }
            public object OriginalValue { get; set; }
            public object CurrentValue { get; set; }
        }

        public void EntityChangedEventEventMethod(ICollection<FluentEventEntity> fluentEventEntity)
        {
            //var properties = fluentEventEntity
            //                    .Properties
            //                    .Where(x => x.Changed)
            //                    .Select(x => new Property { PropertyName = x.PropertyName, OriginalValue = x.OriginalValue, CurrentValue = x.CurrentValue })
            //                    .ToList();

            //var log = new Log { 
            //    EntityName = fluentEventEntity.CurrentEntityType.Name,
            //    EntityFullName = fluentEventEntity.CurrentEntityType.FullName, 
            //    Properties = properties ,
            //    Date = DateTime.Now,
            //};
            //var text = log.ToFluentJson();
            //Logger.LogDebug(text);
        }
    }
}