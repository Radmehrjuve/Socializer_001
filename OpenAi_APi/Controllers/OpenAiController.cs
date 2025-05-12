using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.SemanticKernel.ChatCompletion;

namespace OpenAi_APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        private readonly IChatCompletionService _chatCompletionService;
        public OpenAiController(IChatCompletionService cmp)
        {
                _chatCompletionService = cmp;
        }
        public async Task<string> GetAwsner(List<Message> messages)
        {
            ChatHistory chathistory = new ChatHistory();
            foreach (var message in messages)
            {
                switch (message.Role)
                {
                    case 0:
                        chathistory.AddUserMessage(message.Content);
                        break;
                    case 1:
                        chathistory.AddAssistantMessage(message.Content);
                        break;
                }
            }
            var response = await _chatCompletionService.GetChatMessageContentAsync(chathistory);
            var result = response?.Content?.ToString() ?? "No Response From AI";
            return result;
        }
    }
}
