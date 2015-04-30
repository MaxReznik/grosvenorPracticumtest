
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe GrosvenorPracticum.sln /p:Configuration=Debug
pause
"%ProgramFiles(x86)%\Microsoft Visual Studio 12.0\Common7\IDE\mstest.exe" /testcontainer:GrosvenorPracticumTest\bin\Debug\GrosvenorPracticumTest.dll
pause