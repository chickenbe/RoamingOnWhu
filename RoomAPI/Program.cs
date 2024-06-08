var builder = WebApplication.CreateBuilder(args);

// ��ӷ���DI����
builder.Services.AddControllers();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5004, listenOptions =>
    {
        listenOptions.UseHttps("D:/D_App4/apicert.pfx", "123456");
    });
    options.ListenAnyIP(5259); // HTTP endpoint
});
var app = builder.Build();

// ����HTTP����ܵ�
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
