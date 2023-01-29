namespace DatabaseHandler.Models.NonEntityModels.CustomizingDetailsModels
{
    public class InitializingModel
    {
        public int LevelCount { get; set; }
        public SortedSet<string>? Terms { get; set; }
        public SortedSet<string>? RolesOfOfficials { get; set; }
    }
}
