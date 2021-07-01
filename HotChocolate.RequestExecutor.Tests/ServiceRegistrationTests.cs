using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotChocolate.RequestExecutor.Tests
{
    [TestClass]
    public class ServiceRegistrationTests
    {
        [TestMethod]
        public async Task RegisteredService_ShouldBeAvailableInExecutor()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<ISomething, Something>();

            var executor = await serviceCollection
                .AddGraphQL()
                .AddQueryType<Query>()
                .BuildRequestExecutorAsync();

            var services = serviceCollection.BuildServiceProvider();
            services.GetRequiredService<ISomething>();
        }
    }

    public class Query
    {
        public string Asd()
        {
            return "";
        }
    }

    public interface ISomething{}

    public class Something: ISomething{}
}
