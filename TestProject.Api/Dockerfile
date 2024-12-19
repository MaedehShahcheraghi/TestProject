# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files to the container
COPY ["TestProject.Api/TestProject.Api.csproj", "TestProject.Api/"]
COPY ["TP.Application/TP.Application.csproj", "TP.Application/"]
COPY ["TP.Domain/TP.Domain.csproj", "TP.Domain/"]
COPY ["TP.Infrastructure/TP.Infrastructure.csproj", "TP.Infrastructure/"]
COPY ["TP.Persistence/TP.Persistence.csproj", "TP.Persistence/"]

# Restore dependencies
RUN dotnet restore "TestProject.Api/TestProject.Api.csproj"

# Copy all files
COPY . . 

# Build the solution
WORKDIR "/src/TestProject.Api"
RUN dotnet build "TestProject.Api.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "TestProject.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Final image (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Install ICU libraries for globalization support
RUN apt-get update && apt-get install -y icu-devtools

# Set environment variable to disable globalization invariant mode
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Copy published files from the build stage
COPY --from=publish /app/publish . 

ENTRYPOINT ["dotnet", "TestProject.Api.dll"]
