﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kuponkatalog.Models;

namespace Kuponkatalog.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> GetAllCategorys()
        {
            return _appDbContext.Categories;
        }
    }
}
