using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Shop.Business.Models;
using Sample.Shop.Data;
using Sample.Shop.WebApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CartsController> _logger;

        public CartsController(ShopDbContext context, IMapper mapper, ILogger<CartsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<CartContract> CreateCart()
        {
            var cart = new Cart()
            {
                UserId = 1,
                CreateTime = DateTime.Now
            };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Cart created with id: {cart.Id}.");

            return _mapper.Map<CartContract>(cart);
        }

        [HttpPost("{cartId}/add/{productId}/{qty}")]
        public async Task<CartContract> AddProduct(int cartId, int productId, int qty)
        {
            var userId = 1;

            var cart = _context.Carts.FirstOrDefault(c => c.Id == cartId && c.UserId == userId);
            if (cart == null)
                throw new ApplicationException("Cart not exists.");

            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ApplicationException("Product not exists.");

            var cartProduct = new CartProduct();
            var cartProduct1 = _context.CartProducts.FirstOrDefault(p => p.CartId == cartId && p.ProductId == productId);
            if (cartProduct1 == null)
            {
                cartProduct.CartId = cartId;
                cartProduct.ProductId = productId;
                cartProduct.quantity = qty;
                _context.CartProducts.Add(cartProduct);
            }
            else
            {
                cartProduct1.quantity += qty;
            }

            cart.ItemsCount += qty;
            cart.TotalPrice += (qty * product.Price);

            return _mapper.Map<CartContract>(cart);
        }

    }
}
