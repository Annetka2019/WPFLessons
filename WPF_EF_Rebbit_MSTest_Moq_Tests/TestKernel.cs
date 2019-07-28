using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using WPF_EF_Rebbit_MSTest_Moq.Framework;

namespace WPF_EF_Rebbit_MSTest_Moq_Tests
{
	[TestClass]
	public class TestKernel
	{
		public static StandardKernel Instance { get; private set; }

		[AssemblyInitialize]
		public static void OnStartup(TestContext testContext) {
			Instance = new StandardKernel(new ProjectModule());
		}
	}
}
