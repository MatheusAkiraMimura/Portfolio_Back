namespace Portfolio.Models.ViewModel
{
    public class UserRegistrationViewModel
    {
        public UserRegistrationViewModel()
        {
            Nome = "";
            Email = "";
            Senha = "";
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
