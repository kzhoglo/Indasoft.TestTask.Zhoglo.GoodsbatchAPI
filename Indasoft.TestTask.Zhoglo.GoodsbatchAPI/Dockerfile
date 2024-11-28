#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
USER ContainerAdministrator
RUN net localgroup administrators /add "User Manager\ContainerUser"
USER ContainerUser
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Indasoft.TestTask.Zhoglo.GoodsbatchAPI/Indasoft.TestTask.Zhoglo.GoodsbatchAPI.csproj", "Indasoft.TestTask.Zhoglo.GoodsbatchAPI/"]
COPY ["Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data/Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data.csproj", "Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data/"]
COPY ["Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository/Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository.csproj", "Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository/"]
RUN dotnet restore "./Indasoft.TestTask.Zhoglo.GoodsbatchAPI/Indasoft.TestTask.Zhoglo.GoodsbatchAPI.csproj"
COPY . .
WORKDIR "/src/Indasoft.TestTask.Zhoglo.GoodsbatchAPI"
RUN dotnet build "./Indasoft.TestTask.Zhoglo.GoodsbatchAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Indasoft.TestTask.Zhoglo.GoodsbatchAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Indasoft.TestTask.Zhoglo.GoodsbatchAPI.dll"]