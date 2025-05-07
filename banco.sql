create database AppMulta;

use AppMulta;

CREATE TABLE veiculo (
    id INT AUTO_INCREMENT PRIMARY KEY,
    modelo VARCHAR(255),
    marca VARCHAR(255),
    placa VARCHAR(10)
);

CREATE TABLE multa (
    id INT AUTO_INCREMENT PRIMARY KEY,
    descricao VARCHAR(255),
    valor_multa DECIMAL(10,2),
    id_veiculo INT,
    FOREIGN KEY (id_veiculo) REFERENCES veiculo(id)
);