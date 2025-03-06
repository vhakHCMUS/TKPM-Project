using System;
using System.Security.Cryptography;
using System.Text;

namespace TKPM_Project.Services
{
    public class TokenGeneratorService : IService
    {
        // Phương thức để tạo token
        public Object Execute()
        {
            // print debug message
            Console.WriteLine("TokenGeneratorService.Execute() is called");
            int length = 32;
            using (var rngCrypto = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rngCrypto.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        // Phương thức GetToolInfo chỉ để hiển thị thông tin tool nếu cần
        public string GetToolInfo()
        {
            return "This service generates secure tokens.";
        }
    }
}
