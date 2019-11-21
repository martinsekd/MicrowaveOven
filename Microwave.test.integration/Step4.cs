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
using NUnit.Framework.Internal.Execution;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step4
    {

        //top modules
        private IButton powerButton;
        private IButton startCancelButton;
        private IButton timeButton;
        private IDoor door;

        //module included
        private UserInterface sut_;
        private CookController sutCookController;
        private ITimer sutTimer;
        private IDisplay sutDisplay;
        private IPowerTube sutPowerTube;


        //stubs
        private ILight stubLight;
        private IOutput stubOutput;

        [SetUp]
        public void SetUp()
        {
            stubLight = Substitute.For<ILight>();
            stubOutput = Substitute.For<IOutput>();

            powerButton = new Button();
            startCancelButton = new Button();
            timeButton = new Button();

            door = new Door();

            sutTimer = Substitute.For<ITimer>();

            sutDisplay = new Display(stubOutput);
            sutPowerTube = new PowerTube(stubOutput);

            sutCookController = new CookController(sutTimer,sutDisplay,sutPowerTube);
            sut_ = new UserInterface(powerButton, timeButton, startCancelButton, door, sutDisplay, stubLight, sutCookController);
            sutCookController.UI = sut_;
            



        }

        [Test]
        public void cookControllerCallUserInterface()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();

            //don't want to wait 1 minut every test
            sutTimer.Expired += Raise.Event();

            stubLight.Received(1).TurnOff();
            
        }

        [Test]
        public void cookControllerCallTimer()
        {

        }

        [Test]
        public void cookControllerCallPowerTube()
        {

        }

        [Test]
        public void cookControllerCallDisplay()
        {

        }
    }
}
