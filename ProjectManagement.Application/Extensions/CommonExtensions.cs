using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ProjectManagement.Application.Extensions
{
    public static class CommonExtensions
    {
        public static string GetEnumName(this Enum myEnum)
        {
            var enumDisplayName = myEnum.GetType()
                .GetMember(myEnum.ToString()).FirstOrDefault();

            if (enumDisplayName != null)
                return enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName();

            return "";
        }

        public static bool AnyDigit(this string text)
        {
            return text.Any(char.IsDigit);
        }

        public static string CalculateTime(DateTime start, DateTime end)
        {
            var dateDiff = start - end;
            if (dateDiff.Days > 0)
            {
                return $"{dateDiff.Days} روز پیش";
            }
            else if (dateDiff.Hours > 0)
            {
                return $"{dateDiff.Hours} ساعت پیش";
            }
            else if (dateDiff.Minutes > 0)
            {
                return $"{dateDiff.Minutes} دقیقه پیش";
            }
            else
            {
                return $"لحظاتی پیش";
            }
        }
    }
}
