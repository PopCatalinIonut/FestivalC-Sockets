using System;

namespace festival.model.validator
{
    public class ArtistValidator : IValidator<Artist>
    {
        public void Validate(Artist e)
        {
            String errors="";
            if (e.name == null || e.name == "")
                errors += "Invalid name\n";

            if (e.ID < 0)
                errors += "Invalid ID";

            if (errors.Length>0)
                throw new ValidationException(errors);
        }
    }
}