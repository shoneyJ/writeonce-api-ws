# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8085

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["writeonce-api/writeonce-api.csproj","writeonce-api/"]
COPY ["writeonce-data/writeonce-data.csproj","writeonce-data/"]
RUN dotnet restore "writeonce-api/writeonce-api.csproj"
COPY . .
WORKDIR "/src/writeonce-api"
RUN dotnet build "writeonce-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "writeonce-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base as release
WORKDIR /app
COPY --from=publish /app/publish .


# Start the application
ENTRYPOINT ["dotnet", "writeonce-api.dll"]
