/*INSERT Tabela GENERO*/

INSERT INTO genero (nome)
VALUES ('Ação'), 
	   ('Drama'), 
       ('Fantasia'), 
       ('Ficção');
 
/*INSERT Tabela CLASSIFICACAO
Livre - exibição em qualquer horário.
10 anos - exibição em qualquer horário.
12 anos - a partir das 20h.
14 anos -a partir das 21h.
16 anos -a partir das 22h.
18 anos -a partir das 23h.
*/       
INSERT INTO classificacao (label,
						   numlabel,
                           observacao)
VALUES ('Livre', 0, 'exibição em qualquer horário.'),	
	   ('10 anos', 10, 'exibição em qualquer horário.'),
	   ('12 anos', 12, 'a partir das 20h.'),
	   ('14 anos', 14, 'a partir das 21h.'),
	   ('16 anos', 16, 'a partir das 22h.'),
	   ('18 anos', 18, 'a partir das 23h.');


