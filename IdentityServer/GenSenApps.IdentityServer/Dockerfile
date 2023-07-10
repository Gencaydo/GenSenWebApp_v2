#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY *.csproj ./IdentityServer/GenSenApps.IdentityServer/
COPY *.csproj ./Shared/GenSenWebApps.Shared/
RUN dotnet restore "IdentityServer/GenSenApps.IdentityServer/GenSenApps.IdentityServer.csproj"
COPY . .
WORKDIR /src/IdentityServer/GenSenApps.IdentityServer
RUN dotnet build "GenSenApps.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GenSenApps.IdentityServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GenSenApps.IdentityServer.dll"]