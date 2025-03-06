namespace TKPM_Project.Models.Tools
{
    public class ImageCompressor : Tool
    {
        public ImageCompressor()
            : base("Image Compressor", "Compresses images to reduce file size", "image_compressor_avatar.png")
        {
        }

        public override void Execute()
        {
            // Thực thi logic nén hình ảnh
            Console.WriteLine("Executing Image Compressor...");
        }
    }
}
