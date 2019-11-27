using System;
using System.Collections.Generic;
using System.IO;
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
    public class Step7
    {
        //top level modules
        private Door _door;
        private IButton _powerButton;
        private IButton _timeButton;
        private IButton _startCancelButton;
        
        //modules included
        private UserInterface _userInterface;
        private IOutput _output;
        private Light _light;
        
        //stubs
        private ICookController _cookController;
        private Display _display;

        
        private StringWriter stringWriter;
        

        [SetUp]
        public void SetUp()
        {
            //console test
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _output = new Output();
            _light = new Light(_output);

            _door = new Door();

            _powerButton = new Button();
            _timeButton = new Button();
            _startCancelButton = new Button();
            _display = Substitute.For<Display>(_output);
            _cookController = Substitute.For<ICookController>();

            _userInterface = new UserInterface(_powerButton, _timeButton, _startCancelButton, _door, _display,_light,_cookController);
           

        }

        [Test]
        public void LightTurnsOn_WasOff_CorrectOutPutString()
        {
            //act
            //_door.Close();
            _door.Open();
            //_door.Opened += Raise.EventWith(this, EventArgs.Empty);
            //_light.TurnOn();
            
           
            
            //Assert
            
            //Console.WriteLine("Light is turned on");
            Assert.That(stringWriter.ToString(),Does.Contain("Light is turned on"));
            
        }

        [Test]
        public void LightTurnsOff_WasOn_CorrectOutPutString()
        {
            _door.Open();
            //_light.TurnOn();
            _door.Close();
            //_door.Closed += Raise.EventWith(this, EventArgs.Empty);


            //Assert
            //_output.Received().OutputLine(Arg.Is<string>(x =>
            //  x == "Light is turned off"));
            //Console.WriteLine("Light turns off");
            Assert.That(stringWriter.ToString(), Does.Contain("Light is turned off"));
        }

        private void _door_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TurnOn_WasOn_CorrectOutput()
        {
            _door.Open();

            //Assert
            //_output.Received().OutputLine(Arg.Is<string>(x =>
            //    x == "Light is turned on"));
            
            Assert.That(stringWriter.ToString(),Does.Contain("on"));
        }
    }
}