using HSKAPI.Models.DAL;
using HSKAPI.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region DbContext & Identity Auth:
var connectionString = builder.Configuration.GetConnectionString("MSSQLConnection") ?? throw new InvalidOperationException("Connection string 'MSSQLConnection' not found!");
builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

#region Email Confirmation (1) (using EmailService;)
    //.AddTokenProvider<EmailConfirmationTokenProvider<ApplicationUser>>("emailconfirmation");
#endregion


builder.Services.Configure<IdentityOptions>(options =>
{
    // Thiết lập về Password
    options.Password.RequireDigit = true;  // 0 - 9
    options.Password.RequireNonAlphanumeric = false; // @!#$%^&*
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 4;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true; // Every email is unique! (ko trùng email)

    // Cấu hình đăng nhập. (important!!!)
    // user may get 401 satus code in authorized enpoints after registration if email is not confirm !!!
    options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại
    options.SignIn.RequireConfirmedEmail = true; // Cấu hình confirm email after register (email must exists)
    options.User.RequireUniqueEmail = true;

    // EmailConfirmation (2):
    //options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";

});

#endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// Home page for API:
app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";

    var htmlContent = @"
        <!DOCTYPE html>
        <html>
        <head>
            <title>API HomePage</title>
        </head>
        <body>
            <h1>Welcome to API made with luv by Nguyen Huu Anh Tuan!</h1>
            <p>Have a good day!</p>
        </body>
        </html>
    ";

    await context.Response.WriteAsync(htmlContent, Encoding.UTF8);
});

app.Run();
