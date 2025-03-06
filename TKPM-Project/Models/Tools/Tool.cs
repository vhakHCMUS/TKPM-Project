namespace TKPM_Project.Models.Tools
{
    public class Tool : ITool
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Avatar { get; private set; }

        public Tool(string name, string description, string avatar)
        {
            Name = name;
            Description = description;
            Avatar = avatar;
        }

        public string GetName() => Name;

        public string GetDescription() => Description;

        public string GetAvatar() => Avatar;

        public virtual void Execute()
        {
            // Thực thi công cụ (cụ thể cho mỗi tool khác nhau)
        }

        public string GetPath()
        {
            // Trả về đường dẫn dựa trên tên công cụ
            return $"/Tools/{Name}";
        }
    }

}
