using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.Extensions.WebEncoders.Testing;
using MinimalApiZeroToHero.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("Get-example", () => "Hello from GET");
app.MapPost("Post-Heavy", () => "Your Post Sir");

// synchronous 
app.MapGet("ok-object", () => Results.Ok(new
{
    Name = "Test Account"
}));

// Rewrite above as Async 
app.MapGet("Slow-route", async () =>
{
    await Task.Delay(1000);
    {
        return Results.Ok(new 
            {
                lightStatus = "yellow"
            }
        );
    }
});



app.MapGet("testRoute2", async () =>
{
    await Task.Delay(2400);
    return Results.Json( new
        {
            test = "testJson"
        }
    );
});



// Write top 4 HTTP CRUD REST operations

//Read
app.MapGet("Reading", () =>
{
    return Results.Ok(new
    {
        status = "Ready"
    });
});

//Create
app.MapPost("Create/{name}", (string name) =>
{
    string Name = name;
    return Results.Ok($"Correct {Name}");
});

//Update

app.MapPut("Put-update/{amount}", (int amount) =>
{
    int Amount = amount;
    return Results.Ok(new
        {
            AmountUpdated = Amount

        }
    );
} );

//Delete  
app.MapDelete("Remove/{index}", (int index) =>
{
    int Index = index;
    return Results.Ok(new
        {
            IndexDeleted = Index

        }
    );
} );


// Write  Route with MapMethods 
app.MapMethods("thisOrThat", new [] {"options"}, () =>
{
    return Results.Ok(new
    {
        Peanutbutter = "nJelly"
    });
}
);


// Write Handler coming from a Var 

//Write a Class and pass MapGet a delegate 
app.MapGet("fromsomeclass",Handler.Examp );

app.Run();
