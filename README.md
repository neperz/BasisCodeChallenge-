# BasisCodeChallenge-
Desafio tecnico Basis
Objetivo:
Criar um projeto utilizando as boas pr�ticas de mercado e apresentar o mesmo demonstrando o passo a passo de sua cria��o (base de dados, tecnologias, aplica��o, metodologias, frameworks, etc).

Projeto:
	O projeto consiste em um cadastro de livros. 
No final deste documento foi disponibilizado um modelo dos dados.

Tecnologia:
	A tecnologia a ser utilizada � sempre Web e referente a vaga em que est� concorrendo (C# ou Java). 
A implementa��o do projeto ficar� por sua total responsabilidade assim como os componentes a serem utilizados (relat�rios, camada de persist�ncia, etc) com algumas premissas.
	� opcional a utiliza��o do angular, mas ser� considerado um diferencial.
O c�digo deve ser disponibilizado em reposit�rio GIT de sua prefer�ncia e acesso. 
	O banco de dados � o de sua prefer�ncia. A utiliza��o de camada de persist�ncia tamb�m � escolha sua.

Instru��es:
Deve ser feito CRUD para Livro, Autor e Assunto conforme o modelo de dados.
A tela inicial pode ter um menu simples ou mesmo links direto para as telas constru�das.
O modelo do banco deve ser seguido integralmente, salvo para ajustes de melhoria de performance.
A interface pode ser simples, mas precisa utilizar algum CSS que comande no m�nimo a cor e tamanho dos componentes em tela (utiliza��o do bootstrap ser� um diferencial).
	Os campos que pedem formata��o devem possuir o mesmo (data, moeda, etc).
	Deve ser feito obrigatoriamente um relat�rio (utilizando o componente de relat�rios de sua prefer�ncia(Crystal, ReportViewer, etc) e a consulta desse relat�rio deve ser proveniente de uma view criada no banco de dados. Este relat�rio pode ser simples, mas permita o entendimento dos dados. O relat�rio deve trazer as informa��es das 3 tabelas principais agrupando os dados por autor (aten��o pois um livro pode ter mais de autor).
	TDD (Test Driven Development) ser� considerado um diferencial.
	Tratamento de erros � essencial, evite try catchs gen�ricos em situa��es que permitam utiliza��o de tratamentos espec�ficos, como os poss�veis erros de banco de dados.
	As mensagens emitidas pelo sistema, labels e etc ficam a seu crit�rio.
	O modelo inicial n�o prev�, mas � necess�rio incluir uma forma de informar o valor (em R$) do livro dependendo da forma de compra do mesmo (exemplos: balc�o, self-service, internet, evento, etc). Deve ser feito tanto o modelo quanto a implementa��o necess�ria para que esteja dispon�vel para o usu�rio final.
	Guarde todos os scripts e instru��es para implanta��o de seu projeto, eles devem ser demonstrados na apresenta��o.
	
Apresenta��o:
	Assim que finalizado o projeto, ser� agendada sua apresenta��o. A ideia � discutir seu projeto, avaliar o mesmo funcionalmente e tecnicamente.

Modelo:
Livro
CodI int
Titulo varchar 40
Editora varchar 40
Edicao int
AnoPublicacao varchar 4

Livro_Autor
Livro_CodI int FK
Autor_CodAu int FK

Autor
CodAu int PK
Nome varchar 40

Livro_Assunto
Livro_CodI int FK
Assunto_codAs int FK

Assunto
codAS int
Descricao varchar 20
