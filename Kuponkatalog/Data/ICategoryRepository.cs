using Kuponkatalog.Models;
using System.Collections.Generic;

namespace Kuponkatalog.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategorys();
    }
}
