#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Xin.WebApi/Xin.WebApi.csproj", "Xin.WebApi/"]
COPY ["Xin.Repository/Xin.Repository.csproj", "Xin.Repository/"]
COPY ["Xin.Common/Xin.Common.csproj", "Xin.Common/"]
COPY ["Xin.Job/Xin.Job.csproj", "Xin.Job/"]
COPY ["Xin.SignalR/Xin.SignalR.csproj", "Xin.SignalR/"]
COPY ["Xin.Entity/Xin.Entites.csproj", "Xin.Entity/"]
COPY ["Xin.Service/Xin.Service.csproj", "Xin.Service/"]
COPY ["Xin.Job.Service/Xin.Job.Service.csproj", "Xin.Job.Service/"]
RUN dotnet restore "Xin.WebApi/Xin.WebApi.csproj"
COPY . .
WORKDIR "/src/Xin.WebApi"
RUN dotnet build "Xin.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Xin.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xin.WebApi.dll"]