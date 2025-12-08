# ?? Web Sayt? ??? Salma T?limat?

## Metod 1: Visual Studio-dan i?? salma
1. Visual Studio-da layih?ni aç
2. **F5** bas?n (Debug mode) v? ya **Ctrl+F5** (Without debugging)
3. Brauzer avtomatik aç?lacaq

## Metod 2: Terminal/CMD-d?n i?? salma
```powershell
cd "C:\Users\amilm\OneDrive\Desktop\Pa201\AiForProgrammingWebSite\AiForProgrammingWebSite"
dotnet run
```

Sonra brauzerd? aç?n:
- **http://localhost:5000**

## Metod 3: Watch Mode (Auto-reload)
```powershell
cd "C:\Users\amilm\OneDrive\Desktop\Pa201\AiForProgrammingWebSite\AiForProgrammingWebSite"
dotnet watch run
```

Bu üsulla kod d?yi?iklikl?ri avtomatik yenil?nir.

## Metod 4: Brauzeri avtomatik açmaq üçün
```powershell
cd "C:\Users\amilm\OneDrive\Desktop\Pa201\AiForProgrammingWebSite\AiForProgrammingWebSite"
start http://localhost:5000
dotnet run --launch-profile http
```

## ?? ?g?r port m???uldursa:
```powershell
# Ba?qa port istifad? et
dotnet run --urls "http://localhost:5500"
```

## ?? ?stifad? üçün:
1. Brauzerd? aç?lan s?hif?d? kod yaz?n/yap??d?r?n
2. Dil seçin (C#, Python, JavaScript v? s.)
3. Task seçin (Analyze, Refactor, Debug v? s.)
4. "Analyze Code" düym?sin? bas?n
5. AI n?tic?l?rini görün!

## ?? Qeyd:
- Demo mode-da i?l?yir (OpenAI key olmadan)
- Real AI funksiyas? üçün `appsettings.json`-da API key ?lav? edin
