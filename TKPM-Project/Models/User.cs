namespace TKPM_Project.Models
{
    public class User
    {
        public int Id { get; set; } // Khóa chính
        public string Username { get; set; } // Tên đăng nhập
        public string Password { get; set; } // Mật khẩu (nên hash khi thực tế)
        public string Email { get; set; } // Email người dùng
        public string Role { get; set; } // Phân quyền: anonymous, user, premium, admin
        public bool IsPremium { get; set; } // Đánh dấu user premium
        public DateTime CreatedAt { get; set; } // Ngày tạo tài khoản
    }
}
