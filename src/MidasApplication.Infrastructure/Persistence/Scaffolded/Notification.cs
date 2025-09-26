using System;
using System.Collections.Generic;

namespace FinanceControl.Infrastructure.Persistence.Scaffolded;

public partial class Notification
{
    public Guid NotificationId { get; set; }

    public Guid? TransactionId { get; set; }

    public string? Channel { get; set; }

    public string? Destination { get; set; }

    public string? Status { get; set; }

    public string? ProviderResponse { get; set; }

    public int? Attempts { get; set; }

    public DateTime? LastAttemptAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Transaction? Transaction { get; set; }
}
