# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

### Persona 1: Ana - Profissional Atarefada

#### História:
Ana é uma executiva de 35 anos, mãe de duas crianças pequenas e responsável por um cargo de gestão em uma empresa de tecnologia. Sua rotina é agitada e demanda grande parte do seu tempo, deixando pouco espaço para cuidar de sua saúde. Ela muitas vezes adia a marcação de exames e consultas por falta de tempo e flexibilidade. Ana vê o uso da tecnologia como uma solução para agilizar seu agendamento médico.

#### Necessidades:
- Agendar consultas e exames de forma rápida e flexível.
- Receber notificações e lembretes para não esquecer as marcações.
- Acesso fácil aos resultados dos exames, mesmo com sua agenda cheia.
- Garantia de segurança e privacidade de suas informações.

### Persona 2: Carlos - Aposentado Conectado

#### História:
Carlos tem 65 anos e é aposentado. Ele adora tecnologia e está sempre conectado, seja para ler notícias, se comunicar com a família ou aprender coisas novas. Mesmo após a aposentadoria, ele valoriza sua saúde e faz exames regularmente. Ele acredita que uma plataforma online que facilite a marcação de consultas e exames seria uma maneira conveniente de cuidar de sua saúde.

#### Necessidades:

- Agendar consultas e exames sem sair de casa.
- Interface simples e fácil de usar, pois ele não é um especialista em tecnologia.
- Acesso rápido a informações sobre clínicas e médicos disponíveis.
- Receber orientações claras sobre como proceder com os exames.

### Persona 3: Gabriela - Estudante Multitarefa

#### História:
Gabriela, 22 anos, é estudante universitária em período integral, além de trabalhar meio período como freelancer. Ela está sempre ocupada e enfrenta desafios para equilibrar seus estudos, trabalho e vida social. Ela valoriza muito sua saúde mental e física, mas muitas vezes deixa de marcar consultas médicas devido à falta de tempo. Gabriela vê uma plataforma online como uma maneira de gerenciar seu autocuidado de forma eficiente.

#### Necessidades:
- Agendar consultas e exames em horários flexíveis, adequados à sua agenda.
- Acesso à plataforma via smartphone para agendar durante pausas entre aulas.
- Opções de teleconsulta para economizar tempo em deslocamentos.
- Recomendações de especialistas que compreendam sua rotina agitada.

### Persona 4: Rodrigo - Pai de Família Preocupado

#### História:
 Rodrigo, 40 anos, é casado e pai de três filhos. Ele trabalha em período integral e faz de tudo para dar suporte à família. A saúde de sua esposa e filhos é uma prioridade para ele, mas as marcações de consultas e exames costumam ser um desafio logístico. Rodrigo busca uma maneira eficiente de agendar e gerenciar os cuidados de saúde de toda a família.

#### Necessidades:
- Agendar consultas e exames para múltiplos membros da família.
- Receber notificações e lembretes para garantir que ninguém perca uma marcação importante.
- Acesso a históricos de saúde e resultados anteriores de exames.
- Opções de agendamento em clínicas próximas de casa e escola.

### Persona 5: Sofia - Médica Autônoma

#### História:
Sofia é uma médica autônoma de 30 anos que trabalha em diferentes clínicas e hospitais. Sua rotina é flexível, mas demanda organização para garantir que ela esteja disponível para seus pacientes. Ela reconhece a importância da tecnologia para otimizar processos em sua prática médica e vê valor em uma plataforma que simplifique a marcação de consultas e exames.

#### Necessidades:
- Acesso a uma plataforma que permita sincronizar sua agenda de disponibilidade.
- Facilidade em visualizar os horários disponíveis para novas consultas.
- Receber informações detalhadas sobre os pacientes e suas necessidades.
- Compartilhamento seguro de resultados de exames e históricos médicos com seus pacientes.

### Observação: 
Essas personas são fictícias e foram criadas com base nas informações fornecidas. Elas têm o propósito de ilustrar diferentes perfis de usuários que poderiam se beneficiar da plataforma Marcação Fácil Saúde, considerando suas necessidades, preferências e contextos de vida.


## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Registrar minhas tarefas           | Não esquecer de fazê-las               |
|Administrador       | Alterar permissões                 | Permitir que possam administrar contas |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID     | Descrição do Requisito  | Prioridade |
|-------|-----------------------------------------|----|
| RF-001 | Gerenciar Agendamentos | ALTA | 
| RF-002 | Notificar Consultas Agendadas | MÉDIA |
| RF-003 | Listar Resultados de Exames | MÉDIA |
| RF-004 | Gerenciar Usuários | MÉDIA |
| RF-005 | Agendar Teleconsultas | MÉDIA |
| RF-006 | Permitir Feedback e Avaliações | MÉDIA |
| RF-007 | Atualização de Laudos | ALTA |
| RF-008 | Realizar Pedidos | MÉDIA |
| RF-009 | Emitir Receituário | MÉDIA |
| RF-010 | Consultar Orientações para Realização de Exames | MÉDIA |

