FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
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
#CMD ["dotnet", "TinyTinaBot.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet TinyTinaBot.dll $BOT_URL $BOT_NAME $BOT_KEY