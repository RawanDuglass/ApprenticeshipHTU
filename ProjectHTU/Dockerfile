#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.



#first stage base img 
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

#copy csproj and restore dependencies
COPY *.csproj .
RUN dotnet restore

#copy and publish application files
COPY . .
RUN dotnet publish  -c Release -o /app /p:UseAppHost=false

#final stage img 
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "ProjectHTU.dll"]

