# NursingHomeAPI

A NursingHouseAPI 🏠 é uma API desenvolvida com o objetivo de fornecer recursos para o gerenciamento de idosos 👴🏿👵🏼 em uma casa de repouso, juntamente com suas medicações. 

A API é construída utilizando conceitos e padrões modernos, como o uso de handlers, mediatr e o Entity Framework. O objetivo principal foi organizar a arquitetura de uma forma simples, porém robusta e escalável seguindo alguns conceitos de CQRS.

Para utilizar/testar a API:
  -Clone o projeto
  -Atualize a ConnectionString no AppSettings.Json para a sua própria
  -Abra o Console Nuget (Tools -> NuGet Package Manager -> Package Manager Console)
  -Adicione a migration (Add-Migration -Project Data)
  -E por fim dê o update database (Update-Database)
  -Agora só executar, lembrando de conferir se o projeto NursingHomeAPI está como startup

Deixei o Swagger por padrão, mas o teste via Postman, SoapUI e outras ferramentas de teste no geral não será problema, a API por enquanto não possui autenticação.

![image](https://github.com/predrofreitas/NursingHomeAPI/assets/38004711/2b95a495-84d6-47fa-bb7b-7d255314385b)

Abaixo infos dos controllers 


Elderly Controller
Overview
O ElderlyController é responsável por gerenciar os registros de idosos.

Base URL: /api/elderly

Endpoints
Get All Elderlies
Obtém todos os registros de idosos com opções de paginação e ordenação.

URL: /api/elderly
Método: GET
Parâmetros de consulta:
page (opcional): Número da página.
pageSize (opcional): Número de itens por página.
searchTerm (opcional): Termo de busca.
sortColumn (opcional): Coluna para ordenação.
sortOrder (opcional): Ordem de ordenação (ascendente ou descendente).
Respostas:
200 OK: Lista de registros de idosos.
404 Not Found: Nenhum registro de idoso encontrado.
Get Elderly by ID
Obtém um registro de idoso pelo ID.

URL: /api/elderly/{id}
Método: GET
Parâmetros de caminho:
id: ID do idoso.
Respostas:
200 OK: Registro de idoso encontrado.
404 Not Found: Nenhum registro de idoso encontrado.
Create Elderly
Cria um novo registro de idoso.

URL: /api/elderly
Método: POST
Corpo da solicitação: Objeto JSON contendo os detalhes do idoso.
Respostas:
201 Created: Registro de idoso criado com sucesso.
400 Bad Request: Solicitação inválida.
Update Elderly
Atualiza um registro de idoso existente.

URL: /api/elderly/{id}
Método: PUT
Parâmetros de caminho:
id: ID do idoso.
Corpo da solicitação: Objeto JSON contendo os detalhes atualizados do idoso.
Respostas:
200 OK: Registro de idoso atualizado com sucesso.
400 Bad Request: Solicitação inválida.
404 Not Found: Nenhum registro de idoso encontrado.
Delete Elderly
Exclui um registro de idoso pelo ID.

URL: /api/elderly/{id}
Método: DELETE
Parâmetros de caminho:
id: ID do idoso.
Respostas:
204 No Content: Registro de idoso excluído com sucesso.
404 Not Found: Nenhum registro de idoso encontrado.
Elderly Medication Controller
Overview
O ElderlyMedicationController é responsável por gerenciar os medicamentos dos idosos.

Base URL: /api/elderlyMedication

Endpoints
Get All Medications
Obtém todos os registros de medicamentos dos idosos com opções de paginação e ordenação.

URL: /api/elderlyMedication
Método: GET
Parâmetros de consulta:
page (opcional): Número da página.
pageSize (opcional): Número de itens por página.
searchTerm (opcional): Termo de busca.
sortColumn (opcional): Coluna para ordenação.
sortOrder (opcional): Ordem de ordenação (ascendente ou descendente).
Respostas:
200 OK: Lista de registros de medicamentos dos idosos.
404 Not Found: Nenhum registro de medicamento encontrado.
Get Medication by ID
Obtém um registro de medicamento pelo ID.

URL: /api/elderlyMedication/{id}
Método: GET
Parâmetros de caminho:
id: ID do medicamento.
Respostas:
200 OK: Registro de medicamento encontrado.
404 Not Found: Nenhum registro de medicamento encontrado.
Create Medication
Cria um novo registro de medicamento.

URL: /api/elderlyMedication
Método: POST
Corpo da solicitação: Objeto JSON contendo os detalhes do medicamento.
Respostas:
201 Created: Registro de medicamento criado com sucesso.
400 Bad Request: Solicitação inválida.
Delete Medication
Exclui um registro de medicamento pelo ID.

URL: /api/elderlyMedication/{id}
Método: DELETE
Parâmetros de caminho:
id: ID do medicamento.
Respostas:
200 OK: Registro de medicamento excluído com sucesso.
404 Not Found: Nenhum registro de medicamento encontrado.
