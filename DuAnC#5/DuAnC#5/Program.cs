
using BUS.Common;
using BUS.IService;
using BUS.Service;
using BUS.Systems.Roles;
using BUS.Systems.Users;
using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace DuAnC_5
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(c =>
			{
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                                    Enter 'Bearer' [space] and then your token in the text input below.
                                    \r\n\r\nExample: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							},
							Scheme = "oauth2",
							Name = "Bearer",
							In = ParameterLocation.Header,
						},
						new List<string>()
					}
				});
			});
			builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));
			builder.Services.AddScoped<UserManager<AppUser>,UserManager<AppUser>>();
			builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
			builder.Services.AddTransient<RoleManager<AppRoles>, RoleManager<AppRoles>>();
			builder.Services.AddTransient<ICartService,CartService>();
			builder.Services.AddTransient<IAddressService, AddressService>();
			builder.Services.AddTransient<IBrandService, BrandService>();
			builder.Services.AddTransient<IVoucherService, VoucherService>();
			builder.Services.AddScoped<IStorageService, FileStorageService>();
			builder.Services.AddTransient<IProductService, ProductService>();
			builder.Services.AddTransient<ICategoryService,CategoryService>();
			builder.Services.AddTransient<IManufacturerService, ManufacturerService>();
			builder.Services.AddScoped<ISlideService, SlideService>();
			builder.Services.AddScoped<IOrderService, OrderService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IRoleService, RoleService>();
			builder.Services.AddIdentity<AppUser, AppRoles>()
			   .AddEntityFrameworkStores<MyDbContext>()
			   .AddDefaultTokenProviders();
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins",
					builder => builder.AllowAnyOrigin()
									  .AllowAnyMethod()
									  .AllowAnyHeader());
			});
			string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer");
			string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
			byte[] signingKeyBytes = Encoding.UTF8.GetBytes(signingKey);
			builder.Services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(opt =>
			{
				opt.RequireHttpsMetadata = false;
				opt.SaveToken = true;
				opt.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = issuer,
					ValidIssuer = issuer,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ClockSkew = TimeSpan.Zero,
					IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
				};

			}) ;
			
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseStaticFiles();
            app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseCors("AllowAllOrigins");
			app.MapControllers();

			app.Run();
		}
	}
}
