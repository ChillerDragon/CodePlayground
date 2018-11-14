#include <iostream>
#include <fstream>

using namespace std;

int main ()
{
ofstream digit_lst;
digit_lst.open("digit_force.lst");
digit_lst << "hax\n";
digit_lst << "992\naj";
digit_lst.close();
return 0;
}
