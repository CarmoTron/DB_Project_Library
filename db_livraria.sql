create schema db_livraria;
USE db_livraria;

CREATE TABLE IF NOT EXISTS tb_livros(
	id_livro INT PRIMARY KEY AUTO_INCREMENT,
    disponibilidade TINYINT NOT NULL,
    autor VARCHAR(20) NOT NULL,
    titulo VARCHAR(40) NOT NULL,
    preco FLOAT NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_cliente(
	id_cliente INT PRIMARY KEY AUTO_INCREMENT,
    email VARCHAR(40) NOT NULL,
    endereco VARCHAR(40),
    nome VARCHAR(45) NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_transportadora(
	id_transportadora INT PRIMARY KEY AUTO_INCREMENT,
    data_de_entrega DATETIME NOT NULL,
    nome_transportadora VARCHAR(30) NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_fornecedor(
	id_fornecedor INT PRIMARY KEY AUTO_INCREMENT,
    loc_armazem VARCHAR(45) NOT NULL,
    nome_fornecedor VARCHAR(30) NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_autor(
	id_autor INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(45) NOT NULL,
    nacionalidade VARCHAR(30) NOT NULL,
    obras_publicadas VARCHAR(200)
);

CREATE TABLE IF NOT EXISTS tb_livraria(
	id_livraria INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(30) NOT NULL,
    loja_fisica BOOLEAN NOT NULL,
    site BOOLEAN NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_categoria(
	id_categoria INT PRIMARY KEY AUTO_INCREMENT,
    descricao VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_encomenda(
	id_encomenda INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT NOT NULL,
    CONSTRAINT fk_id_cliente
    FOREIGN KEY (id_cliente)
    REFERENCES tb_cliente(id_cliente),
    status_enc 	ENUM("A Caminho", "Em Preparação", "Preparada", "Enviada", "Devolução", "A Aguardar Pagamento") NOT NULL,
    data_do_pedido DATETIME NOT NULL,
    valor_total FLOAT NOT NULL,
    estimativa_entrega DATETIME NOT NULL,
    data_da_entrega DATETIME
);

CREATE TABLE IF NOT EXISTS tb_realizar(
	id_realiza INT PRIMARY KEY AUTO_INCREMENT,
    id_encomenda INT NOT NULL,
    id_transportadora INT NOT NULL,
    CONSTRAINT fk_realizar_id_encomenda
    FOREIGN KEY (id_encomenda)
    REFERENCES tb_encomenda(id_encomenda),
    CONSTRAINT fk_realizar_id_transportadora
    FOREIGN KEY (id_transportadora)
    REFERENCES tb_transportadora(id_transportadora)
);

CREATE TABLE IF NOT EXISTS tb_conter(
	id_conter INT PRIMARY KEY AUTO_INCREMENT,
    id_livro INT NOT NULL,
    id_encomenda INT NOT NULL,
    CONSTRAINT fk_conter_id_livro
    FOREIGN KEY (id_livro)
    REFERENCES tb_livros (id_livro),
    CONSTRAINT fk_conter_id_encomenda
    FOREIGN KEY (id_encomenda)
    REFERENCES tb_encomenda(id_encomenda)
);

CREATE TABLE IF NOT EXISTS tb_fornece(
	id_fornece INT PRIMARY KEY AUTO_INCREMENT,
    id_livro INT NOT NULL,
    id_fornecedor INT NOT NULL,
	CONSTRAINT fk_fornece_id_livro
    FOREIGN KEY (id_livro)
    REFERENCES tb_livros (id_livro),
    CONSTRAINT fk_fornece_id_fornecedor
    FOREIGN KEY (id_fornecedor)
    REFERENCES tb_fornecedor(id_fornecedor)
);

CREATE TABLE IF NOT EXISTS tb_escrever(
	id_escrever INT PRIMARY KEY AUTO_INCREMENT,
    id_livro INT NOT NULL,
    id_autor INT NOT NULL,
	CONSTRAINT fk_escrever_id_livro
    FOREIGN KEY (id_livro)
    REFERENCES tb_livros (id_livro),
    CONSTRAINT fk_escrever_id_autor
    FOREIGN KEY (id_autor)
    REFERENCES tb_autor(id_autor)
);

CREATE TABLE IF NOT EXISTS tb_contem(
	id_contem INT PRIMARY KEY AUTO_INCREMENT,
    id_livro INT NOT NULL,
    id_categoria INT NOT NULL,
	CONSTRAINT fk_contem_id_livro
    FOREIGN KEY (id_livro)
    REFERENCES tb_livros (id_livro),
    CONSTRAINT fk_contem_id_categoria
    FOREIGN KEY (id_categoria)
    REFERENCES tb_categoria(id_categoria)
);

CREATE TABLE IF NOT EXISTS tb_areas(
	id_areas INT PRIMARY KEY AUTO_INCREMENT,
    id_livraria INT NOT NULL,
    id_categoria INT NOT NULL,
    CONSTRAINT fk_areas_id_livraria
    FOREIGN KEY (id_livraria)
    REFERENCES tb_livraria(id_livraria),
	CONSTRAINT fk_areas_id_categoria
    FOREIGN KEY (id_categoria)
    REFERENCES tb_categoria(id_categoria)
);

INSERT INTO tb_livros (disponibilidade, autor, titulo, preco) VALUES
(1, 'Jose Saramago', 'Harry Potter e a Pedra Filosofal', 30.00),
(1, 'Machado de Assis', 'Dom Casmurro', 35.00),
(1, 'Gabriel García', 'O Alquimista', 25.00),
(1, 'Isabel Allende', 'The House of the Spirits', 28.00),
(1, 'Fernando Pessoa', 'The Shining', 20.00),
(1, 'Isabel Allende', 'The Adventures ', 15.00),
(1, 'Julio Sabita', 'Aventura na Sala', 20.00),
(1, 'Julio Sabita', 'Aventura no Cencal', 15.00),
(1, 'Julio Sabita', 'Aventura no Poco mau', 10.00),
(1, 'Julio Sabita', 'Aventura De papo po ar', 25.00);

INSERT INTO tb_cliente (email, endereco, nome) VALUES 
('johndoe@gmail.com', '123 Main St', 'John Doe'),
('janedoe@gmail.com', '456 Elm St', 'Jane Doe'),
('jamiejohnson@gmail.com', '789 Pine St', 'Jamie Johnson'),
('marksmith@gmail.com', '1111 Maple St', 'Mark Smith'),
('gracelee@gmail.com', '2222 Willow St', 'Grace Lee'),
('davidbrown@gmail.com', '3333 Oak St', 'David Brown'),
('helenanderson@gmail.com', '5555 Cedar St', 'Helen Anderson'),
('carlgarcia@gmail.com', '6666 Walnut St', 'Carl Garcia'),
('alexhernandez@gmail.com', '7777 Redwood St', 'Alex Hernandez'),
('rachelcastro@gmail.com', '8888 Juniper St', 'Rachel Castro');

INSERT INTO tb_fornecedor(loc_armazem, nome_fornecedor) VALUES
('Lisboa', 'Antônio Silva'),
('Porto', 'Beatriz Costa'),
('Braga', 'Carlos Oliveira'),
('Faro', 'Daniela Santos'),
('Coimbra', 'Eduardo Pereira'),
('Aveiro', 'Fernanda Martins'),
('Évora', 'Gustavo Almeida'),
('Viseu', 'Helena Ribeiro'),
('Guarda', 'Igor Fernandes'),
('Funchal', 'Júlia Lima');

INSERT INTO tb_transportadora(data_de_entrega, nome_transportadora) VALUES
('2023-11-23 12:00:00', 'CTT Expresso'),
('2023-11-24 14:30:00', 'DHL Portugal'),
('2023-11-25 10:45:00', 'MRW Portugal'),
('2023-11-26 08:15:00', 'SEUR Portugal'),
('2023-11-27 16:00:00', 'TNT Express'),
('2023-11-28 11:30:00', 'Chronopost Portugal'),
('2023-11-29 09:00:00', 'UPS Portugal'),
('2023-11-30 13:45:00', 'FedEx Portugal'),
('2023-12-01 15:20:00', 'Transfervip'),
('2023-12-02 07:30:00', 'Rangel Express');

INSERT INTO tb_livraria(nome, loja_fisica, site) VALUES
('Livraria Ler Bem', TRUE, TRUE),
('Livraria Cultural', TRUE, TRUE),
('Livraria do Saber', TRUE, FALSE),
('Livraria Encanto', TRUE, TRUE),
('Livraria Virtual', FALSE, TRUE),
('Livraria das Letras', TRUE, FALSE),
('Livraria Online', FALSE, TRUE),
('Livraria Moderna', TRUE, TRUE),
('Livraria do Conhecimento', FALSE, FALSE),
('Livraria Sapiência', TRUE, TRUE);


INSERT INTO tb_autor(nome, nacionalidade, obras_publicadas) VALUES
('José Saramago', 'Portuguese', 'Harry Potter e a Pedra Filosofal'),
('Machado de Assis', 'Brazilian', 'Dom Casmurro, Memórias Póstumas de Brás Cubas'),
('Isabel Allende', 'Brazilian', 'The House of the Spirits, Eva Luna'),
('Gabriel García Márquez', 'Colombian', 'O Alquimista'),
('Fernando Pessoa', 'Portuguese', 'The Shining'),
('Isabel Allende', 'Brazilian', 'The Adventures of Huckleberry Finn'),
('Julio Sabita', 'Portuguese', 'Aventura no Cencal'),
('Julio Sabita', 'Portuguese', 'Aventura na Sala'),
('Julio Sabita', 'Portuguese', 'Aventura no Poço mau'),
('Julio Sabita', 'Portuguese', 'Aventura De papo po ar');

INSERT INTO tb_categoria(descricao) VALUES
('Ficção Científica'),
('Romance Histórico'),
('Fantasia'),
('Poesia'),
('Biografia'),
('Mistério'),
('Autoajuda'),
('História'),
('Drama'),
('Aventura');


INSERT INTO tb_encomenda (id_encomenda,id_cliente, status_enc, data_do_pedido, valor_total, estimativa_entrega, data_da_entrega) VALUES 
(1, 1, 'Em Preparação', '2023-11-23 14:30:00', 150.50, '2023-11-25 10:00:00', '2023-11-25 16:45:00'),
(2, 2, 'A Caminho', '2023-11-24 12:45:00', 80.00, '2023-11-26 14:00:00', '2023-11-27 09:30:00'),
(3, 3, 'A Aguardar Pagamento', '2023-11-25 09:15:00', 200.75, '2023-11-28 11:30:00', NULL),
(4, 4, 'Preparada', '2023-11-26 08:00:00', 120.00, '2023-11-29 09:45:00', '2023-11-29 14:20:00'),
(5, 5, 'Enviada', '2023-11-27 15:30:00', 90.25, '2023-11-30 13:15:00', '2023-12-01 11:10:00'),
(6, 6, 'A Caminho', '2023-11-28 11:00:00', 180.50, '2023-12-01 14:30:00', '2023-12-02 08:45:00'),
(7, 7, 'Em Preparação', '2023-11-29 09:45:00', 250.00, '2023-12-02 08:15:00', NULL),
(8, 8, 'Devolução', '2023-11-30 13:00:00', 75.80, '2023-12-03 10:30:00', '2023-12-03 15:00:00'),
(9, 9, 'A Aguardar Pagamento', '2023-12-01 15:00:00', 160.20, '2023-12-04 12:00:00', NULL),
(10, 10, 'Preparada', '2023-12-02 07:30:00', 110.75, '2023-12-05 09:45:00', '2023-12-06 13:20:00');

INSERT INTO tb_conter (id_livro, id_encomenda) VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 2),
(5, 3),
(6, 3),
(7, 4),
(8, 4),
(9, 5),
(10, 5);


INSERT INTO tb_realizar (id_encomenda, id_transportadora) VALUES
(3, 8),
(7, 1),
(1, 5),
(9, 2),
(5, 6),
(2, 10),
(6, 4),
(10, 3),
(4, 9),
(8, 7);

INSERT INTO tb_fornece (id_livro, id_fornecedor) VALUES
(3, 8),
(7, 1),
(1, 5),
(9, 2),
(5, 6),
(2, 10),
(6, 4),
(10, 3),
(4, 9),
(8, 7);

INSERT INTO tb_escrever (id_livro, id_autor) VALUES
(3, 8),
(7, 8),
(1, 8),
(9, 2),
(5, 6),
(2, 10),
(6, 4),
(10, 3),
(4, 9),
(8, 7);

INSERT INTO tb_contem (id_livro, id_categoria) VALUES
(3, 8),
(7, 1),
(1, 5),
(7, 2),
(7, 6),
(2, 10),
(6, 4),
(10, 3),
(4, 9),
(8, 7);

INSERT INTO tb_areas (id_livraria, id_categoria) VALUES
(3, 8),
(7, 1),
(7, 5),
(9, 2),
(5, 6),
(7, 10),
(7, 4),
(10, 3),
(4, 9),
(8, 7);

SELECT count(nome) "Obras Publicadas" FROM tb_autor WHERE nome = "José Saramago";

-- INDEX COM CONSULTAS
-- qual a categoria com mais livros

SELECT descricao FROM tb_contem as c, tb_livros as L, tb_categoria as CAT 
WHERE ( C.id_livro = L.id_livro ) AND ( C.id_categoria = CAT.id_categoria=1 ) ;

-- 1-Quais o livro de uma determinada area?
CREATE INDEX idx_livros ON tb_livros (id_livro);
CREATE INDEX idx_contem ON tb_contem (id_categoria);
CREATE INDEX idx_categoria ON tb_categoria (descricao);

explain
SELECT titulo Título, C.id_categoria Categoria, descricao Descrição
FROM tb_livros as L 
JOIN tb_contem AS C
ON L.id_livro = C.id_livro 
JOIN tb_categoria as CAT
ON C.id_categoria = CAT.id_categoria
WHERE CAT.descricao = 'História';


show status like 'last_query_cost';

-- cost initial = 1.049 e sem alteracoes
-- row's iniciais 10 ,1 ,1
-- row's finais 1, 1, 1

-- 2-Quantos livros foram encomendadas de uma determinada categoria?

CREATE INDEX idx_categoria ON tb_conter (id_livro);
CREATE INDEX idx_categoria1 ON tb_contem (id_categoria);
CREATE INDEX idx_categoria2 ON tb_categoria (descricao);

explain
SELECT count(*) as livros_encomendados_fantasia
FROM tb_conter 
WHERE id_livro= ANY (SELECT id_livro
FROM tb_contem AS c JOIN tb_categoria AS cat
ON c.id_categoria=cat.id_categoria
WHERE cat.descricao='Fantasia');

-- melhoramento

SELECT count(*) livros_encomendados_fantasia
FROM tb_conter as c INNER JOIN tb_livros as l
ON c.id_livro = l.id_livro INNER JOIN tb_contem as Co
ON l.id_livro = Co.id_livro INNER JOIN tb_categoria as cat
ON co.id_categoria = cat.id_categoria
WHERE cat.descricao='Fantasia';


show status like 'last_query_cost';
-- cost inicial = 3.149
-- cost def = 2.249
-- cost final = 1.399

-- 3-Qual o livro mais caro de cada categoria?
CREATE INDEX idx_tb_livros on tb_livros(preco);

explain 
SELECT preco, titulo
FROM tb_livros
ORDER BY preco desc limit 1;

show status like 'last_query_cost';

-- 4 - Qual o mes do ano em que se venderam mais livros --
explain
SELECT MONTH(data_do_pedido) AS Mes, COUNT(*) AS 'Total de livros vendidos'
FROM tb_encomenda as e
JOIN tb_conter c ON e.id_encomenda = c.id_encomenda
GROUP BY Mes
ORDER BY 'Total de livros vendidos' DESC
LIMIT 1;

-- cost inicial -> 4.749000 --

CREATE INDEX idx_tb_encomenda ON tb_encomenda (id_encomenda);
CREATE INDEX idx_tb_conter ON tb_conter (id_encomenda);


DROP INDEX idx_tb_conter ON tb_conter;

show status like 'last_query_cost';

-- 5-Nome dos autores que escreveram um livro encomendados por cliente x?
CREATE INDEX idx_tb_autor ON tb_cliente (nome);
drop index idx_tb_autor on tb_cliente;



select a.nome Autor, c.nome Nome, l.titulo Livro, e.data_do_pedido 'Data do pedido'
from tb_cliente c
join tb_encomenda as e on c.id_cliente = e.id_cliente
join tb_conter as co on e.id_encomenda = co.id_encomenda
join tb_livros as l on co.id_livro = l.id_livro
join tb_escrever as es on l.id_livro = es.id_livro
join tb_autor as a on es.id_autor = a.id_autor
where c.nome = 'John Doe';

-- cost 

show status like 'last_query_cost';

-- -- -- -- -- -- -- --- --------------------------------------------------------------

-- INDEX COM CONSULTAS
-- qual a categoria com mais livros

SELECT descricao FROM tb_contem as c, tb_livros as L, tb_categoria as CAT 
WHERE ( C.id_livro = L.id_livro ) AND ( C.id_categoria = CAT.id_categoria ) ;

-- 1-Quais o livro de uma determinada area?
CREATE INDEX idx_livros ON tb_livros (id_livro);
CREATE INDEX idx_contem ON tb_contem (id_categoria);
CREATE INDEX idx_categoria ON tb_categoria (descricao);

explain
SELECT titulo Título, C.id_categoria Categoria, descricao Descrição
FROM tb_livros as L 
JOIN tb_contem AS C
ON L.id_livro = C.id_livro 
JOIN tb_categoria as CAT
ON C.id_categoria = CAT.id_categoria
WHERE CAT.descricao = 'História';


show status like 'last_query_cost';

-- cost initial = 1.049 e sem alteracoes
-- row's iniciais 10 ,1 ,1
-- row's finais 1, 1, 1

 
-- -- -- -- -- tb_cliente
--          --
-- VISTAS -- -
--          --
-- -- -- -- --

-- Quantos livros existem?
drop view v_qts_livros;

CREATE VIEW v_qts_livros as
SELECT count(id_livro) as 'Total de Livros'
FROM tb_livros;

SELECT *
FROM v_qts_livros;

-- -- -- -- -- 
--  FUNCAO  --
-- -- -- -- --
DROP FUNCTION fc_vend_para;

CREATE FUNCTION fc_vend_para(id int)
RETURNS VARCHAR (100)
DETERMINISTIC
RETURN (select concat('O ',nome,' comprou ', count(l.id_livro),' livros')
	FROM tb_livros as l 
    JOIN tb_conter as c ON l.id_livro = c.id_livro 
    JOIN tb_encomenda as e ON e.id_encomenda = c.id_encomenda 
    JOIN tb_cliente as cli ON cli.id_cliente = e.id_cliente
	WHERE cli.id_cliente = id
    GROUP BY cli.nome);
    
select fc_vend_para(3) as 'Quantos livros este cliente comprou?';

-- -----------
-- PROCEDURE -
-- -----------

DROP PROCEDURE pc_disponibilidade;

DELIMITER //
CREATE PROCEDURE pc_disponibilidade(v_titulo int)
BEGIN
	UPDATE tb_livros
    SET disponibilidade = 0
    WHERE id_livro  = v_titulo;
END //
DELIMITER ;

call  pc_disponibilidade(2);

-- Inserts adicionais de clientes com nomes portugueses
INSERT INTO tb_cliente (email, endereco, nome) VALUES 
('mariasilva@gmail.com', 'Rua das Flores, 123', 'Maria Silva'),
('joaopedro@gmail.com', 'Avenida Central, 456', 'João Pedro'),
('anacarvalho@gmail.com', 'Travessa dos Amores, 789', 'Ana Carvalho'),
('ricardosantos@gmail.com', 'Praça da Liberdade, 1011', 'Ricardo Santos'),
('carlaferreira@gmail.com', 'Largo do Rossio, 1213', 'Carla Ferreira');

-- Inserts adicionais de encomendas
INSERT INTO tb_encomenda (id_encomenda, id_cliente, status_enc, data_do_pedido, valor_total, estimativa_entrega, data_da_entrega) VALUES 
(11, 11, 'Em Preparação', '2023-12-03 10:00:00', 75.00, '2023-12-06 11:30:00', NULL),
(12, 12, 'A Caminho', '2023-12-04 14:30:00', 90.00, '2023-12-07 13:00:00', '2023-12-08 09:45:00'),
(13, 13, 'A Aguardar Pagamento', '2023-12-05 09:00:00', 120.00, '2023-12-08 14:45:00', NULL),
(14, 14, 'Preparada', '2023-12-06 11:45:00', 110.00, '2023-12-09 12:30:00', '2023-12-10 10:15:00'),
(15, 15, 'Enviada', '2023-12-07 15:15:00', 150.00, '2023-12-10 10:00:00', '2023-12-11 08:30:00');

-- Inserts adicionais de livros encomendados
INSERT INTO tb_conter (id_livro, id_encomenda) VALUES
(4, 11),
(8, 11),
(9, 12),
(3, 12),
(5, 13),
(6, 13),
(1, 14),
(10, 14),
(7, 15),
(2, 15);

SELECT 
    c.nome AS 'Cliente', 
    l.titulo AS 'Livro', 
    GROUP_CONCAT(a.nome SEPARATOR ', ') AS 'Autores',
    e.estimativa_entrega AS 'Data Estimada de Entrega'
    
FROM 
    tb_livros AS l
JOIN 
    tb_conter AS co ON l.id_livro = co.id_livro
JOIN 
    tb_encomenda AS e ON co.id_encomenda = e.id_encomenda
JOIN 
    tb_cliente AS c ON e.id_cliente = c.id_cliente
JOIN 
    tb_escrever AS es ON l.id_livro = es.id_livro
JOIN 
    tb_autor AS a ON es.id_autor = a.id_autor
GROUP BY 
    l.id_livro,e.estimativa_entrega, c.nome;


SELECT 
    l.titulo AS 'Livro', 
    c.nome AS 'Cliente', 
    GROUP_CONCAT(a.nome SEPARATOR ', ') AS 'Autores'
FROM 
    tb_livros AS l
JOIN 
    tb_conter AS co ON l.id_livro = co.id_livro
JOIN 
    tb_encomenda AS e ON co.id_encomenda = e.id_encomenda
JOIN 
    tb_cliente AS c ON e.id_cliente = c.id_cliente
JOIN 
    tb_escrever AS es ON l.id_livro = es.id_livro
JOIN 
    tb_autor AS a ON es.id_autor = a.id_autor
GROUP BY 
    l.id_livro, c.nome;
