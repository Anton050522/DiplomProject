namespace EmailServices.Interface
{
    public interface IEmailService
    {
        public void SendEmailAdmin(string firstName, string LastName, string surName, string email);
        public void SendEmailUser(string firstName, string LastName, string surName, string email, string password);
    }
}
