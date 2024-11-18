using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pmail.ViewModels;

namespace Pmail.Tests.MSTest
{
    // TODO: Add appropriate tests
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        // TODO: Add tests for functionality you add to SettingsViewModel.
        [TestMethod]
        public void TestSettingsViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new SettingsViewModel();
            Assert.IsNotNull(vm);
        }

        // TODO: Add tests for functionality you add to TwoPaneViewViewModel.
        [TestMethod]
        public void TestTwoPaneViewViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new TwoPaneViewViewModel();
            Assert.IsNotNull(vm);
        }
    }
}
