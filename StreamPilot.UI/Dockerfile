# Dockerfile - StreamPilot.UI
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StreamPilot.UI/StreamPilot.UI.csproj", "StreamPilot.UI/"]
RUN dotnet restore "StreamPilot.UI/StreamPilot.UI.csproj"
COPY . .
WORKDIR "/src/StreamPilot.UI"
RUN dotnet build "StreamPilot.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StreamPilot.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StreamPilot.UI.dll"]
