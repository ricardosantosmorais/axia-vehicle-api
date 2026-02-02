# Axia Vehicle API (.NET 8) — Teste Prático

API REST para cadastro e consulta de **Veículos** (protegido por JWT) e cadastro/autenticação de **Usuários**.

## ✅ Tecnologias / Padrões
- .NET 8
- ASP.NET Core Web API (Controllers)
- Swagger / OpenAPI
- EF Core InMemory
- JWT Authentication/Authorization
- MediatR (Commands/Queries/Handlers)
- FluentValidation (validando via pipeline do MediatR)
- Clean Architecture + separação em camadas (Domain / Application / Infrastructure / WebApi)

## Estrutura da solução
```
Axia.VehicleApi.sln
src/
  Axia.VehicleApi.Domain
  Axia.VehicleApi.Application
  Axia.VehicleApi.Infrastructure
  Axia.VehicleApi.WebApi
```

## Como executar
1. Tenha o **.NET SDK 8** instalado.
2. Na pasta raiz do repositório:
```bash
dotnet restore
dotnet run --project src/Axia.VehicleApi.WebApi
```
3. Abra o Swagger:
- https://localhost:5001/swagger  
ou  
- http://localhost:5000/swagger

> Observação: a persistência é **InMemory**, então os dados são reiniciados quando a aplicação para.

## Seed (Admin)
Ao subir a API, é criado um usuário admin automaticamente (caso não exista):
- Login: `admin`
- Senha: `Admin@123`
- Role: `Admin`

## Fluxo recomendado no Swagger
### 1) Login
`POST /api/auth/login`

**Request**
```json
{
  "login": "admin",
  "senha": "Admin@123"
}
```

**Response**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiresAt": "2026-02-02T12:34:56.789+00:00",
  "usuarioId": "00000000-0000-0000-0000-000000000000",
  "login": "admin",
  "role": "Admin"
}
```

### 2) Authorize no Swagger
Clique em **Authorize** (cadeado) e cole:
```
Bearer SEU_TOKEN_AQUI
```

### 3) Veículos (protegido por JWT)
- `POST /api/veiculos`
- `PUT /api/veiculos/{id}`
- `GET /api/veiculos/{id}`
- `GET /api/veiculos`
- `DELETE /api/veiculos/{id}`

## JSONs de exemplo

### Cadastrar usuário
`POST /api/usuarios`

```json
{
  "nome": "João da Silva",
  "login": "joao",
  "senha": "minhaSenha123"
}
```

### Cadastrar veículo
`POST /api/veiculos`

> `marca` é um **enum** e está configurado para serializar como **string**.

```json
{
  "descricao": "Carro compacto para uso urbano",
  "marca": "Fiat",
  "modelo": "Argo",
  "opcionais": "Ar condicionado, Direção hidráulica",
  "valor": 78990.50
}
```

## Tratamento de erros
- Validação: **400** com detalhes em `errors` (ProblemDetails)
- Login inválido: **401**
- Sem token / token inválido em veículos: **401**
- Sem permissão (Admin/User): **403**
- Não encontrado: **404**
