using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Builder;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

namespace TaxasJuros.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services
                .AddMvc()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TaxaJurosApi",
                    Description = "Esta é a API para consultar a taxa de juros.",
                    Contact = new OpenApiContact() { Name = "Matheus Cruz", Email = "matheus.v.o.cruz@gmail.com" }
                });

                c.SchemaFilter<EnumSchemaFilter>();
                c.CustomSchemaIds(x => x.FullName);

                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = "api-docs";
            });
        }
    }

    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();

                StringBuilder enumValues = new StringBuilder();
                foreach (var item in Enum.GetValues(context.Type))
                {
                    var value = (int)item;
                    var name = Enum.GetName(context.Type, item);

                    enumValues.Append($"{value} - {name} ");
                }

                schema.Enum.Add(new OpenApiString(enumValues.ToString()));
            }
        }
    }
}
