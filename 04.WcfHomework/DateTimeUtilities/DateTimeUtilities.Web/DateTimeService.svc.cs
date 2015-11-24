namespace DateTimeUtilities.Web
{
    using System;

    public class DateTimeService : IDateTimeService
    {
        public string GetDayOfWeek(DateTime date)
        {
            string dayOfWeekInEnglish = date.DayOfWeek.ToString();
            switch (dayOfWeekInEnglish)
            {
                case "Monday":
                    return "Понеделник";
                case "Tuesday":
                    return "Вторник";
                case "Wednesday":
                    return "Сряда";
                case "Thursday":
                    return "Четвъртък";
                case "Friday":
                    return "Петък";
                case "Saturday":
                    return "Събота";
                case "Sunday":
                    return "Неделя";
                default:
                    return "Невалиден ден от седмицата!";
            }
        }
    }
}
