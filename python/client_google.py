import socket

client=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
ip=socket.gethostbyname("www.google.com")
port=80
adress=(ip,port)
client.connect(adress)

print("sending data to google...")
client.send("GET / HTTP/1.1\r\nHost: google.com\r\n\r\n")

recv_data = raw_input("sniff data from google: ")
int_recv_data=int(recv_data)
client.recv(int_recv_data)
