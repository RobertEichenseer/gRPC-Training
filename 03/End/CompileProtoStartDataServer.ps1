# Open new PowerShell Terminal 
# CHECK IF YOU'RE in: The project folder in which you cloned the source 
# E.g. C:\LinkedInLearning\gRPC\
# You should see the folders 01, 02, 03 ... .vscode in this directory

# Change directory to Start
Set-Location .\03\Start 

# Compile proto
..\..\Tools\protoc\protoc.exe `
    --csharp_out=.\DataServer\Protos `
    --proto_path=.\DataServer\Protos `
    .\DataServer\Protos\greet.proto 

# Compile proto & create stubs
..\..\Tools\protoc\protoc.exe `
    --plugin=protoc-gen-grpc=..\..\Tools\Protoc_PlugIn\grpc_csharp_plugin.exe `
    --csharp_out=.\DataServer\Protos `
    --grpc_out=.\DataServer\Protos `
    --proto_path=.\DataServer\Protos `
    .\DataServer\Protos\greet.proto

# Start DataServer
## Build DataServer
dotnet build .\DataServer\DataServer.csproj

# Run DataServer
$env:ASPNETCORE_URLS = 'https://*:5001'
dotnet run --project .\DataServer\DataServer.csproj


