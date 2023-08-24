﻿using Microsoft.Extensions.DependencyInjection;
using SmtpToRest.Config;
using SmtpToRest.Processing;
using SmtpToRest.Rest;
using SmtpToRest.Rest.Decorators;
using SmtpToRest.Services.Smtp;

namespace SmtpToRest;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection UseSmtpToRestDefaults(this IServiceCollection services)
	{
		services
			.AddDefaultDecorators()
			.AddSingleton<IRestInputDecoratorInternal, AggregateDecorator>()
			.AddSingleton<IConfiguration, Configuration>()
			.AddSingleton<IConfigurationFileReader, DefaultConfigurationFileReader>()
			.AddSingleton<IMessageStoreFactory, DefaultMessageStoreFactory>()
			.AddSingleton<ISmtpServerFactory, DefaultSmtpServerFactory>()
			.AddSingleton<IMessageProcessor, DefaultMessageProcessor>()
			.AddSingleton<IRestClient, RestClient>()
			.AddSingleton<IHttpClientFactory, DefaultHttpClientFactory>()
			.AddHostedService<SmtpServerBackgroundService>();
		return services;
	}

	private static IServiceCollection AddDefaultDecorators(this IServiceCollection services)
	{
		services
			.AddSingleton<IRestInputDecorator, ConfigurationDecorator>()
			.AddSingleton<IRestInputDecorator, EndpointOverridesDecorator>()
			.AddSingleton<IRestInputDecorator, QueryStringDecorator>()
			.AddSingleton<IRestInputDecorator, JsonPostDataDecorator>();
		return services;
	}
}