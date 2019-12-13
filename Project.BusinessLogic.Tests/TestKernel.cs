using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Project.Startup.Configuration;

namespace Project.BusinessLogic.Tests
{
	[TestClass]
	public class TestKernel
	{
		public static StandardKernel Instance { get; private set; }

		[AssemblyInitialize]
		public static void OnStartup(TestContext testContext) {
			Instance = new StandardKernel(new DiModule());
		}
	}
}
