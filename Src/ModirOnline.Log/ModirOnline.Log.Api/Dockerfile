#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/ModirOnline.Log/ModirOnline.Log.Api/ModirOnline.Log.Api.csproj", "Src/ModirOnline.Log/ModirOnline.Log.Api/"]
COPY ["Src/ModirOnline.Log/ModirOnline.Log.Application/ModirOnline.Log.Application.csproj", "Src/ModirOnline.Log/ModirOnline.Log.Application/"]
COPY ["Src/ModirOnline.Log/ModirOnline.Log.Domain/ModirOnline.Log.Domain.csproj", "Src/ModirOnline.Log/ModirOnline.Log.Domain/"]
COPY ["Src/ModirOnline.Common/ModirOnline.Common/ModirOnline.Common.csproj", "Src/ModirOnline.Common/ModirOnline.Common/"]
COPY ["Src/ModirOnline.Log/ModirOnline.Log.Persistence/ModirOnline.Log.Persistence.csproj", "Src/ModirOnline.Log/ModirOnline.Log.Persistence/"]
RUN dotnet restore "./Src/ModirOnline.Log/ModirOnline.Log.Api/./ModirOnline.Log.Api.csproj"
COPY . .
WORKDIR "/src/Src/ModirOnline.Log/ModirOnline.Log.Api"
RUN dotnet build "./ModirOnline.Log.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ModirOnline.Log.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModirOnline.Log.Api.dll"]