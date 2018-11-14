#include <stdio.h>


void dbg_msg(const char * pLevel, const char * pStr)
{
    printf("[%s]: %s\n", pLevel, pStr);
}

struct CBinaryStorage
{
    int x,space1,space2;
};

void LoadSinglePlayer()
{
    FILE *pFile;
    struct CBinaryStorage statsBuff;

    pFile = fopen("ddpp-stats.dat","rb");
    if (!pFile)
    {
        dbg_msg("ddpp-stats", "failed to load ddpp singleplayer stats");
    }

    fread(&statsBuff,sizeof(struct CBinaryStorage), 1, pFile);
    dbg_msg("ddpp-stats", "successfully loaded singleplayer stats"); // statsBuff.x
    printf("loaded [%d]\n", statsBuff.x);

    fclose(pFile);
}

void SaveSinglePlayer(int data)
{
    FILE *pFile;
    struct CBinaryStorage statsBuff;

    pFile = fopen("ddpp-stats.dat","wb");
    if (!pFile)
    {
        dbg_msg("ddpp-stats", "failed to load ddpp singleplayer stats");
    }
    statsBuff.x = data;
    fwrite(&statsBuff, sizeof(struct CBinaryStorage), 1, pFile);

    fclose(pFile);
}

int main()
{
    int x;
    scanf("%d", &x);
    printf("saving [%d]\n", x);
    SaveSinglePlayer(x);
    LoadSinglePlayer();
}
