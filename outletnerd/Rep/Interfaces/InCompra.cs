using outletnerd.Models;
namespace outletnerd.Rep.Interfaces
{
    public interface InCompra
    {
        public Task<IEnumerable<Compra>> ItemCompra();
    }
}
