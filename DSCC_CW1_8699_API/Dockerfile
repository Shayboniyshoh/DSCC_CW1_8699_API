#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DSCC_CW1_8699_API/DSCC_CW1_8699_API.csproj", "DSCC_CW1_8699_API/"]
RUN dotnet restore "DSCC_CW1_8699_API/DSCC_CW1_8699_API.csproj"
COPY . .
WORKDIR "/src/DSCC_CW1_8699_API"
RUN dotnet build "DSCC_CW1_8699_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSCC_CW1_8699_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSCC_CW1_8699_API.dll"]