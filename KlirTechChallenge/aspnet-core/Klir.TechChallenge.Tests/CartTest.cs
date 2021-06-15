using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Infrastructure.Repositories;
using Klir.TechChallenge.Web.Api.Services;
using KlirTechChallenge.Web.Api.Interfaces;
using System;
using Xunit;

namespace KlirTechChallenge.Tests
{
    public class CartTest
    {
        private readonly ICartService _cartService;

        public CartTest()
        {
            var productPromotionRepository = new ProductPromotionRepository();
            var productRepository = new ProductRepository();
            _cartService = new CartService(productPromotionRepository, productRepository);
        }

        [Fact]
        public void ProductWithBuy1Get1Free_1UnitShouldReturnOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 1, Amount = 1 };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(20, item.FinalPrice);
            Assert.False(item.IsPromotion);
        }

        [Fact]
        public void ProductWithBuy1Get1Free_2UnitsShouldReturnPromotionPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 1, Amount = 2 };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(20, item.FinalPrice);
            Assert.True(item.IsPromotion);
        }

        [Fact]
        public void ProductWithBuy1Get1Free_3UnitsShouldReturnPromotionPricePlusOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 1, Amount = 3 };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(40, item.FinalPrice);
            Assert.True(item.IsPromotion);
        }

        [Fact]
        public void ProductWithThreeFor10Euro_1UnitShouldReturnOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 2, Amount = 1 };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(4, item.FinalPrice);
            Assert.False(item.IsPromotion);
        }

        [Fact]
        public void ProductWithThreeFor10Euro_2UnitsShouldReturnOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 4, Amount = 2 };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(8, item.FinalPrice);
            Assert.False(item.IsPromotion);
        }

        [Fact]
        public void ProductWithThreeFor10Euro_3UnitsShouldReturnPromotionPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 4, Amount = 3 };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(10, item.FinalPrice);
            Assert.True(item.IsPromotion);
        }

        [Fact]
        public void ProductWithThreeFor10Euro_4UnitsShouldReturnPromotionPricePlusOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 4, Amount = 4 };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(14, item.FinalPrice);
            Assert.True(item.IsPromotion);
        }
    }
}
