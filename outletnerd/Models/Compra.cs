namespace outletnerd.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public string tiposDePagamento { get; set; }
        public int Quantidade { get; set; }
        public int? QtdParcela {  get; set; }
        public decimal ValorTotal { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
    }
}
