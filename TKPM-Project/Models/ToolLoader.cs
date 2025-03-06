using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using TKPM_Project.Models;
using TKPM_Project.Models.Tools;

public class ToolLoader
{
    public static List<ITool> LoadTools()
    {
        List<Tool> tools = new List<Tool>();

        // Lấy tất cả các lớp kế thừa từ Tool
        var toolTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Tool)) && !t.IsAbstract)
            .ToList();

        foreach (var type in toolTypes)
        {
            // Lấy constructor đầu tiên (constructor với ít tham số nhất)
            var constructor = type.GetConstructors().OrderBy(c => c.GetParameters().Length).FirstOrDefault();

            if (constructor != null)
            {
                // Tạo danh sách các giá trị mặc định cho constructor
                var parameters = constructor.GetParameters();
                var parameterValues = new object[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                {
                    // Kiểm tra kiểu dữ liệu và khởi tạo giá trị mặc định
                    var parameterType = parameters[i].ParameterType;

                    if (parameterType == typeof(string))
                    {
                        parameterValues[i] = "Default Value";
                    }
                    else if (parameterType.IsValueType)
                    {
                        parameterValues[i] = Activator.CreateInstance(parameterType); // Giá trị mặc định cho kiểu struct
                    }
                    else
                    {
                        parameterValues[i] = null; // Giá trị mặc định cho kiểu class
                    }
                }

                // Tạo một instance từ constructor và truyền các giá trị mặc định
                Tool tool = (Tool)constructor.Invoke(parameterValues);
                tools.Add(tool);
            }
        }

        // Chuyển đổi List<Tool> thành List<ITool>
        return tools.Cast<ITool>().ToList();
    }
}
