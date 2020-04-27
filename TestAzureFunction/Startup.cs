using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SimpleSoapWrapper.Infrastructure;
using SimpleSoapWrapper.Service;

[assembly: FunctionsStartup(typeof(TestAzureFunction.Startup))]

namespace TestAzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAutoMapper(options =>
                    options.AddProfile<MappingProfile>(), typeof(Startup)
            );

            builder.Services.AddScoped<ISoapDemoAPI, SoapDemoAPI>();
        }
    }
}