#include <iostream>

using namespace std;

void swap(int &a, int &b)
{
    cout << "[swapping] < " << a << " >  < " << b << " > " << endl;
    int tmp = a;
    a = b;
    b = tmp;
}

int main ()
{
    int x;
    int y;
    while (true)
    {
        cout << "[x]_";
        cin >> x;
        cout << "[y]_";
        cin >> y;
        cout << "[x] " << x << " [y] " << y << endl;
        swap(x, y);
        cout << "[x] " << x << " [y] " << y << endl;
    }
}
