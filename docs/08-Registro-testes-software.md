# Registro de testes de software

<span style="color:red">Pré-requisitos: <a href="04-Projeto-interface.md"> Projeto de interface</a></span>, <a href="07-Plano-testes-software.md"> Plano de testes de software</a>

Relatório com as evidências dos testes de software realizados no sistema pela equipe, baseado em um plano de testes pré-definido.

Para cada caso de teste definido no <a href="07-Plano-testes-software.md"> Plano de testes de software</a>, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos. Observação: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso.

---

### CT-001 – Cadastrar com e-mail institucional

**Requisito associado:**  
RF-001 - Permitir que o usuário se cadastre utilizando o e-mail da instituição

**Objetivo do teste:**  
Verificar se o usuário consegue se cadastrar apenas com o e-mail institucional na aplicação.

**Passos:**  
1. Acessar o navegador.  
2. Informar o endereço do site.  
3. Clicar em "Cadastrar".  
4. Preencher os campos obrigatórios (e-mail institucio, nome, senha, confirmação de senha).  
6. Clicar em "Registrar".

**Critério de êxito:**  
- O cadastro foi realizado com sucesso.

**Responsável pela elaboração do caso de teste:**  
Gabriel Henrique Duarte Ferraz

---


| **Caso de teste** 	| **CT-001 – Cadastrar perfil** 	|
|:---:	|:---:	|
| Requisito associado | RF-001 e RF-006 – O sistema deve permitir o cadastro de usuários com e-mail institucional e Permitir que o usuário se cadastre e crie um perfil com informações pessoais, como nome e curso |
| Registro de evidência | [Cadastro com e-mail institucional](https://drive.google.com/file/d/1HChgtZf946lYNTDFenb--wc4_kl_9_Mv/view?usp=drive_link)) |

| **Caso de teste** 	| **CT-002 – Login de Usuário** 	|
|:---:	|:---:	|
| Requisito associado |  	RF-001 – O sistema deve permitir que o usuário realize login utilizando e-mail institucional e senha. |
| Registro de evidência | [Login e Logout](https://drive.google.com/file/d/19I5pYaZx5UYz08xf946j7RMqPkE5BMOO/view?usp=drive_link) |

| **Caso de teste** 	| **CT-003 – Cadastrar Nova Viagem (Motorista** 	|
|:---:	|:---:	|
| Requisito associado | RF-003 – Permitir que o motorista cadastre uma viagem com informações de origem, destino e número de assentos. |
| Registro de evidência | [Cadastrar de carona (Motorista)](https://drive.google.com/file/d/13qh-m5p1XNyvNKyvh6JRfYJTlGH14AGq/view?usp=drive_link) |

| **Caso de teste** 	| **CT-004 – Buscar Caronas Disponíveis (Passageiro)** 	|
|:---:	|:---:	|
| Requisito associado | RF-004 – O sistema deve permitir que o usuário pesquise caronas disponíveis por origem ou destino. |
| Registro de evidência | [Caronas Disponiveis](https://drive.google.com/file/d/13qh-m5p1XNyvNKyvh6JRfYJTlGH14AGq/view?usp=drive_link)) |

| **Caso de teste** 	| **CT-005 – Confirmar Participação em uma Carona** 	|
|:---:	|:---:	|
| Requisito associado | RF-008 – O sistema deve permitir que o passageiro confirme sua presença em uma carona. |
| Registro de evidência | [Confirmar presença](https://drive.google.com/file/d/1TbzC-HMvOK8b3a4rS1stNKb0a1njbats/view?usp=drive_link) |

| **Caso de teste** 	| **CT-006 – Cancelar Carona (Passageiro)** 	|
|:---:	|:---:	|
| Requisito associado | RF-002 – Permitir que o passageiro cancele sua carona antes do início da viagem. |
| Registro de evidência | [Cancelar carona (Passageiro)](https://drive.google.com/file/d/1uaYFDaQeeR2KfdZfwFQf4Bap17Azenf5/view?usp=drive_link) |

| **Caso de teste** 	| **CT-007 – Visualizar Mapa na Busca de Caronas** 	|
|:---:	|:---:	|
| Requisito associado | RF-004 + RNF-001 – O sistema deve exibir o mapa de trajetos na consulta de caronas e ser responsivo. |
| Registro de evidência | [Visualizar Mapa](https://drive.google.com/file/d/1LHuFk5YfPahPjR9wIzhuwg0yVBNtCnpx/view?usp=drive_link) |

| **Caso de teste** 	| **CT-008 – Avaliar Motorista** 	|
|:---:	|:---:	|
| Requisito associado | RF-008 – O sistema deve permitir que passageiros avaliem motoristas após uma viagem. |
| Registro de evidência | [Avaliação do Motorista](https://drive.google.com/file/d/1VWdGGcxS8R0grZcTVITrCJVFcXlR7yWK/view?usp=drive_link) |

| **Caso de teste** 	| **CT-09 – Chat entre Motorista e Passageiro** 	|
|:---:	|:---:	|
| Requisito associado | RF-005 – O sistema deve permitir que usuários (motoristas e passageiros) enviem mensagens sobre a viagem. |
| Registro de evidência | [Chat](https://drive.google.com/file/d/1JMn3hMVZ-oFhBsFZ55ax0CIJv9WIO_UA/view?usp=drive_link) |

| **Caso de teste** 	| **CT-010 – Cancelamento de Viagem pelo Motorista** 	|
|:---:	|:---:	|
| Requisito associado | RF-002 – Permitir que o motorista cancele a viagem antes do início da carona. |
| Registro de evidência | [Cancelar Viagem(Motorista)](https://drive.google.com/file/d/1fhZfqHKCFnHU9_h-vGALmGbPAYyphhKF/view?usp=drive_link) |

| **Caso de teste** 	| **CT-011 – Excluir Passageiro da Carona** 	|
|:---:	|:---:	|
| Requisito associado | RF-002 – Permitir que o motorista remova um passageiro de uma carona antes do início da viagem. |
| Registro de evidência | [Excluir Passageiro](https://drive.google.com/file/d/1BNKLlsfNjN-tyQMXG88-GZFOiiAlRoIC/view?usp=drive_link) |

| **Caso de teste** 	| **CT-012 – Acessar Página Sobre Nós** 	|
|:---:	|:---:	|
| Requisito associado | RF-00X – O sistema deve disponibilizar uma página institucional com informações sobre o projeto. |
| Registro de evidência | [Página Sobre Nós](https://drive.google.com/file/d/1pQzolp6aSv2YoWl3Fn_khPzj6WoQerRY/view?usp=drive_link) |



> **Links úteis**:
> - [Screencast: entenda o que é e como gravar vídeos com ele](https://rockcontent.com/br/blog/screencast/) 

## Avaliação

Discorra sobre os resultados do teste, ressaltando os pontos fortes e fracos identificados na solução. Comente como o grupo pretende abordar esses pontos nas próximas iterações. Apresente as falhas detectadas e as melhorias geradas a partir dos resultados obtidos nos testes.

> **Links úteis**:
> - [Ferramentas de Teste para JavaScript](https://geekflare.com/javascript-unit-testing/)
