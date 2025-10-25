CREATE DATABASE fichasdb;
USE fichasdb;

CREATE TABLE usuarios(
  Id INT PRIMARY KEY AUTO_INCREMENT,
  Nome VARCHAR(100) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  Senha VARCHAR(8) NOT NULL
);

CREATE TABLE fichas(
  Id INT PRIMARY KEY AUTO_INCREMENT,
  Nome VARCHAR(100) NOT NULL,
  Idade INT,
  Origem VARCHAR(100),
  Classe VARCHAR(100),
  Forca INT,
  Agilidade INT,
  Inteligencia INT,
  Defesa INT,
  Energia INT,
  Habilidades TEXT,
  Curiosidades TEXT
);