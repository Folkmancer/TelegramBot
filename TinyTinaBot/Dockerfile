#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#WORKDIR /src
#COPY ["TinyTinaBot/TinyTinaBot.csproj", "TinyTinaBot/"]
#RUN dotnet restore "TinyTinaBot/TinyTinaBot.csproj"
#COPY . .
#WORKDIR "/src/TinyTinaBot"
#RUN dotnet build "TinyTinaBot.csproj" -c Release -o /app

#FROM build AS publish
#RUN dotnet publish "TinyTinaBot.csproj" -c Release -o /app

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "TinyTinaBot.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TinyTinaBot.dll"]