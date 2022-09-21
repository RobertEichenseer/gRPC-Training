# gRPC Masterclass (with .NET Core & C#)
## Training
This training provides material for a self-paced gRPC training. It's using .NET Core 6.0 and Powershell

## Companion material 
It can be used as companion material for the LinkedIn Learing traing ["Cross-Plattform-Microservices with ASP.NET Core 6.0 and gRPC"](https://www.linkedin.com/learning/cross-plattform-microservices-mit-asp-dot-net-core-6-0-und-grpc?u=0)

## Training Structure
- Start: folder for own experiments/trainings. 
- End: folder with a full functional example.
- Root: In the root folder of the specific chapters are PowerShell script files with step-to-step instructions. 
### Tools 
Tools used in the training: 
- [.NET Core 6.0 (Runtime + SDK)](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio Code](https://code.visualstudio.com/Download) 
- [VS Code Extension - Dotnet Tools C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [VS Code Extension - vscode-proto3](https://marketplace.visualstudio.com/items?itemName=zxh404.vscode-proto3)
- [grpcurl](https://github.com/fullstorydev/grpcurl)
- [protoc Compiler](https://grpc.io/docs/protoc-installation/)
- [protoc Compiler - C# plug-in (nuget)](https://nuget.info/packages/Grpc.Tools/2.46.3)

### Chapter 01
Building a first gRPC server using .NET Core tooling and ASP.NET Core/C#. 
[Link to chapter 01](./01/README.md)

### Chapter 02
Introduction into ProtocolBuffers as Interface Definition Language (IDL) for contracts between communication partners.
[Link to chapter 02](./02/README.md)

### Chapter 03
Introduction to using the protoc compiler to create class definitions and function stubs. Developing a ASP.NET Core based gRPC server. 
[Link to chapter 03](./03/README.md)

### Chapter 04
Introduction simplified application (DataHub Server & DataHub Client).
[Link to chapter 04](./04/README.md)

### Chapter 05
Data streaming with gRPC. Bi-direktional streaming from client to server and server to client. 
[Link to chapter 05](./05/README.md)

### Chapter 06
Advanced gRPC Topics
- Transient Fault Handling
- Server Reflection 
- Comparison REST <-> gRPC
[Link to chapter 06](./06/README.md)
