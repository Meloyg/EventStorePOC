FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventStorePOC/EventStorePOC.csproj", "EventStorePOC/"]
RUN dotnet restore "EventStorePOC/EventStorePOC.csproj"
COPY . .
WORKDIR "/src/EventStorePOC"
RUN dotnet build "EventStorePOC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventStorePOC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventStorePOC.dll"]
