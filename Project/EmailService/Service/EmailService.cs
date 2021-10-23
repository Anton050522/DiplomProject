using EmailServices.Interface;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailServices.Service
{
    public class EmailService : IEmailService
    {
        public async void SendEmailAdmin(string firstName, string lastName, string surName, string email)
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress("defektoskopiyaas@gmail.com", "Регистрация нового пользователя");
            message.To.Add(email);
            message.Subject = "Регистрации нового пользователя";
            message.Body = $"<div style=\"color: red;\">Пользователь {lastName} {firstName} {surName} зарегестрировался в АС Дефектоскопия. " +
                $"<br>Необходима верификация</br></div>";
            message.Attachments.Add(new Attachment("wwwroot/images/logo.gif"));

            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Credentials = new NetworkCredential("defektoskopiyaas@gmail.com", "stager050522");
                client.Port = 587;
                client.EnableSsl = true;
                await Task.Run(() => client.Send(message)); 
            }
        }
        public async void SendEmailUser(string firstName, string lastName, string surName, string email, string password)
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress("defektoskopiyaas@gmail.com", "Регистрация нового пользователя");
            message.To.Add(email);
            message.Subject = "Спасибо за регистрацию";
            message.Body = $"<div style=\"color: black;\">Пользователь {lastName} {firstName} {surName} успешно зарегистрировался в АС Дефектоскопия. \n" +
                $"<br>Ваши данные для входа в систему:</br>" +
                $"<br>E-mail - {email}</br>" +
                $"<br>Пароль - {password}</br></div>" +
                $"<br>Ожидайте подтверждения регистрации</br></div>" +
                $"<br>Благодарим за использование АС 'Дефектоскопия'!!!</br>";
            message.Attachments.Add(new Attachment("wwwroot/images/logo.gif"));

            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Credentials = new NetworkCredential("defektoskopiyaas@gmail.com", "stager050522");
                client.Port = 587;
                client.EnableSsl = true;
                await Task.Run(() => client.Send(message));
            }
        }
    }
}
