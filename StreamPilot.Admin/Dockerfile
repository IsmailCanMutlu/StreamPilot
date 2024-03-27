# Dockerfile - StreamPilot.Admin
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StreamPilot.Admin/StreamPilot.Admin.csproj", "StreamPilot.Admin/"]
RUN dotnet restore "StreamPilot.Admin/StreamPilot.Admin.csproj"
COPY . .
WORKDIR "/src/StreamPilot.Admin"
RUN dotnet build "StreamPilot.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StreamPilot.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StreamPilot.Admin.dll"]
