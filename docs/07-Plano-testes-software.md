# Plano de testes de software

|               **Caso de teste**              |                                                                        **CT-001 – Cadastro de Usuário**                                                                       |
| :------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|              Requisito associado             |               RF-001 e RF-006 – O sistema deve permitir o cadastro de usuários com e-mail institucional e permitir criação de perfil com nome, telefone e foto.               |
|               Objetivo do teste              |                                   Verificar se o usuário consegue criar uma conta utilizando o e-mail institucional e completar seu perfil.                                   |
|                    Passos                    | - Acessar o site <br> - Ir para a página de cadastro <br> - Preencher os campos obrigatórios (nome, telefone, e-mail institucional, foto, senha) <br> - Clicar em "Registrar" |
|               Critério de êxito              |                                             - O sistema cria a conta com sucesso e o usuário é redirecionado para a tela de login.                                            |
| Responsável pela elaboração do caso de teste |                                                                          Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                                                         |

|               **Caso de teste**              |                                        **CT-002 – Login de Usuário**                                       |
| :------------------------------------------: | :--------------------------------------------------------------------------------------------------------: |
|              Requisito associado             |    RF-001 – O sistema deve permitir que o usuário realize login utilizando e-mail institucional e senha.   |
|               Objetivo do teste              |                          Verificar se o usuário consegue fazer login na aplicação.                         |
|                    Passos                    | - Acessar o site <br> - Clicar em "Entrar" <br> - Informar e-mail e senha válidos <br> - Clicar em "Login" |
|               Critério de êxito              |                                 - O usuário acessa a sua conta com sucesso.                                |
| Responsável pela elaboração do caso de teste |                                       Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                       |

|               **Caso de teste**              |                                                                 **CT-003 – Cadastrar Nova Viagem (Motorista)**                                                                |
| :------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|              Requisito associado             |                                 RF-003 – Permitir que o motorista cadastre uma viagem com informações de origem, destino e número de assentos.                                |
|               Objetivo do teste              |                                                          Verificar se o motorista consegue cadastrar uma nova viagem.                                                         |
|                    Passos                    | - Fazer login como motorista <br> - Acessar a página de "Cadastrar Viagem" <br> - Preencher os campos: origem, destino, número de assentos, horário <br> - Clicar em "Salvar" |
|               Critério de êxito              |                                                              - Viagem aparece na listagem de caronas disponíveis.                                                             |
| Responsável pela elaboração do caso de teste |                                                                          Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                                                         |

|               **Caso de teste**              |                                      **CT-004 – Buscar Caronas Disponíveis (Passageiro)**                                     |
| :------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------: |
|              Requisito associado             |               RF-004 – O sistema deve permitir que o usuário pesquise caronas disponíveis por origem ou destino.              |
|               Objetivo do teste              |                                Validar se o passageiro consegue pesquisar caronas disponíveis.                                |
|                    Passos                    | - Acessar a página "Consultar Caronas" <br> - Inserir um termo de busca (ex: nome da rua ou bairro) <br> - Clicar em "Buscar" |
|               Critério de êxito              |                                     - Lista de caronas compatíveis com a busca é exibida.                                     |
| Responsável pela elaboração do caso de teste |                                                  Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                                 |

|               **Caso de teste**              |                       **CT-005 – Confirmar Participação em uma Carona**                       |
| :------------------------------------------: | :-------------------------------------------------------------------------------------------: |
|              Requisito associado             |     RF-008 – O sistema deve permitir que o passageiro confirme sua presença em uma carona.    |
|               Objetivo do teste              |               Validar se o passageiro consegue confirmar presença em uma carona.              |
|                    Passos                    | - Buscar por caronas <br> - Localizar uma carona desejada <br> - Clicar em "Confirmar Carona" |
|               Critério de êxito              |           - A carona é confirmada e o passageiro recebe uma mensagem de confirmação.          |
| Responsável pela elaboração do caso de teste |                                  Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                 |

