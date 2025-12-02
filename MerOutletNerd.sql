-- drop database dbMer;
create database dbMer;
use dbMer;

-- Cliente
create table Cliente(
  IdCliente int primary key auto_increment,
  Email varchar(100) not null,
  Nome varchar(80) not null,
  Senha varchar(30) not null,
  Telefone varchar(20) not null
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
  ImageUrl varchar(1000) not null,
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
  Nome varchar(100) not null,
  Descricao varchar(250) not null,
  DataCompra date,
  Parcela int,
  QtdTotal int not null,
  ValorTotal decimal(8,2)
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
CREATE TABLE HistoricoCompra (
    IdHistorico INT AUTO_INCREMENT PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdProduto INT NOT NULL,
    Quantidade INT NOT NULL,
    PrecoTotal DECIMAL(10,2) NOT NULL,
    DataCompra DATETIME NOT NULL,
    
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
    FOREIGN KEY (IdProduto) REFERENCES Produto(IdProduto)
);
select * from Funcionario;
select * from Cliente;
select * from Produto;
DELIMITER $$

CREATE PROCEDURE GetProdutosCompra()
BEGIN
    SELECT DISTINCT 
        p.IdProduto,
        p.Nome,
        p.Descricao,
        p.Preco,
        p.ImageUrl,
        p.Quantidade,
        p.Categoria
    FROM Produto p
    INNER JOIN Produto ip ON p.IdProduto = ip.IdProduto;
END$$
set SQL_SAFE_UPDATES = 0
DELIMITER ;
SELECT IdFuncionario, Email, Senha FROM Funcionario WHERE Email=@Email AND Senha=@Senha;
update Produto set Nome = 'Minecraft guia de sobrevivência' where Nome = 'Minecraft guia de sobrevivencia';

insert into Produto(Nome,Descricao,Preco,ImageUrl,Quantidade, Categoria)values('Camisa Harry Potter', 'Camisa Harry Potter', 80.90, 'https://static.zattini.com.br/produtos/camiseta-masculina-harry-potter-brasao-grifinoria-edicao-especial/06/5YP-0120-006/5YP-0120-006_zoom1.jpg?ts=1694579126', 100, 'Roupas');