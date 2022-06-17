# CHECK if you're in the project folder in which you cloned the source 
# E.g. C:\LinkedInLearning\gRPC\
# You should see the folders 01, 02, 03 ... .vscode in this directory

.\Tools\grpcurl\grpcurl.exe -proto .\03\Start\DataServer\Protos\greet.proto -d '{\"name\": \"Robert\"}' localhost:5001 greet.Greeter/SayHello
