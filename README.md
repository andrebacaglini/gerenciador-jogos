# gerenciador-jogos
Repositório cuja finalidade é armazenar o código fonte do projeto que gerenciará os empréstimos dos meus jogos aos meus amigos.

<b>Problema:</b>
  <p>Meus amigos vivem pedindo meus jogos emprestados. Muitas vezes quero jogar um jogo e não sei com quem está.</p>

<b>Informações do projeto:</b>
  <p>O sistema deverá permitir a inserção/edição/exclusão de amigos e jogos, além
  de permitir o gerenciamento e visualização dos seus jogos, dos amigos e qual
  jogo está com quem.</p>

<b>Caracteristicas técnicas:</b>
  <ul>
    <li>O sistema deve possuir controle de acesso (Segurança/Login)</<li>
    <li>MVC</li>
    <li>jQuery</li>
    <li>SQLServer</li>
  </ul>
  
<b>Solução:</b>
<p>Para o banco de dados foi criado em um container Docker baseado na imagem <a href="https://hub.docker.com/r/microsoft/mssql-server-linux/">"microsoft/mssql-server-linux"</a> em sua ultima versão, sem alterções nas configurações basicas da imagem. Portanto, o container fica exposto em localhost:1433 com usuário "sa" e senha definida na criação do container.</p>

<p>Para a aplicação, foi criado um projeto MVC 5 com Razor utilizando o template incial sem autenticação. Foi feito o uso do Scaffolding para auxiliar na criação das Views e Controllers. <br />
  Também foram utilizados os frameworks adicionais:
  <ul>
    <li><a href="https://autofac.org/">Autofac</a> - Para injeção de dependencia</li>
    <li><a href="http://automapper.org/">Automapper</a> - Para conversões de ViewModels para Entidades e vice-versa</li>
    <li><a href="">jQuery</a> - Apesar de já estar embutido no template do MVC, foi utilizado em cenários especificos, como modais e um tratamento para input's tipo date.
  </ul>  
  </p>

<p>Como a aplicação foi desenvolvida utilizando Code First com Entity Framework e Data Migrations, os scripts aqui registrados são resultado da extração realizada da versão estável.
Os scripts são:</p>
  <ul>
    <li><b>SCRIPT_DROP_CREATE_DATABASE.sql</b> - Cria a base de dados db_gerenciador_jogos.</<li>
    <li><b>SCRIPT_DROP_CREATE_TABLES.sql</b> - Cria as tabelas do sistema.</li>  
    <li><b>SCRIPT_INSERT_USER.sql</b> - Cria o usuário do sistema. (com senha a 'P4ssw0rd' sem as aspas)</li>  
  </ul>

Atenção! Ao executar os comandos Add-Migration e Update-Database os exemplos existentes no metodo Seed da classe Configuration serão persistidos.
  

