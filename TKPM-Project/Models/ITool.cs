namespace TKPM_Project.Models
{
    public interface ITool
    {
        string GetName();           // Trả về tên của công cụ
        string GetDescription();    // Trả về mô tả của công cụ
        string GetAvatar();         // Trả về avatar đại diện của công cụ
        void Execute();             // Hàm thực thi của công cụ
        string GetPath();           // Trả về đường dẫn của công cụ, ví dụ: "/Tools/Tool-name"
    }

}
