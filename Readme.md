docker-compose up -d

Ver logs mssql
docker-compose logs sql-server-db

Ver containers
docker-compose ps

docker exec -it sql-server-db "bash"

Getting Started

dotnet build
dotnet ef database update
dotnet run


docker run --name sqlserver --hostname sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=password_segura_mssql" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest 


mysql://challenge-pokemon-db:123456@35.222.39.142:3306/pokemondb