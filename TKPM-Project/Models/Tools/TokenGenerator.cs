namespace TKPM_Project.Models.Tools
{
    public class TokenGenerator : Tool
    {
        public TokenGenerator() : base("Token Generator", "Generates tokens for security purposes", "token_avatar.png")
        {
        }

        public override void Execute()
        {
            // Thực thi logic tạo token
            Console.WriteLine("Executing Token Generator...");
        }
    }

}
