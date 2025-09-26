using Newtonsoft.Json;
using outletnerd.Models;
namespace outletnerd.Rep
{
    public class CarrinhoRep
    {
        private const string ChaveCart = "Carrinho";

        public List<Carrinho> CarrinhoItens(ISession session)
        {
            var cartJson = session.GetString(ChaveCart);
            return cartJson == null ? new List<Carrinho>() : JsonConvert.DeserializeObject<List<Carrinho>>(cartJson);

        }
        public void AddCarrinho(ISession session, Produto produto, int quantidade)
        {
            var cart = CarrinhoItens(session);
            var existingItem = cart.FirstOrDefault(item => item.IdCarrinho == produto.IdProduto);

            if (existingItem != null)
            {
                existingItem.Quantidade += quantidade;
            }
            else
            {
                cart.Add(new Carrinho
                {
                    IdCarrinho = produto.IdProduto,

                    Quantidade = quantidade,
                    Preco = produto.Preco
                });
            }
            SalvarCarrinho(session, cart);
        }
        public void AlterarQuantidadeItem(ISession session, int produtoId, int novaQuantidade)
        {
            var cart = CarrinhoItens(session);
            var itemAlterar = cart.FirstOrDefault(item => item.IdCarrinho == produtoId);

            if (itemAlterar != null)
            {
                if (novaQuantidade <= 0)
                {
                    cart.Remove(itemAlterar);
                }
                else
                {
                    itemAlterar.Quantidade = novaQuantidade;
                }
                SalvarCarrinho(session, cart);
            }
        }

        public void RemoverItemCarrinho(ISession session, int produtoId)
        {
            var cart = CarrinhoItens(session);
            var itemRemover = cart.FirstOrDefault(item => item.IdCarrinho == produtoId);
            if (itemRemover != null)
            {
                cart.Remove(itemRemover);
                SalvarCarrinho(session, cart);
            }
        }

        public void LimparCarrinho(ISession session)
        {
            session.Remove(ChaveCart);
        }

        public decimal TotalCarrinho(ISession session)
        {
            return CarrinhoItens(session).Sum(item => item.Valor);
        }

        private void SalvarCarrinho(ISession session, List<Carrinho> cart)
        {
            session.SetString(ChaveCart, JsonConvert.SerializeObject(cart));
        }
    }
}

