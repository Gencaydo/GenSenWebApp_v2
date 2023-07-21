#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app
EXPOSE 80
COPY *.csproj ./Shared/GenSenWebApps.Shared/
COPY *.csproj ./IdentityServer/GenSenApps.IdentityServer/
RUN dotnet restore IdentityServer/GenSenApps.IdentityServer/GenSenApps.IdentityServer.csproj
COPY . .
RUN dotnet publish IdentityServer/GenSenApps.IdentityServer/GenSenApps.IdentityServer.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "GenSenApps.IdentityServer.dll"]