|               **Caso de teste**              |                             **CT-006 – Cancelar Carona (Passageiro)**                             |
| :------------------------------------------: | :-----------------------------------------------------------------------------------------------: |
|              Requisito associado             |          RF-002 – Permitir que o passageiro cancele sua carona antes do início da viagem.         |
|               Objetivo do teste              |                  Testar se o passageiro consegue cancelar sua carona com sucesso.                 |
|                    Passos                    | - Acessar "Minhas Caronas" <br> - Selecionar a carona agendada <br> - Clicar em "Cancelar Carona" |
|               Critério de êxito              |                 - A carona é cancelada e o sistema exibe uma mensagem de sucesso.                 |
| Responsável pela elaboração do caso de teste |                                    Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                   |

|               **Caso de teste**              |                                             **CT-007 – Visualizar Mapa na Busca de Caronas**                                             |
| :------------------------------------------: | :--------------------------------------------------------------------------------------------------------------------------------------: |
|              Requisito associado             |                   RF-004 + RNF-001 – O sistema deve exibir o mapa de trajetos na consulta de caronas e ser responsivo.                   |
|               Objetivo do teste              |                                  Garantir que o mapa é exibido corretamente durante a busca de caronas.                                  |
|                    Passos                    | - Acessar a página "Consultar Caronas" <br> - Realizar uma busca <br> - Verificar o carregamento do mapa com os pontos de origem/destino |
|               Critério de êxito              |                                      - O mapa aparece corretamente com os marcadores de localização.                                     |
| Responsável pela elaboração do caso de teste |                                                       Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                                       |



|               **Caso de teste**              |                                                   **CT-008 – Avaliar Motorista**                                                   |
| :------------------------------------------: | :--------------------------------------------------------------------------------------------------------------------------------: |
|              Requisito associado             |                        RF-008 – O sistema deve permitir que passageiros avaliem motoristas após uma viagem.                        |
|               Objetivo do teste              |                               Validar se o passageiro consegue deixar uma avaliação para o motorista.                              |
|                    Passos                    | - Acessar o histórico de viagens <br> - Escolher uma carona finalizada <br> - Preencher campo de avaliação <br> - Enviar avaliação |
|               Critério de êxito              |                                   - Avaliação salva com sucesso e aparece no perfil do motorista.                                  |
| Responsável pela elaboração do caso de teste |                                                    Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                                    |


|               **Caso de teste**              |                                                                                                                     **CT-09 – Chat entre Motorista e Passageiro**                                                                                                                     |
| :------------------------------------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|              Requisito associado             |                                                                                        RF-005 – O sistema deve permitir que usuários (motoristas e passageiros) enviem mensagens sobre a viagem.                                                                                       |
|               Objetivo do teste              |                                                                                              Verificar se motorista e passageiro conseguem se comunicar antes da viagem via chat interno.                                                                                              |
|                    Passos                    | - Fazer login no sistema <br> - Acessar a lista de caronas disponíveis <br> - Selecionar uma carona desejada <br> - Clicar na opção "Chat com o motorista" ou "Chat com o passageiro" <br> - Escrever uma mensagem de teste <br> - Verificar se a mensagem aparece para o destinatário |
|               Critério de êxito              |                                                                                               - A mensagem é enviada, recebida e exibida corretamente para ambos os usuários envolvidos.                                                                                               |
| Responsável pela elaboração do caso de teste |                                                                                                                              Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                                                                                                              |

|               **Caso de teste**              |                                                                       **CT-012 – Cancelamento de Viagem pelo Motorista**                                                                      |
| :------------------------------------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|              Requisito associado             |                                                         RF-002 – Permitir que o motorista cancele a viagem antes do início da carona.                                                         |
|               Objetivo do teste              |                                                           Garantir que o motorista consiga cancelar uma viagem criada anteriormente.                                                          |
|                    Passos                    | - Fazer login como motorista <br> - Acessar a área "Minhas Viagens" <br> - Selecionar a viagem que deseja cancelar <br> - Clicar em "Cancelar Viagem" <br> - Confirmar a ação de cancelamento |
|               Critério de êxito              |                            - A viagem é removida da lista de caronas disponíveis e os passageiros previamente confirmados recebem uma notificação de cancelamento.                            |
| Responsável pela elaboração do caso de teste |                                                                                  Gabriel Henrique Duarte Ferraz, Phillipi Garcia, Christian Sena Gomes                                                                                 |



Ferramentas Utilizadas:

Navegador Google Chrome

HTML, CSS, JavaScript (Front-End puro)

API OpenStreetMap (para renderização dos mapas)
 
