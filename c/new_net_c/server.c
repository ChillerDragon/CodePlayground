//currently working on the 3hours networking course by Barry Brown on youtube

#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <fcntl.h> // for open
#include <unistd.h> // for close

const int portnum = 8304;

void do_something(int sock);

int main(int argc, char *argv[])
{
    // Create socket
    //int sockfd = 0, newsockfd = 0;
    int sockfd, newsockfd ;
    
    struct sockaddr_in serv_addr, cli_addr;
    
    sockfd = socket(AF_INET, SOCK_STREAM, 0);
    if (sockfd < 0)
    {
        printf("Can't open socket.\n");
        exit(1);
    }
    
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_port = htons(portnum);
    serv_addr.sin_addr.s_addr = INADDR_ANY;
    
    
    // Bind to socket
    int res = bind(sockfd, (struct sockaddr *)&serv_addr, sizeof(serv_addr));
    if (res < 0)
    {
        printf("Can't bind socket: %s\n", "error");
        exit(1);
    }
    
    //chiller fork for multiple clients
    //if (fork())
    {
        // Listen for connection
        listen(sockfd, 5); // hold max 5 connections in queue
        
        // Accept connection
        int clilen = sizeof(cli_addr);
        newsockfd = accept(sockfd, (struct sockaddr *)&cli_addr, (socklen_t *)&clilen);
        
        // Hand off to function
        do_something(newsockfd);
        
        // Close or socket can't be bound agian
        close(newsockfd);
        close(sockfd);
    }

    return 0;
}

void do_something(int sock)
{
    char aBuf[128];
    strcpy(aBuf, "hello world\n");
    send(sock, aBuf, sizeof(aBuf), 0);
    
    while (1)
    {
        recv(sock, aBuf, sizeof(aBuf), 0);
        if (!strncmp("hax", aBuf, 3))
        {
            printf("client haxxored the server\n");
        }
        else if (!strncmp("q", aBuf, 1))
        {
            printf("client shutdown the server\n");
            return;
        }
    }
}


