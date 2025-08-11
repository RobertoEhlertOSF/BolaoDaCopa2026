z# Bolão Copa do Mundo 2026

Projeto simples de sistema web para bolão da Copa do Mundo 2026, com foco em aprendizado prático para iniciantes em programação.  
Usamos ASP.NET Core MVC para facilitar o desenvolvimento backend e SQLite como banco de dados leve e fácil de usar.

---

## Índice

- [Sobre o Projeto](#sobre-o-projeto)  
- [Funcionalidades](#funcionalidades)  
- [Tecnologias](#tecnologias)  
- [Estrutura do Projeto](#estrutura-do-projeto)  
- [Como Rodar Localmente](#como-rodar-localmente)  
- [Contribuição](#contribuição)  
- [Git Workflow](#git-workflow)  
- [Licença](#licença)

---

## Sobre o Projeto

Este sistema permite criar bolões, cadastrar palpites para os jogos da Copa, calcular pontuação e exibir rankings.  
O foco é facilitar o aprendizado dos conceitos básicos de desenvolvimento web, arquitetura MVC, banco de dados e trabalho em equipe.

---

## Funcionalidades

- Cadastro e login de usuários  
- Criação e gerenciamento de bolões  
- Inserção e edição de palpites antes do jogo começar  
- Atualização manual dos resultados dos jogos (admin)  
- Cálculo e exibição de pontuação e rankings  
- Interface simples e responsiva

---

## Tecnologias

- **Backend:** ASP.NET Core MVC (C#)  
- **Banco de Dados:** SQLite (via Entity Framework Core)  
- **Frontend:** Razor Views (sem SPA para simplicidade)  
- **Controle de Versão:** Git / GitHub  
- **Gerenciamento de Projeto:** Trello  

---

## Estrutura do Projeto

```plaintext
/bolaoDaCopa2026
├── BolaoMvc/               # Projeto ASP.NET Core MVC com controllers, views, models
├── wwwroot/                # Arquivos estáticos (css, js, imagens)
├── appsettings.json        # Configurações (incluindo conexão SQLite)
├── README.md               # Este arquivo
├── .gitignore              # Arquivo de exclusão Git
├── CONTRIBUTING.md         # Guia de contribuição
└── LICENSE                 # Licença do projeto
