FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ClientApplication/ClientApplication.csproj", "ClientApplication/"]
RUN dotnet restore "ClientApplication/ClientApplication.csproj"
COPY . .
WORKDIR "/src/ClientApplication"
RUN dotnet build "ClientApplication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ClientApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ClientApplication.dll"]