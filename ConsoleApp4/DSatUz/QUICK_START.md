# DSatUz - Quick Reference Card

## ?? Getting Started (3 Steps)

### Step 1: Install Node.js
Download from https://nodejs.org/ (LTS version)

### Step 2: Install Dependencies
```bash
cd C:\Users\amilm\OneDrive\Desktop\Pa201\DSatUz
npm install
```

### Step 3: Start the App
```bash
npm start
```
Then press:
- **`w`** ? Open in Web Browser (Easiest! ?)
- **`a`** ? Open in Android Emulator
- **`i`** ? Open in iOS Simulator

---

## ?? App Screens Overview

| Screen | Purpose | What You Can Do |
|--------|---------|-----------------|
| **Home** | Dashboard | View stats, quick shortcuts |
| **Exams** | Browse past exams | View scores, filter, upload PDFs |
| **Exam Detail** | Detailed analysis | See section breakdown, recommendations |
| **Practice** | Practice quizzes | Complete quizzes, track progress |
| **Progress** | Analytics | View trends, set goals, see recommendations |

---

## ?? File Locations

```
DSatUz/
??? src/screens/HomeScreen.js       ? Main dashboard
??? src/screens/ExamsScreen.js      ? Browse exams
??? src/screens/ExamDetailScreen.js ? Exam details
??? src/screens/PracticeScreen.js   ? Practice quizzes
??? src/screens/ProgressScreen.js ? Analytics
??? src/App.js? Main navigation
??? package.json       ? Dependencies
??? app.json              ? App config
??? SETUP_INSTRUCTIONS.md         ? This guide
```

---

## ??? Common Commands

```bash
# Start development server
npm start

# Install dependencies
npm install

# Update packages
npm update

# List installed packages
npm list

# Clean up (if having issues)
rm -r node_modules    # Mac/Linux
rmdir /s node_modules # Windows
npm install       # Then reinstall

# Run on specific port
npm start -- --port 19001
```

---

## ?? Customization Quick Tips

### Change App Colors
Edit `src/screens/*.js` files and look for `#2196F3` (blue color)
Replace with your preferred color.

### Add New Exams
Edit `ExamsScreen.js` and add to the `exams` array:
```javascript
{
  id: '6',
  title: '2023 SAT Test 4',
  date: 'June 2023',
  score: 1420,
  maxScore: 1600,
  sections: ['Reading', 'Writing', 'Math'],
}
```

### Add New Practice Quizzes
Edit `PracticeScreen.js` and add to `practiceQuizzes` array:
```javascript
{
  id: '7',
  title: 'Your Quiz Title',
  category: 'reading', // or 'writing', 'math'
  difficulty: 'Hard',
  questions: 20,
  avgTime: '15 min',
  icon: 'book',
}
```

---

## ?? Important Links

- **Node.js Download**: https://nodejs.org/
- **Expo Docs**: https://docs.expo.dev/
- **React Native**: https://reactnative.dev/
- **React Navigation**: https://reactnavigation.org/

---

## ? Verification Checklist

- [ ] Node.js installed (`node --version` works)
- [ ] npm installed (`npm --version` works)
- [ ] Dependencies installed (`npm install` completed)
- [ ] App starts (`npm start` works)
- [ ] Can open in web browser (`press w`)
- [ ] Navigation works (tabs respond to clicks)
- [ ] All screens load without errors

---

## ?? Quick Troubleshooting

| Problem | Solution |
|---------|----------|
| `npm not found` | Install Node.js from nodejs.org |
| `Cannot find module` | Run `npm install` again |
| Port already in use | Run `npm start -- --port 19001` |
| Blank white screen | Close and restart `npm start` |
| Changes not showing | Save file and reload in browser |

---

## ?? Support

- Check `SETUP_INSTRUCTIONS.md` for detailed help
- Check `README.md` for full documentation
- Review screen files in `src/screens/` folder

---

**Next:** Run `npm start` and press `w` to see the app! ??
