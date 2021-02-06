all: restore clean linux windows macos

clean:
	rm -rf  KipoBot/bin/Release

restore:
	dotnet restore

linux: restore clean
	dotnet build -c Release -r linux-x64

windows: restore clean
	dotnet build -c Release -r win-x64

macos: restore clean
	dotnet build -c Release -r osx-x64
