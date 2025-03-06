using Microsoft.AspNetCore.Mvc;
using TKPM_Project.Models.Tools;
using System.Collections.Generic;
using TKPM_Project.Models;

namespace TKPM_Project.Controllers.Tools
{
    public class ToolController : Controller
    {
        // Action Index cho trang Tool
        public IActionResult Index()
        {
            // Sử dụng ToolLoader để tải tất cả các tool
            List<ITool> tools = ToolLoader.LoadTools();
            // Truyền danh sách tools vào View
            return View(tools);
        }

        // Action để xử lý request đến các tool cụ thể
        public IActionResult Tool(string toolName)
        {
            // Tải danh sách tools (có thể bạn sẽ muốn tối ưu việc này sau)
            List<ITool> tools = ToolLoader.LoadTools();

            // Tìm tool dựa vào tên
            ITool tool = tools.FirstOrDefault(t =>
                t.GetName().ToLower() == toolName.ToLower());

            if (tool == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy tool
            }

            // Trả về view có tên trùng với tên của tool
            return View(toolName, tool);
        }
    }
}