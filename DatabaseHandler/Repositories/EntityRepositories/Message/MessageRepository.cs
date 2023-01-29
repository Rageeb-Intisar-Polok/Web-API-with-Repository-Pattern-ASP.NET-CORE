// initial all message getting is configured. rest of the entire required
// configuration is still need to program.

using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Repositories.EntityRepositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        public readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }
        public async Task<List<Message>> GetLastMessage(string UserId)
        {
            List<Message> Messages = await _context.Messages.FromSqlRaw<Message>("InitialGetMessageOfConnectionId {0}", UserId).ToListAsync();
            return Messages;
          //  return _context.messages.FromSqlRaw<Message>("InitialGetMessageOfConnectionId {0}", UserId).ToList<Message>();
        }
        public async Task<List<Message>> GetNextMessage(String UserId, String MessageId)
        {
            List<Message> Messages = await _context.Messages.FromSqlRaw<Message>("InitialGetMessageOfConnectionId {0}", UserId).ToListAsync();
            //  return _context.messages.FromSqlRaw<Message>("InitialGetMessageOfConnectionId {0}", UserId).ToList<Message>();
            return Messages;
        }
    }
}
