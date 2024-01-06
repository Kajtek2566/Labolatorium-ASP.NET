using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_3.Models
{
    public interface IDateTimeProvider
    {
        DateTime CurrentTime();
    }
}
