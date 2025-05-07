using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        }
    }
}
