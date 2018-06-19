FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 8080

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY UserService.csproj ./
RUN dotnet restore ./UserService.csproj
COPY . .
WORKDIR /src/
RUN dotnet build UserService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish UserService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserService.dll"]
