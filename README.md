# Desafio de Desenvolvedor AeC: BrasilApiSolution

Este repositório contém o projeto desenvolvido para o desafio proposto pela AeC, que envolve a criação de uma API RESTful para consumo de dados da Brasil API.

## 📌 Índice

- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Instalação e Configuração](#instalação-e-configuração)
- [Documentação da API via Swagger](#documentação-da-api-via-swagger)
- [Funcionalidades](#funcionalidades)
- [Estrutura de banco de Dados](#estrutura-de-banco-de-dados)
- [Assets (Imagens)](#assets-imagens)

## 🛠️ Tecnologias Utilizadas

- .NET 6+
- Dapper para interação com o banco de dados
- Microsoft SQL Server como SGBD
- Swagger para documentação da API
- Docker para conteinerização da aplicação

## 📂 Estrutura do Projeto

O projeto `BrasilApiSolution` é composto por:

- **Api**:
  - **Controllers**: Contém os controladores da aplicação, como `WeatherCityController.cs`.
  - **Application**: 
    - **Interfaces**: Define os contratos para os serviços, como `IWeatherService.cs`.
    - **Services**: Implementa os serviços de comunicação com a Brasil API, com destaque para `BrasilApiServiceClient.cs`.
  - **Domain**:
    - **Models**: Contém as entidades do domínio da aplicação como `City.cs`, `WeatherCity.cs`, `ErrorLog.cs` entre outras.
  - **Repository**:
    - **Interfaces**: Define os contratos para os repositórios.
    - **Implementações**: Gerencia a persistência dos dados, como `WeatherRepository.cs`.
  - **Configurações**:
    - **appsettings.json**: Configurações padrão do ASP.NET Core.
    - **Dockerfile**: Instruções para a criação do container Docker da aplicação.
    - **Program.cs**: Ponto de entrada da aplicação e configurações iniciais.

## 🚀 Instalação e Configuração


1. **Clonando o projeto**: 
   - Execute o comando abaixo para clonar o projeto.
     ```bash
     git clone https://github.com/pujoni/BrasilApiSolution.git
     ```

2. **Configuração de ambiente**:
   - Certifique-se de ter o Docker instalado em sua máquina e a conexão com o SQL Server configurada corretamente.

3. **Executando com Docker**:
   - Navegue até a pasta raiz do projeto e execute o comando:
     ```bash
     docker-compose up
     ```

Após a inicialização, você poderá acessar a API através do navegador ou de qualquer cliente HTTP, como o Postman, para testar as rotas. Lembre-se: O projeto está configurado para funcionar em conjunto com o SQL Server, então certifique-se de que o banco de dados está acessível e de que as tabelas estão configuradas de acordo com o descrito acima.


## 📖 Documentação da API via Swagger

Após a inicialização da aplicação, você pode acessar a documentação da API gerada pelo Swagger através da rota `/swagger`.

## 🌐 Funcionalidades

- **BrasilApiServiceClient**:
- Obter informações climáticas de uma cidade.
- Obter informações climáticas de um aeroporto.
- Listar cidades disponíveis.
- Listar código de Capitais

- **WeatherRepository**:
- Persistência das informações climáticas no banco de dados.
- Registro de logs de erros.

**Docker**:
A aplicação está configurada para rodar em um container Docker. Consulte o arquivo `Dockerfile` para mais detalhes.


## 📜 Estrutura de Banco de Dados

### 1. City

| Campo   | Descrição                 |
| ------- | ------------------------- |
| Id      | Identificador da cidade   |
| Nome    | Nome da cidade            |
| Estado  | Estado da cidade          |

```sql
SELECT TOP (1000) [Id], [Nome], [Estado] FROM [WeatherDatabase].[dbo].[City]
```
### 2. ErrorLog

| Campo       | Descrição                 |
| ----------- | ------------------------- |
| Id          | Identificador do log      |
| Message     | Mensagem de erro          |
| StackTrace  | Rastreamento de pilha     |
| Date        | Data do erro              |

```sql
SELECT TOP (1000) [Id], [Message], [StackTrace], [Date] FROM [WeatherDatabase].[dbo].[ErrorLog]
```
### 3. WeatherAirport

| Campo              | Descrição                  |
| ------------------ | -------------------------- |
| Id                 | Identificador do registro  |
| Codigo_icao        | Código ICAO do aeroporto   |
| Atualizado_em      | Data de atualização        |
| Pressao_atmosferica| Pressão atmosférica        |
| Visibilidade       | Visibilidade               |
| Vento              | Velocidade do vento        |
| Direcao_vento      | Direção do vento           |
| Umidade            | Umidade                    |
| Condicao           | Condição meteorológica     |
| Condicao_Desc      | Descrição da condição      |
| Temp               | Temperatura                |

```sql
SELECT TOP (1000) [Id], [Codigo_icao], [Atualizado_em], [Pressao_atmosferica], [Visibilidade], [Vento], [Direcao_vento], [Umidade], [Condicao], [Condicao_Desc], [Temp] FROM [WeatherDatabase].[dbo].[WeatherAirport]
```
### 4. WeatherCapital

| Campo              | Descrição                  |
| ------------------ | -------------------------- |
| Id                 | Identificador do registro  |
| Codigo_icao        | Código ICAO da capital     |
| Atualizado_em      | Data de atualização        |
| Pressao_atmosferica| Pressão atmosférica        |
| Visibilidade       | Visibilidade               |
| Vento              | Velocidade do vento        |
| Direcao_vento      | Direção do vento           |
| Umidade            | Umidade                    |
| Condicao           | Condição meteorológica     |
| Condicao_Desc      | Descrição da condição      |
| Temp               | Temperatura                |

```sql
SELECT TOP (1000) [Id], [Codigo_icao], [Atualizado_em], [Pressao_atmosferica], [Visibilidade], [Vento], [Direcao_vento], [Umidade], [Condicao], [Condicao_Desc], [Temp] FROM [WeatherDatabase].[dbo].[WeatherCapital]
```
### 5. WeatherCity

| Campo         | Descrição                |
| ------------- | ------------------------ |
| Id            | Identificador do registro|
| Cidade        | Nome da cidade           |
| Estado        | Estado da cidade         |
| Atualizado_em | Data de atualização      |

```sql
SELECT TOP (1000) [Id], [Cidade], [Estado], [Atualizado_em] FROM [WeatherDatabase].[dbo].[WeatherCity]
```
### 6. WeatherDetails

| Campo         | Descrição                |
| ------------- | ------------------------ |
| Id            | Identificador do registro|
| CityId        | ID da cidade relacionada |
| Data          | Data da previsão         |
| Condicao      | Condição do tempo        |
| Min           | Temperatura mínima       |
| Max           | Temperatura máxima       |
| Indice_uv     | Índice UV                |
| Condicao_desc | Descrição da condição    |

```sql
SELECT TOP (1000) [Id], [CityId], [Data], [Condicao], [Min], [Max], [Indice_uv], [Condicao_desc] FROM [WeatherDatabase].[dbo].[WeatherDetails]
```
## 🖼️ Assets (Imagens)

## Estrutura do Código

**Estrutura e visualização da construção do meu código**:
![Estrutura do Código](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/cdStructure.png)

## Documentação via Swagger

**Retorna todas as cidades**:
![Swagger Cidade](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/swcity.png)
**Dados da cidade desejada**:
![Swagger Retorno Cidade](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/swReturnCity.png)
**Clima da cidade desejada**:
![Swagger Lista de Cidades](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/swListCities.png)
**Lista de Cidades com Aeroportos**:
![Swagger Capital](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/swCapital.png)
**Clima em Aeroporto**:
![Swagger Aeroporto](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/swAirport.png)

## Imagens do Banco de Dados

**Logs**:
![Banco de Dados Log de Erro](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/dbErrorLog.png)
**Clima em aeroportos**:
![Banco de Dados Aeroporto](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/dbAirport.png)
**Detalhes de Clima**:
![Banco de Dados Detalhes](https://github.com/pujoni/BrasilApiSolution/raw/master/assets/dbDetails.png)
---

[Link do Projeto no GitHub](https://github.com/pujoni/BrasilApiSolution)


