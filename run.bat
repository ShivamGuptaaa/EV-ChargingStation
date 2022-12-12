::Start Uni Tests
start cmd.exe /c "dotnet watch test --project tests\EV.CharginStation.Api.UnitTests\EV.CharginStation.Api.UnitTests.csproj"

::Start Project
start cmd.exe /c "dotnet run --project src\WebAPI\EV.ChargingStation.Api\EV.ChargingStation.csproj"


::Start UI Project
cd src\UI
start cmd.exe /c "npm install && npm start"