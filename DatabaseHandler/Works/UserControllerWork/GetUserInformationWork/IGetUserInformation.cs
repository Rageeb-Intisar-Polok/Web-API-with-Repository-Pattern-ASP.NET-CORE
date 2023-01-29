namespace DatabaseHandler.Works.UserControllerWork.GetUserInformationWork
{
    public interface IGetUserInformation
    {
        public Task<object> AboutUser(string id);
    }
}
