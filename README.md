# ProjetoDS
Repositório para o projeto final da matéria de DS do terceiro semestre

# ProjetoDS

## 📌 Descrição do Projeto

O **ProjetoDS** é uma aplicação web desenvolvida em **ASP.NET Core MVC**, com foco na gestão de uma biblioteca, permitindo o controle de **usuários**, **livros** e **empréstimos**. O projeto segue o padrão arquitetural **MVC (Model–View–Controller)** e utiliza **Entity Framework Core** para persistência de dados.

A aplicação foi construída com fins educacionais, aplicando conceitos fundamentais de desenvolvimento web com .NET, separação de responsabilidades, acesso a dados e renderização de views com Razor.

---

## 🛠️ Tecnologias Utilizadas

* **ASP.NET Core MVC**
* **C#**
* **Entity Framework Core**
* **Razor Pages / Razor Views**
* **SQL Server (ou LocalDB)**
* **HTML5 / CSS3**
* **Bootstrap**

---

## 🧱 Padrão MVC Utilizado

### Model

Responsável por representar as entidades do sistema e suas regras de negócio.

Principais models:

* **UsuarioModel** – representa os usuários do sistema
* **LivroModel** – representa os livros cadastrados
* **EmprestimoModel** – representa os empréstimos realizados

### View

Responsável pela interface com o usuário. Utiliza **Razor** para renderização dinâmica dos dados.

As views estão organizadas na pasta **Views**, separadas por controller.

### Controller

Responsável por intermediar as requisições do usuário, processar regras de negócio e retornar as views apropriadas.

Controllers principais:

* **UsuarioController**
* **LivroController**
* **EmprestimoController**
* **HomeController**

---

## 🗂️ Estrutura do Projeto

```
ProjetoDS
│
├── Controllers
│   ├── UsuarioController.cs
│   ├── LivroController.cs
│   ├── EmprestimoController.cs
│   └── HomeController.cs
│
├── Models
│   ├── UsuarioModel.cs
│   ├── LivroModel.cs
│   ├── EmprestimoModel.cs
│   └── ErrorViewModel.cs
│
├── Views
│   ├── Usuario
│   ├── Livro
│   ├── Emprestimo
│   └── Home
│
├── Data
│   └── BibliotecaContext.cs
│
├── Migrations
│
├── Services
├── Repository
│
├── wwwroot
│   ├── css
│   ├── js
│   └── lib
│
├── appsettings.json
├── Program.cs
└── ProjetoDS.csproj
```

---

## 🧩 Entity Framework Core

O projeto utiliza **Entity Framework Core** para o mapeamento objeto-relacional e acesso ao banco de dados.

O contexto principal da aplicação está localizado em:

```
Data/BibliotecaContext.cs
```

As migrations ficam armazenadas na pasta **Migrations**, permitindo versionamento da base de dados.

---

## 🖥️ Razor e Views

As views utilizam **Razor**, permitindo a integração de código C# diretamente no HTML.

Exemplo:

```csharp
@model LivroModel

<h2>@Model.Titulo</h2>
<p>@Model.Autor</p>
```

---

## 📦 ViewData, ViewBag e TempData

### ViewData

Usado para passar dados do Controller para a View através de um dicionário.

```csharp
ViewData["Mensagem"] = "Cadastro realizado com sucesso";
```

### ViewBag

Forma dinâmica de transportar dados do Controller para a View.

```csharp
ViewBag.Usuario = "Administrador";
```

### TempData

Usado para persistir dados entre requisições, muito comum em redirecionamentos.

```csharp
TempData["Sucesso"] = "Operação concluída";
```

---

## 🔐 ASP.NET Identity

O projeto utiliza **ASP.NET Core Identity** para controle de **autenticação e autorização de usuários**.

Com o Identity, a aplicação gerencia:

* Cadastro de usuários
* Login e logout
* Controle de acesso por autenticação
* Armazenamento seguro de senhas (hash)

O Identity está integrado ao **Entity Framework Core**, utilizando o **BibliotecaContext** como contexto principal para persistência dos dados de autenticação.

### Principais recursos utilizados

* **IdentityUser** – entidade base para usuários
* **UserManager** – gerenciamento de usuários
* **SignInManager** – controle de login e logout
* **Roles (opcional)** – controle de permissões

Exemplo de uso em Controller:

```csharp
public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
```

O uso do Identity garante maior segurança e organização no controle de acesso ao sistema.

---

## ▶️ Como Executar o Projeto

1. Clone o repositório:

```bash
git clone <url-do-repositorio>
```

2. Abra o projeto no **Visual Studio**

3. Configure a string de conexão no arquivo:

```
appsettings.json
```

4. Execute as migrations (se necessário):

```bash
dotnet ef database update
```

5. Execute o projeto:

```bash
dotnet run
```

---

## 📌 Observações Importantes

* O projeto segue boas práticas de separação de responsabilidades
* Ideal para estudos de **ASP.NET Core MVC**
* Pode ser expandido com autenticação, autorização e validações mais avançadas

---

## 👨‍💻 Integrantes do Projeto

* **Kauan Rodrigues**
* **Itauan Silva**

Projeto desenvolvido para fins educacionais, aplicando conceitos de Desenvolvimento de Sistemas com ASP.NET Core MVC.

---

## 📄 Licença

Este projeto é de uso educacional e livre para estudos e modificações.
