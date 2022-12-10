using NBomber.Contracts;
using NBomber.CSharp;

using var httpClient = new HttpClient();

var step = Step.Create("Get All Listings Endpoint", async context =>
{
    var response = await httpClient.GetAsync("https://localhost:7244/listing/all");
    return response.IsSuccessStatusCode
        ? Response.Ok(response.StatusCode)
        : Response.Fail();
});

var scenario = ScenarioBuilder.CreateScenario("Get All Listings", step)
    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
    .WithLoadSimulations(
        Simulation.InjectPerSec(rate: 100, during: TimeSpan.FromSeconds(60))
    );

NBomberRunner
    .RegisterScenarios(scenario)
    .Run();