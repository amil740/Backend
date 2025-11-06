namespace AiForProgrammingWebSite.Models;

public class CodeAnalysisRequest
{
    public string Code { get; set; } = string.Empty;
    public string Language { get; set; } = "csharp";
    public string Task { get; set; } = "analyze"; // analyze, refactor, debug, complete, explain
}

public class CodeAnalysisResponse
{
    public string OriginalCode { get; set; } = string.Empty;
    public string ProcessedCode { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public List<CodeSuggestion> Suggestions { get; set; } = new();
    public List<CodeIssue> Issues { get; set; } = new();
    public bool Success { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}

public class CodeSuggestion
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // Performance, Security, Best Practice, etc.
    public int Line { get; set; }
    public string Severity { get; set; } = "Info"; // Info, Warning, Error
}

public class CodeIssue
{
    public string Type { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public int Line { get; set; }
    public string Severity { get; set; } = "Warning";
    public string? SuggestedFix { get; set; }
}
