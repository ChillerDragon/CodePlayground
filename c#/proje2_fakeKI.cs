using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

class Sample
{
    public static void Main()
    {
        int pathstepcounter = -1;
        int xposleft = -1; //-2 = falsche ebene
        int xposright = 1;
        int x1posleft = -2;
        int x1posright = -2;
        int x2posleft = -2;
        int x2posright = -2;
        int x3posleft = -2;
        int x3posright = -2;
        int botscanfinishposx = -1;  //-1
        int botscanfinishposy = 0;
        int spawnx = 49; //49
        int spawny = 2;  //2
        int posy = spawny;
        int pos = spawnx;
        int deaths = 0;
        int botdeaths = 0;
        int finishes = 0;
        int i = 0;
        int i1 = 0;
        int i2 = 0;
        int i3 = 0;
        int i4 = 0; //unused
        int i5 = 0; //unused
        int i6 = 0; //unused
        int i50 = 0;
        int xposdeath = 10;    // ytag + pos + posnumber + death(tilename) = xposdeath, x1posdeath, x1pos1death ....
        int xpos1death = 17;
        int xpos2death = 35;
        int xpos3death = 44;
        int x1posdeath = 1;
        int x1pos1death = 2;
        int x1pos2death = 3;
        int x2posdeath = 2;
        int x2pos1death = 5;
        int x2pos2death = 17;
        int x2pos3death = 18;
        int x3posdeath = 40;
        int xlength;
        int x1length;
        int x2length;
        int x3length;
        int path_new_length = 0;
        int path_shortest_length = 0;
        int charpathlength;
        int botspeed = 10;                          // BOT SPEED   <---------------------------------------
        bool botmoveswap = true;
        bool die = false;
        bool botalive = false;
        bool followpath = false;    //change testy path following tests
        string input;
        string msg = "";
        char[] x3 = new char[50];
        char[] x2 = new char[50];
        char[] x1 = new char[50];
        char[] x = new char[50];


        //testy array array addy stuff xD
        ArrayList path_shortest = new ArrayList();
        ArrayList path_new = new ArrayList();


        ArrayList path = new ArrayList();
        path.Add('l'); //48
        path.Add('l'); //47
        path.Add('l'); //46
        path.Add('l'); //45
        path.Add('l'); //44 
        path.Add('l'); //43
        path.Add('l'); //42
        path.Add('l'); //41
        path.Add('l'); //40
        path.Add('l'); //39
        path.Add('l'); //38
        path.Add('l'); //37
        path.Add('u');
        path.Add('l'); //36
        path.Add('l'); //35
        path.Add('d'); //32
        path.Add('l'); //31
        path.Add('d');
        path.Add('l');
        path.Add('l');
        path.Add('u');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('d');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('u');
        path.Add('l');
        path.Add('l');
        path.Add('d');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');
        path.Add('l');

        char skin = '#';
        char charxposleft = ' ';
        char charxposright = ' ';
        char charxposup = ' ';
        char charxposdown = ' ';
        char botscanfinish = ' ';

        //char charx1posleft = ' ';
        //char charx1posright = ' ';
        //char charx2posleft = ' ';
        //char charx2posright = ' ';
        //char charx3posleft = ' ';
        //char charx3posright = ' ';

        xlength = x.Length;
        x1length = x1.Length;
        x2length = x2.Length;
        x3length = x3.Length;




        //random stuff

        // int randup = 5;
        int randdown = 6;

        int randleft = 6;
        // int randright = 4;


        Random rnd = new Random();
        int rbotpos = rnd.Next(0, 11); // 0...10
        int rbotposy = rnd.Next(0, 11); //0...10


        /*


        ***********************************
        *           WARNING !!!           *
        ***********************************

        No "ismsg" is added becareful if u add xp and level or someother stuff

        */


        ConsoleKeyInfo cki = new ConsoleKeyInfo();
        do
        {
            //bot scan for tiles in the whole map
            //scan finish 'F'

            //scan x
            if (botscanfinish != 'F')
            {
                while (botscanfinish != 'F' && botscanfinishposx < xlength - 1)
                {
                    botscanfinishposx++;
                    botscanfinish = x[botscanfinishposx];
                }
            }

            //scan x1
            if (botscanfinish != 'F')
            {
                botscanfinishposx = -1;
                botscanfinishposy = 1;

                while (botscanfinish != 'F' && botscanfinishposx < x1length - 1)
                {
                    botscanfinishposx++;
                    botscanfinish = x1[botscanfinishposx];
                }
            }

            //scan x2
            if (botscanfinish != 'F')
            {
                botscanfinishposx = -1;
                botscanfinishposy = 2;

                while (botscanfinish != 'F' && botscanfinishposx < x2length - 1)
                {
                    botscanfinishposx++;
                    botscanfinish = x2[botscanfinishposx];
                }
            }

            //scan x3
            if (botscanfinish != 'F')
            {
                botscanfinishposx = -1;
                botscanfinishposy = 3;

                while (botscanfinish != 'F' && botscanfinishposx < x3length - 1)
                {
                    botscanfinishposx++;
                    botscanfinish = x3[botscanfinishposx];
                }
            }



            //change prefered direction towards found tile
            //testy change every move
            //shoudl maybe do change from spawn


            if (botscanfinishposx < pos)
            {
                if (randleft < 10)
                {
                    randleft = 6;
                    randleft++;
                }
            }
            else
            {
                if (randleft > 0)
                {
                    randleft = 6;
                    randleft--;
                }
            }








            //die
            if (die == true)
            {
                posy = spawny;
                pos = spawnx;
                msg = "you died!";

                die = false;




                if (botalive)
                {
                    botdeaths++;
                }
                else
                {
                    deaths++;
                }

            }



            //msg
            if (msg != "")
            {
                i50++;
                if (i50 > 200)
                {
                    msg = "";
                    i50 = 0;
                }
            }


            //reset the map

            //reset x
            while (i < xlength)
            {
                x[i] = ' ';
                i++;
            }
            i = 0;
            //reset x1
            while (i1 < x1length)
            {
                x1[i1] = ' ';
                i1++;
            }
            i1 = 0;
            //reset x2
            while (i2 < x2length)
            {
                x2[i2] = ' ';
                i2++;
            }
            i2 = 0;
            //reset x3
            while (i3 < x3length)
            {
                x3[i3] = ' ';
                i3++;
            }
            i3 = 0;

            //show the player
            if (posy == 0)
            {
                if (pos > -1 && pos < xlength)
                    x[pos] = skin;
            }
            else if (posy == 1)
            {
                if (pos > -1 && pos < x1length)
                    x1[pos] = skin;
            }
            else if (posy == 2)
            {
                if (pos > -1 && pos < x2length)
                    x2[pos] = skin;
            }
            else if (posy == 3)
            {
                if (pos > -1 && pos < x3length)
                    x3[pos] = skin;
            }


            //obsatclzz
            //old anolog ._.   working on new shit!
            /*
            //show test
            x[5] = '+';

            //test kill
            if (posy == 0 && pos == 5)
                die = true;
            */

            //new shit o.O

            //show '+'
            /* 
            //x
            x[xposdeath] = '+';
            x[xpos1death] = '+';
            x[xpos2death] = '+';
            x[xpos3death] = '+';
            //x1
            x1[x1posdeath] = '+';
            x1[x1pos1death] = '+';
            x1[x1pos2death] = '+';
            //x2
            x2[x2posdeath] = '+';
            x2[x2pos1death] = '+';
            x2[x2pos2death] = '+';
            x2[x2pos3death] = '+';
            */

            //x
            x[1] = '+';
            x[6] = '+';
            x[7] = '+';
            x[8] = '+';
            x[9] = '+';
            x[10] = '+';
            x[11] = '+';
            x[12] = '+';
            x[13] = '+';
            x[14] = '+';
            x[17] = '+';
            x[19] = '+';
            x[21] = '+';
            x[23] = '+';
            //x1
            x1[11] = '+';
            x1[21] = '+';
            x1[23] = '+';
            x1[36] = '+';
            //x2
            x2[6] = '+';
            x2[7] = '+';
            x2[8] = '+';
            x2[9] = '+';
            x2[13] = '+';
            x2[14] = '+';
            x2[17] = '+';
            x2[19] = '+';
            x2[0] = '+';
            x2[3] = '+';
            x2[36] = '+';
            x2[33] = '+';
            //x3
            x3[6] = '+';
            x3[14] = '+';
            x3[17] = '+';
            x3[19] = '+';
            x3[21] = '+';
            x3[23] = '+';
            x3[0] = '+';
            x3[1] = '+';
            x3[3] = '+';
            x3[33] = '+';


            //show finish

            x1[2] = 'F';

            //finish game

            if (pos == 2 && posy == 1)
            {
                msg = "you finished!";
                finishes++;
                pos = spawnx;
                posy = spawny;

                if (botalive)
                {

                    Char[] path_shortest_char = (Char[])path_shortest.ToArray(typeof(char));
                    Char[] path_new_char = (Char[])path_new.ToArray(typeof(char));


                    path_shortest_length = path_shortest_char.Length;
                    path_new_length = path_new_char.Length;

                    int path_new_clear_length = path_new_length;


                    if (path_shortest_length == 0 || path_shortest_length < path_new_length)
                    {
                        path_shortest = path_new;
                    }

                    while (path_new_clear_length > 0)
                    {
                        path_new.Remove('l');
                        path_new.Remove('r');
                        path_new.Remove('u');
                        path_new.Remove('d');

                        path_new_clear_length--;
                    }
                }

            }



            //kill (old)


            //new testy kill on move using char inputs :)  ** didnt startet yet **

            /*
            if (posy == 0) //x
            {
                if (pos == xposdeath || pos == xpos1death || pos == xpos2death || pos == xpos3death)
                    die = true;
            }
            else if (posy == 1) //x1
            {
                if (pos == x1posdeath ||pos == x1pos1death || pos == x1pos2death)
                    die = true;
            }
            else if (posy == 2) //x2
            {
                if (pos == x2posdeath || pos == x2posdeath || pos == x2pos2death || pos == x2pos3death)
                    die = true;
            }
            else if (posy == 3) //x3
            {

            }

             */



            //umfeld erkennung
            //left right
            if (posy == 0)
            {
                xposleft = pos - 1;
                xposright = pos + 1;

                x1posleft = -2;
                x1posright = -2;
                x2posleft = -2;
                x2posright = -2;
                x3posleft = -2;
                x3posright = -2;
            }
            else if (posy == 1)
            {
                x1posleft = pos - 1;
                x1posright = pos + 1;

                xposleft = -2;
                xposright = -2;
                x2posleft = -2;
                x2posright = -2;
                x3posleft = -2;
                x3posright = -2;
            }
            else if (posy == 2)
            {
                x2posleft = pos - 1;
                x2posright = pos + 1;

                xposleft = -2;
                xposright = -2;
                x1posleft = -2;
                x1posright = -2;
                x3posleft = -2;
                x3posright = -2;
            }
            else if (posy == 3)
            {
                x3posleft = pos - 1;
                x3posright = pos + 1;

                xposleft = -2;
                xposright = -2;
                x1posleft = -2;
                x1posright = -2;
                x2posleft = -2;
                x2posright = -2;
            }


            //still left and right
            //choose the shown & used one:
            //x
            if (xposleft != -2 && xposright != -2)
            {

                //left
                if (xposleft == -1)
                {
                    charxposleft = '@';
                }
                else
                {
                    charxposleft = x[xposleft];
                }

                //right
                if (xposright > xlength - 1)
                {
                    charxposright = '@';
                }
                else
                {
                    charxposright = x[xposright];
                }
            }
            //x1
            if (x1posleft != -2 && x1posright != -2)
            {

                //left
                if (x1posleft == -1)
                {
                    charxposleft = '@';
                }
                else
                {
                    charxposleft = x1[x1posleft];
                }

                //right
                if (x1posright > xlength - 1)
                {
                    charxposright = '@';
                }
                else
                {
                    charxposright = x1[x1posright];
                }
            }
            //x2
            if (x2posleft != -2 && x2posright != -2)
            {

                //left
                if (x2posleft == -1)
                {
                    charxposleft = '@';
                }
                else
                {
                    charxposleft = x2[x2posleft];
                }

                //right
                if (x2posright > xlength - 1)
                {
                    charxposright = '@';
                }
                else
                {
                    charxposright = x2[x2posright];
                }
            }
            //x3
            if (x3posleft != -2 && x3posright != -2)
            {

                //left
                if (x3posleft == -1)
                {
                    charxposleft = '@';
                }
                else
                {
                    charxposleft = x3[x3posleft];
                }

                //right
                if (x3posright > xlength - 1)
                {
                    charxposright = '@';
                }
                else
                {
                    charxposright = x3[x3posright];
                }
            }

            //umfeld erkennung up and down
            if (posy == 0)
            {
                charxposup = x1[pos];
                charxposdown = '#';
            }
            else if (posy == 1)
            {
                charxposup = x2[pos];
                charxposdown = x[pos];
            }
            else if (posy == 2)
            {
                charxposup = x3[pos];
                charxposdown = x1[pos];
            }
            else if (posy == 3)
            {
                charxposup = '#';
                charxposdown = x2[pos];
            }

            /*
            Char[] path_shortest_char2 = (Char[])path_shortest.ToArray(typeof(char));
            Char[] path_new_char2 = (Char[])path_new.ToArray(typeof(char));

            path_new_length = path_new_char2.Length;
            path_shortest_length = path_shortest_char2.Length;


            */

            //print the map
            Console.Clear();
            //Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            //Console.WriteLine("charpathlength: {0} pathstepcounter: {1}", charpathlength, pathstepcounter);

            Console.WriteLine("path_shortest_length: {0}", path_shortest_length);
            Console.WriteLine("path_new_length: {0}", path_new_length);




            Console.WriteLine("botspeed: {0}", botspeed);
            Console.WriteLine("##################################################");
            Console.WriteLine(x3);
            Console.WriteLine(x2);
            Console.WriteLine(x1);
            Console.WriteLine(x);
            Console.WriteLine("##################################################");
            Console.WriteLine("pos: ({0}|{1}) l: {2} r: {3} u: {4} d: {5} botdeaths: {6} deaths: {7}", pos, posy, charxposleft, charxposright, charxposup, charxposdown, botdeaths, deaths);
            Console.WriteLine("pos finish: ({0}|{1})", botscanfinishposx, botscanfinishposy);
            Console.WriteLine("finishes: {0}", finishes);
            //PrintValues(path, '\t');
            Console.WriteLine("{0}", msg);



            if (botalive == false)
            {
                while (Console.KeyAvailable == false)
                    Thread.Sleep(1); // Loop until input is entered.
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (posy < 3)
                            posy++;

                        if (charxposup == '+')
                        {
                            die = true;
                        }


                        break;
                    case ConsoleKey.DownArrow:
                        if (posy > 0)
                            posy--;

                        if (charxposdown == '+')
                        {
                            die = true;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (pos < xlength - 1)
                            pos++;

                        if (charxposright == '+')
                        {
                            die = true;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (pos > 0)
                            pos--;

                        if (charxposleft == '+')
                        {
                            die = true;
                        }
                        break;
                    case ConsoleKey.K:
                        die = true;
                        break;
                    case ConsoleKey.T:
                        input = Console.ReadLine();
                        if (input == "exit")
                        {
                            Console.Clear();
                            Console.WriteLine("exit");
                        }
                        else if (input == "bot")
                        {
                            botalive = true;
                            msg = "bot...";
                        }
                        else if (input == "path 0")
                        {
                            followpath = false;
                        }
                        else if (input == "path 1")
                        {
                            followpath = true;
                        }
                        else if (input == "test")
                        {
                            Console.Clear();
                            Console.WriteLine("################ STARZING TESTS ##############");
                            i++;
                            Console.WriteLine("THIS IS FUCKING INTEGEAR : {0}", i);
                            i++;
                            Console.WriteLine("THIS IS FUCKING INTEGEAR : {0}", i);
                            i++;
                            Console.WriteLine("THIS IS FUCKING INTEGEAR : {0}", i);
                            i++;
                            i++;

                            Console.WriteLine("THIS IS FUCKING INTEGEAR : {0}", i);
                            Console.WriteLine("THIS IS FUCKING INTEGEAR : {0}", i);
                            i++;
                            Console.WriteLine("THIS IS FUCKING INTEGEAR : {0}", i);
                            i++;
                            Console.WriteLine("THIS IS FUCKING INTEGEAR : {0}", i);
                            i++;
                            Console.WriteLine("THIS IS FUCKING INTEGEAR : {0}", i);

                        }
                        else if (input == "info")
                        {
                            Console.Clear();
                            Console.WriteLine("INFO");
                        }
                        else
                        {
                            Console.WriteLine("UKNMDK");
                            msg = "unknown command type 'info' for more infos.";
                        }
                        break;
                }
            }
            else
            {




                if (followpath == true)
                {


                    Char[] charpath = (Char[])path.ToArray(typeof(char));

                    charpathlength = charpath.Length;




                    if (charpathlength - 1 > pathstepcounter)
                    {
                        pathstepcounter++;
                    }
                    else
                    {
                        //followpath = false;
                        //msg = "path ended.";
                        msg = "path ended. restarting path...";
                        pathstepcounter = 0;
                    }

                    if (charpath[pathstepcounter] == 'l')
                    {
                        if (pos > 0)
                        {
                            if (charxposleft != '+')
                            {
                                pos--;
                            }
                            else
                            {
                                msg = "bot detected kill tile! and stopped moving left (bad path lul)";
                            }
                        }
                    }
                    else if (charpath[pathstepcounter] == 'r')
                    {
                        if (pos < xlength - 1)
                        {
                            if (charxposright != '+')
                            {
                                pos++;
                            }
                            else
                            {
                                msg = "bot detected kill tile! and stopped moving right (bad path lul)";
                            }
                        }
                    }
                    else if (charpath[pathstepcounter] == 'u')
                    {
                        if (posy < 3)
                        {
                            if (charxposup != '+')
                            {
                                posy++;
                            }
                            else
                            {
                                msg = "bot detected kill tile! and stopped moving up (bad path lul)";
                            }
                        }
                    }
                    else if (charpath[pathstepcounter] == 'd')
                    {
                        if (posy > 0)
                        {
                            if (charxposdown != '+')
                            {
                                posy--;
                            }
                            else
                            {
                                msg = "bot detected kill tile! and stopped moving down (bad path lul)";
                            }
                        }
                    }
                    else
                    {
                        msg = "error: uknown moving syntax use: l, r, u & d";
                    }
                }
                else   //no path
                {
                    if (botmoveswap == true)
                    {



                        //randombot move generation left and right
                        rbotpos = rnd.Next(0, 11);

                        botmoveswap = false;


                        //left right
                        if (rbotpos < randleft)  //left
                        {
                            if (pos > 0)
                            {
                                if (charxposleft != '+')
                                {
                                    pos--;
                                    path_new.Add('l');
                                }
                                else
                                {
                                    msg = "bot detected kill tile! and stopped moving left";
                                }
                            }
                        }
                        else //right
                        {
                            if (pos < xlength - 1)
                            {
                                if (charxposright != '+')
                                {
                                    pos++;
                                    path_new.Add('r');
                                }
                                else
                                {
                                    msg = "bot detected kill tile! and stopped moving right";
                                }
                            }
                        }
                    }
                    else
                    {

                        //randombot move generation up and down
                        rbotposy = rnd.Next(0, 11);

                        botmoveswap = true;

                        //up down
                        if (rbotposy < randdown) //Down
                        {
                            if (posy > 0)
                            {
                                if (charxposdown != '+')
                                {
                                    posy--;
                                    path_new.Add('d');
                                }
                                else
                                {
                                    msg = "bot detected kill tile! and stopped moving down";
                                }
                            }
                        }
                        else  //up
                        {
                            if (posy < 3)
                            {
                                if (charxposup != '+')
                                {
                                    posy++;
                                    path_new.Add('u');
                                }
                                else
                                {
                                    msg = "bot detected kill tile! and stopped moving up";
                                }
                            }
                        }






                    }
                }


                /*  acceleration
                if (botspeed > 0)
                 botspeed--;
                */

                Thread.Sleep(botspeed);
            }

        } while (cki.Key != ConsoleKey.X);

    }

    public static void PrintValues(IEnumerable myList, char mySeparator)
    {
        foreach (Object obj in myList)
            Console.Write(" {0}", obj);
        Console.WriteLine();
    }

}

