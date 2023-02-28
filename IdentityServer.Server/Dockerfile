#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IdentityServer.Server/IdentityServer.Server.csproj", "IdentityServer.Server/"]
COPY ["EmailService/EmailService.csproj", "EmailService/"]
RUN dotnet restore "IdentityServer.Server/IdentityServer.Server.csproj"
COPY . .
WORKDIR "/src/IdentityServer.Server"
RUN dotnet build "IdentityServer.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:6006
ENTRYPOINT ["dotnet", "IdentityServer.Server.dll"]