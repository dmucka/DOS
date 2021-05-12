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
    public class AddNewToleranceTest : BUnitTestContext
    {
        /// <summary>
        /// Everything empty.
        /// </summary>
        [TestMethod]
        public async Task Unit01()
        {
            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Min Value.
        /// </summary>
        [TestMethod]
        public async Task Unit02()
        {
            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetNumericTextBox("Min Value").Change(CommonTestFunctions.RandomDecimal(minDecimalBad, maxDecimalBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Max Value.
        /// </summary>
        [TestMethod]
        public async Task Unit03()
        {
            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetNumericTextBox("Max Value").Change(CommonTestFunctions.RandomDecimal(minDecimalBad, maxDecimalBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Value Name.
        /// </summary>
        [TestMethod]
        public async Task Unit04()
        {
            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetTextBox("Value Name").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Process.
        /// </summary>
        [TestMethod]
        public async Task Unit05()
        {
            var processes = (await TestContext.Services.GetService<ProcessService>().GetAllAsync()).Select(x => x.Name).ToList();
            processes.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Process").Change(processes.First());

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Product.
        /// </summary>
        [TestMethod]
        public async Task Unit06()
        {
            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Product").Change(products.First());

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Product and Process.
        /// </summary>
        [TestMethod]
        public async Task Unit07()
        {
            var processes = (await TestContext.Services.GetService<ProcessService>().GetAllAsync()).Select(x => x.Name).ToList();
            processes.Shuffle();

            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Process").Change(processes.First());
            cut.GetDropDownList("Product").Change(products.First());

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Product, Process and Value Name.
        /// </summary>
        [TestMethod]
        public async Task Unit08()
        {
            var processes = (await TestContext.Services.GetService<ProcessService>().GetAllAsync()).Select(x => x.Name).ToList();
            processes.Shuffle();

            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Process").Change(processes.First());
            cut.GetDropDownList("Product").Change(products.First());
            cut.GetTextBox("Value Name").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Product, Process and Max Value.
        /// </summary>
        [TestMethod]
        public async Task Unit09()
        {
            var processes = (await TestContext.Services.GetService<ProcessService>().GetAllAsync()).Select(x => x.Name).ToList();
            processes.Shuffle();

            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Process").Change(processes.First());
            cut.GetDropDownList("Product").Change(products.First());
            cut.GetNumericTextBox("Max Value").Change(CommonTestFunctions.RandomDecimal(minDecimalBad, maxDecimalBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything empty except Product, Process and Min Value.
        /// </summary>
        [TestMethod]
        public async Task Unit10()
        {
            var processes = (await TestContext.Services.GetService<ProcessService>().GetAllAsync()).Select(x => x.Name).ToList();
            processes.Shuffle();

            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            cut.GetDropDownList("Process").Change(processes.First());
            cut.GetDropDownList("Product").Change(products.First());
            cut.GetNumericTextBox("Min Value").Change(CommonTestFunctions.RandomDecimal(minDecimalBad, maxDecimalBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();
            Assert.AreEqual(0, tolerances.Count);
        }

        /// <summary>
        /// Everything filled in correctly.
        /// </summary>
        [TestMethod]
        public async Task Unit11()
        {
            var processes = (await TestContext.Services.GetService<ProcessService>().GetAllAsync()).Select(x => x.Name).ToList();
            processes.Shuffle();

            var products = new List<string> { "TestProduct1", "TestProduct2", "TestProduct3" };
            var productService = TestContext.Services.GetService<ProductService>();
            foreach (string p in products)
                await productService.InsertAsync(new Product(p, false));
            products.Shuffle();

            var cut = RenderComponent<DOS_PL.Pages.Tolerances.Add>();
            var form = cut.GetForm();

            string valueNameText = CommonTestFunctions.RandomString(smallLength);
            decimal minValue = CommonTestFunctions.RandomDecimal(minDecimal, maxDecimal);
            decimal maxValue = CommonTestFunctions.RandomDecimal(minDecimal, maxDecimal);

            cut.GetDropDownList("Process").Change(processes.First());
            cut.GetDropDownList("Product").Change(products.First());
            cut.GetTextBox("Value Name").Change(valueNameText);
            cut.GetNumericTextBox("Min Value").Change(minValue);
            cut.GetNumericTextBox("Max Value").Change(maxValue);

            form.Submit();
            cut.Render();

            var toleranceService = TestContext.Services.GetService<ToleranceService>();
            var tolerances = await toleranceService.GetAllAsync();

            Assert.AreEqual(1, tolerances.Count);
            Assert.AreEqual(valueNameText, tolerances.First().ValueName);
        }
    }
}
