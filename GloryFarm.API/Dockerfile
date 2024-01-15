#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GloryFarm.API/GloryFarm.API.csproj", "GloryFarm.API/"]
RUN dotnet restore "GloryFarm.API/GloryFarm.API.csproj"
COPY . .
WORKDIR "/src/GloryFarm.API"
RUN dotnet build "GloryFarm.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GloryFarm.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GloryFarm.API.dll"]