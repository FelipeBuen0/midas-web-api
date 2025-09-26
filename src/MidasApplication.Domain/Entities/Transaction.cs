using System;
using System.Collections.Generic;

namespace MidasApplication.Domain;

public partial class Transaction
{
    public Guid TransactionId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? AccountId { get; set; }

    public decimal? Amount { get; set; }

    public string? Currency { get; set; }

    public string? Direction { get; set; }

    public string? Description { get; set; }

    public DateTime? OccurredAt { get; set; }

    public Guid? SourceEventId { get; set; }

    public string? ExternalId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual WebhookEvent? SourceEvent { get; set; }

    public virtual User? User { get; set; }
}
