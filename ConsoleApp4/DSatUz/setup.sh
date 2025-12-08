#!/bin/bash
# DSatUz Project Setup Script for macOS/Linux

echo ""
echo "================================================"
echo "  DSatUz - SAT Exam Preparation App Setup"
echo "================================================"
echo ""

# Check if Node.js is installed
if ! command -v node &> /dev/null; then
    echo "[ERROR] Node.js is not installed!"
    echo "Please download and install Node.js from: https://nodejs.org/"
    echo "After installation, run this script again."
    exit 1
fi

echo "[OK] Node.js is installed"
node --version
npm --version

echo ""
echo "Installing project dependencies..."
echo ""

# Install npm packages
npm install

if [ $? -ne 0 ]; then
  echo "[ERROR] Failed to install dependencies"
    exit 1
fi

echo ""
echo "================================================"
echo "   Setup Complete!"
echo "================================================"
echo ""
echo "To start the development server, run:"
echo "   npm start"
echo ""
echo "Then choose your platform:"
echo "   - Press 'a' for Android"
echo "   - Press 'i' for iOS"
echo "   - Press 'w' for Web"
echo ""
