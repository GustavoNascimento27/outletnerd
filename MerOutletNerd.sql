-- drop database dbMer;
create database dbMer;
use dbMer;

-- Cliente
create table Cliente(
  IdCliente int primary key auto_increment,
  Email varchar(100) not null,
  Nome varchar(80) not null,
  Senha varchar(30) not null,
  Telefone bigint not null
);

-- Funcionario
create table Funcionario(
  IdFuncionario int primary key auto_increment,
  Nome varchar(80) not null,
  Email varchar(120) not null,
  Senha varchar(30) not null
);

-- Fornecedor
create table Fornecedor(
  IdFornecedor int primary key,
  Nome varchar(60) not null,
  Lote int not null
);

-- Produto
create table Produto(
  IdProduto int primary key auto_increment,
  Nome varchar(80) not null,
  Descricao varchar(120) not null,
  Preco decimal(8,2) not null,
  ImageUrl varchar(120) not null,
  Quantidade int not null,
  Categoria varchar(40) not null
);

-- Carrinho
create table Carrinho(
  IdCarrinho int primary key auto_increment,
  IdCliente int not null,
  foreign key (IdCliente) references Cliente(IdCliente)
);

-- ItemProduto (Carrinho possui vários produtos)
create table ItemProduto(
  IdItem int primary key auto_increment,
  IdCarrinho int not null,
  IdProduto int not null,
  Quantidade int not null,
  foreign key (IdCarrinho) references Carrinho(IdCarrinho),
  foreign key (IdProduto) references Produto(IdProduto)
);

-- Pedido
create table Pedido(
  IdPedido int primary key auto_increment,
  DataPedido date not null,
  StatusPedido varchar(25) not null,
  ValorTotal decimal(8,2) not null,
  IdCliente int not null,
  foreign key (IdCliente) references Cliente(IdCliente)
);

-- Compra
create table Compra(
  IdCompra int primary key auto_increment,
  DataCompra date not null,
  Parcela int not null,
  QtdTotal int not null,
  ValorTotal decimal(8,2),
  IdPedido int not null,
  foreign key (IdPedido) references Pedido(IdPedido)
);

-- Pagamento
create table Pagamento(
  IdPagamento int primary key auto_increment,
  Metodo varchar(30) not null,
  Valor decimal(8,2) not null,
  IdCompra int not null,
  foreign key (IdCompra) references Compra(IdCompra)
);

-- Nota Fiscal
create table NotaFiscal(
  IdNF int primary key auto_increment,
  DataEmissao date not null,
  IdCompra int not null,
  foreign key (IdCompra) references Compra(IdCompra)
);
select * from Cliente;

insert into Produto(Nome,Descricao,Preco,ImageUrl,Quantidade, Categoria)values('Pelúcias de Pokémon', '4 Pelúcias de pokémon', 50.90, 'imgProd/pikachu.png', 100, 'Brinquedos');