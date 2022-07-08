FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS restore
WORKDIR /src
COPY ["src/Poc.Ocelot.Backoffice/Poc.Ocelot.Backoffice.csproj", "src/Poc.Ocelot.Backoffice/"]
RUN dotnet restore "src/Poc.Ocelot.Backoffice/Poc.Ocelot.Backoffice.csproj"

FROM restore as build
COPY . .
WORKDIR /src/src/Poc.Ocelot.Backoffice
RUN dotnet build "Poc.Ocelot.Backoffice.csproj" --no-restore -c Release

FROM build AS publish
RUN dotnet publish "Poc.Ocelot.Backoffice.csproj" --no-build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.Ocelot.Backoffice.dll"]