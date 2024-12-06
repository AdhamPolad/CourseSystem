using CourseSystem.Dtos.CustomDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CourseSystem.Filter
{
    public class ModelStateHandler : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
     
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ModelState.IsValid is false)
            {
                var modelErrors = context.ModelState.Values.SelectMany(x => x.Errors).ToList();
                List<string> errors = new List<string>();

                modelErrors.ForEach(x=> errors.Add(x.ErrorMessage));

                ResponceDto responce = new()
                {
                    Errors = errors,
                    IsSucces = false,
                };

                context.Result = new ObjectResult(responce)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
                return;

            }


        }
    }
}
