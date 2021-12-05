#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 7000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Challenge.csproj", "Engine.Api/"]
RUN dotnet restore "Engine.Api/Challenge.csproj"
COPY . ./Engine.Api/
WORKDIR "/src/Engine.Api"
RUN dotnet build "Challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Challenge.dll"]