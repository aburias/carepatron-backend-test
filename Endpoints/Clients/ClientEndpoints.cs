using application.Clients.Commands.CreateClient;
using application.Clients.Commands.UpdateClient;
using application.Clients.Queries.GetAll;
using application.Clients.Queries.Search;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace api.Endpoints.Clients
{
    public static class ClientEndpoints
    {
        public static WebApplication AddClientEndpoints(this WebApplication app)
        {
            app.MapGet("/clients", async ([FromServices] IMediator mediatr) =>
            {
                return Results.Ok(await mediatr.Send(new GetAllQuery()));
            })
            .WithName("get clients");

            app.MapPost("/clients", async (
                [FromServices] IMediator mediatr,
                [FromBody] CreateClientCommand command,
                [FromServices] IValidator<CreateClientCommand> validator) =>
            {
                var validationResult = validator.Validate(command);
                if (validationResult.IsValid)
                    return Results.Ok(await mediatr.Send(command));

                return Results.BadRequest(validationResult.Errors);
            });

            app.MapPut("/clients", async (
                [FromServices] IMediator mediatr,
                [FromBody] UpdateClientCommand command,
                [FromServices] IValidator<UpdateClientCommand> validator) =>
            {
                var validationResult = validator.Validate(command);
                if (validationResult.IsValid)
                    return Results.Ok(await mediatr.Send(command));

                return Results.BadRequest(validationResult.Errors);
            });

            app.MapGet("/clients/search", async (
                [FromServices] IMediator mediatr,
                [FromQuery] string query) =>
            {
                return Results.Ok(await mediatr.Send(new SearchQuery(query)));
            });

            return app;
        }
    }
}
