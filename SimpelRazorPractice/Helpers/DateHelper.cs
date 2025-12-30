using System;
namespace SimpelRazorPractice.Helpers
{
    public class DateHelper
    {
        public static string Today()
        {
            return DateTime.Now.ToShortDateString();
        }
    }
}
