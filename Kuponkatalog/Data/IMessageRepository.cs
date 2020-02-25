using Kuponkatalog.Models;
using System.Collections.Generic;

namespace Kuponkatalog.Data
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void SetMessageToRead(int messageId);
        void DeleteMessage(int messageId);
        IEnumerable<Message> GetUnarchivedMessages();
        IEnumerable<Message> GetArchivedMessages();
        Message GetMessageById(int messageId);
        void ArchiveMessage(int messageId);
    }
}
