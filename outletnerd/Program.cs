using outletnerd.Rep;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30); // Tempo de inatividade da sess�o (pode ajustar)
    options.Cookie.HttpOnly = true; // Impede que o cookie seja acessado por scripts do lado do cliente
    options.Cookie.IsEssential = true; // Torna o cookie de sess�o essencial para a funcionalidade do aplicativo
});

builder.Services.AddSingleton<string>(builder.Configuration.GetConnectionString("DefaultConnection")!);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ProdutoRep>();
builder.Services.AddScoped<PedidoRep>();
builder.Services.AddScoped<CarrinhoRep>();
builder.Services.AddScoped<ItemProdutoRep>();
builder.Services.AddScoped<FornecedorRep>();
builder.Services.AddScoped<FuncionarioRep>();
builder.Services.AddScoped<NotaFiscalRep>();
builder.Services.AddScoped<CompraRep>();
builder.Services.AddScoped<PagamentoRep>();
builder.Services.AddScoped<ClienteRep>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
