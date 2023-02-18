using System.Threading.Tasks;

namespace TFG.RulesPenaltiesF1.Core.Interfaces
{
   public interface IEmailSender
   {
      Task SendEmailAsync(string to, string from, string subject, string body);
   }
}
