FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["GoldenReports.WebUI/GoldenReports.WebUI.csproj", "GoldenReports.WebUI/"]
RUN dotnet restore "GoldenReports.WebUI/GoldenReports.WebUI.csproj"
COPY . .
WORKDIR "/src/GoldenReports.WebUI"
RUN dotnet build "GoldenReports.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoldenReports.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoldenReports.WebUI.dll"]
