using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services;

namespace Socializer_001.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatServices chatservices;
        public ChatController(ChatServices cs)
        {
            chatservices = cs;
        }

        [HttpGet]
        public IActionResult CreateChatDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateChatDetails(CreateChatDetail CD)
        {
            Chat Newchat = new Chat()
            {
                Id = -1,
                UserId = 1,
                Name = CD.Name,
                Description = CD.Description,
                AccessToken = "test01",
                TimeStamp = DateTime.UtcNow
            };

            return RedirectToAction("ChatPage", Newchat);
        }
        [HttpGet]
        public IActionResult ChatPage(Chat Chat)
        {
            return View(Chat);
        }
    }
}
