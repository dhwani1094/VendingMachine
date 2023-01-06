using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Interface;
using VendingMachine.Model;

namespace VendingMachineUnitTest
{
    [TestClass]
    public class VendingMachineTestCase
    {
        private Mock<IProductService> _productService;
        private Mock<ICoinService> _coinService;
        private Mock<ICoinRepository> _coinRepository;
        private Mock<IProductRepository> _productRepository;

        [TestInitialize]
        public void InitialiseService()
        {
           
            _productRepository = new Mock<IProductRepository>();
            _productService = new Mock<IProductService>();
            _coinService = new Mock<ICoinService>();
            _coinRepository = new Mock<ICoinRepository>();

        }

        [TestMethod]
        public void VendingMachine_CheckValidCoin()
        {
            
            string coinType = "Nickles";
            _coinService.Setup(mock => mock.getCoin(coinType)).Returns(CreateValidNickleCoin());
            var vendingMachine = new VendingMachine.VendingMachineImplementation(_coinService.Object,_productService.Object);
            var result = vendingMachine.getCoin(coinType);
            Assert.AreEqual(result != null, true);
            Assert.AreEqual(result.coinName, "Nickles");
            Assert.AreEqual(result.coinValue,"0.05");
           

        }

        [TestMethod]
        public void VendingMachine_FetchCoinType_Invalid()
            {
            _coinService.Setup(mock => mock.getCoin(It.IsAny<string>())).Returns(() => null);
            var vendingMachine = new VendingMachine.VendingMachineImplementation(_coinService.Object, _productService.Object);
            Coins result = vendingMachine.getCoin("INVALIDCODE");
            Assert.AreEqual(result == null, true);
        }


        [TestMethod]
        public void VendingMachine_FetchProductCode_Valid()
        {
           
            string productCode = "Coke12";
            _productService.Setup(mock => mock.GetProduct(productCode)).Returns(ValidProduct());
            var vendingMachine = new VendingMachine.VendingMachineImplementation(_coinService.Object, _productService.Object);
            Product result = vendingMachine.getProduct(productCode);
            Assert.AreEqual(result != null, true); 
            Assert.AreEqual(result.productName, "Coke");
            Assert.AreEqual(result.price, 1.00m);
           

        }

        [TestMethod]
        public void VendingMachine_FetchProductCode_Invalid()
        {
            _productService.Setup(mock => mock.GetProduct(It.IsAny<string>())).Returns(() => null);
            var vendingMachine = new VendingMachine.VendingMachineImplementation(_coinService.Object, _productService.Object);
            Product result = vendingMachine.getProduct("INVALIDCODE");
            Assert.AreEqual(result == null, true);
           
        }


         private Coins CreateValidNickleCoin()
        {
            return new Coins
            {
            coinName = "Nickles",
            coinValue = "0.05",
        };
    }

         private Product ValidProduct()
        {
            return new Product()
            {
                
                productName = "Coke",
                price = 1.00m
            };
        }
    }
}
