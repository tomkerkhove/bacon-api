FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Bacon.gRPC.Service/", "Bacon.gRPC.Service/"]
COPY ["Bacon.Factory/", "Bacon.Factory/"]
RUN dotnet build "Bacon.gRPC.Service/Bacon.gRPC.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bacon.gRPC.Service/Bacon.gRPC.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bacon.gRPC.Service.dll"]