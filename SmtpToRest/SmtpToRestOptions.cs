﻿using SmtpToRest.Config;

namespace SmtpToRest;

public class SmtpToRestOptions
{
	public bool UseBuiltInDecorators { get; set; } = true;
	public bool UseBuiltInHttpClientFactory { get; set; } = true;
	public bool UseBuiltInMessageStoreFactory { get; set; } = true;
	public bool UseBuiltInSmtpServerFactory { get; set; } = true;
	public bool UseBuiltInMessageProcessor { get; set; } = true;

	public ConfigurationMode ConfigurationMode { get; set; } = ConfigurationMode.ConfigurationProvider;
	/// <summary>
	/// Required in <see cref="ConfigurationMode"/> is <see cref="SmtpToRest.ConfigurationMode.OptionInjection"/>
	/// </summary>
	public IConfiguration? Configuration { get; set; }
}