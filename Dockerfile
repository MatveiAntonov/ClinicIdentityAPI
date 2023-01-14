FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-image
WORKDIR /home/app
COPY ["*.sln", "./"]
COPY ["IdentityServer.Client/*.csproj", "./IdentityServer.Client/"]
COPY ["IdentityServer.Server/*.csproj", "./IdentityServer.Server/"]
COPY ["EmailService/*.csproj", "./EmailService/"]
RUN dotnet restore
COPY . .
RUN dotnet publish ./IdentityServer.Server/IdentityServer.Server.csproj -o ./IdentityServer.Server/publish/
RUN dotnet publish ./IdentityServer.Client/IdentityServer.Client.csproj -o ./IdentityServer.Client/publish/

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /IdentityServer.Client/publish
COPY --from=build-image /home/app/IdentityServer.Client/publish/ .
ENV ASPNETCORE_URLS=http://+:6001
RUN ["dotnet", "IdentityServer.Client.dll"]
WORKDIR /IdentityServer.Server/publish
COPY --from=build-image /home/app/IdentityServer.Server/publish .
ENV ASPNETCORE_URLS=http://+:6000
ENTRYPOINT ["dotnet", "IdentityServer.Server.dll"]	