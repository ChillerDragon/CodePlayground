import socket
import threading
import time

tLock=threading.Lock()
shutdown = False

def receving(name, sock):
	while not shutdown:
		try:
			time.sleep(0.5)
			tLock.acquire()
			while True:
				data, addr=sock.recvfrom(1024)
				print(str(data))
		except:
			time.sleep(0.5)
			pass
		finally:
			time.sleep(0.5)
			tLock.release()

client_port=raw_input("client port: ")
client_address=(socket.gethostbyname(socket.gethostname()), int(client_port))
server_ip=raw_input("server ip: ")
server_port=raw_input("server port: ")
server_address=(server_ip,int(server_port))
client_socket=socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
client_socket.bind((client_address))
client_socket.setblocking(0)

rT=threading.Thread(target=receving, args=("RecevingThread: ", client_socket))
rT.start()

client_username=raw_input("Name: ")
message=raw_input(client_username + "-> ")

while message != 'q':
	if message != '':
		client_socket.sendto(client_username + ": " + message, server_address)
	tLock.acquire()
	message=raw_input(client_username + "-> ")
	tLock.release()
	time.sleep(0.2)

shutdown=True
rT.join()
client_socket.close()
			
