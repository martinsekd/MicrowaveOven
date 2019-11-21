using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using MicrowaveOvenClasses.Interfaces;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step3
    {
        private Button powerButton;
        private Button timeButton;
        private Button startCancelButton;
        private Door door;
        private IOutput fakeOutput;
        private ITimer fakeTimer;
        private IPowerTube fakePowerTube;
        private Light light;
        private Display display;
        private CookController cookController;
        private UserInterface sut;

        [SetUp]
        public void SetUp()
        {
            powerButton = new Button();
            timeButton = new Button();
            startCancelButton = new Button();
            door = new Door();

            fakeOutput = Substitute.For<IOutput>();
            fakeTimer = Substitute.For<ITimer>();
            fakePowerTube = Substitute.For<IPowerTube>();

            light = new Light(fakeOutput);
            display = new Display(fakeOutput);
            cookController = new CookController(fakeTimer, display, fakePowerTube);
            sut = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cookController);

            cookController.UI = sut;
        }

        [Test]
        public void Buttonspressed()
        {
            
            //_sut.TurnOn();
            //Assert.That(_output.OutTextTest.Contains("Light is turned on"));
        }
    }
}
