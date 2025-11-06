# DSatUz Setup Instructions

## ?? Quick Start Guide

### Step 1: Install Node.js (If not already installed)

1. Download from: https://nodejs.org/
2. Choose the LTS version
3. Run the installer and follow the prompts
4. Verify installation by opening Command Prompt and running:
   ```
   node --version
   npm --version
   ```

### Step 2: Install Dependencies

Navigate to the DSatUz directory and run:

```bash
npm install
```

This will install all required packages including:
- React Native
- Expo
- React Navigation
- All other dependencies

### Step 3: Start the Development Server

```bash
npm start
```

### Step 4: Choose Your Platform

After running `npm start`, you'll see options:

#### **For Web (Easiest - No emulator needed)**
- Press `w` in the terminal
- Your browser will open automatically with the app

#### **For Android**
- Press `a` in the terminal
- Requires Android Studio & Emulator OR physical Android device
- Install Expo Go app on device and scan QR code

#### **For iOS**
- Press `i` in the terminal
- Requires macOS with Xcode
- Install Expo Go app on iPhone and scan QR code

## ?? Automated Setup

### Windows Users:
Double-click `setup.bat` to run automated setup

### Mac/Linux Users:
```bash
chmod +x setup.sh
./setup.sh
```

## ?? Opening in VS Code

```bash
# Navigate to project
cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz

# Open in VS Code
code .
```

## ?? Troubleshooting

### Issue: "npm: command not found"
- **Solution**: Install Node.js from https://nodejs.org/

### Issue: "Cannot find module"
- **Solution**: Delete `node_modules` folder and run `npm install` again
  ```bash
  rmdir /s /q node_modules
  npm install
  ```

### Issue: Port 19000 already in use
- **Solution**: Run on different port
  ```bash
  npm start -- --port 19001
  ```

### Issue: Expo not found
- **Solution**: Install Expo CLI globally
  ```bash
  npm install -g expo-cli
  ```

## ?? Project Structure Reminder

```
DSatUz/
??? src/
?   ??? screens/
?   ?   ??? HomeScreen.js
?   ?   ??? ExamsScreen.js
?   ?   ??? ExamDetailScreen.js
?   ?   ??? PracticeScreen.js
?   ?   ??? ProgressScreen.js
?   ??? App.js
??? package.json
??? app.json
??? index.js
??? setup.bat
??? setup.sh
??? README.md
```

## ?? Running Commands

### Development
```bash
npm start   # Start Expo server
npm run web # Run on web browser
npm run android    # Run on Android
npm run ios        # Run on iOS
```

### Useful Commands
```bash
npm install        # Install dependencies
npm update         # Update packages
npm list      # List installed packages
npm audit        # Check for vulnerabilities
```

## ?? Next Steps

Once the app is running:

1. **Explore the app** - Navigate through all screens
2. **Test features** - Try filtering exams, starting quizzes
3. **Add your PDFs** - Replace sample data with real exam PDFs
4. **Customize** - Modify colors, text, and data to your needs
5. **Deploy** - Build for production when ready

## ?? Need Help?

- **Expo Documentation**: https://docs.expo.dev/
- **React Native Docs**: https://reactnative.dev/
- **GitHub Issues**: Open an issue in the repository

---

**Happy coding! ??**
