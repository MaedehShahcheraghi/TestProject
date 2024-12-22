using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace TestProject.Api.OpenApiConfig
{
  

    public class AddCaptchaIdHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            if (context.ApiDescription.RelativePath.Contains("login"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "CaptchaId",
                    In = ParameterLocation.Header,
                    Description = "The ID of the captcha generated from the generateCaptcha endpoint",
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });
            }
            if (context.ApiDescription.RelativePath.Contains("AddProduct"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "CaptchaId",
                    In = ParameterLocation.Header,
                    Description = "The ID of the captcha generated from the generateCaptcha endpoint",
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });
            }
        }
    }

}
