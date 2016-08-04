using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TirePressureMonitoringSystem
    {
        SensorMock _sensorMock;
        Alarm _alarm;

        [SetUp]
        public void test_initialize()
        {
            _sensorMock = new SensorMock();
            _alarm = new Alarm(_sensorMock);
        }

        [Test]
        [TestCase (16)]
        [TestCase (22)]
        public void should_sensor_with_out_of_range__value_trigger_the_alarm(int sensorValue)
        {            
            _sensorMock.PushNextPressurePsiValue(sensorValue);
           
            _alarm.Check();
            bool resultAlarm = _alarm.AlarmOn;
            Assert.IsTrue(resultAlarm);
        }

        [Test]
        public void should_sensor_with_regular_value_alarm_not_trigger()
        {
            _sensorMock.PushNextPressurePsiValue(18);
        
            _alarm.Check();

            bool resultAlarm = _alarm.AlarmOn;

            Assert.IsFalse(resultAlarm);
        }

        [Test]
        public void should_sensor_with_high_value_trigger_the_alarm_then_regular_value_keep_alarm_on()
        {
            _sensorMock.PushNextPressurePsiValue(16);
            _sensorMock.PushNextPressurePsiValue(18);
           
            _alarm.Check();

            bool resultAlarm = _alarm.AlarmOn;

            // Si la pression est trop faible => l'alarme doit sonner.
            Assert.IsTrue(resultAlarm);
            _alarm.Check();
            resultAlarm = _alarm.AlarmOn;

            // Si la pression revient à normale => l'alarme doit continuer à sonner.
            Assert.IsTrue(resultAlarm);
        }


    }
}