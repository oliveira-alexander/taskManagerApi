# 🧩 Task Manager API

API REST desenvolvida com ASP.NET Core para gerenciamento de tarefas, aplicando boas práticas de arquitetura, testes automatizados e documentação OpenAPI.

## 🚀 Objetivo do projeto

Este projeto foi criado com foco em aprendizado e consolidação de conceitos essenciais para desenvolvimento backend em .NET:

Arquitetura em camadas <br>
Clean Code e separação de responsabilidades <br>
CRUD completo com EF Core <br>
Testes unitários <br>
Documentação automática da API <br>

## 🛠️ Tecnologias utilizadas
.NET 9 <br>
ASP.NET Core Web API <br>
Entity Framework Core <br>
Banco InMemory (para simplicidade e testes) <br>
OpenAPI / Swagger (documentação) <br>
xUnit (testes unitários)

## 📂 Arquitetura do projeto

O projeto segue uma arquitetura em camadas: <br>

TaskManagerAPI <br>
│<br>
├── Controllers     → Camada HTTP (entrada da API) <br>
├── Services        → Regras de negócio <br>
├── Repositories    → Acesso a dados <br>
├── Entities        → Entidades do domínio <br>
├── DTOs            → Objetos de transferência de dados <br>
├── Mapper          → Conversão DTO ↔ Entity <br>
├── Exceptions      → Exceções personalizadas<br>
└── Tests           → Testes automatizados <br>


## ▶️ Como executar o projeto
1️⃣ Clonar o repositório <br>
git clone https://github.com/oliveira-alexander/taskManagerApi <br>
cd taskManagerApi <br><br>

2️⃣ Restaurar dependências <br>
dotnet restore <br><br>

3️⃣ Rodar a API <br>
dotnet run <br>

### A API será iniciada em:

http://localhost:5014

## 📄 Documentação da API (SwaggerUI)

A documentação interativa é gerada automaticamente.

Após rodar o projeto, acesse:

http://localhost:5014/swagger

Você poderá:

Visualizar endpoints
Testar requisições direto no navegador
Ver schemas de Request/Response

### ➕ Adicionar Tarefas
POST /tasks
### 📋 Listar tarefas
GET /tasks
### ✏️ Atualizar tarefa
PUT /tasks
### ❌ Deletar tarefa
DELETE /tasks/{id}

## 🧪 Executando os testes
dotnet test

Os testes cobrem:

Services
Regras de negócio
Exceções personalizadas

## 📚 Conceitos aplicados

Este projeto utiliza conceitos importantes do ecossistema .NET:

Dependency Injection
Async / Await
LINQ
DTO Pattern
Repository Pattern
Service Layer Pattern

## ❓ Q & A (Questions and Answers)

### 📌 Por que usar arquitetura em camadas?
R: A arquitetura em camadas separa a aplicação em responsabilidades bem definidas, fazendo com que a manutenção, extensão e testes sejam mais simples e eficientes.

- Problemas com bancos de dados, podem ser analisados nos repositories
- Problemas com regras de negócio, estão centralizadas nos services
- Problemas com rotas, requisições HTTP ou indisponibilidade, a análise começa nos controllers.
