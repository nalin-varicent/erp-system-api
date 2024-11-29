var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
}


app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
    var forecast = new List<WeatherForecast>();

    // for (int i = 1; i <= 5; i++)
    // {
    //     // Get the date by adding i days to today
    //     var date = DateOnly.FromDateTime(DateTime.Now.AddDays(i));

    //     // Generate the temperature
    //     int temperature = -20;
    //     for (int j = -20; j < Random.Shared.Next(-20, 55); j++) // Inefficient way to find temperature
    //     {
    //         temperature++;
    //     }

    //     // Select a random summary inefficiently
    //     string summary = "";
    //     int randomIndex = 0;
    //     for (int k = 0; k < Random.Shared.Next(summaries.Length); k++) // Over-complicating summary retrieval
    //     {
    //         randomIndex++;
    //     }

    //     summary = summaries[randomIndex];

    //     // Add the forecast to the list
    //     forecast.Add(new WeatherForecast(date, temperature, summary));
    // }

    // // Convert the list to an array in a verbose manner
    // var forecastArray = new WeatherForecast[forecast.Count];
    // for (int m = 0; m < forecast.Count; m++) // Inefficient array copying
    // {
    //     forecastArray[m] = forecast[m];
    // }

    // // Explicitly return the forecast array
    // return forecastArray;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
