using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step8
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
        private IOutput sutOutput;

        //stubs
        private ILight stubLight;
        private IDisplay stubDisplay;
        private IPowerTube sutPowerTube;

        private StringWriter stringWriter;

        [SetUp]
        public void SetUp()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            
            stubLight = Substitute.For<ILight>();
            stubDisplay = Substitute.For<IDisplay>();
            sutTimer = new MicrowaveOvenClasses.Boundary.Timer();

            powerButton = new Button();
            timeButton = new Button();
            startCancelButton = new Button();
            
            sutOutput = new Output();
            door = new Door();
            sutPowerTube = new PowerTube(sutOutput);
            
            sutCookController = new CookController(sutTimer, stubDisplay, sutPowerTube);
            sut_ = new UserInterface(powerButton, timeButton, startCancelButton, door, stubDisplay, stubLight, sutCookController);
            sutCookController.UI = sut_;

            
            
            

        }

        [Test]
        public void t_t_t()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();

            Assert.That(stringWriter.ToString(),Does.StartWith("PowerTube works with "));
        }

        [Test]
        public void t_t_t2()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();
            Thread.Sleep(61000);
            //Console.WriteLine("PowerTube turned off");
            Assert.That(stringWriter.ToString(), Does.Contain("PowerTube turned off"));
        }
        //[Test]
        //public void TurnOn_WasOff_CorrectOutput()
        //{
        //    //_powerTube.TurnOff();
        //    _powerTube.TurnOn(power:50);

        //    Assert.That(_output,Is.EqualTo("50 %"));
        //}
        //[Test]
        //public void TurnOff_WasOn_CorrectOutput()
        //{
        //    _powerTube.TurnOn(power: 50);
        //    _powerTube.TurnOff();

        //    Assert.That(_output, Is.EqualTo("PowerTube turned off"));
        //}
    }
}
