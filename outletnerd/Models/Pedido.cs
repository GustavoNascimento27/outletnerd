namespace outletnerd.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime DataPedido = DateTime.Now;
        public string Status {  get; set; }
        public decimal ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
    }
}
