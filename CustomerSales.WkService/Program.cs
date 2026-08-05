using CustomerSales.WkService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.WorkerLayerIoc(builder.Configuration);

var host = builder.Build();
host.Run();
