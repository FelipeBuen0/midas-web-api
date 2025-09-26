using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure.Persistence.Scaffolded;

public partial class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WebhookEvent> WebhookEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("accounts_pkey");

            entity.ToTable("accounts");

            entity.Property(e => e.AccountId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("accountId");
            entity.Property(e => e.AccountMask).HasColumnName("accountMask");
            entity.Property(e => e.BankName).HasColumnName("bankName");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdAt");
            entity.Property(e => e.ExternalIdentifier).HasColumnName("externalIdentifier");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_accounts_user_id");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("notifications_pkey");

            entity.ToTable("notifications");

            entity.Property(e => e.NotificationId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("notificationId");
            entity.Property(e => e.Attempts)
                .HasDefaultValue(0)
                .HasColumnName("attempts");
            entity.Property(e => e.Channel).HasColumnName("channel");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdAt");
            entity.Property(e => e.Destination).HasColumnName("destination");
            entity.Property(e => e.LastAttemptAt).HasColumnName("lastAttemptAt");
            entity.Property(e => e.ProviderResponse)
                .HasColumnType("jsonb")
                .HasColumnName("providerResponse");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TransactionId).HasColumnName("transactionId");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("fk_notifications_transaction_id");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.HasIndex(e => e.ExternalId, "transactions_externalId_key").IsUnique();

            entity.Property(e => e.TransactionId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("transactionId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Amount)
                .HasPrecision(14, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdAt");
            entity.Property(e => e.Currency)
                .HasDefaultValueSql("'BRL'::text")
                .HasColumnName("currency");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Direction).HasColumnName("direction");
            entity.Property(e => e.ExternalId).HasColumnName("externalId");
            entity.Property(e => e.OccurredAt).HasColumnName("occurredAt");
            entity.Property(e => e.SourceEventId).HasColumnName("sourceEventId");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updateAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_transactions_account_id");

            entity.HasOne(d => d.SourceEvent).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.SourceEventId)
                .HasConstraintName("fk_transactions_source_event_id");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_transactions_user_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.PreferredChannel).HasColumnName("preferredChannel");
            entity.Property(e => e.TelegramId).HasColumnName("telegramId");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
        });

        modelBuilder.Entity<WebhookEvent>(entity =>
        {
            entity.HasKey(e => e.WebhookEventId).HasName("webhookEvents_pkey");

            entity.ToTable("webhookEvents");

            entity.Property(e => e.WebhookEventId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("webhookEventId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdAt");
            entity.Property(e => e.EventExternalId).HasColumnName("eventExternalId");
            entity.Property(e => e.Processed)
                .HasDefaultValue(false)
                .HasColumnName("processed");
            entity.Property(e => e.ProcessingAttempts)
                .HasDefaultValue(0)
                .HasColumnName("processingAttempts");
            entity.Property(e => e.RawPayload)
                .HasColumnType("jsonb")
                .HasColumnName("rawPayload");
            entity.Property(e => e.ReceivedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("receivedAt");
            entity.Property(e => e.Source).HasColumnName("source");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
