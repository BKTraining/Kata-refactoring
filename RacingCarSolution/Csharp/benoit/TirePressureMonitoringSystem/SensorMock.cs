using System;
using System.Collections.Generic;
using System.Text;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{

    class SensorMock : ISensor
    {
        Queue<double> _queue =new Queue<double>();

        public void PushNextPressurePsiValue(double value)
        {
            _queue.Enqueue(value);
        }

        public double PopNextPressurePsiValue()
        {
            return _queue.Dequeue();
        }
    }

}
