# Kipo
The cutest bot in the universe!

### Linux Dependencies:
```bash top sed cut free grep dotnet-sdk-2.1 dotnet-runtime-2.1 zip```

### Building from source:
You can either use an IDE like Visual Studio(Windows) or JetBrains Rider(all platforms) to build Kipo, or use provided Makefile for that.
To build Kipo using Makefile, first clone the repository:

```$ git clone https://github.com/Nequss/Kipo.git```

then cd into Kipo directory and run:
```$ make {options}```

To build for Windows:
```$ make windows```

To build for Linux:
```$ make linux```

To build for MacOS:
```$ make macos```

To build for all platforms:
```$ make all```

The build output will be located in: ```{KipoDirectory}/KipoBot/bin/Release/netcoreapp2.1/``` in the appropriate directory.

You can also create .zip archive that contains all Releases that you've build: ```$ make zip```
The .zip archive will be located in Kipo Directory.
