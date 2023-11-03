using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationDRY
{
    public class CalendarValidator : AbstractValidator<Calendar>
    {
        public CalendarValidator(IValidator<IHasDateRange> dateRangeValidator)
        {
            Include(dateRangeValidator);
        }
    }

    public class ScheduleValidator : AbstractValidator<Schedule>
    {
        public ScheduleValidator(IValidator<IHasDateRange> dateRangeValidator)
        {
            Include(dateRangeValidator);
        }
    }

    public class DateRangeValidator : AbstractValidator<IHasDateRange>
    {
        public DateRangeValidator()
        {
            RuleFor(x => x)
                .Must(x => x.To >= x.From)
                .WithMessage("To cannot be less than From");
        }
    }

    public interface IHasDateRange
    {
        DateTime From { get; set; }
        DateTime To { get; set; }
    }

    public class Calendar : IHasDateRange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        // other properties
    }

    public class Schedule : IHasDateRange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
     
        // other properties
    }
}
