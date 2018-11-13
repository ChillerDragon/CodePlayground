import socket

def Main():
	server=socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

	ip=socket.gethostbyname(socket.gethostname())
	port=1234
	adress=(ip,port)
	server.bind(adress)
	
	print("UDP server started at " + str(ip) + ":" + str(port))
	while True:
		data, addr = server.recvfrom(1024)
		print("message from: " + str(addr))
		print("from connect user: " + str(data))
		data=str(data).upper()
		print("sending: " + str(data))
		server.sendto(data, addr)
	server.close()

if __name__ == '__main__':
	Main()

