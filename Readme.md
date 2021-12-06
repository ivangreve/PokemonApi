# Pokemon API 

### Pre-requisitos
- Instalar **Docker**.
  - Engine version 20.10 (at least).

### API con Docker 🐋

1. Clonar el proyecto
- Run: `git clone git@github.com:ivangreve/PokemonApi.git`.

2. Build containers.
- En la carpeta raíz ejecutar: `docker-compose build`

3. Levantar containers
- En la carpeta raíz ejecutar: `docker-compose up`

4. Swagger access: `http://localhost:5000/swagger/index.html`

### Authentication 🔑

1. Use `/authenticate` service:
   - `/api/auth/authenticate`
   - Enviar en el body los datos para authenticar:

```json
{
  "username": "pokemonuser",
  "password": "123456"
}
```

_NOTA: Se utilizaron estas credenciales harcodeadas por cuestion de tiempo, lo que habría que hacer es crear algún método que valide los datos persistidos en una alguna tabla de usuarios, ó utilizar algún otro método como OAuth_

2. Agregar Authorization Header al request:
```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InBva2Vtb251c2VyIiwibmJmIjoxNjM4NzU3MTA4LCJleHAiOjE2Mzg3NjA3MDgsImlhdCI6MTYzODc1NzEwOH0.GL6i-dwNPcLTVPFjI2wRbnMwd29eCO0az_w2eq2TA1o
```

## Useful knowledge

Si no se desea correr todos los servicios ejecutar:  `docker-compose up <serviceName>` command.

Example:
- DataBase service: `docker-compose up mysql_service`
- Backend service: `docker-compose up engine_pokemon`


## Used Technologies/Tools 🪛

- [.NET CORE](https://es.wikipedia.org/wiki/.NET_Core)
- [MySql](https://www.mysql.com/)
- [Docker](https://docker.com/)
- [SwaggerUI](https://swagger.io/)
- [Json Web Token](https://jwt.io/)

##