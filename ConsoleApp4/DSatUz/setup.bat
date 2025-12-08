@echo off
REM DSatUz Project Setup Script
REM This script sets up the DSatUz React Native project

echo.
echo ================================================
echo   DSatUz - SAT Exam Preparation App Setup
echo ================================================
echo.

REM Check if Node.js is installed
where node >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo [ERROR] Node.js is not installed!
    echo Please download and install Node.js from: https://nodejs.org/
    echo After installation, run this script again.
 pause
    exit /b 1
)

echo [OK] Node.js is installed
node --version
npm --version

echo.
echo Installing project dependencies...
echo.

REM Install npm packages
npm install

if %ERRORLEVEL% NEQ 0 (
    echo [ERROR] Failed to install dependencies
    pause
    exit /b 1
)

echo.
echo ================================================
echo   Setup Complete!
echo ================================================
echo.
echo To start the development server, run:
echo   npm start
echo.
echo Then choose your platform:
echo   - Press 'a' for Android
echo   - Press 'i' for iOS
echo- Press 'w' for Web
echo.
pause
