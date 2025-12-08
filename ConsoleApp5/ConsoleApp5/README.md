# AI Creative Studio - Image & Video Generator

A beautiful, modern web application similar to ChatGPT that can generate AI-based images and videos with a stunning user interface.

## Features

? **AI Chat Assistant** - ChatGPT-like conversational interface
?? **AI Image Generator** - Create stunning images from text descriptions using DALL-E 3
?? **AI Video Generator** - Generate videos from text prompts
??? **Gallery** - Save and view all your AI-generated creations
?? **Responsive Design** - Works perfectly on desktop, tablet, and mobile
?? **English Keyboard Interface** - All text input uses English keyboard

## Technologies Used

- **Backend**: ASP.NET Core 8.0 (C# 12.0)
- **Frontend**: HTML5, CSS3, JavaScript (Vanilla)
- **APIs**: OpenAI (DALL-E 3, GPT-4)
- **Styling**: Modern CSS with Gradients, Animations, and Glassmorphism

## Setup Instructions

### 1. Get Your API Keys

#### OpenAI API Key (Required for Chat and Image Generation)
1. Go to [OpenAI Platform](https://platform.openai.com/)
2. Sign up or log in
3. Navigate to API Keys section
4. Create a new API key
5. Copy the key

### 2. Configure API Keys

Open `appsettings.json` and replace the placeholder with your actual API key:

```json
{
  "OpenAI": {
    "ApiKey": "sk-your-actual-api-key-here"
  }
}
```

### 3. Run the Application

#### Using Visual Studio:
1. Open the solution in Visual Studio
2. Press F5 or click the Run button
3. The application will open in your default browser

#### Using Command Line:
```bash
cd ConsoleApp5
dotnet run
```

The application will be available at:
- HTTPS: https://localhost:7000
- HTTP: http://localhost:5000

## Usage Guide

### Chat Tab
- Type your message in English
- Press Enter to send (Shift+Enter for new line)
- Have conversations with the AI assistant

### Image Generator Tab
1. Enter a detailed description of the image you want
2. Select the image size (Square, Landscape, or Portrait)
3. Click "Generate Image"
4. Wait a few seconds for your image to appear
5. The image is automatically saved to your gallery

### Video Generator Tab
1. Enter a description of the video you want
2. Select the video duration
3. Click "Generate Video"
4. Note: Video generation requires additional API configuration

### Gallery Tab
- View all your AI-generated images and videos
- Click on any item to open it in a new tab
- Gallery is saved in your browser's local storage

## Design Features

?? **Modern Dark Theme** - Easy on the eyes with beautiful gradients
? **Smooth Animations** - Fluid transitions and interactions
?? **Glassmorphism UI** - Frosted glass effect with backdrop blur
?? **Gradient Accents** - Purple and pink color scheme
?? **Mobile Responsive** - Adapts perfectly to all screen sizes

## API Costs

- **DALL-E 3**: ~$0.04 per image (1024x1024)
- **GPT-4**: ~$0.03 per 1K tokens
- Make sure to monitor your API usage on the OpenAI dashboard

## Troubleshooting

### "Failed to generate image" error
- Check that your OpenAI API key is correctly configured
- Verify your API key has sufficient credits
- Check your internet connection

### Images not displaying
- Check browser console for errors
- Verify API responses are successful
- Ensure CORS is properly configured

### Chat not responding
- Confirm API key is valid
- Check OpenAI API status
- Review browser console for errors

## Project Structure

```
ConsoleApp5/
??? Controllers/
?   ??? HomeController.cs       # Main page controller
?   ??? AIController.cs          # API endpoints for AI operations
??? Views/
?   ??? Home/
?   ?   ??? Index.cshtml        # Main application page
?   ??? Shared/
?   ?   ??? _Layout.cshtml      # Layout template
?   ??? _ViewStart.cshtml       # View start configuration
??? wwwroot/
?   ??? css/
?   ?   ??? site.css            # All styling (modern design)
?   ??? js/
?       ??? site.js             # All JavaScript functionality
??? Program.cs                   # Application entry point
??? appsettings.json            # Configuration file
??? ConsoleApp5.csproj          # Project file
```

## Future Enhancements

- [ ] User authentication and accounts
- [ ] Image editing capabilities
- [ ] More AI models integration
- [ ] Video generation completion tracking
- [ ] Image variations and improvements
- [ ] Prompt history and favorites
- [ ] Export and share functionality
- [ ] Advanced settings and parameters

## Support

For issues or questions:
- Check the OpenAI documentation
- Review browser console for errors
- Verify API key configuration

## License

This project is for educational and personal use.

---

**Enjoy creating amazing AI-generated content! ?????**
