using System;

namespace festival.model.validator
{
    public class TicketValidator : IValidator<Ticket>
    {
        public void Validate(Ticket e)
        {
            String errors = "";

            if (e.ID < 0)
                errors += "Invalid ID\n";

            if (e.seats < 0)
                errors += "Invalid seats\n";

            if (e.buyerName == null || String.IsNullOrEmpty(e.buyerName))
                errors += "Invalid buyer name\n";

            if (e.showID == null)
                errors += "Invalid show\n";

            if (errors.Length > 0)
                throw new ValidationException(errors);
        }
    }
}