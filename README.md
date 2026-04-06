# Notifyx

Microsserviço de notificações. Recebe eventos via RabbitMQ e dispara notificações por Email, SMS ou InApp.

## Pré-requisitos

- .NET 10
- Docker Desktop
- EF Core CLI: `dotnet tool install --global dotnet-ef`

## Como rodar

**1. Subir os containers (SQL Server + RabbitMQ)**
```bash
docker-compose up -d
```

**2. Aplicar as migrations** (apenas na primeira vez)
```bash
cd src/Notifyx.WebApi
dotnet ef migrations add InitialCreate --project ../Notifyx.Infrastructure
dotnet ef database update
```

**3. Configurar Mailtrap para simular email**
1. Crie sua conta em mailtrap.io.
2. Vá em Inboxes > Selecione sua Inbox > SMTP Settings.
3. Copie seu Username e Password.
4. No projeto Notifyx.WebApi, adicione essas credenciais aos seus User Secrets/AppSettings.Development.Json

**4. Rodar a API**
```bash
dotnet run --project src/Notifyx.WebApi
```

API disponível em `https://localhost:63284`  
Documentação: `https://localhost:63284/scalar/v1`  
RabbitMQ painel: `http://localhost:15672` (guest/guest)

---

## Integração com outros microsserviços

### 1. Gerar o pacote de contratos

No repositório do Notifyx, execute:

```bash
dotnet build contracts/Notifyx.Contracts -c Release
dotnet pack contracts/Notifyx.Contracts -c Release --no-build
```

O arquivo gerado será:
```
contracts/Notifyx.Contracts/bin/Release/Notifyx.Contracts.1.0.0.nupkg
```

Envie esse arquivo para os outros times.

---

### 2. Configurar o pacote no projeto consumidor

Na raiz do projeto consumidor, crie um arquivo `nuget.config`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="local-notifyx" value="./packages" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

Crie a pasta `packages/` e coloque o `.nupkg` dentro dela. Depois instale:

```bash
dotnet add package Notifyx.Contracts
```

---

### 3. Instalar o EasyNetQ

```bash
dotnet add package EasyNetQ
```

---

### 4. Registrar no DI

```csharp
services.AddEasyNetQ("host=localhost;username=guest;password=guest");
```

---

### 5. Publicar um evento

```csharp
public class SeuService(IBus bus)
{
    public async Task ExemploAsync()
    {
        await bus.PubSub.PublishAsync(new NotificationEvent(
            UserId: Guid.Parse("id-do-usuario"),
            Title: "Título da notificação",
            Body: "Corpo da mensagem",
            Type: NotificationType.Email,
            SourceService: "NomeDoSeuServico"
        ));
    }
}
```

---

### Tipos de notificação

| Valor | Canal |
|-------|-------|
| `NotificationType.All` | Email + SMS + InApp |
| `NotificationType.Email` | Email (Mailtrap em dev) |
| `NotificationType.Sms` | SMS (simulado) |
| `NotificationType.InApp` | InApp (simulado) |
