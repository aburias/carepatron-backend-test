using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Abstractions
{
    public interface IEmailRepository
    {
        Task Send(string email, string message);
    }
}
