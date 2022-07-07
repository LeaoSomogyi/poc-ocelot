FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS restore
WORKDIR /src
COPY ["src/Poc.Ocelot.Accounts/Poc.Ocelot.Accounts.csproj", "src/Poc.Ocelot.Accounts/"]
RUN dotnet restore "src/Poc.Ocelot.Accounts/Poc.Ocelot.Accounts.csproj"

FROM restore as build
COPY . .
WORKDIR /src/src/Poc.Ocelot.Accounts
RUN dotnet build "Poc.Ocelot.Accounts.csproj" --no-restore -c Release

FROM build AS publish
RUN dotnet publish "Poc.Ocelot.Accounts.csproj" --no-build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.Ocelot.Accounts.dll"]