- **RF-001 -Gerenciar Agendamentos:** Os usuários devem poder agendar consultas e exames de acordo com sua disponibilidade. A plataforma deve oferecer opções de datas, horários e locais de atendimento. O sistema deve informar ao usuário as orientações para a realização do exames, comunicando os documentos necessários, preparo para realizar procedimento e etc.

- **RF-002 - Notificar consultas agendadas:** A plataforma deve enviar notificações e lembretes aos usuários sobre as consultas e exames agendados. As notificações podem ser via e-mail ou notificações push.

- **RF-003 - Listar resultados de exames:** Os usuários devem ter acesso aos resultados de exames anteriores, histórico médico e recomendações de profissionais de saúde. As informações devem ser apresentadas de maneira clara e compreensível.

- **RF-004 - Gerenciar Usuários:** A plataforma deve permitir a criação de perfis de usuário personalizados, como pacientes, médicos, clínicas e laboratórios. Cada perfil deve ter acesso a funcionalidades específicas.

- **RF-005 - Agendar teleconsultas**: A plataforma deve oferecer a opção de teleconsulta, permitindo aos usuários consultar remotamente com profissionais de saúde. Deve haver suporte técnico para garantir a qualidade das videochamadas.

- **RF-006 - Permitir Feedback e Avaliações:** Os usuários devem poder avaliar a qualidade dos serviços prestados por clínicas e profissionais de saúde. As avaliações podem ajudar outros usuários na escolha de prestadores de serviços.

- **RF-007 - Atualizar Laudos:** Os médicos devem ser capazes de inserir, editar e excluir laudos relacionados aos exames do paciente.

- **RF-008 - Realizar Pedidos:** Os médicos devem ser capazes de emitir ou excluir atestado de licença médica, atestado de comparecimento e pedidos médicos.

- **RF-009 - Emitir Receituário:** O sistema deve permitir que os médicos sejam capazes de emitir receituário para os pacientes.

- **RF-010 - Lista de Agendamento:** O sistema deve permitir que o médico tenha acesso a lista de pacientes agendados com o nome do paciente, data de nascimento, data da consulta e horário.

- **RF-011 - Consultar Orientações para Realização de Exames:** O sistema deve informar ao usuário as orientações para a realização do exames, comunicando os documentos necessários, preparo para realizar procedimento e etc.


### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| Simplificar a Interface | MÉDIA | 
|RNF-002| Proteger Dados | ALTA | 
|RNF-003| Adaptar Sistema | MÉDIA | 

- **RNF-001 - Simplificar a Interface:** A interface deve ser fácil de usar, mesmo para pessoas com pouca experiência em tecnologia. O processo de agendamento deve ser simplificado, com instruções claras.

- **RNF-002 - Proteger Dados:** A segurança dos dados do usuário é fundamental, incluindo informações médicas e pessoais. Deve haver criptografia e medidas de proteção para evitar vazamentos de informações.

- **RNF-003 - Adaptar Sitema:** O sistema deve ser responsivo e permitir o acesso da aplicação por diferentes tipos de telas. 

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| Regulamentações de Saúde                              |
|02| Dados Sensíveis                                       |
|03| Acesso à Internet                                     |
|04| Acesso a Dispositivos                                 |
|05| Variedade de Plataformas                              |
|06| Requisitos Mínimos de Hardware                        |
|07| Proteção contra Ciberataques                          |
|08| Conformidade com Padrões Web                          |
|09| Manutenção e Atualizações                             |

- **1. Regulamentações de Saúde:**
A plataforma deve cumprir todas as regulamentações e leis relacionadas à privacidade e segurança de informações médicas.
- **2. Dados Sensíveis:**
A plataforma não deve compartilhar, vender ou usar de forma inadequada os dados de saúde dos usuários.
- **3. Acesso à Internet:**
A plataforma requer acesso à internet, o que pode ser uma limitação para usuários em áreas com conectividade precária.
- **4. Acesso a Dispositivos:**
Os usuários devem ter acesso a um dispositivo compatível (computador, smartphone, tablet) para usar a plataforma.
- **5. Variedade de Plataformas:**
A plataforma deve ser compatível com diferentes sistemas operacionais e navegadores para atender a uma variedade de dispositivos.
- **6. Requisitos Mínimos de Hardware:**
A plataforma pode ter requisitos mínimos de hardware e conexão para garantir uma experiência satisfatória.
- **7. Proteção contra Ciberataques:**
A plataforma deve implementar medidas robustas de segurança para evitar ataques cibernéticos e proteger os dados dos usuários.
- **8. Conformidade com Padrões Web:**
A plataforma deve seguir os padrões e práticas recomendadas de desenvolvimento web para garantir a acessibilidade e usabilidade.
- **9. Manutenção e Atualizações:**
A plataforma requer manutenção constante para correções de bugs, atualizações de segurança e melhorias de recursos

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

