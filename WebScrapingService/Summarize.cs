using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace WebScrapingService;

public class SummaryService : ISummarise
{
    private OpenAIAPI _api;

    public SummaryService(APIAuthentication authentication)
    {
        _api = new OpenAIAPI(authentication);
    }
    public async Task<string> Summary(string url)
    {
        var prompt = $"Give a 150 character summary of {url} ";
        var result = await _api.Completions.CreateCompletionAsync(new CompletionRequest(prompt, model: Model.DavinciText, numOutputs:1, temperature:0.7, top_p:1.0, max_tokens:60, frequencyPenalty:0.0, presencePenalty:1 ));
        return result.ToString();
    }
}