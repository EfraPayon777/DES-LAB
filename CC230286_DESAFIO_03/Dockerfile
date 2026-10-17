
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["WebApplication1/CC230286_DESAFIO_03.csproj", "WebApplication1/"]
COPY ["CC230286_DESAFIO_03.BL/CC230286_DESAFIO_03.BL.csproj", "CC230286_DESAFIO_03.BL/"]
COPY ["CC230286_DESAFIO_03.DAL/CC230286_DESAFIO_03.DAL.csproj", "CC230286_DESAFIO_03.DAL/"]
COPY ["CC230286_DESAFIO_03.Entities/CC230286_DESAFIO_03.Entities.csproj", "CC230286_DESAFIO_03.Entities/"]

RUN dotnet restore "WebApplication1/CC230286_DESAFIO_03.csproj"

COPY . .

RUN dotnet build "WebApplication1/CC230286_DESAFIO_03.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-restore

FROM build AS publish

ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "WebApplication1/CC230286_DESAFIO_03.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CC230286_DESAFIO_03.dll"]
