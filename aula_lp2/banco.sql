create database aula_lp2;

use aula_lp2;

CREATE TABLE pessoa (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255),
    cpf VARCHAR(14),
    data_nascimento DATE,
    telefone VARCHAR(20)
);

CREATE TABLE propriedade (
     id INT AUTO_INCREMENT PRIMARY KEY,
     descricao VARCHAR(255),
     valor DECIMAL(10,2),
     id_pessoa INT,
     FOREIGN KEY (id_pessoa) REFERENCES pessoa(id)
);