# Registro de Testes de Software

## Introdução:
Este plano de testes visa garantir a qualidade e funcionamento correto da plataforma Medcenter. Os testes serão realizados para verificar se a plataforma atende aos requisitos funcionais e não funcionais estabelecidos.

## Escopo:
Os testes serão realizados nas aplicações interativas da plataforma.

## Objetivos dos Testes:

- Validar o fluxo de navegação do usuário.
- Verificar a comunicação adequada de datas, informações (valores, orientações para exames, etc) e pedidos.
- Garantir que a plataforma atenda aos requisitos funcionais e não funcionais.
- Identificar e relatar defeitos, erros e problemas de usabilidade.

## Casos de Teste:

### 1. Teste de Navegação do Usuário/Administrador:

- `Cenário 1` O usuário acessa o website e realiza o login com sucesso.
- `Cenário 2` O usuário tenta acessar uma página sem estar logado e recebe a mensagem de redirecionamento para a página de login.
- `Cenário 3` O usuário agenda uma consulta, passando por todas as etapas do processo.
- `Cenário 4` O usuário acessa a lista de profissionais disponíveis e verifica a correta exibição das informações.
- `Cenário 5` O usuário acessa a área de exames, solicita um novo exame e verifica se os campos obrigatórios estão corretamente validados.
- `Cenário 6` O usuário acessa a área de resultados e visualiza os resultados de exames anteriores.
- `Cenário 7` O usuário altera sua senha com sucesso.
- `Cenário 8` O usuário administrador acessa a plataforma do administrador e realiza o login com sucesso.
- `Cenário 9` O administrador envia um pedido a um usuário.
- `Cenário 10` O administrador envia um documento a um usuário (receita, atestado ou laudo).
- `Cenário 11` O administrador acessa o resultado de um exame de um usuário.
- `Cenário 12` O administrador visualiza em sua agenda as consultas agendadas.


### 2. Teste de Comunicação de Datas e Informações:

- 'Cenário 1' O usuário agenda uma consulta e verifica se a data e hora escolhidas correspondem às informações exibidas.
- 'Cenário 2' O usuário solicita um exame e verifica se as informações sobre as orientações estão claras e corretas.
- 'Cenário 3' O usuário verifica se as notificações e lembretes de consultas e exames são enviados corretamente.



### 3. Teste de Requisitos Funcionais:

- `Cenário 1` O usuário agendará uma consulta e um exame, verificando se as ações são concluídas com sucesso.
- `Cenário 2` O corpo clínico gerenciará sua agenda, definindo disponibilidade e visualizando as consultas e exames agendados.
- `Cenário 3` A clínica/laboratório cadastrará serviços e exames, e disponibilizará os resultados de exames.

### 4. Teste de Requisitos Não Funcionais:

- `Cenário 1` O usuário com pouca experiência em tecnologia avaliará a facilidade de uso da interface.
- `Cenário 2` A segurança dos dados do usuário será testada, verificando a criptografia e medidas de proteção.
- `Cenário 3` A plataforma será testada em diferentes dispositivos e navegadores para verificar a compatibilidade.
- `Cenário 4` Será avaliada a velocidade de acesso à plataforma em diferentes conexões de internet.




## Critérios de Aceitação:

Os testes serão considerados bem-sucedidos se:

- Todos os casos de teste forem executados com sucesso.
- Não houver falhas críticas que afetem a usabilidade da plataforma.
- A plataforma atender aos requisitos funcionais e não funcionais estabelecidos.
- A segurança dos dados do usuário for mantida.
- A plataforma for compatível com os navegadores e dispositivos especificados.
- Não houver vulnerabilidades significativas identificadas.

## Responsáveis pelos Testes:

- Scrum Master;
- Product Owner;
- Time de desenvolvimento.

Em caso de identificação de defeitos, a equipe de desenvolvimento deverá imediatamente trabalhar na correção e lançar uma atualização da plataforma.

## Data de Início dos Testes:

Os testes terão início em a definir.

## Data de Conclusão dos Testes:

A previsão de conclusão dos testes é a definir.


