import socket

def Main():
	client=socket.socket(socket.AF_INET,socket.SOCK_DGRAM)

	client_ip=socket.gethostbyname(socket.gethostname())
	client_port = 1337

	client.bind((client_ip,int(client_port)))

	ip = raw_input("server ip: ")
	port = raw_input("server port: ")
	server=(ip,int(port))
	

	message = raw_input("-> ")
	while message != 'q':
		client.sendto(message, server)
		data, addr = server.recvfrom(1024)
		print("Server: " + str(data))
		message = raw_input("-> ")
	server.close()

if __name__ == '__main__':
	Main()		



