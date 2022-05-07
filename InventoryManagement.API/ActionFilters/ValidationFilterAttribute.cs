using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryManagement.API.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is IEntityDto);
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult(new ErrorDetails() 
                    {StatusCode=400, Message="Resource wasn't provided!!",details="" });
                return;
            }

            if (!context.ModelState.IsValid)
            {

                context.Result = new BadRequestObjectResult(new ErrorDetails()
                { StatusCode = 400, Message = "One or more validation errors occurred.", validationErrors = context.ModelState });
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
