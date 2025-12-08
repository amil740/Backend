# ?? DSatUz - Troubleshooting Guide

## ? Can't Open the Project?

If you're having trouble opening the DSatUz project, follow this guide.

---

## ?? Common Issues & Solutions

### Issue 1: "Project folder not found"

**Symptom:** You get an error saying the DSatUz folder doesn't exist

**Solution:**
```bash
# Check if folder exists
dir C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz

# If not found, the folder may not have been created
# Create it manually:
mkdir C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz
```

**Verify:** You should see files like:
- package.json
- app.json
- src/ (folder)
- README.md

---

### Issue 2: "npm not found" or "npm is not recognized"

**Symptom:** Terminal shows `npm: command not found`

**Solution:**
1. Install Node.js from https://nodejs.org/
2. Download the **LTS version**
3. Run the installer
4. **Restart your computer**
5. Open a new terminal and test:
   ```bash
   npm --version
   node --version
   ```

---

### Issue 3: "Cannot find node_modules"

**Symptom:** App won't start because `node_modules` is missing

**Solution:**
```bash
# Navigate to project
cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz

# Install dependencies
npm install

# This will create node_modules folder
# Wait for it to complete (2-5 minutes)
```

---

### Issue 4: "Port 19000 already in use"

**Symptom:** Error when trying to start with `npm start`

**Solution:**
```bash
# Try different port
npm start -- --port 19001

# Or kill the process using port 19000
# Windows:
netstat -ano | findstr :19000
taskkill /PID <PID_NUMBER> /F

# Mac/Linux:
lsof -i :19000
kill -9 <PID_NUMBER>
```

---

### Issue 5: "Cannot open in VS Code"

**Symptom:** VS Code won't open the folder

**Solution:**
```bash
# Navigate to project
cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz

# Open in VS Code
code .

# Or use the workspace file:
code DSatUz.code-workspace
```

---

### Issue 6: "Blank white screen" or "Module not found"

**Symptom:** App opens but shows errors

**Solution:**
```bash
# Stop the app (Ctrl+C in terminal)

# Clear cache
npm start -- --clear

# If still not working:
# Delete node_modules and reinstall
rmdir /s /q node_modules
npm install
npm start -- --clear
```

---

## ?? Step-by-Step Recovery

### Step 1: Verify File Exists

Open Command Prompt and run:
```bash
dir C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz
```

**Expected Output:**
```
Mode        LastWriteTime         Length Name
----     -------------   ------ ----
d-----       ...    src
-a----              ...      package.json
-a----       ...  app.json
-a----    ...      index.js
-a----           ...        README.md
```

If you don't see these files, the project wasn't created. Contact support.

---

### Step 2: Install Node.js (if needed)

Check if Node.js is installed:
```bash
node --version
npm --version
```

**If you see version numbers:** Node.js is installed ?

**If you get "command not found":**
1. Download from https://nodejs.org/
2. Install LTS version
3. Restart computer
4. Try again

---

### Step 3: Install Dependencies

```bash
cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz
npm install
```

**Expected:** Should show `added X packages` when done

**Problems?** Wait for it to complete (don't interrupt!)

---

### Step 4: Start Development Server

```bash
npm start
```

**Expected Output:**
```
Expo DevTools Running on http://localhost:19002
Starting Metro Bundler
```

---

### Step 5: Open in Browser

In the terminal, press: **`w`**

**Expected:** Browser opens to http://localhost:19000

---

## ?? Diagnostic Checklist

Run through these checks:

- [ ] Can navigate to folder: `cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz`
- [ ] Folder contains files: `dir` shows package.json, src/, etc.
- [ ] Node.js installed: `node --version` works
- [ ] npm installed: `npm --version` works
- [ ] Can run npm install: `npm install` completes
- [ ] Can start server: `npm start` works
- [ ] Can open in browser: Press `w` and browser opens

---

## ?? Specific Commands to Try

### If you're on Windows:
```bash
# Open Command Prompt
# Run these commands:

cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz

npm install

npm start

# Then press: w
```

### If you're on Mac/Linux:
```bash
cd /Users/[username]/Desktop/Pa201/DSatUz

npm install

npm start

# Then press: w
```

---

## ?? Quick Fixes (Try These First)

### Fix 1: Clear Everything and Restart
```bash
cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz
rmdir /s /q node_modules
npm install
npm start -- --clear
```

### Fix 2: Use Different Port
```bash
npm start -- --port 19001
```

### Fix 3: Restart Terminal
```bash
# Close the terminal completely
# Open a new terminal
# Navigate and try again
cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz
npm start
```

### Fix 4: Use Setup Script
```bash
# Windows:
setup.bat

# Mac/Linux:
chmod +x setup.sh
./setup.sh
```

---

## ?? Need More Help?

### Try These Resources:

1. **Check file exists:**
   ```bash
   ls C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz
   ```

2. **Check Node.js:**
   ```bash
   node --version
   npm --version
   npm list -g
 ```

3. **Check npm cache:**
   ```bash
   npm cache clean --force
   npm install
   ```

4. **Reinstall npm globally:**
   ```bash
   npm install -g npm@latest
   ```

---

## ?? Information to Provide if Stuck

When asking for help, provide:

1. Your operating system (Windows, Mac, Linux)
2. Node.js version (`node --version`)
3. npm version (`npm --version`)
4. The exact error message you see
5. What you were trying to do
6. Steps you've already tried

---

## ? Success Indicators

When everything is working:
- ? Terminal shows "Expo DevTools Running on..."
- ? QR code appears in terminal
- ? Browser opens to http://localhost:19000
- ? App displays with blue header
- ? "Welcome to DSatUz" text visible
- ? Tab navigation works

---

## ?? Last Resort: Full Reset

If nothing else works:

```bash
# 1. Delete everything
rmdir /s /q C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz

# 2. Create fresh folder
mkdir C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz

# 3. Install Node.js fresh
# Download from https://nodejs.org/

# 4. Start over with:
cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz
npm install
npm start
```

---

## ?? Support Options

- **Quick questions:** Check QUICK_START.md
- **Setup issues:** Check SETUP_INSTRUCTIONS.md
- **Full help:** Check README.md
- **Verification:** Check COMPLETE_CHECKLIST.md

---

**If you're still stuck, please tell me:**
1. What error message do you see?
2. What were you trying to do?
3. What operating system?
4. What have you already tried?

Then I can provide more specific help! ??

