using System.IdentityModel.Tokens.Jwt;
using GoldenReports.WebUI.Configuration;
using GoldenReports.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddAppConfiguration()
    .AddControllers("api")
    .AddVersioning()
    .AddSwagger()
    .AddSecurity()
    .AddCors()
    .AddGoldenReports();

var app = builder.Build();

app.UseGlobalExceptionHandler();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

app.UseAuthentication();

app.UseAuthorization();

app.UseApiSwagger();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapGet("settings", async ctx =>
{
    var clientSettings = ctx.RequestServices.GetRequiredService<ClientSettings>();
    await ctx.Response.WriteAsJsonAsync(clientSettings, ctx.RequestAborted);
    await ctx.Response.CompleteAsync();
});

app.MapFallbackToFile("index.html");

app.Run();
