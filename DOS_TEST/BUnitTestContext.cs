using Bunit;
using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Syncfusion.Blazor;

namespace DOS_TEST
{
    public abstract class BUnitTestContext : TestContextWrapper
    {
        protected const int smallLength = 255;
        protected const int longLength = 1023;
        protected const decimal minDecimal = -9999.9999M;
        protected const decimal maxDecimal = 9999.9999M;

        protected const int smallLengthBad = 300;
        protected const int longLengthBad = 1100;
        protected const decimal minDecimalBad = 111111.11111M;
        protected const decimal maxDecimalBad = 111111.11111M;
        [TestInitialize]
        public void Setup()
        {
            TestContext = new Bunit.TestContext();

            var container = new ServiceContainer(ContainerOptions.Default.WithMicrosoftSettings());
            container.RegisterFrom<TestModule>();

            // setup syncfusion blazor
            var collection = new ServiceCollection();
            collection.AddSyncfusionBlazor();
            TestContext.JSInterop.SetupVoid("import", "./_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor-638e27.min.js");

            var provider = container.CreateServiceProvider(collection);

            TestContext.Services.AddFallbackServiceProvider(provider);

        }

        [TestCleanup]
        public void TearDown()
        {
            TestContext?.Services.Dispose();
            TestContext?.Dispose();
        }
    }
}
