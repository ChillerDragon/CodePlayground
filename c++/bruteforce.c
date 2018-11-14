#include <stdio.h>
#include <string.h>
#include <stdlib.h>


static const char alphabet[] =
"abcdefghijklmnopqrstuvwxyz"
"ABCDEFGHIJKLMNOPQRSTUVWXYZ"
"0123456789";

static const int alphabetSize = sizeof(alphabet) - 1;

void bruteImpl(char* str, int index, int maxDepth)
{
    for (int i = 0; i < alphabetSize; ++i)
    {
        str[index] = alphabet[i];
        
        if (index == maxDepth - 1)
        {
            FILE *f = fopen("Desktop/c++/bruteforce.lst", "a");
            if (f == NULL)
            {
                printf("Error opening file!\n");
                exit(1);
            }
            //printf("%s\n", str);
            fprintf(f, "%s\n", str);
            fclose(f);
        }
        else
        {
            bruteImpl(str, index + 1, maxDepth);
        }
    }
}

void bruteSequential(int maxLen)
{
    char* buf = malloc(maxLen + 1);
    
    for (int i = 1; i <= maxLen; ++i)
    {
        memset(buf, 0, maxLen + 1);
        bruteImpl(buf, 0, i);
    }
    
    free(buf);
}

int main(void)
{
    char c;
    printf("_ ");
    c = getchar();
    int len = c - '0';
    bruteSequential(len);
    return 0;
}
