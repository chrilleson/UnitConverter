﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UnitConverter.Api.csproj", "./"]
RUN dotnet restore "UnitConverter.Api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "UnitConverter.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitConverter.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitConverter.Api.dll"]