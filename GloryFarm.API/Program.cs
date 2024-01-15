using GloryFarm.API.GraphQL;
using GloryFarm.API.GraphQL.FarmAddress_types;
using GloryFarm.API.GraphQL.FarmInfo_Types;
using GloryFarm.API.GraphQL.Mutation;
using GloryFarm.Infrastructure;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPooledDbContextFactory<GloryFarmContext>(options =>
                                options.UseNpgsql(builder.Configuration.GetConnectionString("GloryFarmConnectionString"),
                                 b => b.MigrationsAssembly("GloryFarm.API")));


builder.Services.AddGraphQLServer()
               .AddQueryType<Query>()
               .AddType<FarmInfoType>()
               .AddType<FarmAddressType>()
               .AddMutationType<Mutation>()
               .AddSubscriptionType<Subscription>()
               .AddFiltering()
               .AddSorting()
               .AddInMemorySubscriptions();
               //.AddProjections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql",

}, "/graphql-voyager");

app.Run();
