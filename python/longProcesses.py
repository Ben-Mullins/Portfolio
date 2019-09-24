#!/usr/bin/python

import psutil
import socket
import time

killedProcesses = set()
hostname = socket.gethostname()
hoursToReset = 12 # How many hours the program should be running before it is killed and restarted
startTime = time.time()

for num in psutil.pids():
        Processes = psutil.Process(num)
        timeLapsed = abs(startTime - Processes.create_time())
        procName = " ".join(Processes.cmdline())
        try:
                if ("/opt/splunk/etc/apps" in procName and ".py" in procName):
			if timeLapsed >= (hoursToReset * 3600): 
                        	print("Killing " + Processes.name())
                        	Processes.kill()
				killedProcesses.add(procName)
        except Exception as err:
		print(err)
                pass

if len(killedProcesses) > 0:

	print("The following processes have been terminated on " + hostname + ": " + str(killedProcesses))
