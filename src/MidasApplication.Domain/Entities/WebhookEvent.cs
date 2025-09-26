using System;
using System.Collections.Generic;

namespace MidasApplication.Domain;

public partial class WebhookEvent
{
    public Guid WebhookEventId { get; set; }

    public string? EventExternalId { get; set; }

    public string? RawPayload { get; set; }

    public string? Source { get; set; }

    public DateTime? ReceivedAt { get; set; }

    public bool? Processed { get; set; }

    public int? ProcessingAttempts { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
