using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailService.EmailServices.Entities;

namespace MailService.EmailServices.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
