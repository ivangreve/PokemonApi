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


==== MySql Container creation ===

docker pull mysql
docker images
docker run -d -p 13306:3306 --name mysql_service -e MYSQL_ROOT_PASSWORD=password mysql:latest --character-set-server=utf8mb4 --collation-server=utf8mb4_unicode_ci


// Me logeo con el user root y password configurada "password"
docker exec -it mysql_container mysql -uroot -p 

// Configuro el user
create user 'mysqluser' identified by 'password';
grant all privileges on *.* TO 'mysqluser'@'%';




==============================

{
  "name": "Mewtwo",
  "hp": 999,
  "isFirstEdition": true,
  "expansionSetId": 2,
  "pokemonTypeId": 5,
  "pokemonRarityId": 3,
  "price": 99999,
  "image": "https://assets.pokemon.com/assets/cms2/img/pokedex/full/150.png",
  "cardCreationTime": "2021-12-05T17:29:47.419Z"
}