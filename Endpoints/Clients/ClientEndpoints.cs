﻿using application.Clients.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Endpoints.Clients
{
    public static class ClientEndpoints
    {
        public static WebApplication AddClientEndpoints(this WebApplication app)
        {
            app.MapGet("/clients", async ([FromServices] IMediator mediatr) =>
            {
                return await mediatr.Send(new GetAllQuery());
            })
            .WithName("get clients");

            return app;
        }
    }
}