import socket
import time

def communicate(data):
	client.send(data)
	print("server: " + str(client.recv(1024)))
	return
	

client=socket.socket()

username = raw_input("username: ")
ip = raw_input("server ip: ")
port = raw_input("server port: ")
print("connecting to server...")
client.connect((ip,int(port)))
print("succsesfully connected to server.")
client.send(username)

while True:
	communicate(raw_input(username + ": "))
	
