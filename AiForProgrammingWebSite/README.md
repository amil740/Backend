# ?? AI Programming Assistant

Advanced AI-powered code analysis and optimization tool built with **Blazor Server** and **.NET 8**.

![AI Programming Assistant](https://img.shields.io/badge/.NET-8.0-blue)
![Blazor](https://img.shields.io/badge/Blazor-Server-purple)
![License](https://img.shields.io/badge/license-MIT-green)

## ? Features

### ?? **Code Analysis**
- Deep code quality analysis
- Performance optimization suggestions
- Security vulnerability detection
- Best practices recommendations

### ?? **Smart Refactoring**
- Automatic code refactoring
- SOLID principles application
- Clean code transformations
- Design pattern suggestions

### ?? **Bug Detection & Fixing**
- Intelligent bug detection
- Root cause analysis
- Suggested fixes with explanations
- Runtime error prevention

### ? **Code Completion**
- Context-aware code generation
- Implementation suggestions
- Error handling additions
- Documentation generation

### ?? **Code Explanation**
- Plain language explanations
- Concept breakdowns
- Use case examples
- Learning resources

### ?? **Multi-Language Support**
- C# / .NET
- Python
- JavaScript / TypeScript
- Java
- C++
- Go
- Rust
- And more...

## ?? Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- OpenAI API Key (optional for full functionality)

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/yourusername/ai-programming-assistant.git
cd ai-programming-assistant
```

2. **Restore packages**
```bash
cd AiForProgrammingWebSite
dotnet restore
```

3. **Configure OpenAI API (Optional)**

Edit `appsettings.json`:
```json
{
  "OpenAI": {
    "ApiKey": "YOUR_OPENAI_API_KEY_HERE",
    "Endpoint": "https://api.openai.com/v1",
    "Model": "gpt-4-turbo-preview"
  }
}
```

To get an API key:
- Visit [OpenAI Platform](https://platform.openai.com)
- Create an account or sign in
- Go to API Keys section
- Generate a new API key

**Note:** The application works in demo mode without an API key, but will provide mock responses.

4. **Run the application**
```bash
dotnet run
```

5. **Open in browser**
Navigate to: `https://localhost:5001` or `http://localhost:5000`

## ?? Technology Stack

| Technology | Purpose |
|------------|---------|
| **Blazor Server** | Interactive web UI framework |
| **.NET 8** | Backend framework |
| **OpenAI GPT-4** | AI code analysis engine |
| **Tailwind CSS** | Modern styling framework |
| **Highlight.js** | Syntax highlighting |
| **Azure OpenAI** | Enterprise AI (alternative) |

## ?? Usage

### Basic Workflow

1. **Select Language** - Choose your programming language from the dropdown
2. **Choose Task** - Select the AI task:
   - ?? Analyze - Code quality analysis
   - ?? Refactor - Code improvement
   - ?? Debug - Bug detection
   - ? Complete - Code completion
   - ?? Explain - Code explanation

3. **Paste Code** - Enter your code in the text area
4. **Analyze** - Click "Analyze Code" button
5. **Review Results** - Get AI-powered insights, suggestions, and improvements

### Example Use Cases

**Bug Detection:**
```csharp
public int Divide(int a, int b)
{
    return a / b; // AI will detect: Missing zero check!
}
```

**Code Refactoring:**
```csharp
// Before
public void Process(string data)
{
    if (data != null)
        if (data.Length > 0)
            Console.WriteLine(data);
}

// AI suggests: Guard clauses, null checking, etc.
```

## ??? Project Structure

```
AiForProgrammingWebSite/
??? Components/
?   ??? Layout/
?   ?   ??? MainLayout.razor          # Main layout
?   ??? Pages/
?   ?   ??? Home.razor                # Main AI interface
?   ?   ??? About.razor               # About page
?   ??? App.razor                     # Root component
?   ??? Routes.razor                  # Routing configuration
?   ??? _Imports.razor                # Global imports
??? Models/
?   ??? CodeModels.cs                 # Data models
??? Services/
?   ??? AiCodingAssistantService.cs   # AI service logic
??? wwwroot/
?   ??? css/
?       ??? app.css                   # Custom styles
??? Program.cs                        # Application entry point
??? appsettings.json                  # Configuration
??? AiForProgrammingWebSite.csproj    # Project file
```

## ?? Configuration

### OpenAI Settings

```json
{
  "OpenAI": {
    "ApiKey": "sk-...",              // Your OpenAI API key
    "Endpoint": "https://api.openai.com/v1",
    "Model": "gpt-4-turbo-preview"    // or "gpt-3.5-turbo"
  }
}
```

### Azure OpenAI Settings

```json
{
  "OpenAI": {
    "ApiKey": "your-azure-key",
    "Endpoint": "https://your-resource.openai.azure.com/",
    "Model": "your-deployment-name"
  }
}
```

## ?? Advanced Features

### Real-time Analysis
Code is analyzed in real-time with streaming responses for better user experience.

### Multi-language Support
Supports 8+ programming languages with language-specific best practices.

### Syntax Highlighting
Beautiful code highlighting using Highlight.js with the GitHub Dark theme.

### Responsive Design
Fully responsive UI that works on desktop, tablet, and mobile devices.

### Statistics Dashboard
Track analysis results with visual statistics for issues, suggestions, and code metrics.

## ?? Deployment

### Deploy to Azure

```bash
# Create Azure Web App
az webapp create --name your-app-name --resource-group your-rg --plan your-plan

# Deploy
dotnet publish -c Release
# Then use Azure deployment methods (VS Publish, GitHub Actions, etc.)
```

### Docker Support

```bash
# Build image
docker build -t ai-programming-assistant .

# Run container
docker run -p 8080:80 ai-programming-assistant
```

## ?? Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## ?? License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ?? Acknowledgments

- [OpenAI](https://openai.com) for GPT-4 API
- [Microsoft](https://microsoft.com) for .NET and Blazor
- [Tailwind CSS](https://tailwindcss.com) for styling
- [Highlight.js](https://highlightjs.org) for syntax highlighting

## ?? Contact

For questions or support, please open an issue on GitHub.

---

**Made with ?? using Blazor, .NET 8, and AI**

?? Don't forget to star this repo if you find it useful!
