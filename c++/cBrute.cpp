#include <iostream>

using namespace std;

char Bruteforce(char aRoot)
{
    char aLetter[26] = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    
    for (int i = 0; i < 26; i++)
    {
        string tmp = "";
        tmp = aRoot;
        tmp += aLetter[i];
        
        
        cout << tmp << endl;
    }
    aRoot += aLetter[0];
    
    return aRoot;
}

int main()
{
    //"abcdefghijklmnopqrstuvwxyz";
    //'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z';
    char aRoot[26] = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    
    for (int i = 0; i < 26; i++)
    {
        Bruteforce(aRoot[i]);
    }
}

