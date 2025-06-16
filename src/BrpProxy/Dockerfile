#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    TZ=Europe/Amsterdam \
    # Disable config change monitoring for better container performance
    # See https://github.com/Contrast-Security-OSS/agent-operator/blob/master/docs/public/08-tips.md
    DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false
# Install ICU libraries
RUN apk add --no-cache icu-libs
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["BrpProxy/BrpProxy.csproj", "BrpProxy/"]
COPY ["Brp.Shared.DtoMappers/Brp.Shared.DtoMappers.csproj", "Brp.Shared.DtoMappers/"]
COPY ["Brp.Shared.Infrastructure/Brp.Shared.Infrastructure.csproj", "Brp.Shared.Infrastructure/"]
COPY ["Brp.Shared.Validatie/Brp.Shared.Validatie.csproj", "Brp.Shared.Validatie/"]
COPY ["Serilog.Sinks.PersistentFile/Serilog.Sinks.PersistentFile.csproj", "Serilog.Sinks.PersistentFile/"]

RUN dotnet restore "BrpProxy/BrpProxy.csproj"

COPY . .

WORKDIR "/src/BrpProxy"
RUN dotnet build "./BrpProxy.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BrpProxy.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Create non-root user and set permissions
RUN addgroup -g 1000 -S brp-api && \
    adduser -u 1000 -S -D -G brp-api brp-api-user && \
    chown -R brp-api-user:brp-api /app

# Set user for running the application
USER brp-api-user

# Define the entry point
ENTRYPOINT ["dotnet", "BrpProxy.dll"]