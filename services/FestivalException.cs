using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace festival.services
{
    public class FestivalException : ApplicationException
    {
        public FestivalException(String message) : base(message) {
        }
    }
}