#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IdentityServer.Client/IdentityServer.Client.csproj", "IdentityServer.Client/"]
RUN dotnet restore "IdentityServer.Client/IdentityServer.Client.csproj"
COPY . .
WORKDIR "/src/IdentityServer.Client"
RUN dotnet build "IdentityServer.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:6007
ENTRYPOINT ["dotnet", "IdentityServer.Client.dll"]