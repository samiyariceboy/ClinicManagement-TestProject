using System;
namespace ClinicManagement.Common.Utilities
{
    public static class DateTimeExtentions
    {
        public static DateTime SystemNow() => DateTime.UtcNow;
    }
}
