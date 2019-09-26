FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TinyTinaBot/TinyTinaBot.csproj", "TinyTinaBot/"]
RUN dotnet restore "TinyTinaBot/TinyTinaBot.csproj"
COPY . .
WORKDIR "/src/TinyTinaBot"
RUN dotnet build "TinyTinaBot.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TinyTinaBot.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ASPNETCORE_URLS=http://*:$PORT BotUrl=$BOT_URL BotName=$BOT_NAME  BotKey=$BOT_API_KEY dotnet TinyTinaBot.dll