# ?? Troubleshooting Guide

## Common Issues & Solutions

### ?? Application Won't Start

#### Error: "Port already in use"
**Solution:**
```bash
# Find and kill process using port 5000 or 7000
netstat -ano | findstr :5000
netstat -ano | findstr :7000
taskkill /PID [process_id] /F
```

#### Error: ".NET 8.0 not found"
**Solution:**
- Download and install .NET 8.0 SDK from: https://dotnet.microsoft.com/download/dotnet/8.0

#### Error: "Cannot find view"
**Solution:**
```bash
# Clean and rebuild
dotnet clean
dotnet build
dotnet run
```

---

### ??? Image Generation Issues

#### "Failed to generate image"
**Possible causes:**
1. ? Invalid API key
2. ? No credits in OpenAI account
3. ? Network connection issue
4. ? OpenAI service down

**Solutions:**
1. ? Verify API key in `appsettings.json`:
   ```json
   {
     "OpenAI": {
       "ApiKey": "sk-your-actual-key-here"
     }
   }
   ```

2. ? Check OpenAI account:
   - Visit: https://platform.openai.com/account/billing
   - Verify you have credits

3. ? Test API key manually:
   ```bash
   curl https://api.openai.com/v1/models \
     -H "Authorization: Bearer YOUR_API_KEY"
   ```

4. ? Check OpenAI status:
   - Visit: https://status.openai.com/

#### Images not displaying
**Solution:**
1. Open browser Developer Tools (F12)
2. Check Console tab for errors
3. Check Network tab for failed requests
4. Verify CORS is enabled in Program.cs

---

### ?? Chat Not Responding

#### "Connection error"
**Solutions:**
1. ? Verify internet connection
2. ? Check API key configuration
3. ? Review browser console (F12) for errors

#### Chat sends but no response
**Solutions:**
1. ? Check OpenAI API usage limits
2. ? Verify GPT-4 access (or change to GPT-3.5-turbo in AIController.cs)
3. ? Check rate limits on OpenAI dashboard

---

### ?? Video Generation Issues

#### "Video generation requires additional API configuration"
**Explanation:**
- Video generation is a placeholder feature
- Requires integration with services like:
  - Runway ML
  - Stability AI
  - Pika Labs
  - Other video generation APIs

**To implement:**
1. Sign up for a video generation service
2. Get API key
3. Update `AIController.cs` `GenerateVideo` method
4. Add appropriate API calls

---

### ?? Browser/Display Issues

#### Sidebar not showing on mobile
**Solution:**
- Look for hamburger menu (?) in top-left corner
- Click to toggle sidebar

#### Styling looks broken
**Solutions:**
1. ? Clear browser cache (Ctrl+Shift+Delete)
2. ? Hard refresh (Ctrl+F5)
3. ? Check that CSS file is loading (F12 ? Network tab)

#### Buttons not working
**Solutions:**
1. ? Check browser console for JavaScript errors (F12)
2. ? Verify site.js is loading
3. ? Try different browser (Chrome, Edge, Firefox)

---

### ?? Gallery Issues

#### Gallery items not saving
**Solution:**
- Gallery uses browser's localStorage
- Check if localStorage is enabled in browser settings
- Try different browser
- Clear browser cache and try again

#### Gallery items disappeared
**Possible causes:**
- Browser cache cleared
- Different browser/incognito mode
- localStorage disabled

**Note:** Gallery is stored locally in browser. For permanent storage, implement a database solution.

---

### ?? API Key Issues

#### "Invalid API key"
**Checklist:**
1. ? Key starts with "sk-"
2. ? No extra spaces before/after key
3. ? Key is in correct format in appsettings.json
4. ? Using the correct key (not organization key)

#### "Rate limit exceeded"
**Solutions:**
1. ? Wait a few seconds and try again
2. ? Check your OpenAI usage tier
3. ? Upgrade OpenAI plan if needed

#### "Insufficient credits"
**Solution:**
- Add credits to OpenAI account
- Visit: https://platform.openai.com/account/billing

---

### ?? Development Issues

#### Changes not reflecting
**Solutions:**
```bash
# Stop the app (Ctrl+C)
# Clean and rebuild
dotnet clean
dotnet build
dotnet run
```

#### CSS/JS changes not appearing
**Solutions:**
1. ? Hard refresh browser (Ctrl+F5)
2. ? Clear browser cache
3. ? Check file paths in HTML

---

### ?? Performance Issues

#### App running slow
**Solutions:**
1. ? Check internet speed
2. ? Close unnecessary browser tabs
3. ? Check OpenAI API response times
4. ? Monitor Network tab in DevTools

#### Images taking too long
**Explanation:**
- DALL-E 3 typically takes 10-30 seconds per image
- This is normal for AI image generation
- Consider using lower resolution for faster results

---

### ?? Debugging Tips

#### Enable detailed logging
In `appsettings.Development.json`:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Information"
    }
  }
}
```

#### Check browser console
1. Press F12
2. Go to Console tab
3. Look for red error messages
4. Share errors for troubleshooting

#### Check network requests
1. Press F12
2. Go to Network tab
3. Click on failed requests
4. Check Response tab for error details

---

### ?? Still Having Issues?

1. **Check the logs:**
   - Browser console (F12)
   - Terminal where app is running
   - Visual Studio Output window

2. **Verify setup:**
   - Review README.md
   - Check QUICKSTART.md
   - Ensure all files are created correctly

3. **Test API independently:**
   - Use Postman or curl to test OpenAI API
   - Verify your API key works outside the app

4. **Start fresh:**
   ```bash
   # Clean everything
   dotnet clean
   # Restore packages
   dotnet restore
   # Rebuild
   dotnet build
   # Run
   dotnet run
   ```

---

### ? Success Checklist

Before reporting issues, verify:
- [ ] .NET 8.0 SDK installed
- [ ] Valid OpenAI API key configured
- [ ] OpenAI account has credits
- [ ] Internet connection working
- [ ] Port 7000 and 5000 are available
- [ ] Browser is up to date
- [ ] JavaScript enabled in browser
- [ ] No errors in browser console
- [ ] App builds successfully

---

**Good luck! Happy debugging! ??**
