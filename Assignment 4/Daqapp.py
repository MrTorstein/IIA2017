"""
A DAQ simulation application module.
The module contains five classes: Sensor, AnalogSensor, DigitalSensor, TemperatureSensor and the DAQSim
"""

from time import sleep
from random import Random
from threading import Thread
from logging import info, basicConfig, INFO
from datetime import datetime
from numpy import zeros

class Sensor():
    """
    Abstract class for sensors
    Takes the sensor id to be stored for reference, and sets up an RNG
    """
    def __init__(self, sensor_id):
        self.sensor_id = sensor_id
        self.sensor_value = None
        self.RNG = Random()
    
    def _set_sensor_value(self, value):
        """
        Function used to set the sensor value
        Author: Torstein Solheim Ølberg
        Version 1
        Date: 10/03-24
        """
        self.sensor_value = value
        return value
    
    def get_number(self):
        """Get the next random number
        Author: Torstein Solheim Ølberg
        Version 1
        Date: 10/03-24
        """
        raise(NotImplementedError)

class AnalogSensor(Sensor):
    """
    Class simulation an analog sensor with a default range of -3.3V to 3.3V, and 40 bits digital representation.
    """
    def get_number(self, distribution_range = (-3.3, 3.3)):
        """Get the next random number
        Author: Torstein Solheim Ølberg
        Version 1
        Date: 10/03-24
        """
        data = self.RNG.uniform(distribution_range[0], distribution_range[1])
        data = int(2 ** 40 * (data - distribution_range[0]) / (distribution_range[1] - distribution_range[0]))
        return self._set_sensor_value(data)

class DigitalSensor(Sensor):
    """
    Class simulation a digital sensor with 40 bit representation.
    """
    def get_number(self):
        """Get the next random number
        Author: Torstein Solheim Ølberg
        Version 1
        Date: 10/03-24
        """
        return self._set_sensor_value(2 ** 40 * self.RNG.choice((0, 1)))

class TemperatureSensor(AnalogSensor):
    """
    Class simulation an analog temperature sensor with a range of 5 to 40 degrees.
    """
    def get_number(self):
        """Get the next random number
        Author: Torstein Solheim Ølberg
        Version 1
        Date: 10/03-24
        """
        return super().get_number((5, 40))

class DAQSim():
    """
    Class simulation a DAQ device with a specific number of sensors of analog, digital and temperature type.
    It runs a single thread for each sensor and prints gathers the sensorvalues at spesific time intervals.
    Sensor values are logged to the terminal and saved to a .csv file
    """
    def __init__(self, file, sleeptime = 1.3, nr_a_sensors = 17, nr_d_sensors = 61, nr_t_sensors = 8):
        self.file = file
        self.sleeptime = sleeptime
        self.nr_sensors = nr_a_sensors + nr_d_sensors + nr_t_sensors
        self.threads = [[], [], []]
        self.sensor_values = [list(zeros(nr_a_sensors + 1)), list(zeros(nr_d_sensors + 1)), list(zeros(nr_t_sensors + 1))]
        self.nr_values_updated = 0
        
        self.savethread = Thread(target = self.save_to_file, args = (file,), daemon = True)
        
        for i in range(1, nr_a_sensors + 1):
            self.threads[0].append(Thread(target = self.gather_sensor_value, args = (AnalogSensor(i), file, 0,), daemon = True))
        for i in range(1, nr_d_sensors + 1):
            self.threads[0].append(Thread(target = self.gather_sensor_value, args = (DigitalSensor(i), file, 1,), daemon = True))
        for i in range(1, nr_t_sensors + 1):
            self.threads[0].append(Thread(target = self.gather_sensor_value, args = (TemperatureSensor(i), file, 2,), daemon = True))
    
    def write_header(self):
        """Writes a header to the csv file
        Author: Torstein Solheim Ølberg
        Version 1
        Date: 10/03-24
        """
        self.file.write("time")
        for i in range(self.nr_sensors):
            self.file.write(f", Sensor {i + 1}")
        self.file.write("\n")
    
    def save_to_file(self, file):
        """Thread function saving all sensor values when they have been updated.
        Author: Torstein Solheim Ølberg
        Version 1.1
        Date: 25/03-24
        """
        while True:
            if self.nr_values_updated >= self.nr_sensors:
                dataline = f"{self.sensor_values[0][0]}, "
                for valuelist in self.sensor_values:
                    for value in valuelist[1:]:
                        dataline += f"{value}, "
                file.write(dataline + "\n")
                
                self.nr_values_updated = 0
                info("new data saved to file")
                
                sleep(self.sleeptime)
    
    def gather_sensor_value(self, sensor, file, sensor_type):
        """Thread function getting a sensor value and saving it to the temperary list of values
        Author: Torstein Solheim Ølberg
        Version 1
        Date: 10/03-24
        """
        while True:
            if self.nr_values_updated < self.nr_sensors:
                info(sensor.get_number())

                time = datetime.now()
                if self.nr_values_updated == 0:
                    self.sensor_values[sensor_type][0] = time
                self.sensor_values[sensor_type][sensor.sensor_id] = sensor.sensor_value
            
                self.nr_values_updated += 1
            
                sleep(self.sleeptime)
    
    def start(self):
        """Function starting all the threads for the DAQ
        Author: Torstein Solheim Ølberg
        Version 1
        Date: 10/03-24
        """
        info("Starting threads")
        self.savethread.start()
        for sensortype in self.threads:
            for thread in sensortype:
                thread.start()

if __name__ == "__main__":
    # A simple run of the simulator
    format = "%(asctime)s: %(message)s"
    basicConfig(format=format, level=INFO, datefmt="%H:%M:%S")
    
    with open("data.csv", "a", encoding = "utf-8") as outfile:
        with open("data.csv", "r", encoding = "utf-8") as infile:
            A = DAQSim(outfile)
    
            if len(infile.readlines()) == 0:
                A.write_header()
            
            print("Press enter to stop DAQ")
            
            A.start()
            
            input("")
