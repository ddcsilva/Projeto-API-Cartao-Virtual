using Flunt.Notifications;
using Flunt.Validations;

namespace ApiCartao.Domain.Commands.Inputs
{
    public class GerarCartaoVirtualCommand : Notifiable
    {
        public string Email { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract().IsEmail(Email, "Email", "Email Inválido"));
        }
    }
}
