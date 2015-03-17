--@author Rafael Alves de Sousa
--date 20/11/2014
--@contact rafaelalvesdesousa1992@gmail.com

USE SistemaDeEntregas;
GO

INSERT INTO Transportadora(tpsCnpj, tpsEndereco, tpsCidade, tpsBairro, tpsCep, tpsChaveAcesso)
VALUES ('09876543211234','RUA FICTICIA, 1234','CIDADE FICTICIA', 'BAIRRO FICTICIO','09876111','46688C0A-FF3F-4AAA-99DF-0AC966A81723');
GO

INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('PROPRIO'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('PAI'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('MÃE'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('FILHOS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('IRMÃOS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('AVÓS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('TIOS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('SOBRINHOS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('BISAVÓS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('PRIMOS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('TRISAVÓS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('SOGROS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('GENRO'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('NORA'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('CUNHADOS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('PADRASTO'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('MADRASTA'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('ENTEADOS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('PORTEIRO'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('VIZINHOS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('OUTROS'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('ESPOSO'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('FUNCIONARIO'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('SECRETARIO'));
INSERT INTO Parentesco(prcDescricaoParentesco) VALUES(UPPER('ZELADOR'));


INSERT INTO Motivo(mtvDescricao) VALUES(UPPER('ENTREGUE'));
INSERT INTO Motivo(mtvDescricao) VALUES(UPPER('AUSENTE'));
INSERT INTO Motivo(mtvDescricao) VALUES(UPPER('RECUSADO'));
INSERT INTO Motivo(mtvDescricao) VALUES(UPPER('DESCONHECIDO'));
INSERT INTO Motivo(mtvDescricao) VALUES(UPPER('END. NÃO LOCALIZADO'));
INSERT INTO Motivo(mtvDescricao) VALUES(UPPER('NÃO VISITADO'));
INSERT INTO Motivo(mtvDescricao) VALUES(UPPER('OUTROS'));