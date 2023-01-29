namespace DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels
{
    public class VisibleStudent
    {
        public string ID { get; set; } = "Unknown";
        public string Name { get; set; } = "Unknown";
        public string? Email { get; set; } = "Unknown";
        public string? Phone { get; set; } = "Unknown";



        public string Department { get; set; }
        public int Level { get; set; }
        public string Term { get; set; }
    }
}
