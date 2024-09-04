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



// Write top 4 HTTP CRUD REST operations


// Write  Route with MapMethods 


// Write Handler coming from a Var 

//Write a Class and pass MapGet a delegate 

app.Run();
