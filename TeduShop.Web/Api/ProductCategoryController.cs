using System;
using System.Collections.Generic;
using System.Linq;
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
        public HttpResponseMessage Get(HttpRequestMessage requestMessage, int page, int pageSize = 20)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var totalRow = 0;
                 
                var category = _productCategoryService.GetAll();

                totalRow = category.Count();

                var query = category.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var listProductCategoryVm = Mapper.Map<List<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = listProductCategoryVm,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow/pageSize)
                };

                
                var responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);

                return responseMessage;
            });
        }
    }
}