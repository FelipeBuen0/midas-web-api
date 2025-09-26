using System;
using System.Collections.Generic;

namespace MidasApplication.Domain;

public partial class Account
{
    public Guid AccountId { get; set; }

    public Guid? UserId { get; set; }

    public string? BankName { get; set; }

    public string? AccountMask { get; set; }

    public string? ExternalIdentifier { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
