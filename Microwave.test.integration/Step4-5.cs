using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step45
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

            sutTimer = new Timer();

            sutDisplay = new Display(stubOutput);
            sutPowerTube = new PowerTube(stubOutput);

            sutCookController = new CookController(sutTimer,sutDisplay,sutPowerTube);
            sut_ = new UserInterface(powerButton, timeButton, startCancelButton, door, sutDisplay, stubLight, sutCookController);
            sutCookController.UI = sut_;
            



        }


        [Test]
        public void cookControllerCallTimer()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();

            Thread.Sleep(61000);
            stubOutput.Received().OutputLine(Arg.Is<string>("PowerTube turned off"));

        }


        [Test]
        public void cookControllerCallDisplay()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();

            Thread.Sleep(3000);
            stubOutput.Received().OutputLine(Arg.Is<string>(s => s.StartsWith("Display shows:") && s.Length-s.Replace(":","").Length==2));
        }
    }
}
