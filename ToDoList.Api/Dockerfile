FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDoList/ToDoList.Api.csproj", "ToDoList/"]
COPY ["ToDoList.Core/ToDoList.Core.csproj", "ToDoList.Core/"]
RUN dotnet restore "ToDoList/ToDoList.Api.csproj"
COPY . .
WORKDIR "/src/ToDoList"
RUN dotnet build "ToDoList.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoList.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoList.Api.dll"]
