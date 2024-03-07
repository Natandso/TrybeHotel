# Projeto TrybeHotel

Penúltimo projeto de C# fornecido para prática de todas as tecnologias até então estudadas no momento pela instituição Trybe. Neste projeto criamos um CRUD com tudo que aprendemos em c#!

## Diagrama Entidade Relacionamento do projeto
![Diagrama Trybe Hotel](image.png)

## Aprendizados

Neste projeto tive o prazer de aplicar os temas sobre a programação orientada a objetos e os princípios SOLID em uma API RestFul.

## Stack utilizada

**C#:** Azure, JWT, SOLID, Entitity Framework, C#.NET, Docker.



## Instalação

Instalação com NPM

```bash
  git clone git@github.com:tryber/csharp-031-csharp-projeto-trybe-hotel-fase-d.git
  cd cd csharp-031-csharp-projeto-trybe-hotel-fase-d/ cd src
  donet restore
  docker compose up -d --build para subir o container
```
    
## Autores

- [@Natan Santana (Aero)](https://github.com/Natandso)


## Licença e Autoria

Arquivos como .trybe e trybe.yml

[Trybe](https://www.betrybe.com/)


# Sobre os Requisitos do Projeto

Neste projeto, dividimos ele em  4 partes aonde trago para vocês a junção de todas elas finalizadas!


## Database Utilizado
  - [Nessa seção](#Azure) temos o diagrama de entidades;

<details>

### 1. Implemente as models da aplicação
Mais informações:
Implemente os arquivos do diretório /src/TrybeHotel/Models/

Implemente a model City
Implemente a model Hotel
Implemente a model Room
Implemente o contexto do banco de dados

O que será testado:

Será testado que todas as models foram implementadas corretamente.
Será testado que as models possuem as chaves primárias e estrangeiras necessárias.

### 2. Desenvolva o endpoint GET /city
Mais informações:
Este endpoint será responsável por listar todas as cidades.
Implemente a lógica da sua controller no método GetCities() do arquivo src/TrybeHotel/Controllers/CityController.cs.
Implemente a lógica de interação ao banco de dados no método GetCities() do arquivo src/TrybeHotel/Repository/CityRepository.cs.
A sua repository retorna um tipo CityDto que deverá ser implementado no arquivo src/TrybeHotel/Dto/CityDto.cs. A sua classe de DTO deve seguir o formato da response da requisição.

👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.

👀 De olho na dica 2: Para converter qualquer tipo de coleção no tipo de coleção List, utilize o método ToList().


O endpoint deve ser acessível através da URL /city e deve ser do tipo GET;
O corpo da requisição é vazio.
A resposta deve ser o status 200.
O corpo da resposta deve seguir o formato abaixo:
[
    {
	    "cityId": 1,
	    "name": "Rio Branco"
    },

  /*...*/
]
O que será testado:

Será testado que, quando solicitada a requisição, a mesma informe os dados correspondentes do banco de dados.
Será testado que o status de retorno será 200.
Será testado que o corpo da resposta segue o padrão esperado.

### 3. Desenvolva o endpoint POST /city
Mais informações:
Este endpoint será responsável por inserir uma nova cidade.
Implemente a lógica da sua controller no método PostCity() do arquivo src/TrybeHotel/Controllers/CityController.cs.
Implemente a lógica de interação ao banco de dados no método AddCity() do arquivo src/TrybeHotel/Repository/CityRepository.cs.
A sua repository retorna um tipo CityDto que deverá ser implementado no arquivo src/TrybeHotel/Dto/CityDto.cs. A sua classe de DTO deve seguir o formato da response da requisição.

👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.

👀 De olho na dica 2: Para obter um único elemento de uma coleção, você pode obter o primeiro com o método First(). Exemplo: coleção.First().


O endpoint deve ser acessível através da URL /city e deve ser do tipo POST;
O corpo da requisição deve seguir o padrão abaixo
{
	"Name": "Rio de Janeiro"
}
A resposta deve ser o status 201.
O corpo da resposta deve seguir o formato abaixo:
{
	  "cityId": 2,
	  "name": "Rio de Janeiro"
},
O que será testado:

Será testado que, quando solicitada a requisição, a mesma insira no banco de dados e retorne de acordo com o modelo
Será testado que o status de retorno será 201.
Será testado que o corpo da resposta segue o padrão esperado.

### 4. Desenvolva o endpoint GET /hotel
Mais informações:
Este endpoint será responsável por listar todos os hotéis.
Implemente a lógica da sua controller no método GetHotels() do arquivo src/TrybeHotel/Controllers/HotelController.cs.
Implemente a lógica de interação ao banco de dados no método GetHotels() do arquivo src/TrybeHotel/Repository/HotelRepository.cs.
A sua repository retorna um tipo HotelDto que deverá ser implementado no arquivo src/TrybeHotel/Dto/HotelDto.cs. A sua classe de DTO deve seguir o formato da response da requisição.

👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.

👀 De olho na dica 2: Para converter qualquer tipo de coleção no tipo de coleção List, utilize o método ToList().


O endpoint deve ser acessível através da URL /hotel e deve ser do tipo GET;
O corpo da requisição é vazio.
A resposta deve ser o status 200.
O corpo da resposta deve seguir o formato abaixo:
[
    {
		  "hotelId": 1,
		  "name": "Trybe Hotel SP",
		  "address": "Avenida Paulista, 1400",
		  "cityId": 1,
		  "cityName": "São Paulo"
	  },

  /*...*/
]
O que será testado:

Será testado que, quando solicitada a requisição, a mesma informe os dados correspondentes do banco de dados.
Será testado que o status de retorno será 200.
Será testado que o corpo da resposta segue o padrão esperado.

### 5. Desenvolva o endpoint POST /hotel
Mais informações:
Este endpoint será responsável por inserir um novo hotel.
Implemente a lógica da sua controller no método PostHotel() do arquivo src/TrybeHotel/Controllers/HotelController.cs.
Implemente a lógica de interação ao banco de dados no método AddHotel() do arquivo src/TrybeHotel/Repository/HotelRepository.cs.
A sua repository retorna um tipo HotelDto que deverá ser implementado no arquivo src/TrybeHotel/Dto/HotelDto.cs. A sua classe de DTO deve seguir o formato da response da requisição.

👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.

👀 De olho na dica 2: Para obter um único elemento de uma coleção, você pode obter o primeiro com o método First(). Exemplo: coleção.First().


O endpoint deve ser acessível através da URL /hotel e deve ser do tipo POST;
O corpo da requisição deve seguir o padrão abaixo
{
	"Name":"Trybe Hotel RJ",
	"Address":"Avenida Atlântica, 1400",
	"CityId": 2
}
A resposta deve ser o status 201.
O corpo da resposta deve seguir o formato abaixo:
{
	"hotelId": 2,
	"name": "Trybe Hotel RJ",
	"address": "Avenida Atlântica, 1400",
	"cityId": 2,
	"cityName": "Rio de Janeiro"
}
O que será testado:

Será testado que, quando solicitada a requisição, a mesma insira no banco de dados e retorne de acordo com o modelo
Será testado que o status de retorno será 201.
Será testado que o corpo da resposta segue o padrão esperado.

### 6. Desenvolva o endpoint GET /room/:hotelId
Mais informações:
Este endpoint será responsável por listar todos os quartos de um determinado hotel
Implemente a lógica da sua controller no método GetRoom() do arquivo src/TrybeHotel/Controllers/RoomController.cs.
Implemente a lógica de interação ao banco de dados no método GetRooms() do arquivo src/TrybeHotel/Repository/RoomRepository.cs.
A sua repository retorna um tipo RoomDto que deverá ser implementado no arquivo src/TrybeHotel/Dto/RoomDto.cs. A sua classe de DTO deve seguir o formato da response da requisição.

👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.

👀 De olho na dica 2: Para converter qualquer tipo de coleção no tipo de coleção List, utilize o método ToList().


O endpoint deve ser acessível através da URL /room/:hotelId e deve ser do tipo GET;
O corpo da requisição é vazio.
A resposta deve ser o status 200.
O corpo da resposta deve seguir o formato abaixo:
[
    {
		  "roomId": 1,
		  "name": "Suite básica",
		  "capacity": 2,
		  "image": "image suite",
		  "hotel": {
  			"hotelId": 1,
			  "name": "Trybe Hotel SP",
			  "address": "Avenida Paulista, 1400",
			  "cityId": 1,
			  "cityName": "São Paulo"
		  }
	  },

  /*...*/
]
O que será testado:

Será testado que, quando solicitada a requisição, a mesma informe os dados correspondentes do banco de dados.
Será testado que o status de retorno será 200.
Será testado que o corpo da resposta segue o padrão esperado.

### 7. Desenvolva o endpoint POST /room
Mais informações:
Este endpoint será responsável por inserir um novo quarto a um hotel.
Implemente a lógica da sua controller no método PostRoom() do arquivo src/TrybeHotel/Controllers/RoomController.cs.
Implemente a lógica de interação ao banco de dados no método AddRoom() do arquivo src/TrybeHotel/Repository/RoomRepository.cs.
A sua repository retorna um tipo RoomDto que deverá ser implementado no arquivo src/TrybeHotel/Dto/RoomDto.cs. A sua classe de DTO deve seguir o formato da response da requisição.

👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.

👀 De olho na dica 2: Para obter um único elemento de uma coleção, você pode obter o primeiro com o método First(). Exemplo: coleção.First().


O endpoint deve ser acessível através da URL /room e deve ser do tipo POST;
O corpo da requisição deve seguir o padrão abaixo
{
	"Name":"Suite básica",
	"Capacity":2,
	"Image":"image suite",
	"HotelId": 1
}
A resposta deve ser o status 201.
O corpo da resposta deve seguir o formato abaixo:
{
	"roomId": 1,
	"name": "Suite básica",
	"capacity": 2,
	"image": "image suite",
	"hotel": {
		"hotelId": 1,
		"name": "Trybe Hotel SP",
		"address": "Avenida Paulista, 1400",
		"cityId": 1,
		"cityName": "São Paulo"
	}
}
O que será testado:

Será testado que, quando solicitada a requisição, a mesma insira no banco de dados e retorne de acordo com o modelo
Será testado que o status de retorno será 201.
Será testado que o corpo da resposta segue o padrão esperado.

### 8. Desenvolva o endpoint DELETE /room/:roomId
Mais informações:
Este endpoint será responsável por deletar um determinado quarto.
Implemente a lógica da sua controller no método Delete() do arquivo src/TrybeHotel/Controllers/RoomController.cs.
Implemente a lógica de interação ao banco de dados no método DeleteRoom() do arquivo src/TrybeHotel/Repository/RoomRepository.cs.
O endpoint deve ser acessível através da URL /room/:roomId e deve ser do tipo DELETE;
O corpo da requisição é vazio.
A resposta deve ser o status 204.
O que será testado:

Será testado que, quando solicitada a requisição, a mesma faça a exclusão solicitada no banco de dados.
Será testado que o status de retorno será 204.

</details>