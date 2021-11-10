FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TinyTinaBot/TinyTinaBot.csproj", "TinyTinaBot/"]
RUN dotnet restore "TinyTinaBot/TinyTinaBot.csproj"
COPY . .
WORKDIR "/src/TinyTinaBot"
RUN dotnet build "TinyTinaBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TinyTinaBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT ASPNETCORE_HTTPS_PORT=$PORT BotUrl=$BOT_URL BotName=$BOT_NAME BotKey=$BOT_KEY dotnet TinyTinaBot.dll