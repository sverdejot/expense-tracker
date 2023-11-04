using System.ComponentModel.DataAnnotations;

namespace Persistance.Options;

public class DatabaseOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;

    public int MaxRetryCount { get; set; } = 3;

    public int CommandTimeout { get; set; } = 30;

    public bool EnabledDetailedErrors { get; set; } = true;

    public bool EnableSensitiveDataLogging { get; set; } = false;
}
