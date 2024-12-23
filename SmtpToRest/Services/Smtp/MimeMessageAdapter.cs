﻿using System.Linq;
using MimeKit;

namespace SmtpToRest.Services.Smtp;

internal class MimeMessageAdapter : IMimeMessage
{
    public string FirstFromAddress => _adaptee.From.Mailboxes.First().Address;
    public string[]? FromAddresses => _adaptee.From.Mailboxes.Select(m => m.Address).ToArray();
    public string? FirstToAddress => _adaptee.To.Mailboxes.First().Address;
    public string[]? FirstAddresses => _adaptee.To.Mailboxes.Select(m => m.Address).ToArray();
    public string? SubjectAsString => _adaptee.Headers["Subject"];
    public string? BodyAsString => _adaptee.TextBody;

    private readonly MimeMessage _adaptee;

    public MimeMessageAdapter(MimeMessage adaptee)
    {
        _adaptee = adaptee;
    }

    public static implicit operator MimeMessage(MimeMessageAdapter adapter)
    {
		return adapter._adaptee;
	}
}