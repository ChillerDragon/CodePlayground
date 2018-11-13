import socket

server_log=open('server_log.dat','w')

server=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
ip=socket.gethostbyname(socket.gethostname())
port = 8303
adress=(ip,port)
server.bind(adress)
server.listen(10)
print("[server] server successfully started at " + str(ip) + ":" + str(port))
client,addr=server.accept()
print("[server] " + str(addr[0]) + ":" + str(addr[1]) + " joined the server")
username=client.recv(1024)
server_log.write('[server] ' + str(addr[0]) + ' joined the server\n')

client,addr=server.accept()
print("[server] " + str(addr[0]) + ":" + str(addr[1]) + " joined the server")
username=client.recv(1024)
server_log.write('[server] ' + str(addr[0]) + ' joined the server\n')

while True:
	data=client.recv(1024)
	print("[" + username + "]" + str(addr[0]) + ": "  + str(data))
	server_log.write(str(addr[0]) + ": " + str(data) + "\n")
	#print("[*] procressing data...")
	if(data=="hello server"):
		client.send('hello client')
		print("[*] procressing done...")
	elif(data=="disconnect"):
		client.send('bye')
		client.close()
		print("[server] " + str(addr[0]) + ":" + str(addr[1]) + " left the server")
		server_log.write('[server] ' + str(addr[0]) + ' has left the server\n')
		break
	else:
		client.send('invalid data')
		print("[*] procressing done... [INVALID DATA]")
	
	
server_log.close()
