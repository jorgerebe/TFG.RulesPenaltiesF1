using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Infrastructure;

public class FakeEmailSender : IEmailSender
{
   public Task SendEmailAsync(string to, string from, string subject, string body)
   {
      return Task.CompletedTask;
   }
}
