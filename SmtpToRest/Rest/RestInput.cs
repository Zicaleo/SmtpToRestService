﻿namespace SmtpToRest.Rest;

public class RestInput
{
	public string? HttpClientName { get; set; }
	public string? ApiToken { get; set; }
	public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;
	public string? Endpoint { get; set; }
	public string? HttpClientCertAuthCrt { get; set; }
	public string? HttpClientCertAuthPassword { get; set; }
	public string? Service { get; set; }
	public string? QueryString { get; set; }
	public string? Content { get; set; }
}