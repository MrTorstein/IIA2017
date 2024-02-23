import time

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
    
    while True:
        # Write to tag
        var.set_value(random()) # Set value to a random number
        print(f'New value is : {var.get_value()}') # Get and print full value of the node
        time.sleep(1)

finally :
    # Disconnect
    client.disconnect()
