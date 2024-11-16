create database myfinance;
use myfinance;

create table PLANOCONTA(
	id int not null identity(1,1),
	nome varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
);

create table TRANSACAO(
	id int not null identity(1,1),
	date datetime not null,
	valor decimal(9,2) not null,
	historico varchar(100),
	tipo char(1) not null,
	planocontaid int not null,
	primary key(id),
	foreign key(planocontaid) references PLANOCONTA(id)
);

select *from planoconta;
select * from transacao;

insert into planoconta(nome, tipo) values('Combustível', 'D') 
insert into planoconta(nome, tipo) values('Alimentação', 'D')
insert into planoconta(nome, tipo) values('Aluguel', 'D')
insert into planoconta(nome, tipo) values('Água', 'D')
insert into planoconta(nome, tipo) values('Luz', 'D')
insert into planoconta(nome, tipo) values('Internet', 'D')
insert into planoconta(nome, tipo) values('Salário', 'R')
insert into planoconta(nome, tipo) values('Crédito de Dividentos', 'R')

insert into transacao (date, valor, historico, tipo, planocontaid)
values (getdate(),458, 'Gasolina da Blazer', 'D', 1)

insert into transacao (date, valor, historico, tipo, planocontaid)
values ('2024-11-02 13:05', 120.58, 'Almoço de Domingo', 'D', 2)

insert into transacao (date, valor, historico, tipo, planocontaid)
values ('2024-10-01',25, 'Padaria', 'D', 2)

insert into transacao (date, valor, tipo, planocontaid)
values ('2024-11-05',1000, 'R', 7)

insert into transacao (date, valor, historico, tipo, planocontaid)
values ('2024-31-10',868.32, 'Dividendos Itau', 'R', 8)

insert into transacao values ('2024-31-10',57.89, 'Dividendos Itau', 'R', 8)

select *from transacao where tipo = 'D'
select *from transacao where tipo = 'R'

-- Funçoes agregadas.

select count(*) from transacao where tipo = 'D'
select count(*) from transacao where tipo = 'R'

select sum(valor) from transacao where tipo = 'D'
select sum(valor) from transacao where tipo = 'R'

select avg(valor) from transacao where tipo = 'D'
select avg(valor) from transacao where tipo = 'R'

select max(valor) from transacao where tipo = 'D'
select max(valor) from transacao where tipo = 'R'

select min(valor) from transacao where tipo = 'D'
select min(valor) from transacao where tipo = 'R'

select * from transacao where date >='20240101 00:00:00' and date <= '20240331 23:59:59'

select * from transacao where date between '20240101 00:00:00' and '20240331 23:59:59'

select tipo, sum(valor) from transacao 
where date >='20240101 00:00:00' and date <= '20241231 23:59:59'
group by tipo

select * from transacao as t inner join planoconta as p
on t.planocontaid = p.id
where date >='20240101 00:00:00' and date <= '20241231 23:59:59'

select t.*, p.nome as Categoria from transacao as t inner join planoconta as p
on t.planocontaid = p.id
where date >='20240101 00:00:00' and date <= '20241231 23:59:59'

-- Como descobrir quais categorias de plano de contas ainda não possui transaçoes vinculadas? (left join)
select * from planoconta as p left join transacao as t
on p.id = t.planocontaid

select p.id, p.nome, t.id codigotransacao 
from planoconta as p left join transacao as t
on p.id = t.planocontaid

select p.id, p.nome, t.id codigotransacao 
from planoconta as p left join transacao as t
on p.id = t.planocontaid
where t.id is null