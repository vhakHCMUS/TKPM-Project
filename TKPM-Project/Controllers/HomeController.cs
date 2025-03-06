using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TKPM_Project.Models;
using TKPM_Project.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace TKPM_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Index action sẽ load tất cả các tools và hiển thị chúng trên giao diện
        public IActionResult Index()
        {
            // Sử dụng ToolLoader để lấy danh sách các tools
            List<ITool> tools = ToolLoader.LoadTools();

            // Truyền danh sách tools vào View
            return View(tools);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
