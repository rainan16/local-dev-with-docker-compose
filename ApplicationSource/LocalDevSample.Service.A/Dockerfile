#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LocalDevSample.Service.A.WebApi/LocalDevSample.Service.A.WebApi.csproj", "LocalDevSample.Service.A.WebApi/"]
RUN dotnet restore "LocalDevSample.Service.A.WebApi/LocalDevSample.Service.A.WebApi.csproj"
COPY . .
WORKDIR "/src/LocalDevSample.Service.A.WebApi"
RUN dotnet build "LocalDevSample.Service.A.WebApi.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "LocalDevSample.Service.A.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocalDevSample.Service.A.WebApi.dll"]