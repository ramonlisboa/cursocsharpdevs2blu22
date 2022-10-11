select * 
from convenio;

select * 
from pessoa;

select * 
from endereco;

select * 
from pessoa as p
join endereco as e 
	on p.id = e.id_pessoa
;    