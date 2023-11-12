namespace Domain;

public record DateOverdueAlertEvent : AlertEvent
{
    public DateTime AlertingDate { get; set; }

    public int DaysOverdue =>
        (FiredAt - AlertingDate).Days;
}
