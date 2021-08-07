#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HiringProject.Api/HiringProject.Api.csproj", "HiringProject.Api/"]
RUN dotnet restore "HiringProject.Api/HiringProject.Api.csproj"
COPY . .
WORKDIR "/src/HiringProject.Api"
RUN dotnet build "HiringProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HiringProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HiringProject.Api.dll"]