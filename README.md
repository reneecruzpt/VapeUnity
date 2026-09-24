# VapeUnity — Plataforma Web ASP.NET Core MVC

[![.NET](https://img.shields.io/badge/.NET-7.0%20%2F%208.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-ORM-blue)](https://docs.microsoft.com/ef/core/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Aplicação web full-stack desenvolvida em **C# / ASP.NET Core MVC** com arquitetura robusta para gestão de comunidade e comércio eletrónico. O sistema inclui autenticação avançada de utilizadores, controlo de acessos por papéis, confirmação de contas por e-mail e integração com bases de dados relacionais MySQL.

---

## 🚀 Funcionalidades Principais

- **Sistema de Identidade & Contas (ASP.NET Core Identity):**
  - Registo e autenticação de utilizadores com validação de dados.
  - Confirmação de e-mail e recuperação de palavra-passe com geração de tokens seguros.
  - Login social integrado via **Google OAuth 2.0**.
  - Áreas administrativas e controlo de acesso baseado em permissões.
- **Camada de Dados & Persistência:**
  - Mapeamento objeto-relacional via **Entity Framework Core**.
  - Suporte e otimização para base de dados **MySQL** (`Pomelo.EntityFrameworkCore.MySql`).
- **Comunicação & Notificações Transacionais:**
  - Envio automatizado de e-mails transacionais (boas-vindas, redefinição de credenciais) via **SendGrid API**.
- **Interface e Apresentação:**
  - Padrão arquitetural MVC com Razor Pages e Razor Views dinâmicas.
  - Layout responsivo com Bootstrap e validações assíncronas do lado do cliente.

---

## 🛠️ Tecnologias Utilizadas

- **Backend:** C# / ASP.NET Core
- **ORM:** Entity Framework Core
- **Base de Dados:** MySQL
- **Autenticação:** ASP.NET Core Identity & Google External Auth
- **Serviço de E-mail:** SendGrid REST API
- **Frontend:** Razor Views, HTML5, CSS3, JavaScript, Bootstrap

---

## ⚙️ Como Executar Localmente

### Pré-requisitos
- [.NET SDK 7.0 ou superior](https://dotnet.microsoft.com/download)
- Servidor [MySQL](https://dev.mysql.com/downloads/installer/) (ou MariaDB)
- Ferramenta de linha de comando `dotnet-ef`:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Configuração

1. **Clonar o repositório:**
   ```bash
   git clone https://github.com/reneecruzpt/VapeUnity.git
   cd VapeUnity
   ```

2. **Configurar as credenciais no `appsettings.json`:**
   Configure a string de ligação para o seu servidor MySQL local e insira as suas chaves do Google e SendGrid (ou use User Secrets):
   ```json
   "ConnectionStrings": {
     "ContextoConnection": "Server=localhost;Port=3306;Database=vapeunity;User=root;Password=SuaSenha;"
   }
   ```

3. **Restaurar dependências e aplicar migrações:**
   ```bash
   dotnet restore
   dotnet ef database update
   ```

4. **Executar a aplicação:**
   ```bash
   dotnet run
   ```
   Acesse a aplicação no navegador em `https://localhost:7167` ou `http://localhost:5178`.

---

## 📄 Licença
Este projeto está sob licença MIT.
