#!/bin/bash

echo "Packing Application Layer"
dotnet pack ./GoldenReports.Application/GoldenReports.Application.csproj -c Release --include-symbols /p:AssemblyVersion=$1 /p:Version=$1 --output $2

echo "Packing Persistence Layer"
dotnet pack ./GoldenReports.Persistence/GoldenReports.Persistence.csproj -c Release --include-symbols /p:AssemblyVersion=$1 /p:Version=$1 --output $2

echo "Packing API Layer"
dotnet pack ./GoldenReports.API/GoldenReports.API.csproj -c Release --include-symbols /p:AssemblyVersion=$1 /p:Version=$1 --output $2

echo "Packing WebUI"
dotnet publish ./GoldenReports.WebUI/GoldenReports.WebUI.csproj -c Release /p:AssemblyVersion=$1 /p:Version=$1 --output $2/web-ui
tar -czvf web-ui.tar.gz web-ui -C $2
rm -rf $2/web-ui

echo "Building WebUI Docker Image"
docker build . --file GoldenReports.WebUI/Dockerfile -t golden-reports --build-arg VERSION=$1
