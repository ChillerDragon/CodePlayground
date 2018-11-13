import socket
import time

ip=socket.gethostbyname(socket.gethostname())
port=8303

clients=[]

server=socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
server_adress=(ip,port)
server.bind(server_adress)
server.setblocking(0)

qutting=False

print("server started at " + str(ip) + ":" + str(port))

while not qutting:
	try:
		time.sleep(0.5)
		data, addr=server.recvfrom(1024)
		if "Quit" in str(data):
			qutting=True
		if addr not in clients:
			clients.append(addr)
		print("[" + time.ctime(time.time()) + "]" + str(addr) + ": " + str(data))
		for client in clients:
			if (client != addr):
				server.sendto(data, client)
	except:
		time.sleep(0.5)
		pass
server.close()
