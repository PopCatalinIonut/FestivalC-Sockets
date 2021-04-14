using System;

namespace festival.model.validator
{
    public class ShowValidator : IValidator<Show>
    {
        public void Validate(Show e)
        {
            String errors = "";

            if (e.ID < 0)
                errors += "Invalid ID\n";

            if (e.date == null || e.date > DateTime.Now)
                errors += "Invalid Date\n";

            if (String.IsNullOrEmpty(e.location) || e.location == null)
                errors += "Invalid location\n";

            if (e.soldSeats < 0 || e.totalSeats < 0 || e.totalSeats < e.soldSeats)
                errors += "Invalid seats\n";

            if (e.name == null || String.IsNullOrEmpty(e.name))
                errors += "Invalid name\n";

            if (e.artist == null)
                errors += "Invalid artist\n";

            if (errors.Length > 0)
                throw new ValidationException(errors);
        }
    }
}