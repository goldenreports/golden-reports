FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GoldenReports.API/GoldenReports.API.csproj", "GoldenReports.API/"]
RUN dotnet restore "GoldenReports.API/GoldenReports.API.csproj"
COPY . .
WORKDIR "/src/GoldenReports.API"
RUN dotnet build "GoldenReports.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoldenReports.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoldenReports.API.dll"]
