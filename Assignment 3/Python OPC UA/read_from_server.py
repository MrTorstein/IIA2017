import time

from opcua import Client
from random import random
from numpy import linspace
from matplotlib.pyplot import plot, title, xlabel, ylabel, legend, savefig, show

client = Client("opc.tcp://Beist:49580") # Initiate client

data = []

try :
    # Connect to server
    client.connect()

    # Get node
    var = client.get_node("ns=2;s=Data.Temperature") 

    # Print node value
    print(f'Node : {var}')
    
    while True:
        current_value = var.get_value() # Read from tag
        print(current_value) # Print data value
        with open("data.csv", "a", encoding = "utf-8") as outfile:
            outfile.write(f"{len(data)},{current_value}")
        data.append(current_value)
        
        time.sleep(1)

except KeyboardInterrupt: # Plot data from session if interrupted
    plot(range(0, len(data)), data)
    title("Plot of data from this session")
    xlabel("Datapoint number")
    ylabel("Data value")
    legend(["Data()"])
    savefig("Plot.png")
    show()

finally :
    # Disconnect when finish
    client.disconnect()
