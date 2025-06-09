using EComBlazor.lib.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.Exceptions
{
    public class ExHandlingMiddleware(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            try
            {
                await _next(context);
            }
            catch (DbUpdateException ex)
            {
                var logger = context.RequestServices.GetRequiredService<IAppLoger<ExHandlingMiddleware>>();
                var innerEx = ex.InnerException as SqlException;
                if (innerEx != null)
                {
                    logger.LogError(innerEx, "SQL Exception");
                    switch(innerEx.Number)
                    {
                        case 2627: // Unique constraint violation
                            context.Response.StatusCode = StatusCodes.Status409Conflict;
                            await context.Response.WriteAsync($"Unique constraint violation: {innerEx.Message}");
                            break;
                        case 515: // Can't accept null value
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync($"Can't accept null value: {innerEx.Message}");
                            break;
                        case 547: // Forign Key constraint violation
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync($"Forign Key constraint violation: {innerEx.Message}");
                            break;
                        default:
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            await context.Response.WriteAsync($"There's an error in the server: {innerEx.Message}");
                            break;
                    }
                }
                else
                {
                    logger.LogError(ex, "Non SQL Exception");
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("There's an error in the server");
                }
            }
            catch (Exception ex)
            {
                var logger = context.RequestServices.GetRequiredService<IAppLoger<ExHandlingMiddleware>>();
                logger.LogError(ex, "Other Exception");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"There's an error in the server: {ex.Message}");
            }
        }
    }
}
