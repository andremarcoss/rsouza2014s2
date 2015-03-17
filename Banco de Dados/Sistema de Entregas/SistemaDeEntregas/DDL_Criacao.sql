--@author Rafael Alves de Sousa
--date 20/11/2014
--@contact rafaelalvesdesousa1992@gmail.com

--Criando o banco de dados
CREATE DATABASE SistemaDeEntregas;
GO
USE SistemaDeEntregas;
GO
-------Tabela Transportadoras-------
CREATE TABLE Transportadora(
	tpsCnpj CHAR(14) NOT NULL UNIQUE,
	tpsEndereco VARCHAR(200) NOT NULL,
	tpsCidade VARCHAR(50) NOT NULL,
	tpsCep CHAR(8) NOT NULL,
	tpsBairro VARCHAR(20) NOT NULL,
	tpsChaveAcesso VARCHAR(50) NOT NULL UNIQUE DEFAULT(NEWID()),
	tpsAtivo BIT NOT NULL DEFAULT(1)
);
GO
-------Tabela Motoristas-------
CREATE TABLE Motorista(
	mtCpf CHAR(14) NOT NULL,
	mtSenha VARCHAR(20) NOT NULL,
	mtNome VARCHAR(200)
)
-------Tabela Motivos-------
CREATE TABLE Motivo(
	mtvId INT NOT NULL IDENTITY,
	mtvDescricao VARCHAR(200) NOT NULL UNIQUE
)
-------Tabela Parentescos-------
CREATE TABLE Parentesco(
	prcId INT NOT NULL IDENTITY,
	prcDescricaoParentesco VARCHAR(100) NOT NULL UNIQUE
)
-------Tabela Remessas-------
CREATE TABLE Remessa(
	rmsIdentificador VARCHAR(50) NOT NULL DEFAULT(''),
	rmsTotalVolumes INT NOT NULL,
	rmsNotaFiscal VARCHAR(20) NOT NULL,
	rmsTransportadora CHAR(14) NOT NULL,
	rmsMotorista CHAR(14) NOT NULL,
	rmsPedido VARCHAR(20) NOT NULL DEFAULT(''),
	rmsRomaneio	VARCHAR(20) NOT NULL DEFAULT(''),
	rmsEnderecoEntrega VARCHAR (500) NOT NULL,
	rmsCepEntrega CHAR(8) NOT NULL,
	rmsCidadeEntrega VARCHAR(50) NOT NULL,
	rmsUFEntrega CHAR(2) NOT NULL,
	rmsObservacaoEnderecoEntrega VARCHAR(100),
	rmsDestinatarioEntrega VARCHAR(100) NOT NULL,
	rmsMotivo INT,
	rmsParentescoRecebedor INT,
	rmsDataBaixa DATETIME,
	rmsObservacaoEntrega VARCHAR(200),
	rmsDataIntegracao DATETIME NOT NULL DEFAULT(GETDATE()),
	rmsChave VARCHAR(50) NOT NULL DEFAULT(NEWID()),
	rmsIntegrado BIT NOT NULL DEFAULT(0)
)
-------Criação de Chaves Primárias-------
ALTER TABLE Remessa ADD CONSTRAINT PK_Remessa PRIMARY KEY (rmsTransportadora,rmsMotorista,rmsNotafiscal,rmsIdentificador,rmsRomaneio,rmsPedido);
GO
ALTER TABLE Transportadora ADD CONSTRAINT PK_Transportadora_CNPJ PRIMARY KEY (tpsCnpj);
GO
ALTER TABLE Motorista ADD CONSTRAINT PK_Motorista_CPF PRIMARY KEY (mtCpf);
GO
ALTER TABLE Motivo ADD CONSTRAINT PK_Motivo PRIMARY KEY (mtvId);
GO
ALTER TABLE Parentesco ADD CONSTRAINT PK_Parentesco_PRCID PRIMARY KEY (prcId);
GO
-------Criação de Indíces-------
CREATE INDEX IDX_Remessas_rmsTransportadora ON Remessa (rmsTransportadora ASC);
GO
CREATE INDEX IDX_Remessas_rmsNotaFiscal ON Remessa (rmsNotaFiscal ASC);
GO
CREATE INDEX IDX_Remessas_rmsDataIntegracao ON Remessa (rmsDataIntegracao ASC);
GO
-------Criação de Chaves Estrangeiras-------
ALTER TABLE Remessa ADD CONSTRAINT FK_RemessasMotorista FOREIGN KEY (rmsMotorista)
REFERENCES Motorista;
GO
ALTER TABLE Remessa ADD CONSTRAINT FK_RemessasTransportadora FOREIGN KEY (rmsTransportadora)
REFERENCES Transportadora;
GO
ALTER TABLE Remessa ADD CONSTRAINT FK_RemessasMotivo FOREIGN KEY (rmsMotivo)
REFERENCES Motivo;
GO
ALTER TABLE Remessa ADD CONSTRAINT FK_RemessasParentesco FOREIGN KEY (rmsParentescoRecebedor)
REFERENCES Parentesco;
GO

--Criando o usuário padrão dos sistemas
--CREATE LOGIN [sistemadeentrega] WITH PASSWORD=N'sistemadeentrega', 
--DEFAULT_DATABASE=[SistemaDeEntregas], DEFAULT_LANGUAGE=[Português (Brasil)], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
--GO

--Deletando banco existente
--DROP DATABASE SistemaDeEntregas;
--GO
