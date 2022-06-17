# CHECK if you're in the project folder in which you cloned the source 
# E.g. C:\LinkedInLearning\gRPC\
# You should see the folders 01, 02, 03 ... .vscode in this directory

# proto file usage
.\Tools\grpcurl\grpcurl.exe -proto .\06\Start\DataHub\DataHub.Protos\DataHub.proto localhost:5001 MsgBroker.Ingest/SendDataPackage

# Reflection 
.\Tools\grpcurl\grpcurl.exe localhost:5001 describe 
.\Tools\grpcurl\grpcurl.exe localhost:5001 describe MsgBroker.Ingest
.\Tools\grpcurl\grpcurl.exe localhost:5001 describe MsgBroker.RequestSendDataPackage

