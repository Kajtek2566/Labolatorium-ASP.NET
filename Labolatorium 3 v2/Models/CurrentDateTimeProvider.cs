namespace Labolatorium_3_v2.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentTime() => DateTime.Now;
    }
}
