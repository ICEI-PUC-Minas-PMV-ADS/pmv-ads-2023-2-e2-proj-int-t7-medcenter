# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Abaixo encontra-se nosso plano de teste de software, de acordo com as especificações do projeto.

| **Caso de Teste** 	| **CT-01 – Gerenciar Agendamentos** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - Os usuários devem poder agendar consultas e exames de acordo com sua disponibilidade. A plataforma deve oferecer opções de datas, horários e locais de atendimento. O sistema deve informar ao usuário as orientações para a realização do exames, comunicando os documentos necessários, preparo para realizar procedimento e etc.	|
| Objetivo do Teste 	| Verificar se os usuários conseguem agendar consultas e exames, considerando datas, horários, locais e recebendo as devidas orientações.	|
| Passos 	| - Acessar o sistema <br> - Navegar até a seção de agendamento <br> - Escolher entre consulta ou exame <br> - Selecionar data, horário e local <br> - Verificar se as orientações para o exame estão disponíveis	|
|Critério de Êxito | - O agendamento foi concluído com sucesso e as orientações estão claras.	|
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Notificar consultas agendadas**	|
|Requisito Associado | RF-002 - A plataforma deve enviar notificações e lembretes aos usuários sobre as consultas e exames agendados. As notificações podem ser via e-mail ou notificações push.	|
| Objetivo do Teste 	| Verificar se os usuários recebem notificações e lembretes sobre consultas e exames agendados.	|
| Passos 	| - Agendar uma consulta ou exame <br> - Verificar se uma notificação ou lembrete é recebido via e-mail ou notificação push	|
|Critério de Êxito | - O usuário recebeu com sucesso a notificação ou lembrete.	|
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Listar resultados de exames**	|
|Requisito Associado | RF-003 - Os usuários devem ter acesso aos resultados de exames anteriores, histórico médico e recomendações de profissionais de saúde. As informações devem ser apresentadas de maneira clara e compreensível.	|
| Objetivo do Teste 	| Verificar se os usuários conseguem listar e acessar resultados de exames anteriores, histórico médico e recomendações.	|
| Passos 	| - Acessar o sistema <br> - Navegar até a seção de resultados de exames <br> - Selecionar exame desejado <br> - Verificar histórico médico e recomendações	|
|Critério de Êxito | - Os resultados, histórico médico e recomendações são apresentados de forma clara e compreensível.	|
| **Caso de Teste** 	| **CT-04 – Gerenciar Usuários**	|
|Requisito Associado | RF-004 - A plataforma deve permitir a criação de perfis de usuário personalizados, como pacientes, médicos, clínicas e laboratórios. Cada perfil deve ter acesso a funcionalidades específicas.	|
| Objetivo do Teste 	| Verificar se a plataforma permite a criação de perfis personalizados e se cada perfil tem acesso às funcionalidades específicas.	|
| Passos 	| - Criar perfis de pacientes, médicos, clínicas e laboratórios <br> - Verificar se cada perfil tem acesso apenas às funcionalidades específicas	|
|Critério de Êxito | - Os perfis foram criados corretamente e têm acesso apenas às funcionalidades específicas.	|
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Agendar Teleconsultas**	|
|Requisito Associado | RF-005 - A plataforma deve oferecer a opção de teleconsulta, permitindo aos usuários consultar remotamente com profissionais de saúde. 	|
| Objetivo do Teste 	| Verificar se a plataforma oferece a opção de teleconsulta.	|
| Passos 	| - Agendar uma teleconsulta <br> - Verificar se a qualidade da videochamada é satisfatória	|
|Critério de Êxito | - A teleconsulta foi agendada com sucesso e a qualidade da videochamada é satisfatória.	|
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Permitir Feedback e Avaliações**	|
|Requisito Associado | RF-006 - Os usuários devem poder avaliar a qualidade dos serviços prestados por clínicas e profissionais de saúde. As avaliações podem ajudar outros usuários na escolha de prestadores de serviços.	|
| Objetivo do Teste 	| Verificar se os usuários conseguem fornecer feedback e avaliações sobre os serviços prestados por clínicas e profissionais de saúde.	|
| Passos 	| - Acessar a seção de feedback e avaliações <br> - Fornecer feedback e avaliação para clínicas e profissionais de saúde	|
|Critério de Êxito | - O feedback e as avaliações foram fornecidos com sucesso.	|
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Atualizar Laudos**	|
|Requisito Associado | RF-007 - Os médicos devem ser capazes de inserir, editar e excluir laudos relacionados aos exames do paciente.	|
| Objetivo do Teste 	| Verificar se os médicos conseguem inserir, editar e excluir laudos relacionados aos exames do paciente.	|
| Passos 	| - Acessar o sistema como médico <br> - Inserir, editar e excluir laudos relacionados aos exames do paciente	|
|Critério de Êxito | - Os médicos conseguem realizar as operações de inserção, edição e exclusão de laudos com sucesso.	|
| **Caso de Teste** 	| **CT-08 – Realizar Pedidos**	|
|Requisito Associado | RF-008 - Os médicos devem ser capazes de emitir ou excluir atestado de licença médica, atestado de comparecimento e pedidos médicos.	|
| Objetivo do Teste 	| Verificar se os médicos conseguem emitir ou excluir atestados e pedidos médicos.	|
| Passos 	| - Acessar o sistema como médico <br> - Emitir e excluir atestado de licença médica, atestado de comparecimento e pedidos médicos	|
|Critério de Êxito | - Os médicos conseguem emitir e excluir atestados e pedidos médicos com sucesso.	|
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Emitir Receituário**	|
|Requisito Associado | RF-009 - O sistema deve permitir que os médicos sejam capazes de emitir receituário para os pacientes.	|
| Objetivo do Teste 	| Verificar se os médicos conseguem emitir receituário para os pacientes.	|
| Passos 	| - Acessar o sistema como médico <br> - Emitir receituário para pacientes	|
|Critério de Êxito | - Os médicos conseguem emitir receituário com sucesso.	|
|  	|  	|
| **Caso de Teste** 	| **CT-10 – Lista de Agendamento**	|
|Requisito Associado | RF-010 - O sistema deve permitir que o médico tenha acesso à lista de pacientes agendados com o nome do paciente, data de nascimento, data da consulta e horário.	|
| Objetivo do Teste 	| Verificar se o médico tem acesso à lista de pacientes agendados com as informações corretas.	|
| Passos 	| - Acessar o sistema como médico <br> - Verificar a lista de pacientes agendados	|
|Critério de Êxito | - O médico tem acesso à lista de pacientes agendados com informações corretas.	|
|  	|  	|
| **Caso de Teste** 	| **CT-11 – Consultar Orientações para Realização de Exames**	|
|Requisito Associado | RF-011 - O sistema deve informar ao usuário as orientações para a realização dos exames, comunicando os documentos necessários, preparo para realizar procedimento e etc.	|
| Objetivo do Teste 	| Verificar se o sistema fornece corretamente as orientações necessárias para a realização dos exames.	|
| Passos 	| - Acessar o sistema como usuário <br> - Navegar até a seção de agendamento de exames <br> - Verificar as orientações para os exames agendados	|
|Critério de Êxito | - As orientações para a realização dos exames estão disponíveis e corretas.	|
