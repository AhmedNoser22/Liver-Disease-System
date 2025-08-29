namespace Liver_Disease_System.Setting
{
    public static class FileSetting
    {
        public static List<string> AllowedExtensions { get; } = new List<string> { ".png", ".jpg" };
        public const long MaxFileSize = 1 * 1024 * 1024; // 1 MB
    }
}
