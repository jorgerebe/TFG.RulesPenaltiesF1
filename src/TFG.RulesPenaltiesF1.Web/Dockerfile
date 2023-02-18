#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/TFG.Jorge.Web/TFG.Jorge.WebApp.csproj", "src/TFG.Jorge.Web/"]
COPY ["src/TFG.Jorge.Infrastructure/TFG.Jorge.Infrastructure.csproj", "src/TFG.Jorge.Infrastructure/"]
COPY ["src/TFG.Jorge.Core/TFG.Jorge.Core.csproj", "src/TFG.Jorge.Core/"]
RUN dotnet restore "src/TFG.Jorge.Web/TFG.Jorge.WebApp.csproj"
COPY . .
WORKDIR "/src/src/TFG.Jorge.Web"
RUN dotnet build "TFG.Jorge.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TFG.Jorge.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TFG.Jorge.WebApp.dll"]