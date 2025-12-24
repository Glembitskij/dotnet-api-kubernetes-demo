# 1. Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ProductApi.Api/*.csproj ./ 
RUN dotnet restore

COPY ProductApi.Api/. ./
RUN dotnet publish -c Release -o /app/publish

# 2. Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

COPY --from=build /app/publish .

EXPOSE 5000
ENTRYPOINT ["dotnet", "ProductApi.Api.dll"]
