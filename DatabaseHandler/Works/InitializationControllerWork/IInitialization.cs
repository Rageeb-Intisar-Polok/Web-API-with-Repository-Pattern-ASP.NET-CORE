using DatabaseHandler.Models.NonEntityModels.CustomizingDetailsModels;

namespace DatabaseHandler.Works.InitializationControllerWork
{
    public interface IInitialization
    {
        public Task<string> Initialize(InitializingModel Model);
    }
}
