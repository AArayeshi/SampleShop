using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        const int userId = 1;

        public CartsController(ShopDbContext context, IMapper mapper, ILogger<CartsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{cartId}")]
        public async Task<CartContract> GetCart(int cartId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == cartId && c.UserId == userId);
            if (cart == null)
                throw new ApplicationException("Cart not exists.");

            return _mapper.Map<CartContract>(cart);
        }

        [HttpPost("create")]
        public async Task<CartContract> CreateCart()
        {
            var cart = new Cart()
            {
                UserId = userId,
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
            var cart = _context.Carts.FirstOrDefault(c => c.Id == cartId && c.UserId == userId);
            if (cart == null)
                throw new ApplicationException("Cart not exists.");

            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ApplicationException("Product not exists.");

            var cartProduct = _context.CartProducts.FirstOrDefault(p => p.CartId == cartId && p.ProductId == productId);
            if (cartProduct == null)
            {
                cartProduct = new CartProduct()
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = qty
                };
                cart.ItemsCount++;
                _context.CartProducts.Add(cartProduct);
            }
            else
            {
                cartProduct.Quantity += qty;
            }

            //cart.ItemsCount += qty;
            //cart.TotalPrice = cart.ItemsCount * product.Price;

            await _context.SaveChangesAsync();
            return _mapper.Map<CartContract>(cart);
        }

        [HttpPost("{cartId}/remove/{productId}/{qty?}")]
        public async Task<CartContract> RemoveProduct(int cartId, int productId, int? qty = null)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == cartId && c.UserId == userId);
            if (cart == null)
                throw new ApplicationException("Cart not exists.");

            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ApplicationException("Product not exists.");

            var cartProduct = _context.CartProducts.FirstOrDefault(p => p.CartId == cartId && p.ProductId == productId);
            if (cartProduct == null)
                throw new ApplicationException("Product not exists.");

            if (qty == null)
            {
                _context.CartProducts.Remove(cartProduct);
                cart.ItemsCount--;
            }
            else
            {
                if(cartProduct.Quantity < qty.Value)
                    throw new ApplicationException("There is no enough quantity.");

                cartProduct.Quantity -= qty.Value;
                if(cartProduct.Quantity == 0)
                    cart.ItemsCount --;
                //cart.TotalPrice = cart.ItemsCount * product.Price;
            }
            
            await _context.SaveChangesAsync();

            return _mapper.Map<CartContract>(cart);
        }
    }
}
