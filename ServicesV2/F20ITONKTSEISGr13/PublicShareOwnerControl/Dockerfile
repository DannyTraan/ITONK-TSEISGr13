#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PublicShareOwnerControl/PublicShareOwnerControl.csproj", "PublicShareOwnerControl/"]
RUN dotnet restore "PublicShareOwnerControl/PublicShareOwnerControl.csproj"
COPY . .
WORKDIR "/src/PublicShareOwnerControl"
RUN dotnet build "PublicShareOwnerControl.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PublicShareOwnerControl.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PublicShareOwnerControl.dll"]