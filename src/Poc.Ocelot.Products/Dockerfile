FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS restore
WORKDIR /src
COPY ["src/Poc.Ocelot.Products/Poc.Ocelot.Products.csproj", "src/Poc.Ocelot.Products/"]
RUN dotnet restore "src/Poc.Ocelot.Products/Poc.Ocelot.Products.csproj"

FROM restore as build
COPY . .
WORKDIR /src/src/Poc.Ocelot.Products
RUN dotnet build "Poc.Ocelot.Products.csproj" --no-restore -c Release

FROM build AS publish
RUN dotnet publish "Poc.Ocelot.Products.csproj" --no-build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.Ocelot.Products.dll"]