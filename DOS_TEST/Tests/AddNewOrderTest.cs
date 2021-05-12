using Bunit;
using DOS_BL.Services;
using DOS_DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOS_TEST
{
    [TestClass]
    public class AddNewOrderTest : BUnitTestContext
    {
        /// <summary>
        /// Everything empty.
        /// </summary>
        [TestMethod]
        public async Task Unit01()
        {
            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Everything empty except Product.
        /// </summary>
        [TestMethod]
        public async Task Unit02()
        {
            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Product").Change(products.First());

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Everything empty except Notes.
        /// </summary>
        [TestMethod]
        public async Task Unit03()
        {
            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            cut.GetTextBox("Notes").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Everything empty except Customer.
        /// </summary>
        [TestMethod]
        public async Task Unit04()
        {
            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            cut.GetTextBox("Customer").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Everything empty except Serial Number.
        /// </summary>
        [TestMethod]
        public async Task Unit05()
        {
            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            cut.GetTextBox("Serial Number").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Everything empty except Serial Number and Customer.
        /// </summary>
        [TestMethod]
        public async Task Unit06()
        {
            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            cut.GetTextBox("Serial Number").Change(CommonTestFunctions.RandomString(smallLengthBad));
            cut.GetTextBox("Customer").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Random product, Serial Number and Customer < 256 chars, notes empty.
        /// </summary>
        [TestMethod]
        public async Task Unit07()
        {
            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Product").Change(products.First());
            cut.GetTextBox("Serial Number").Change(CommonTestFunctions.RandomString(smallLengthBad));
            cut.GetTextBox("Customer").Change(CommonTestFunctions.RandomString(smallLength));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Random product, Serial Number < 256 chars and Customer, notes empty.
        /// </summary>
        [TestMethod]
        public async Task Unit08()
        {
            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Product").Change(products.First());
            cut.GetTextBox("Serial Number").Change(CommonTestFunctions.RandomString(smallLength));
            cut.GetTextBox("Customer").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Random product, Serial Number < 256 chars and Customer < 256 chars, notes > 1023 chars.
        /// </summary>
        [TestMethod]
        public async Task Unit09()
        {
            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Product").Change(products.First());
            cut.GetTextBox("Serial Number").Change(CommonTestFunctions.RandomString(smallLength));
            cut.GetTextBox("Customer").Change(CommonTestFunctions.RandomString(smallLength));
            cut.GetTextBox("Notes").Change(CommonTestFunctions.RandomString(longLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();
            Assert.AreEqual(0, orders.Count);
        }

        /// <summary>
        /// Random product, Serial Number < 256 chars and Customer < 256 chars, notes empty.
        /// </summary>
        [TestMethod]
        public async Task Unit10()
        {
            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            string snText = CommonTestFunctions.RandomString(smallLength);
            string customerText = CommonTestFunctions.RandomString(smallLength);

            cut.GetTextBox("Customer").Change(customerText);
            cut.GetTextBox("Serial Number").Change(snText);
            cut.GetDropDownList("Product").Change(products.First());

            form.Submit();
            cut.Render();

            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();

            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(customerText, orders.First().Customer);
            Assert.AreEqual(snText, orders.First().SerialNumber);
        }

        /// <summary>
        /// Random product, Serial Number < 256 chars and Customer < 256 chars, notes < 1024 chars.
        /// </summary>
        [TestMethod]
        public async Task Unit11()
        {
            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Orders.Add>();
            var form = cut.GetForm();

            string snText = CommonTestFunctions.RandomString(smallLength);
            string customerText = CommonTestFunctions.RandomString(smallLength);
            string notesText = CommonTestFunctions.RandomString(longLength);

            cut.GetTextBox("Serial Number").Change(snText);
            cut.GetTextBox("Customer").Change(customerText);
            cut.GetTextBox("Notes").Change(notesText);
            cut.GetDropDownList("Product").Change(products.First());

            form.Submit();
            cut.Render();

            var orderService = TestContext.Services.GetService<OrderService>();
            var orders = await orderService.GetAllAsync();

            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(customerText, orders.First().Customer);
            Assert.AreEqual(snText, orders.First().SerialNumber);
            Assert.AreEqual(notesText, orders.First().Notes);
        }
    }
}
