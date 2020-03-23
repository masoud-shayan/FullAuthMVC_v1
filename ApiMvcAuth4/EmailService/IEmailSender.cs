﻿using System.Threading.Tasks;

 namespace ApiMvcAuth4.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
