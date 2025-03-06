using TKPM_Project.Models;

namespace TKPM_Project.Controllers.Tools
{
    public class ToolServiceViewModel
    {
        // Thuộc tính lưu trữ thông tin của tool
        public ITool Tool { get; set; }

        // Thuộc tính lưu trữ instance của service
        public object Service { get; set; }
    }
}
