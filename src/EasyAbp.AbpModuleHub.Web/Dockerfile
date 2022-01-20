#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/EasyAbp.AbpModuleHub.Web/EasyAbp.AbpModuleHub.Web.csproj", "src/EasyAbp.AbpModuleHub.Web/"]
COPY ["src/EasyAbp.AbpModuleHub.HttpApi/EasyAbp.AbpModuleHub.HttpApi.csproj", "src/EasyAbp.AbpModuleHub.HttpApi/"]
COPY ["src/EasyAbp.AbpModuleHub.Application.Contracts/EasyAbp.AbpModuleHub.Application.Contracts.csproj", "src/EasyAbp.AbpModuleHub.Application.Contracts/"]
COPY ["src/EasyAbp.AbpModuleHub.Domain.Shared/EasyAbp.AbpModuleHub.Domain.Shared.csproj", "src/EasyAbp.AbpModuleHub.Domain.Shared/"]
COPY ["src/EasyAbp.AbpModuleHub.Application/EasyAbp.AbpModuleHub.Application.csproj", "src/EasyAbp.AbpModuleHub.Application/"]
COPY ["src/EasyAbp.AbpModuleHub.Domain/EasyAbp.AbpModuleHub.Domain.csproj", "src/EasyAbp.AbpModuleHub.Domain/"]
COPY ["src/EasyAbp.AbpModuleHub.EntityFrameworkCore/EasyAbp.AbpModuleHub.EntityFrameworkCore.csproj", "src/EasyAbp.AbpModuleHub.EntityFrameworkCore/"]
RUN dotnet restore "src/EasyAbp.AbpModuleHub.Web/EasyAbp.AbpModuleHub.Web.csproj"
COPY . .
WORKDIR "/src/src/EasyAbp.AbpModuleHub.Web"
RUN dotnet build "EasyAbp.AbpModuleHub.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyAbp.AbpModuleHub.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyAbp.AbpModuleHub.Web.dll"]