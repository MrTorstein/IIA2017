import time
import nidaqmx

from opcua import Client
from random import random

client = Client("opc.tcp://Beist:49580") # Initiate client

try :
    # Connect to server
    client.connect()

    # Get node
    var = client.get_node("ns=2;s=Data.Temperature") 

    # Print node value
    print(f'Node : {var}')
    with nidaqmx.Task() as task:
        task.ai_channels.add_ai_thrmcpl_chan("Dev1/ai0", min_val = 0.0, max_val = 100.0, 
                                             units = nidaqmx.constants.TemperatureUnits.DEG_C, 
                                             thermocouple_type = nidaqmx.constants.ThermocoupleType.J,
                                             cjc_source = nidaqmx.constants.CJCSource.BUILT_IN)
        
        while True:
            # Write to tag
            var.set_value(round(task.read(number_of_samples_per_channel = 1)[0], 0)) # Set value to a random number
            print(f'New value is : {var.get_value()}') # Get and print full value of the node
            time.sleep(1)

finally :
    # Disconnect
    client.disconnect()
