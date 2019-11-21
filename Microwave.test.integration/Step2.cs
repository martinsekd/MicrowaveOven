using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step2
    {

        private UserInterface sut_;
        private IButton powerButton;
        private IButton startCancelButton;
        private IButton timeButton;
        private IDoor door;

        private ICookController stubCookController;
        private IDisplay stubDisplay;
        private ILight stubLight;

        [SetUp]
        public void SetUp()
        {
            powerButton = Substitute.For<IButton>();
            startCancelButton = Substitute.For<IButton>();
            timeButton = Substitute.For<IButton>();

            door = new Door();

            stubCookController = Substitute.For<ICookController>();
            stubDisplay = Substitute.For<IDisplay>();
            stubLight = Substitute.For<ILight>();

            sut_ = new UserInterface(powerButton, timeButton, startCancelButton, door, stubDisplay, stubLight, stubCookController);
        }

        [Test]
        public void Open_hh_kk()
        {
            door.Open();
            
            stubLight.Received(1).TurnOn();

        }

        [Test]
        public void Close_hh_kk()
        {
            door.Open();
            door.Close();

            stubLight.Received(1).TurnOff();
        }
    }
}
