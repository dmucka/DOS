using Bunit;
using DOS_BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_TEST
{
    [TestClass]
    public class AddNewProductTest : BUnitTestContext
    {
        /// <summary>
        /// Everything empty.
        /// </summary>
        [TestMethod]
        public async Task Unit01()
        {
            var cut = RenderComponent<DOS_PL.Pages.Products.Add>();
            var form = cut.GetForm();

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var productService = TestContext.Services.GetService<ProductService>();
            var products = await productService.GetAllAsync();
            Assert.AreEqual(0, products.Count);
        }

        /// <summary>
        /// Everything empty except Name.
        /// </summary>
        [TestMethod]
        public async Task Unit02()
        {
            var cut = RenderComponent<DOS_PL.Pages.Products.Add>();
            var form = cut.GetForm();

            cut.GetTextBox("Name").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var productService = TestContext.Services.GetService<ProductService>();
            var products = await productService.GetAllAsync();
            Assert.AreEqual(0, products.Count);
        }

        /// <summary>
        /// Everything empty except Description.
        /// </summary>
        [TestMethod]
        public async Task Unit03()
        {
            var cut = RenderComponent<DOS_PL.Pages.Products.Add>();
            var form = cut.GetForm();

            cut.GetTextBox("Description").Change(CommonTestFunctions.RandomString(longLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var productService = TestContext.Services.GetService<ProductService>();
            var products = await productService.GetAllAsync();
            Assert.AreEqual(0, products.Count);
        }

        /// <summary>
        /// Everything empty except Process.
        /// </summary>
        [TestMethod]
        public async Task Unit04()
        {
            var cut = RenderComponent<DOS_PL.Pages.Products.Add>();
            var form = cut.GetForm();

            var listView = cut.FindComponent<Syncfusion.Blazor.Lists.SfListView<DOS_PL.Pages.Products.Add.CheckedProcess>>();
            listView.Instance.DataSource.ElementAt(CommonTestFunctions.RandomInt(1, 5)).IsChecked = true;

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var productService = TestContext.Services.GetService<ProductService>();
            var products = await productService.GetAllAsync();
            Assert.AreEqual(0, products.Count);
        }

        /// <summary>
        /// Everything empty except Name and Description.
        /// </summary>
        [TestMethod]
        public async Task Unit05()
        {
            var cut = RenderComponent<DOS_PL.Pages.Products.Add>();
            var form = cut.GetForm();

            cut.GetTextBox("Description").Change(CommonTestFunctions.RandomString(longLengthBad));
            cut.GetTextBox("Name").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var productService = TestContext.Services.GetService<ProductService>();
            var products = await productService.GetAllAsync();
            Assert.AreEqual(0, products.Count);
        }

        /// <summary>
        /// Everything empty except Name and Process.
        /// </summary>
        [TestMethod]
        public async Task Unit06()
        {
            var cut = RenderComponent<DOS_PL.Pages.Products.Add>();
            var form = cut.GetForm();

            cut.GetListViewItem(CommonTestFunctions.RandomInt(1, 5)).SetAttribute("aria-selected", "true");
            cut.GetTextBox("Name").Change(CommonTestFunctions.RandomString(smallLengthBad));

            form.Submit();
            cut.Render();

            Assert.IsNotNull(cut.GetValidationErrors());
            var productService = TestContext.Services.GetService<ProductService>();
            var products = await productService.GetAllAsync();
            Assert.AreEqual(0, products.Count);
        }

        /// <summary>
        /// Valid Name, Random Process, Empty Description
        /// </summary>
        [TestMethod]
        public async Task Unit08()
        {
            var cut = RenderComponent<DOS_PL.Pages.Products.Add>();
            var form = cut.GetForm();

            var nameText = CommonTestFunctions.RandomString(smallLength);

            var listView = cut.FindComponent<Syncfusion.Blazor.Lists.SfListView<DOS_PL.Pages.Products.Add.CheckedProcess>>();
            listView.Instance.DataSource.ElementAt(CommonTestFunctions.RandomInt(1, 5)).IsChecked = true;
            cut.GetTextBox("Name").Change(nameText);

            form.Submit();
            cut.Render();

            var productService = TestContext.Services.GetService<ProductService>();
            var products = await productService.GetAllAsync();

            Assert.AreEqual(1, products.Count);
            Assert.AreEqual(nameText, products.First().Name);
            Assert.IsNull(products.First().Description);
        }

        /// <summary>
        /// Valid Name, Random Process, Random Description
        /// </summary>
        [TestMethod]
        public async Task Unit09()
        {
            var cut = RenderComponent<DOS_PL.Pages.Products.Add>();
            var form = cut.GetForm();

            var nameText = CommonTestFunctions.RandomString(smallLength);
            var descriptionText = CommonTestFunctions.RandomString(longLength);

            var listView = cut.FindComponent<Syncfusion.Blazor.Lists.SfListView<DOS_PL.Pages.Products.Add.CheckedProcess>>();
            listView.Instance.DataSource.ElementAt(CommonTestFunctions.RandomInt(1, 5)).IsChecked = true;
            cut.GetTextBox("Name").Change(nameText);
            cut.GetTextBox("Description").Change(descriptionText);

            form.Submit();
            cut.Render();

            var productService = TestContext.Services.GetService<ProductService>();
            var products = await productService.GetAllAsync();

            Assert.AreEqual(1, products.Count);
            Assert.AreEqual(nameText, products.First().Name);
            Assert.AreEqual(descriptionText, products.First().Description);
        }
    }
}
