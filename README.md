created project using:  dotnet new web -n MyKestrelApp
built project using: dotnet build
run project using: dotnet run
built docker container for x86: docker buildx build --platform linux/amd64 -t mykestrel:x86 .