using Microsoft.AspNetCore.Mvc;
using TKPM_Project.Models.Tools;
using System.Collections.Generic;
using System.Linq;
using System;
using TKPM_Project.Services;
using TKPM_Project.Models;

namespace TKPM_Project.Controllers.Tools
{
    public class ToolController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public ToolController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            List<ITool> tools = ToolLoader.LoadTools();
            return View(tools);
        }

        public IActionResult Tool(string toolName)
        {
            List<ITool> tools = ToolLoader.LoadTools();
            ITool tool = tools.FirstOrDefault(t =>
                t.GetName().ToLower() == toolName.ToLower());

            if (tool == null)
            {
                return NotFound();
            }

            var serviceType = Type.GetType($"TKPM_Project.Services.{toolName}Service");
            if (serviceType != null)
            {
                var serviceInstance = _serviceProvider.GetService(serviceType);
                var viewModel = new ToolServiceViewModel
                {
                    Tool = tool,
                    Service = serviceInstance
                };

                return View(toolName, viewModel);
            }

            return View(toolName, tool);
        }

        [HttpPost]
        [Route("Tool/Execute/{toolName}")]
        public IActionResult Execute(string toolName)
        {
            var services = _serviceProvider.GetServices<IService>();
            var service = services.FirstOrDefault(s => s.GetType().Name == $"{toolName}Service");

            if (service == null)
            {
                return BadRequest(new { error = $"Could not resolve service for tool '{toolName}'." });
            }

            object result = service.Execute();
            return result != null ? Ok(result) : BadRequest(new { error = "Service returned null." });

        }
    }
}