using Portfolio.Interfaces;
using Portfolio.Interfaces.Repository;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterUser(User user)
        {
            // Verificar se os campos necessários estão presentes
            if (string.IsNullOrWhiteSpace(user.Nome) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Senha))
            {
                throw new ArgumentException("Nome, Email e Senha são obrigatórios.");
            }

            // Verificar se o email já está em uso
            if (!await _userRepository.IsEmailUniqueAsync(user.Email))
            {
                throw new InvalidOperationException("O email já está em uso.");
            }

            // Criptografar a senha
            user.Senha = CriptografarSenha(user.Senha);

            // Adicionar o usuário no banco de dados
            return await _userRepository.AddAsync(user);
        }

        private string CriptografarSenha(string senha)
        {
            // Implementação de criptografia de senha (BCrypt)
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public async Task<User> Authenticate(string email, string senha)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            // Verifique se a senha é válida
            if (!BCrypt.Net.BCrypt.Verify(senha, user.Senha))
            {
                return null;
            }

            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            // Implementar a lógica de atualização (não esqueça de criptografar a senha, se alterada)
            return await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
