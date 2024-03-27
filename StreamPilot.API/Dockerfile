# Dockerfile - StreamPilot.Api
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StreamPilot.Api/StreamPilot.Api.csproj", "StreamPilot.Api/"]
RUN dotnet restore "StreamPilot.Api/StreamPilot.Api.csproj"
COPY . .
WORKDIR "/src/StreamPilot.Api"
RUN dotnet build "StreamPilot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StreamPilot.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StreamPilot.Api.dll"]
