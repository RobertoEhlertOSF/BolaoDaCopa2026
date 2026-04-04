# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY BolaoDaCopa2026/BolaoDaCopa2026.csproj BolaoDaCopa2026/
RUN dotnet restore BolaoDaCopa2026/BolaoDaCopa2026.csproj

# Copy everything else
COPY . .
WORKDIR /src/BolaoDaCopa2026

# Publish app
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/publish .

# Expose port
EXPOSE 8080

# Start app
ENTRYPOINT ["dotnet", "BolaoDaCopa2026.dll"]