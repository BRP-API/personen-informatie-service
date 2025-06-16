#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    TZ=Europe/Amsterdam
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BrpService/BrpService.csproj", "BrpService/"]
RUN dotnet restore "./BrpService/BrpService.csproj"
COPY . .
COPY config/BrpService/test-data.json BrpService/Data/test-data.json
RUN rm BrpProxy/appsettings.json && rm BrpProxy/appsettings.Development.json
WORKDIR "/src/BrpService"
RUN dotnet build "BrpService.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
RUN dotnet publish "BrpService.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN groupadd -g 1000 brp-api && \
    useradd -m -u 1000 -g brp-api brp-api-user
USER brp-api-user

# See https://github.com/Contrast-Security-OSS/agent-operator/blob/master/docs/public/08-tips.md
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false

ENTRYPOINT ["dotnet", "Personen Mock.dll"]