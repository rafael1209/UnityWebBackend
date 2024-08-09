﻿using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;

namespace UnityWebCore
{
        public class Startup
        {
                private readonly IConfiguration configuration;

                public Startup()
                {
                        configuration = new ConfigurationBuilder()
                            .AddEnvironmentVariables()
                            .AddJsonFile("appsettings.json", optional: true)
                            .Build();
                }

                public void ConfigureServices(IServiceCollection services)
                {
                        services.AddControllers();
                        services.AddEndpointsApiExplorer();
                        services.AddSwaggerGen(options =>
                        {
                                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                                {
                                        Name = "Authorization",
                                        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                                        In = ParameterLocation.Header,
                                        Type = SecuritySchemeType.ApiKey,
                                        Scheme = "Bearer"
                                });

                                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                                {
                                    {
                                        new OpenApiSecurityScheme
                                        {
                                            Name = "Bearer",
                                            In = ParameterLocation.Header,
                                            Reference = new OpenApiReference
                                            {
                                                Id = "Bearer",
                                                Type = ReferenceType.SecurityScheme
                                            }
                                        },
                                        new List<string>()
                                    }
                                });
                        });
                        services.AddHttpContextAccessor();
                }

                public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                {
                        //if (env.IsDevelopment())
                        {
                                app.UseDeveloperExceptionPage();
                                app.UseSwagger();
                                app.UseSwaggerUI();
                                app.UseHsts();
                        }

                        app.UseStaticFiles();
                        app.UseRouting();
                        app.UseAuthentication();
                        app.UseAuthorization();
                        app.UseCors(k => { k.WithMethods("POST", "GET", "PATCH", "PUT"); k.AllowAnyOrigin(); k.AllowAnyHeader(); });
                        app.UseEndpoints(endpoints =>
                        {
                                endpoints.MapDefaultControllerRoute().AllowAnonymous();
                                if (env.IsDevelopment())
                                {
                                        endpoints.MapSwagger();
                                }
                                endpoints.MapControllers().AllowAnonymous();
                        });
                }
        }
}
