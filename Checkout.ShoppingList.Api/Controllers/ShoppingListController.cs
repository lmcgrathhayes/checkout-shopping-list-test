using Checkout.ShoppingList.Core.Infrastructure.Interfaces;
using Checkout.ShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Checkout.ShoppingList.Api.Controllers
{
    [Authorize]
    [RoutePrefix("shoppingList")]
    public class ShoppingListController : ApiController
    {
        private IShoppingListRepository _repository;

        public ShoppingListController(IShoppingListRepository repository)
        {
            _repository = repository;
        }

        //GET api/shoppingList
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get(int pageIndex = 0, int pageSize = 10)
        {
            return Request.CreateResponse(_repository.Get(pageIndex, pageSize));
        }

        //POST ShoppingList
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(ShoppingListItem item)
        {
            if (item == null)
                BadRequest("Argument Null Exception");

            if (_repository.Exists(item))
                Request.CreateErrorResponse(HttpStatusCode.Conflict, new Exception("Shopping list item already exists."));

            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.Created, item);
        }

        //PUT ShoppingList
        [Route("")]
        [HttpPut]
        public void Put(ShoppingListItem item)
        {
            if (item == null)
                BadRequest("Argument Null Exception");

            if (!_repository.Exists(item))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _repository.Update(item);
        }

        //GET api/shoppingList/Pepsi
        [Route(@"{name}")]
        [HttpGet]
        public ShoppingListItem GetByName(string name)
        {
            var item = _repository.GetByName(name);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return item;
        }

        //DELETE ShoppingList/Pepsi
        [Route("{name}")]
        [HttpDelete]
        public void DeleteByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                BadRequest("Argument Null Exception");

            if (!_repository.Exists(new ShoppingListItem() { Name = name }))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _repository.DeleteByName(name);
        }
    }
}
