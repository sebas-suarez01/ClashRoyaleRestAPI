FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["ClashRoyaleRestAPI.API/ClashRoyaleRestAPI.API.csproj", "ClashRoyaleRestAPI.API/"]
COPY ["ClashRoyaleRestAPI.Application/ClashRoyaleRestAPI.Application.csproj", "ClashRoyaleRestAPI.Application/"]
COPY ["ClashRoyaleRestAPI.Domain/ClashRoyaleRestAPI.Domain.csproj", "ClashRoyaleRestAPI.Domain/"]
COPY ["ClashRoyaleRestAPI.Infrastructure/ClashRoyaleRestAPI.Infrastructure.csproj", "ClashRoyaleRestAPI.Infrastructure/"]

RUN dotnet restore "ClashRoyaleRestAPI.API/ClashRoyaleRestAPI.API.csproj"

COPY . .

WORKDIR "/src/ClashRoyaleRestAPI.API/"

RUN dotnet build "ClashRoyaleRestAPI.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ClashRoyaleRestAPI.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClashRoyaleRestAPI.API.dll"]
