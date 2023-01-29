using DatabaseHandler.Context;
using DatabaseHandler.Repositories.CommonGenericRepository;
using DatabaseHandler.Repositories.EntityRepositories.DepartmentRepository;
using DatabaseHandler.Repositories.EntityRepositories.LevelTermRepository;
using DatabaseHandler.Repositories.EntityRepositories.MessageRepository;
using DatabaseHandler.Repositories.EntityRepositories.RolesRepository;
using DatabaseHandler.Repositories.EntityRepositories.StudentRepository;
using DatabaseHandler.Repositories.EntityRepositories.TeacherRepository;
using DatabaseHandler.Repositories.EntityRepositories.UserRepository;
using DatabaseHandler.Works.DepartmentControllerWork;
using DatabaseHandler.Works.InitializationControllerWork;
using DatabaseHandler.Works.UserControllerWork.AddNewUserWork;
using DatabaseHandler.Works.UserControllerWork.GetUserInformationWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient(typeof(ICommonGenericRepository<>), typeof(CommonGenericRepository<>));
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<ILevelTermRepository, LevelTermRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IOfficialRepository,OfficialRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IStudentRepository,StudentRepository>();
builder.Services.AddTransient<ITeacherRepository,TeacherRepository>();
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IInitialization, Initialization>();
builder.Services.AddTransient<IDepartmentRepository,DepartmentRepository>();
builder.Services.AddTransient<IDepartmentHandling,DepartmentHandling>();
builder.Services.AddTransient<IAddNewUser, AddNewUser>();
builder.Services.AddTransient<IGetUserInformation,GetUserInformation>();


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

app.Run();
