﻿using System;
using SmtpToRest.Config;
using SmtpToRest.Services.Smtp;

namespace SmtpToRest.Rest.Decorators;

internal class EndpointOverridesDecorator : DecoratorBase, IRestInputDecorator
{
	public void Decorate(RestInput restInput, ConfigurationMapping mapping, IMimeMessage message)
	{
		restInput.ApiToken = mapping.CustomApiToken ?? restInput.ApiToken;
		if (Enum.TryParse(mapping.CustomHttpMethod, true, out HttpMethod parsedHttpMethod))
			restInput.HttpMethod = parsedHttpMethod;
		restInput.Endpoint = mapping.CustomEndpoint ?? restInput.Endpoint;
		restInput.HttpClientCertAuthCrt = mapping.CustomHttpClientCertAuthCrt ?? restInput.HttpClientCertAuthCrt;
		restInput.HttpClientCertAuthPassword = mapping.CustomHttpClientCertAuthPassword ?? restInput.HttpClientCertAuthPassword;
	}
}