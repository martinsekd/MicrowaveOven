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
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step5
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

        //stubs
        private ILight stubLight;
        private IDisplay stubDisplay;
        private IPowerTube stubPowerTube;

        [SetUp]
        public void SetUp()
        {
            stubDisplay = Substitute.For<IDisplay>();
            stubLight = Substitute.For<ILight>();
            stubPowerTube = Substitute.For<IPowerTube>();

            powerButton = new Button();
            startCancelButton = new Button();
            timeButton = new Button();
            door = new Door();

            sutTimer = new Timer();
            sutCookController = new CookController(sutTimer,stubDisplay,stubPowerTube);
            sut_ = new UserInterface(powerButton,timeButton,startCancelButton,door,stubDisplay,stubLight,sutCookController);
            sutCookController.UI = sut_;


        }

        [Test]
        public void thatnogetsker()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();

            Thread.Sleep(61000);
            stubDisplay.Received(1).ShowTime(0,0);
            
            
        }

        [Test]
        public void thatnogetsker2()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();

            Thread.Sleep(62000);
            stubDisplay.DidNotReceive().ShowTime(0, -1);


        }
    }
}
