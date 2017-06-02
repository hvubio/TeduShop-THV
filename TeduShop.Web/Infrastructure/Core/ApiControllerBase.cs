using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private readonly IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            _errorService = errorService;
        }

        // hứng các request Error gởi lên
        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage,
            Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine(
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var va in eve.ValidationErrors)
                        Trace.WriteLine($"- Property: \"{va.PropertyName}\", Error: \"{va.ErrorMessage}\"");
                }
                LogError(ex);
                if (ex.InnerException != null)
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                if (dbEx.InnerException != null)
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception exception)
            {
                LogError(exception);
                response = requestMessage.CreateResponse(HttpStatusCode.BadGateway, exception.Message);
            }

            return response;
        }


        private void LogError(Exception ex)
        {
            var error = new Error
            {
                CreatedDate = DateTime.Now,
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };

            _errorService.Create(error);
            _errorService.Save();
        }
    }
}