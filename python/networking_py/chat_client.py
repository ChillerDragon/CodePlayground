import socket
import threading
import time

mode_menu=True

while mode_menu:
    client_mode=raw_input("clientmode: ")
    if (client_mode=="r") or (client_mode=="rw") or (client_mode=="w"):
        mode_menu=False
    else:
        print("error. Choose between following modes: 'r' 'rw' 'w'")

tLock=threading.Lock()
shutdown = False

def receving(name, sock):
    while not shutdown:
        try:
            time.sleep(0.5)
            tLock.acquire()
            while True:
                data, addr=sock.recvfrom(1024)
                if (client_mode!="w"):
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

client_username=raw_input("Username: ")

message="joined the server."
client_socket.sendto(client_username + " " + message, server_address)
message=""

while message != "!kill":
    if (client_mode == "r"):
        tLock.acquire()
        tLock.release()
        time.sleep(0.2)
    elif (client_mode == "rw"):
        if message != '':
            client_socket.sendto(client_username + ": " + message, server_address)
        tLock.acquire()
        message=raw_input(client_username + "-> ")
        tLock.release()
    elif (client_mode == "w"):
        if message != '':
            client_socket.sendto(client_username + ": " + message, server_address)
        tLock.acquire()
        message=raw_input(client_username + "-> ")
        tLock.release()

client_socket.sendto(client_username + " has left the server.", server_address)

shutdown=True
rT.join()
client_socket.close()
			

