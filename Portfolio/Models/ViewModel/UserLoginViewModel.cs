namespace Portfolio.Models.ViewModel
{
    public class UserLoginViewModel
    {
        public UserLoginViewModel()
        {
            Email = "";
            Senha = "";
        }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
