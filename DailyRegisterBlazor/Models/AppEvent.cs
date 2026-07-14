using SQLite;

namespace DailyRegisterBlazor.Models;

public class AppEvent
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(50), NotNull]
    public string Type { get; set; } = string.Empty;

    public int? ContactId { get; set; }

    public decimal? Amount { get; set; }

    [NotNull]
    public string Description { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Status { get; set; }
    // "unpaid", "partial", "paid"

    public string? StatusNote { get; set; }

    public decimal? RemainingAmount { get; set; }
    // How much is still owed (null for non-debts)

    public decimal? PaidAmount { get; set; }
    // How much has been paid so far

    public DateTime EventDate { get; set; } = DateTime.Now;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Ignore]
    public string? ContactName { get; set; }
}