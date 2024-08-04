FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Lunar.Poker.Aspire.Web.csproj", "Lunar.Poker.Aspire.Web/"]
COPY ["../Lunar.Poker.Aspire.ServiceDefaults/Lunar.Poker.Aspire.ServiceDefaults.csproj", "Lunar.Poker.Aspire.ServiceDefaults/"]
RUN dotnet restore "Lunar.Poker.Aspire.Web/Lunar.Poker.Aspire.Web.csproj"
COPY . .
WORKDIR "/src/Lunar.Poker.Aspire.Web"
RUN dotnet build "Lunar.Poker.Aspire.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Lunar.Poker.Aspire.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lunar.Poker.Aspire.Web.dll"]