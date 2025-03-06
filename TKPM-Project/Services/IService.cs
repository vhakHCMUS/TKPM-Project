namespace TKPM_Project.Services
{
    public interface IService
    {
        object Execute();  // Kiểu trả về là object để có thể trả về bất kỳ loại dữ liệu nào
        string GetToolInfo();
    }
}
