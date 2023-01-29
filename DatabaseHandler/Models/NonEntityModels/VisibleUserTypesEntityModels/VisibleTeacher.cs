namespace DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels
{
    public class VisibleTeacher
    {
        public string ID { get; set; } = "Unknown";
        public string Name { get; set; } = "Unknown";
        public string? Email { get; set; } = "Unknown";
        public string? Phone { get; set; } = "Unknown";


        public string Department { get; set; }
        public string? Designation { get; set; } = "Unknown";
    }
}
