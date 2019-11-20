using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using MicrowaveOvenClasses.Boundary;

namespace Microwave.Test.Unit
{
    [TestFixture]
    class UIIntegrationTest
    {
        private UserInterface sut_;
        private IButton powerButton;
        private IButton startCancelButton;
        private IButton timeButton;
        private IDoor door;

        [SetUp]
        public void SetUp()
        {
            powerButton = new Button();
            startCancelButton = new Button();
            timeButton = new Button();

            door = new Door();

            var stubCookController = Substitute.For<ICookController>();
            var stubDisplay = Substitute.For<IDisplay>();
            var stubLight = Substitute.For<ILight>();

            sut_ = new UserInterface(powerButton, timeButton, startCancelButton, door, stubDisplay, stubLight, stubCookController);

        }


        [Test]
        public void Press_press()
        {
            powerButton.Press();
        }
    }
}
