FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["Algorithm.Api/Algorithm.Api.csproj", "Algorithm.Api/"]
RUN dotnet restore "Algorithm.Api/Algorithm.Api.csproj"
COPY . .
WORKDIR "/src/Algorithm.Api"
RUN dotnet build "Algorithm.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Algorithm.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Algorithm.Api.dll"]