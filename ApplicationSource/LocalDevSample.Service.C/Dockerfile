#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LocalDevSample.Service.C.WebApi/LocalDevSample.Service.C.WebApi.csproj", "LocalDevSample.Service.C.WebApi/"]
RUN dotnet restore "LocalDevSample.Service.C.WebApi/LocalDevSample.Service.C.WebApi.csproj"
COPY . .
WORKDIR "/src/LocalDevSample.Service.C.WebApi"
RUN dotnet build "LocalDevSample.Service.C.WebApi.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "LocalDevSample.Service.C.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocalDevSample.Service.C.WebApi.dll"]