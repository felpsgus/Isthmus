FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Isthmus.Api/Isthmus.Api.csproj", "Isthmus.Api/"]
RUN dotnet restore "Isthmus.Api/Isthmus.Api.csproj"
COPY . .
WORKDIR "/src/Isthmus.Api"
RUN dotnet build "./Isthmus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Isthmus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
COPY --from=publish /app/publish .

COPY --from=build /src /src

RUN dotnet tool install --global dotnet-ef --version 9.0.4

ENV PATH="$PATH:/root/.dotnet/tools"

ENTRYPOINT ["dotnet", "Isthmus.Api.dll"]