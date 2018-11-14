#include <stdlib.h>
#include <stdio.h>

void read()
{
    unsigned char buffer[10];
    FILE *fp;
    fp = fopen("data", "rb");
    /*
    fread(buffer, sizeof(buffer), 1, fp);
    for (int i = 0; i < 10; i++)
    {
        printf("%u ", buffer[i]);
    }
    */
    char x;
    fread(&x, sizeof(char), 1, fp);
    printf("loaded: %d\n", x);
    fread(&x, sizeof(char), 1, fp);
    printf("loaded: %d\n", x);
    fread(&x, sizeof(char), 1, fp);
    printf("loaded: %d\n", x);
    fclose(fp);
}

void write(char data)
{
    FILE *wf;
    wf = fopen("data","wb");
    int val = fwrite(&data, sizeof(data), 1, wf);
    if (!val)
    {
        printf("error writing to file\n");
    }
    fclose(wf);
}

int main()
{
    char x;
    scanf("%c", &x);
    printf("writing %c...\n", x);
    write(x);
    read();
}
