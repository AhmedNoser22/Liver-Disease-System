namespace Liver_Disease_System
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLiverDiseaseSystem(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddSwaggerGen
                (
                option =>
                {
                    option.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Liver Disease System",
                        Description = "A System designed to manage, monitor," +
                        " and track patients with liver diseases, providing tools for diagnosis," +
                        " medical records, and treatment follow-up.",
                        Contact = new OpenApiContact
                        {
                            Name = "Ahmed Noser",
                            Url = new Uri("https://www.linkedin.com/in/ahmednoser122")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license")
                        }
                    });
                    option.AddSecurityDefinition
                    (
                        "Bearer",
                        new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.Http,
                            Name = "Authorization",
                            Scheme = "Bearer",
                            BearerFormat = "JWT",
                            In = ParameterLocation.Header,
                            Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
                        }
                    );
                    option.AddSecurityRequirement
                    (
                        new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                                    Name ="Bearer",
                                    In = ParameterLocation.Header
                                },
                                new List<string>()

                            }
                        }
                    );
                }
                );
            Services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });
            Services.AddDbContext <AppDbContext>
                (
                optins=>optins.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                );
            Services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            // Repository Pattern
            Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            Services.AddScoped<IMedicalRecordRepo, MedicalRecordRepo>();
            Services.AddScoped<IPatientRepo, PatientRepo>();
            Services.AddScoped<IDoctorRepo, DoctorRepo>();
            // Services
            Services.AddScoped<IServiceMedicalRecord, ServiceMedicalRecord>();
            Services.AddScoped<IServicePatient, ServicePatient>();
            Services.AddScoped<IServiceDoctor, ServiceDoctor>();
            Services.AddScoped<IServicesAppointment, ServicesAppointment>();
            Services.AddScoped<IServiceToken, ServiceToken>();
            Services.AddScoped<IServiceAuth, ServiceAuth>();
            Services.AddScoped<IServiceRole, ServiceRole>();
            Services.AddScoped<IServiceMedicine,ServiceMedicine>();
            return Services;
        }
    }
}
