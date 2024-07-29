FROM mcr.microsoft.com/dotnet/sdk:8.0 AS development
WORKDIR /app
EXPOSE 80
 
COPY . .
 
RUN dotnet restore .
 
RUN dotnet publish "./src/Basis.CodeChallenge.API/Basis.CodeChallenge.API.csproj" -c Release -o out
#COPY ./src/Bais.CodeChallenge.API/data/data.sqlite /app/data.sqlite

 
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine as runtime
WORKDIR /app
COPY --from=development /app/out .


ENV DB_CONNECTION_STRING__USERDB=Data Source=/data/data.sqlite

ENTRYPOINT ["dotnet", "Basis.CodeChallenge.API.dll"]
