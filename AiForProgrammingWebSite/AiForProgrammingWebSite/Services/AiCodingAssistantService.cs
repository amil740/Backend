using AiForProgrammingWebSite.Models;
using Azure;
using Azure.AI.OpenAI;
using System.Text;
using System.Text.Json;

namespace AiForProgrammingWebSite.Services;

public class AiCodingAssistantService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _model;

    public AiCodingAssistantService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _apiKey = _configuration["OpenAI:ApiKey"] ?? "";
        _model = _configuration["OpenAI:Model"] ?? "gpt-4-turbo-preview";
    }

    public async Task<CodeAnalysisResponse> AnalyzeCodeAsync(CodeAnalysisRequest request)
    {
        try
        {
            var systemPrompt = GetSystemPrompt(request.Task);
            var userPrompt = GetUserPrompt(request);

            var response = await CallOpenAIAsync(systemPrompt, userPrompt);
            
            return ParseResponse(response, request);
        }
        catch (Exception ex)
        {
            return new CodeAnalysisResponse
            {
                Success = false,
                ErrorMessage = $"Error: {ex.Message}",
                OriginalCode = request.Code
            };
        }
    }

    private string GetSystemPrompt(string task)
    {
        return task.ToLower() switch
        {
            "analyze" => @"You are an expert code analyzer. Analyze the provided code and:
1. Identify potential bugs and issues
2. Suggest performance improvements
3. Recommend best practices
4. Check for security vulnerabilities
5. Provide detailed explanations

Return your response in JSON format with these fields:
- suggestions: array of {title, description, category, line, severity}
- issues: array of {type, message, line, severity, suggestedFix}
- explanation: overall code analysis summary",

            "refactor" => @"You are an expert code refactoring specialist. Refactor the provided code to:
1. Improve readability and maintainability
2. Apply SOLID principles
3. Optimize performance
4. Follow language-specific best practices
5. Add helpful comments

Return your response in JSON format with:
- processedCode: the refactored code
- explanation: detailed explanation of changes made
- suggestions: array of additional improvement ideas",

            "debug" => @"You are an expert debugger. Analyze the code for bugs and:
1. Identify syntax errors
2. Find logical errors
3. Detect runtime issues
4. Suggest fixes for each issue
5. Explain root causes

Return your response in JSON format with:
- issues: array of {type, message, line, severity, suggestedFix}
- processedCode: corrected version of the code
- explanation: debugging summary",

            "complete" => @"You are an intelligent code completion assistant. Based on the provided code:
1. Understand the context and intent
2. Complete the implementation
3. Add error handling
4. Include documentation
5. Follow best practices

Return your response in JSON format with:
- processedCode: completed code
- explanation: what was added and why",

            "explain" => @"You are a code education expert. Explain the provided code:
1. What does it do?
2. How does it work?
3. Key concepts used
4. Potential use cases
5. Learning points

Return your response in JSON format with:
- explanation: comprehensive code explanation
- suggestions: array of learning resources or related concepts",

            _ => "You are an expert programming assistant. Help with the provided code."
        };
    }

    private string GetUserPrompt(CodeAnalysisRequest request)
    {
        return $@"Language: {request.Language}
Task: {request.Task}

Code:
```{request.Language}
{request.Code}
```

Please analyze this code and provide your response in valid JSON format.";
    }

    private async Task<string> CallOpenAIAsync(string systemPrompt, string userPrompt)
    {
        if (string.IsNullOrEmpty(_apiKey) || _apiKey == "YOUR_OPENAI_API_KEY_HERE")
        {
            // Return mock response for demo purposes
            return GetMockResponse();
        }

        var requestBody = new
        {
            model = _model,
            messages = new[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user", content = userPrompt }
            },
            temperature = 0.7,
            max_tokens = 2000
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

        var response = await _httpClient.PostAsync(
            "https://api.openai.com/v1/chat/completions",
            content
        );

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var jsonResponse = JsonDocument.Parse(responseContent);
        
        return jsonResponse.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? "";
    }

    private string GetMockResponse()
    {
        return @"{
            ""explanation"": ""This code is a simple console application. Consider adding error handling, logging, and following SOLID principles for better maintainability."",
            ""suggestions"": [
                {
                    ""title"": ""Add Error Handling"",
                    ""description"": ""Consider wrapping your code in try-catch blocks to handle potential exceptions."",
                    ""category"": ""Best Practice"",
                    ""line"": 1,
                    ""severity"": ""Warning""
                },
                {
                    ""title"": ""Use Dependency Injection"",
                    ""description"": ""Consider using DI container for better testability and maintainability."",
                    ""category"": ""Architecture"",
                    ""line"": 1,
                    ""severity"": ""Info""
                },
                {
                    ""title"": ""Add Logging"",
                    ""description"": ""Implement structured logging using ILogger for better observability."",
                    ""category"": ""Best Practice"",
                    ""line"": 1,
                    ""severity"": ""Info""
                }
            ],
            ""issues"": [
                {
                    ""type"": ""Simplicity"",
                    ""message"": ""Code could benefit from more structure and organization."",
                    ""line"": 1,
                    ""severity"": ""Info"",
                    ""suggestedFix"": ""Create separate classes and methods for different responsibilities.""
                }
            ],
            ""processedCode"": ""// Refactored version\\nusing Microsoft.Extensions.Logging;\\n\\nvar builder = WebApplication.CreateBuilder(args);\\nvar app = builder.Build();\\n\\napp.MapGet(\\""/\"", () => \""Hello, World!\"");\\n\\napp.Run();""
        }";
    }

    private CodeAnalysisResponse ParseResponse(string jsonResponse, CodeAnalysisRequest request)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Try to extract JSON from markdown code blocks if present
            var json = jsonResponse;
            if (jsonResponse.Contains("```json"))
            {
                var start = jsonResponse.IndexOf("```json") + 7;
                var end = jsonResponse.IndexOf("```", start);
                json = jsonResponse.Substring(start, end - start).Trim();
            }
            else if (jsonResponse.Contains("```"))
            {
                var start = jsonResponse.IndexOf("```") + 3;
                var end = jsonResponse.IndexOf("```", start);
                json = jsonResponse.Substring(start, end - start).Trim();
            }

            var response = JsonSerializer.Deserialize<CodeAnalysisResponse>(json, options);
            
            if (response != null)
            {
                response.OriginalCode = request.Code;
                response.Success = true;
                
                if (string.IsNullOrEmpty(response.ProcessedCode))
                {
                    response.ProcessedCode = request.Code;
                }
                
                return response;
            }
        }
        catch (JsonException)
        {
            // If JSON parsing fails, create a response from the text
            return new CodeAnalysisResponse
            {
                Success = true,
                OriginalCode = request.Code,
                ProcessedCode = request.Code,
                Explanation = jsonResponse,
                Suggestions = new(),
                Issues = new()
            };
        }

        return new CodeAnalysisResponse
        {
            Success = false,
            ErrorMessage = "Failed to parse AI response",
            OriginalCode = request.Code
        };
    }
}
