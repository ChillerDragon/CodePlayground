#!/usr/bin/python
#create a digit list (dlst)

print("creating digit_force.lst in this directory...")
dlst = open('digit_force.lst', 'w')
print("addding values to the list... Ctrl-C to stop and save")
i=0
try:
	while True:
		dlst.write(str(i) + '\n')
		i+=1	
except KeyboardInterrupt:
	pass
dlst.close()
print("successfully saved.\ncreated list till: " + str(i))
