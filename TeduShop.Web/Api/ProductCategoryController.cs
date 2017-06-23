using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using AutoMapper;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService,
            IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var category = _productCategoryService.GetAll();
                var listProductCategoryVm = Mapper.Map<List<ProductCategoryViewModel>>(category);
                var responseMessage =
                    requestMessage.CreateResponse(HttpStatusCode.OK, listProductCategoryVm);
                return responseMessage;
            });
        }
    }
}