using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kuponkatalog.Models;

namespace Kuponkatalog.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _appDbContext;

        public MessageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddMessage(Message message)
        {
            _appDbContext.Message.Add(message);
            _appDbContext.SaveChanges();
        }

        public void ArchiveMessage(int messageId)
        {
            var message = GetMessageById(messageId);
            message.Status = Enums.messageStatus.Archived;
            _appDbContext.Update(message);
            _appDbContext.SaveChanges();
        }

        public void DeleteMessage(int messageId)
        {
            var message = GetMessageById(messageId);
            _appDbContext.Message.Remove(message);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Message> GetArchivedMessages()
        {
            var messages = new List<Message>();

            foreach (var message in _appDbContext.Message)
            {
                if (message.Status == Enums.messageStatus.Archived)
                {
                    messages.Add(message);
                }
            }

            messages = messages.OrderByDescending(m => m.TimeSend).ToList();

            return messages;
        }

        public Message GetMessageById(int messageId)
        {
            var message = _appDbContext.Message.FirstOrDefault(m => m.MessageId == messageId);

            return message;
        }

        public IEnumerable<Message> GetUnarchivedMessages()
        {
            var messages = new List<Message>();

            foreach (var message in _appDbContext.Message)
            {
                if (message.Status != Enums.messageStatus.Archived)
                {
                    messages.Add(message);
                }
            }

            messages = messages.OrderByDescending(m => m.TimeSend).ToList();

            return messages;
        }

        public void SetMessageToRead(int messageId)
        {
            var message = GetMessageById(messageId);
            message.Status = Enums.messageStatus.Read;
            _appDbContext.Message.Update(message);
            _appDbContext.SaveChanges();
        }
    }
}
