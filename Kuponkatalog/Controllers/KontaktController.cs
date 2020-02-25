using Kuponkatalog.Data;
using Kuponkatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kuponkatalog.Controllers
{
    public class KontaktController : Controller
    {
        private readonly IMessageRepository _messageRepository;

        public KontaktController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                _messageRepository.AddMessage(message);

                return RedirectToAction("TakForBesked");
            }

            return View(message);
        }

        [HttpGet]
        public IActionResult TakForBesked()
        {
            return View();
        }
    }
}