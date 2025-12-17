using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using System;

namespace ProjetoDS.Services
{
    public class FakeEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Apenas exibe no console (não envia e-mail de verdade)
            Console.WriteLine($"FakeEmailSender -> Para: {email}, Assunto: {subject}, Mensagem: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
}
