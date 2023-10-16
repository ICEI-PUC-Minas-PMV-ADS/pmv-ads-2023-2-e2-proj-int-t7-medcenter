# Plano de Testes de Usabilidade

![Teste de Usabilidade](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t7-medcenter/assets/128256600/a0d9079f-4adf-46a7-9d03-862871074e5d)

| **Caso de Teste** 	| **CT-01 – O usuário localiza a página de login e registro.** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-001 - Simplificar a Interface: A interface deve ser fácil de usar, mesmo para pessoas com pouca experiência em tecnologia. O processo de agendamento deve ser simplificado, com instruções claras.  |
| Objetivo do Teste 	| Avaliar o tempo que o usuário leva para localizar a página de login e registro.	|
| Passos 	| - Acessar o sistema <br> - Localizar na homepage o ícone de perfil ou o botão de login <br> - Navegar até a seção de login e cadastro <br> - Escolher entre login ou cadastro <br> - Informar dados de cadastro ou login <br> - Verificar se o login foi realizado com sucesso	|
|Critério de Êxito | - O usuario foi capaz de se cadastrar e realizar o login no site.	|

<br>

| **Caso de Teste** 	| **CT-02 – O usuário é redirecionado para a página de login quando acessa uma página que requer autenticação.** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-001 - Simplificar a Interface: A interface deve ser fácil de usar, mesmo para pessoas com pouca experiência em tecnologia. O processo de agendamento deve ser simplificado, com instruções claras.  |
| Objetivo do Teste 	| Impedir o acesso do usuário a páginas que requerem registro e direcioná-lo para a página de login se tentar acessá-las.	|
| Passos 	| - Acessar o sistema <br> - Tentar acessar uma página que requer registro <br> - Ser direcionado com êxito para a página de login.	|
|Critério de Êxito | - O usuário foi impedido de acessar páginas restritas e foi direcionado com êxito para a página de login.	|

<br>

| **Caso de Teste** 	| **CT-03 – O usuário solicita um novo exame.** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-001 - Simplificar a Interface: A interface deve ser fácil de usar, mesmo para pessoas com pouca experiência em tecnologia. O processo de agendamento deve ser simplificado, com instruções claras.  |
| Objetivo do Teste 	| Avaliar a capacidade do usuário de solicitar um novo exame.	|
| Passos 	| - Acessar o sistema <br> - Fazer login <br> - Acessar a área de exames <br> - Solicitar um novo exame <br>	- Inserir as informações necessárias. <br> - Receber a notificação de solicitação enviada. <br> - Se a solicitação for aceita, receber a alerta de confirmação e as instruções para o exame. <br> - Se a solicitação for negada, receber o alerta de solicitação negada com o motivo. | 
|Critério de Êxito | - O usuário foi capaz de solicitar o exame e receber o devido alerta.	|

<br>

| **Caso de Teste** 	| **CT-04 – O usuário acessa o resultado de um exame.** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-001 - Simplificar a Interface: A interface deve ser fácil de usar, mesmo para pessoas com pouca experiência em tecnologia. O processo de agendamento deve ser simplificado, com instruções claras.  |
| Objetivo do Teste 	| Acessar o resultado de algum exame.	|
| Passos 	| - Acessar o sistema <br> - Fazer login <br> - Acessar a área de resultados <br> - Baixar um resultado <br> | 
|Critério de Êxito | - O usuário foi capaz de baixar o resultado de algum exame.	|

<br>

| **Caso de Teste** 	| **CT-05 –O usuário acessa as funções de administrador.** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-001 - Simplificar a Interface: A interface deve ser fácil de usar, mesmo para pessoas com pouca experiência em tecnologia. O processo de agendamento deve ser simplificado, com instruções claras.  |
| Objetivo do Teste 	| Testar a usabilidade do usuário Administrador.	|
| Passos 	| - Acessar o sistema <br> - Fazer login como ADM <br> - Enviar um pedido a um usuário. <br> - Enviar um documento a um usuário (receita, atestado ou laudo) <br> - Acessar o resultado de um exame de um usuário <br> - Visualizar em sua agenda as consultas agendadas | 
|Critério de Êxito | - O usuário foi capaz de utilizar as funcionalidades de administrador.	|

<br>

| **Caso de Teste** 	| **CT-06 –O usuário acessa as funções de administrador.** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-003 - Adaptar Sitema: O sistema deve ser responsivo e permitir o acesso da aplicação por diferentes tipos de telas.  |
| Objetivo do Teste 	| Avaliar a capacidade de resposta da tela em diversos dispositivos.	|
| Passos 	| - Acessar o sistema em diferentes dispositivos | 
|Critério de Êxito | - O sistema continua responsivo e intuitivo em diferentes resoluções|
