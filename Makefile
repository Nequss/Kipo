all: restore linux windows macos

clean:
	rm -rf  KipoBot/bin/Release

restore:
	dotnet restore

linux: restore
	dotnet build -c Release -r linux-x64

windows: restore
	dotnet build -c Release -r win-x64

macos: restore
	dotnet build -c Release -r osx-x64
