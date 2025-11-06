# Quick Start Guide - AI Creative Studio

## ?? Quick Setup (5 Minutes)

### Step 1: Get OpenAI API Key
1. Visit: https://platform.openai.com/api-keys
2. Sign up/Login
3. Click "Create new secret key"
4. Copy the key (starts with "sk-")

### Step 2: Configure Your API Key
Open `appsettings.json` and paste your key:

```json
{
  "OpenAI": {
    "ApiKey": "sk-paste-your-key-here"
  }
}
```

### Step 3: Run the Application

**In Visual Studio:**
- Press `F5` or click the green ?? Run button

**Or in Terminal:**
```bash
dotnet run
```

### Step 4: Start Creating! ??

The app will open in your browser automatically at:
- https://localhost:7000

---

## ?? What Can You Do?

### ?? Chat Tab
- Talk with AI assistant
- Ask questions
- Get creative ideas
- Type in English and press Enter

### ?? Image Generator Tab
Try these prompts:
- "A futuristic cityscape at sunset with flying cars"
- "A cute robot playing with a cat in a garden"
- "Abstract art with vibrant colors and geometric shapes"
- "A magical forest with glowing mushrooms and fairies"

### ?? Video Generator Tab
Try these prompts:
- "Ocean waves crashing on a beach at sunset"
- "A butterfly flying through a field of flowers"
- "Northern lights dancing in the night sky"

### ??? Gallery Tab
- See all your creations
- Click to view full size
- Automatically saved in browser

---

## ?? API Costs

- **Images**: ~$0.04 per image (affordable!)
- **Chat**: ~$0.03 per 1,000 tokens
- **Monitor usage**: https://platform.openai.com/usage

?? **Tip**: Start with $5 credit - that's ~100 images!

---

## ? Pro Tips

1. **Be Specific**: More detailed prompts = better results
2. **Try Different Sizes**: Landscape for wallpapers, Portrait for phones
3. **Experiment**: Don't be afraid to try creative descriptions
4. **Save Your Favorites**: Gallery is automatically saved
5. **English Only**: Use English keyboard for best results

---

## ?? Example Prompts

### For Stunning Images:
```
"A serene Japanese garden with cherry blossoms, koi pond, 
and traditional wooden bridge, soft morning light, highly detailed"

"Cyberpunk street scene with neon signs, rain-soaked streets, 
futuristic vehicles, night time, cinematic lighting"

"Cute cartoon character, 3D render, Disney Pixar style, 
friendly smile, colorful, high quality"
```

### For Chat:
```
"Help me write a story about a space adventure"
"What are creative business ideas for 2024?"
"Explain quantum computing in simple terms"
```

---

## ? Need Help?

### Image not generating?
- ? Check API key is correct
- ? Verify internet connection
- ? Check OpenAI account has credits

### Chat not responding?
- ? Confirm API key in appsettings.json
- ? Check browser console (F12) for errors
- ? Visit OpenAI status page

### App won't start?
- ? Make sure .NET 8.0 is installed
- ? Run `dotnet restore` in terminal
- ? Check port 7000 is not in use

---

## ?? Enjoy Creating!

This is YOUR creative AI studio. Experiment, have fun, and create amazing content!

**Happy Creating! ?????**
