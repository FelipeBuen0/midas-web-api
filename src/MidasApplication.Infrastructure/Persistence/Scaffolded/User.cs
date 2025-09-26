using System;
using System.Collections.Generic;

namespace FinanceControl.Infrastructure.Persistence.Scaffolded;

public partial class User
{
    public Guid UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? TelegramId { get; set; }

    public string? PreferredChannel { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
