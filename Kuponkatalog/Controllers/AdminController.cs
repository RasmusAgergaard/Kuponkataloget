using Kuponkatalog.Data;
using Kuponkatalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kuponkatalog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IPageRepository _pageRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;

        public AdminController(ICatalogRepository catalogRepository, IPageRepository pageRepository, ITagRepository tagRepository, IUserRepository userRepository, IMessageRepository messageRepository)
        {
            _catalogRepository = catalogRepository;
            _pageRepository = pageRepository;
            _tagRepository = tagRepository;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
        }

        /********** Index **********/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /********** Catalogs **********/
        [HttpGet]
        public IActionResult Catalogs()
        {
            var catalogViewModel = _catalogRepository.GetAllCatalogs();

            return View(catalogViewModel);
        }

        [HttpGet]
        public IActionResult NewCatalog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCatalog(Catalog catalog)
        {
            _catalogRepository.AddCatalog(catalog);

            return RedirectToAction("Catalogs");
        }

        [HttpGet]
        public IActionResult EditCatalog(int id)
        {
            var catalog = _catalogRepository.GetCatalogById(id);

            return View(catalog);
        }

        [HttpPost]
        public IActionResult EditCatalog(CatalogViewModel catalogViewModel)
        {
            _catalogRepository.UpdateCatalog(catalogViewModel);

            return RedirectToAction("Catalogs");
        }

        [HttpGet]
        public IActionResult DeleteCatalog(int id)
        {
            _catalogRepository.DeleteCatalogById(id);
            return RedirectToAction("Catalogs");
        }

        [HttpGet]
        public IActionResult AddPagesToCatalog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPagesToCatalog(CatalogPages catalogPages)
        {
            var catalogId = catalogPages.CatalogId;
            var pageId = catalogPages.PageId;
            _catalogRepository.AddPageToCatalog(catalogId, pageId);

            return View();
        }

        [HttpGet]
        public IActionResult RemovePagesFromCatalog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemovePagesFromCatalog(CatalogPages catalogPages)
        {
            var catalogId = catalogPages.CatalogId;
            var pageId = catalogPages.PageId;
            _catalogRepository.RemovePageFromCatalog(catalogId, pageId);

            return View();
        }

        /********** Pages **********/
        [HttpGet]
        public IActionResult Pages()
        {
            var pageAdminViewModel = _pageRepository.GetPagesWithCatalogs();

            return View(pageAdminViewModel);
        }

        [HttpGet]
        public IActionResult NewPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewPage(Page page)
        {
            _pageRepository.AddPage(page);

            return RedirectToAction("Pages");
        }

        [HttpGet]
        public IActionResult EditPage(int id)
        {
            var pageViewModel = _pageRepository.GetPageById(id);

            return View(pageViewModel);
        }

        [HttpPost]
        public IActionResult EditPage(PageViewModel pageViewModel)
        {
            _pageRepository.UpdatePage(pageViewModel);

            return RedirectToAction("Pages");
        }

        [HttpGet]
        public IActionResult DeletePage(int id)
        {
            _pageRepository.DeletePageById(id);
            return RedirectToAction("Pages");
        }

        [HttpGet]
        public IActionResult AutomaticAdTester5000()
        {
            var pages = _pageRepository.GetAllPages();
            return View(pages);
        }

        [HttpGet]
        public async Task<IActionResult> TestUrlOfAllPages()
        {
            var client = new HttpClient();
            var pages = _pageRepository.GetAllPages().ToList();
            var errorUrl = "https://www.kuponkataloget.dk/Home/LukketKampagne";

            foreach (var page in pages)
            {
                if (page.PageId > 10)
                {
                    HttpResponseMessage response = await client.GetAsync(page.TargetUrl);
                    //response.EnsureSuccessStatusCode();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (responseUri == errorUrl)
                    {
                        page.Status = Enums.pageStatus.Expired;

                        var pageViewModel = new PageViewModel();
                        pageViewModel.Page = page;
                        pageViewModel.SavedPageId = page.PageId;
                        _pageRepository.UpdatePage(pageViewModel);
                    }
                }
            }

            return RedirectToAction("AutomaticAdTester5000");
        }

        /********** Tags **********/
        [HttpGet]
        public IActionResult AddTagToPage(int id, AddTagToPageViewModel addTagToPageViewModel)
        {
            //Lists
            addTagToPageViewModel.PageId = id;
            addTagToPageViewModel.TagsAvalible = _tagRepository.GetAllTags().ToList();
            addTagToPageViewModel.TagsOnPage = _tagRepository.GetTagsForPage(id).ToList();

            return View(addTagToPageViewModel);
        }

        [HttpPost]
        public IActionResult AddTagToPage(AddTagToPageViewModel addTagToPageViewModel)
        {
            //Add tag
            var tagId = addTagToPageViewModel.TagId;
            var pageId = addTagToPageViewModel.PageId;
            _tagRepository.AddTagToPage(tagId, pageId);

            //Lists
            addTagToPageViewModel.TagsAvalible = _tagRepository.GetAllTags().ToList();
            addTagToPageViewModel.TagsOnPage = _tagRepository.GetTagsForPage(pageId).ToList();

            return View(addTagToPageViewModel);
        }

        [HttpGet]
        public IActionResult RemoveTagFromPage(int id, AddTagToPageViewModel addTagToPageViewModel)
        {
            //Lists
            addTagToPageViewModel.PageId = id;
            addTagToPageViewModel.TagsAvalible = _tagRepository.GetAllTags().ToList();
            addTagToPageViewModel.TagsOnPage = _tagRepository.GetTagsForPage(id).ToList();

            return View(addTagToPageViewModel);
        }

        [HttpPost]
        public IActionResult RemoveTagFromPage(AddTagToPageViewModel addTagToPageViewModel)
        {
            //Remove tag
            var tagId = addTagToPageViewModel.TagId;
            var pageId = addTagToPageViewModel.PageId;
            _tagRepository.RemoveTagFromPage(tagId, pageId);

            //Lists
            addTagToPageViewModel.TagsAvalible = _tagRepository.GetAllTags().ToList();
            addTagToPageViewModel.TagsOnPage = _tagRepository.GetTagsForPage(pageId).ToList();

            return View(addTagToPageViewModel);
        }


        /********** Users **********/
        [HttpGet]
        public IActionResult Users()
        {
            var users = _userRepository.GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public IActionResult DeleteUser(string id)
        {
            _userRepository.DeleteUserById(id);

            return RedirectToAction("Users");
        }

        /********** Messages **********/
        [HttpGet]
        public IActionResult Messages()
        {
            var messages = _messageRepository.GetUnarchivedMessages();

            return View(messages);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            _messageRepository.SetMessageToRead(id);

            var message = _messageRepository.GetMessageById(id);

            return View(message);
        }

        [HttpGet]
        public IActionResult ArchiveMessage(int id)
        {
            _messageRepository.ArchiveMessage(id);

            return RedirectToAction("Messages");
        }

        [HttpGet]
        public IActionResult UnarchiveMessage(int id)
        {
            _messageRepository.SetMessageToRead(id);

            return RedirectToAction("MessagesArchive");
        }

        [HttpGet]
        public IActionResult DeleteMessage(int id)
        {
            _messageRepository.DeleteMessage(id);

            return RedirectToAction("MessagesArchive");
        }

        [HttpGet]
        public IActionResult MessagesArchive()
        {
            var messages = _messageRepository.GetArchivedMessages();

            return View(messages);
        }
    }
}
