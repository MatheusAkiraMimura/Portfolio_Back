namespace Portfolio.Models.ViewModel
{
    public class UserResponseViewModel
    {
        public UserResponseViewModel()
        {
            Nome = "";
            Email = "";
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
