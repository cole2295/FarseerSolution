@echo off
copy "%cd%\..\Framework\Farseer.Net\Lib\Farseer.Net.dll" "%cd%\..\Framework\Farseer.Net.Sql\Lib\" /y
copy "%cd%\..\Framework\Farseer.Net\Lib\Farseer.Net.dll" "%cd%\..\Framework\Farseer.Net.DI\Lib\" /y
copy "%cd%\..\Framework\Farseer.Net\Lib\Farseer.Net.dll" "%cd%\..\Framework\Farseer.Net.Redis\Lib\" /y
copy "%cd%\..\Framework\Farseer.Net\Lib\Farseer.Net.dll" "%cd%\..\Framework\Farseer.Net.Utils\Lib\" /y
copy "%cd%\..\Framework\Farseer.Net\Lib\Farseer.Net.dll" "%cd%\..\Framework\Farseer.Net.Tools\Lib\" /y
pause
