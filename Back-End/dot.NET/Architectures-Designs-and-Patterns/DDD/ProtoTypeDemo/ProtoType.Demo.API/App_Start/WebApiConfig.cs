using ProtoType.Demo.API.App_Start;
using ProtoType.Demo.API.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Extensions;
using ODataV4 = System.Web.OData;

namespace ProtoType.Demo.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // support both Json and XML based on Accept Header from client

            //config.Formatters.JsonFormatter.SupportedMediaTypes
            //.Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.Add(new CustomJsonFormatter());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            // Odata Test Route


            ODataV4.Builder.ODataModelBuilder builder = new ODataV4.Builder.ODataConventionModelBuilder();
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            builder.EntitySet<PeopleVM>("People");
            ODataV4.Extensions.HttpConfigurationExtensions.MapODataServiceRoute(
                configuration: config,
                routeName: "Peopleroute",
                routePrefix: "odata4",
                model: builder.GetEdmModel());


        }
    }
}
