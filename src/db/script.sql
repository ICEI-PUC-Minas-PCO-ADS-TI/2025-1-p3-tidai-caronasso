USE caronasso;

-- Criação da tabela Usuario 
CREATE TABLE IF NOT EXISTS Usuario(
	id INTEGER AUTO_INCREMENT,
    data_cadastro DATE,
    nome VARCHAR(80),
    email VARCHAR(80),
    senha VARCHAR(80),
    endereco VARCHAR(150),
    descricao VARCHAR(250),
    curso VARCHAR(80),
    genero VARCHAR(20),
    disponivel BOOL,
    CONSTRAINT pk_id PRIMARY KEY(id),
    CONSTRAINT genero_valido CHECK (genero IN ("homem", "mulher", "outro")) 
);

-- Criação da tabela Chat 
CREATE TABLE IF NOT EXISTS Chat(
	id INTEGER AUTO_INCREMENT,
    id_usuario1 INTEGER,
    id_usuario2 INTEGER,
    CONSTRAINT PRIMARY KEY(id),
    CONSTRAINT fk_usuario1 FOREIGN KEY(id_usuario1) REFERENCES usuario.id,
    CONSTRAINT fk_usuario2 FOREIGN KEY(id_usuario2) REFERENCES usuario.id
);

-- Criação da tabela Mensagem 
CREATE TABLE IF NOT EXISTS Mensagem(
	id INTEGER AUTO_INCREMENT,
    id_chat INTEGER,
    id_remetente INTEGER,
    conteudo VARCHAR(400),
    horario_envio DATETIME,
    CONSTRAINT PRIMARY KEY(id),
    CONSTRAINT fk_chat FOREIGN KEY(id_chat) REFERENCES chat(id),
    CONSTRAINT fk_remetente FOREIGN KEY(id_remetente) REFERENCES usuario(id)
);

-- Criação da tabela Viagem 
CREATE TABLE IF NOT EXISTS Viagem(
	id INTEGER AUTO_INCREMENT,
	id_motorista INTEGER,
	origem VARCHAR(150),
	destino VARCHAR(150),
	data_partida DATE,
	vagas_disponiveis INTEGER,
	description TEXT,
	CONSTRAINT PRIMARY KEY(id),
	CONSTRAINT fk_motorista FOREIGN KEY(id_motorista) REFERENCES usuario(id)
);

-- Criação da tabela ViagemPassageiro 
CREATE TABLE IF NOT EXISTS ViagemPassageiro(
	id INTEGER AUTO_INCREMENT,
	id_viagem INTEGER,
	id_passageiro INTEGER,
	status VARCHAR(20),
	CONSTRAINT PRIMARY KEY(id),
	CONSTRAINT fk_viagem FOREIGN KEY(id_viagem) REFERENCES viagem(id),
	CONSTRAINT fk_passageiro FOREIGN KEY(id_passageiro) REFERENCES usuario(id)
);