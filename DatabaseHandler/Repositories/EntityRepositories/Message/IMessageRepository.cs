
using DatabaseHandler.Models.EntityModels;

namespace DatabaseHandler.Repositories.EntityRepositories.MessageRepository

{
    public interface IMessageRepository
    {
        public Task<List< Message >> GetLastMessage(String UserId);
        public Task<List< Message >> GetNextMessage(String UserId, String MessageId);
    }
}
