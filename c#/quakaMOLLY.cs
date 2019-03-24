using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAKAmolly
{
    class Program
    {
        static void Main(string[] args)
        {

            //Plaanned:
            /*

            add a two demensional array for bullets to have much more bullets
            1 array for each player 
            like its used for blocks

            */



            //var init
            //General Vars:
            int block_amount = 50;
            string player_block_skin = "O";
            int r = 0; //return int for fake funcs
            int i = 0; //is used for many iterative stuff just reset it to 0 before u use it :) dont use it over tick rofl
            int i2 = 0; //used as b just better name rofl
            int b = 0; //used as an "i" but i is need tehrer also so its b to count blocks
            int info_hud = 0;
            string map_border = "#"; //pretty similar shit as "world_border" but only used in maps not outside to prevnt bugsis
            string world_border = "-";
            int world_w = 50;
            int world_h = 10;
            string[,] world = new string[world_w, world_h];
            string[] collision_tiles = new string[3];
            collision_tiles[0] = "O";
            collision_tiles[1] = "2";
            collision_tiles[2] = "#";
            //collision_tiles[3] = "!";
            int i_border = 0;
            int i_x, i_y;
            i_x = 0;
            i_y = 0;
            //##############
            //Player[1] vars
            //##############
            int blocks_placed_p1 = 0;
            int max_ammo_p1 = 15;
            int bullets_fired_p1 = 0; //count how many bullets the player has fired used at Spacebar
            int score_p1 = 0;
            int respawn_delay_p1 = 0;
            bool isAlive_p1 = true;
            string bullet_skin_p1 = "*";
            int fire_dir_p1 = 0;
            int fire_state_p1 = 0; // 0 = not shooting   > 0 = firing
            int direction_p1 = 0; //x = 1 y = 2
            string player_skin_p1 = "§";
            int spawnX_p1 = 3;
            int spawnY_p1 = 3;
            int[,] bullet_info_p1 = new int[16, 5];     //BulletIndex BulletAlive BulletPosX BulletPosY BulletDirection
            //indexing
            bullet_info_p1[0, 0] = 0;
            bullet_info_p1[1, 0] = 1;
            bullet_info_p1[2, 0] = 2;
            bullet_info_p1[3, 0] = 3;
            bullet_info_p1[4, 0] = 4;
            bullet_info_p1[5, 0] = 5;
            bullet_info_p1[6, 0] = 6;
            bullet_info_p1[7, 0] = 7;
            bullet_info_p1[8, 0] = 8;
            bullet_info_p1[9, 0] = 9;
            bullet_info_p1[10, 0] = 10;
            bullet_info_p1[11, 0] = 11;
            bullet_info_p1[12, 0] = 12;
            bullet_info_p1[13, 0] = 13;
            bullet_info_p1[14, 0] = 14;
            bullet_info_p1[15, 0] = 15;
            //set all bullets to dead
            bullet_info_p1[0, 1] = 0;
            bullet_info_p1[1, 1] = 0;
            bullet_info_p1[2, 1] = 0;
            bullet_info_p1[3, 1] = 0;
            bullet_info_p1[4, 1] = 0;
            bullet_info_p1[5, 1] = 0;
            bullet_info_p1[6, 1] = 0;
            bullet_info_p1[7, 1] = 0;
            bullet_info_p1[8, 1] = 0;
            bullet_info_p1[9, 1] = 0;
            bullet_info_p1[10, 1] = 0;
            bullet_info_p1[11, 1] = 0;
            bullet_info_p1[12, 1] = 0;
            bullet_info_p1[13, 1] = 0;
            bullet_info_p1[14, 1] = 0;
            bullet_info_p1[15, 1] = 0;
            int[,] block_info_p1 = new int[block_amount, 4];      //blockIndex BlockAlive(lvl) BlockPosX BlockPosY
            //indexing
            //block_info_p1[0, 0] = 0;
            //block_info_p1[1, 0] = 1;
            //block_info_p1[2, 0] = 2;
            //block_info_p1[3, 0] = 3;
            //block_info_p1[4, 0] = 4;
            //block_info_p1[5, 0] = 5;
            //block_info_p1[6, 0] = 6;
            //block_info_p1[7, 0] = 7;
            //block_info_p1[8, 0] = 8;
            //block_info_p1[9, 0] = 9;
            //indexing smart heuueueue
            i = 0;
            while (i < block_amount)
            {
                block_info_p1[i, 0] = i;
                i++;
            }
            //set all blocks to dead(lvl0)
            //block_info_p1[0, 1] = 0;
            //block_info_p1[1, 1] = 0;
            //block_info_p1[2, 1] = 0;
            //block_info_p1[3, 1] = 0;
            //block_info_p1[4, 1] = 0;
            //block_info_p1[5, 1] = 0;
            //block_info_p1[6, 1] = 0;
            //block_info_p1[7, 1] = 0;
            //block_info_p1[8, 1] = 0;
            //block_info_p1[9, 1] = 0;
            //smarter way
            i = 0;
            while (i < block_amount)
            {
                block_info_p1[i, 1] = 0;
                i++;
            }
            int[,] pos_bullet_p1 = new int[1, 2];
            int[,] pos_p1 = new int[1, 2];
            pos_p1[0, 0] = spawnX_p1;
            pos_p1[0, 1] = spawnY_p1;
            //##############
            //Player[2] vars
            //##############
            int blocks_placed_p2 = 0;
            int max_ammo_p2 = 15;
            int bullets_fired_p2 = 0; //count how many bullets the player has fired used at Spacebar
            int score_p2 = 0;
            int respawn_delay_p2 = 0;
            bool isAlive_p2 = true;
            string bullet_skin_p2 = "*";
            int fire_dir_p2 = 0;
            int fire_state_p2 = 0; // 0 = not shooting   > 0 = firing
            int direction_p2 = 0; //x = 1 y = 2
            string player_skin_p2 = "@";
            int spawnX_p2 = 46;
            int spawnY_p2 = 7;
            int[,] bullet_info_p2 = new int[16, 5];     //BulletIndex BulletAlive BulletPosX BulletPosY BulletDirection
            //indexing
            bullet_info_p2[0, 0] = 0;
            bullet_info_p2[1, 0] = 1;
            bullet_info_p2[2, 0] = 2;
            bullet_info_p2[3, 0] = 3;
            bullet_info_p2[4, 0] = 4;
            bullet_info_p2[5, 0] = 5;
            bullet_info_p2[6, 0] = 6;
            bullet_info_p2[7, 0] = 7;
            bullet_info_p2[8, 0] = 8;
            bullet_info_p2[9, 0] = 9;
            bullet_info_p2[10, 0] = 10;
            bullet_info_p2[11, 0] = 11;
            bullet_info_p2[12, 0] = 12;
            bullet_info_p2[13, 0] = 13;
            bullet_info_p2[14, 0] = 14;
            bullet_info_p2[15, 0] = 15;
            //set all bullets to dead
            bullet_info_p2[0, 1] = 0;
            bullet_info_p2[1, 1] = 0;
            bullet_info_p2[2, 1] = 0;
            bullet_info_p2[3, 1] = 0;
            bullet_info_p2[4, 1] = 0;
            bullet_info_p2[5, 1] = 0;
            bullet_info_p2[6, 1] = 0;
            bullet_info_p2[7, 1] = 0;
            bullet_info_p2[8, 1] = 0;
            bullet_info_p2[9, 1] = 0;
            bullet_info_p2[10, 1] = 0;
            bullet_info_p2[11, 1] = 0;
            bullet_info_p2[12, 1] = 0;
            bullet_info_p2[13, 1] = 0;
            bullet_info_p2[14, 1] = 0;
            bullet_info_p2[15, 1] = 0;
            int[,] block_info_p2 = new int[block_amount, 4];      //blockIndex BlockAlive(lvl) BlockPosX BlockPosY
            //indexing
            i = 0;
            while (i < block_amount)
            {
                block_info_p2[i, 0] = i;
                i++;
            }
            //set all blocks to dead(lvl0)
            i = 0;
            while (i < block_amount)
            {
                block_info_p2[i, 1] = 0;
                i++;
            }
            int[,] pos_bullet_p2 = new int[1, 2];
            int[,] pos_p2 = new int[1, 2];
            pos_p2[0, 0] = spawnX_p2;
            pos_p2[0, 1] = spawnY_p2;



            //dunno what dis does commentet it out xD
            //while (i_x < world_w)
            //{
            //    while (i_y < world_h)
            //    {
            //        world[i_x, i_y] = "+";
            //        i_y++;
            //    }
            //    i_x++;
            //}

            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {

                while (Console.KeyAvailable == false)
                    Thread.Sleep(1); // Loop until input is entered.
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.B:
                        if (blocks_placed_p1 < block_amount)
                        {
                            if (direction_p1 == -1) //left
                            {
                                i = 0;
                                r = -1; //retruns block id
                                while (i < block_amount) // block amount
                                {
                                    if (block_info_p1[i, 2] == pos_p1[0, 0] - 1 && block_info_p1[i, 3] == pos_p1[0, 1] && block_info_p1[i, 1] > 0) //same pos and block alive
                                    {
                                        r = i; //return the id of the block
                                    }
                                    i++;
                                }

                                if (r != -1)
                                {
                                    block_info_p1[r, 1]++;
                                }
                                else
                                {
                                    block_info_p1[blocks_placed_p1, 1] = 1; //set block to alive
                                                                            //set block pos 
                                    block_info_p1[blocks_placed_p1, 2] = pos_p1[0, 0] - 1; //x
                                    block_info_p1[blocks_placed_p1, 3] = pos_p1[0, 1];     //y
                                }
                            }
                            else if (direction_p1 == 1) //right
                            {
                                i = 0;
                                r = -1; //retruns block id
                                while (i < block_amount) // block amount
                                {
                                    if (block_info_p1[i, 2] == pos_p1[0, 0] + 1 && block_info_p1[i, 3] == pos_p1[0, 1] && block_info_p1[i, 1] > 0) //same pos and block alive
                                    {
                                        r = i; //return the id of the block
                                    }
                                    i++;
                                }

                                if (r != -1)
                                {
                                    block_info_p1[r, 1]++;
                                }
                                else
                                {
                                    block_info_p1[blocks_placed_p1, 1] = 1; //set block to alive
                                                                            //set block pos 
                                    block_info_p1[blocks_placed_p1, 2] = pos_p1[0, 0] + 1; //x
                                    block_info_p1[blocks_placed_p1, 3] = pos_p1[0, 1];     //y
                                }
                            }
                            else if (direction_p1 == -2) //up
                            {
                                i = 0;
                                r = -1; //retruns block id
                                while (i < block_amount) // block amount
                                {
                                    if (block_info_p1[i, 2] == pos_p1[0, 0] && block_info_p1[i, 3] == pos_p1[0, 1] - 1 && block_info_p1[i, 1] > 0) //same pos and block alive
                                    {
                                        r = i; //return the id of the block
                                    }
                                    i++;
                                }

                                if (r != -1)
                                {
                                    block_info_p1[r, 1]++;
                                }
                                else
                                {
                                    block_info_p1[blocks_placed_p1, 1] = 1; //set block to alive
                                                                            //set block pos 
                                    block_info_p1[blocks_placed_p1, 2] = pos_p1[0, 0]; //x
                                    block_info_p1[blocks_placed_p1, 3] = pos_p1[0, 1] - 1;     //y
                                }
                            }
                            else if (direction_p1 == 2) //down
                            {
                                i = 0;
                                r = -1; //retruns block id
                                while (i < block_amount) // block amount
                                {
                                    if (block_info_p1[i, 2] == pos_p1[0, 0] && block_info_p1[i, 3] == pos_p1[0, 1] + 1 && block_info_p1[i, 1] > 0) //same pos and block alive
                                    {
                                        r = i; //return the id of the block
                                    }
                                    i++;
                                }

                                if (r != -1)
                                {
                                    block_info_p1[r, 1]++;
                                }
                                else
                                {
                                    block_info_p1[blocks_placed_p1, 1] = 1; //set block to alive
                                                                            //set block pos 
                                    block_info_p1[blocks_placed_p1, 2] = pos_p1[0, 0]; //x
                                    block_info_p1[blocks_placed_p1, 3] = pos_p1[0, 1] + 1;     //y
                                }
                            }
                            blocks_placed_p1++;
                        }
                        break;
                    case ConsoleKey.P: //place blocks
                        if (blocks_placed_p2 < block_amount)
                        {
                            if (direction_p2 == -1) //left
                            {
                                i = 0;
                                r = -1; //retruns block id
                                while (i < block_amount) // block amount
                                {
                                    if (block_info_p2[i, 2] == pos_p2[0, 0] - 1 && block_info_p2[i, 3] == pos_p2[0, 1] && block_info_p2[i, 1] > 0) //same pos and block alive
                                    {
                                        r = i; //return the id of the block
                                    }
                                    i++;
                                }

                                if (r != -1)
                                {
                                    block_info_p2[r, 1]++;
                                }
                                else
                                {
                                    block_info_p2[blocks_placed_p2, 1] = 1; //set block to alive
                                                                            //set block pos 
                                    block_info_p2[blocks_placed_p2, 2] = pos_p2[0, 0] - 1; //x
                                    block_info_p2[blocks_placed_p2, 3] = pos_p2[0, 1];     //y
                                }
                            }
                            else if (direction_p2 == 1) //right
                            {
                                i = 0;
                                r = -1; //retruns block id
                                while (i < block_amount) // block amount
                                {
                                    if (block_info_p2[i, 2] == pos_p2[0, 0] + 1 && block_info_p2[i, 3] == pos_p2[0, 1] && block_info_p2[i, 1] > 0) //same pos and block alive
                                    {
                                        r = i; //return the id of the block
                                    }
                                    i++;
                                }

                                if (r != -1)
                                {
                                    block_info_p2[r, 1]++;
                                }
                                else
                                {
                                    block_info_p2[blocks_placed_p2, 1] = 1; //set block to alive
                                                                            //set block pos 
                                    block_info_p2[blocks_placed_p2, 2] = pos_p2[0, 0] + 1; //x
                                    block_info_p2[blocks_placed_p2, 3] = pos_p2[0, 1];     //y
                                }
                            }
                            else if (direction_p2 == -2) //up
                            {
                                i = 0;
                                r = -1; //retruns block id
                                while (i < block_amount) // block amount
                                {
                                    if (block_info_p2[i, 2] == pos_p2[0, 0] && block_info_p2[i, 3] == pos_p2[0, 1] - 1 && block_info_p2[i, 1] > 0) //same pos and block alive
                                    {
                                        r = i; //return the id of the block
                                    }
                                    i++;
                                }

                                if (r != -1)
                                {
                                    block_info_p2[r, 1]++;
                                }
                                else
                                {
                                    block_info_p2[blocks_placed_p2, 1] = 1; //set block to alive
                                                                            //set block pos 
                                    block_info_p2[blocks_placed_p2, 2] = pos_p2[0, 0]; //x
                                    block_info_p2[blocks_placed_p2, 3] = pos_p2[0, 1] - 1;     //y
                                }
                            }
                            else if (direction_p2 == 2) //down
                            {
                                i = 0;
                                r = -1; //retruns block id
                                while (i < block_amount) // block amount
                                {
                                    if (block_info_p2[i, 2] == pos_p2[0, 0] && block_info_p2[i, 3] == pos_p2[0, 1] + 1 && block_info_p2[i, 1] > 0) //same pos and block alive
                                    {
                                        r = i; //return the id of the block
                                    }
                                    i++;
                                }

                                if (r != -1)
                                {
                                    block_info_p2[r, 1]++;
                                }
                                else
                                {
                                    block_info_p2[blocks_placed_p2, 1] = 1; //set block to alive
                                                                            //set block pos 
                                    block_info_p2[blocks_placed_p2, 2] = pos_p2[0, 0]; //x
                                    block_info_p2[blocks_placed_p2, 3] = pos_p2[0, 1] + 1;     //y
                                }
                            }
                            blocks_placed_p2++;
                        }
                        break;
                    case ConsoleKey.O:
                        isAlive_p2 = false;
                        if (bullets_fired_p2 < 15)
                        {
                            if (bullet_info_p2[bullets_fired_p2, 1] == 0 && isAlive_p2)
                            {
                                bullet_info_p2[bullets_fired_p2, 1] = 1;
                                bullets_fired_p2++;
                            }
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        if (bullets_fired_p1 < 15)
                        {
                            if (bullet_info_p1[bullets_fired_p1, 1] == 0 && isAlive_p1)
                            {
                                bullet_info_p1[bullets_fired_p1, 1] = 1;
                                bullets_fired_p1++;
                            }
                        }
                        break;
                    case ConsoleKey.W:
                        i = 0;
                        r = 0;
                        while (i < collision_tiles.Length)
                        {
                            if (world[pos_p1[0, 0], pos_p1[0, 1] - 1] == collision_tiles[i])
                            {
                                r = 1;
                            }
                            i++;
                        }

                        if (r == 0) //no coll found
                        {
                            if (pos_p1[0, 1] > 0 && isAlive_p1)
                            {
                                pos_p1[0, 1]--;
                            }
                        }
                        direction_p1 = -2;
                        break;
                    case ConsoleKey.A:
                        i = 0;
                        r = 0;
                        while (i < collision_tiles.Length)
                        {
                            if (world[pos_p1[0, 0] - 1, pos_p1[0, 1]] == collision_tiles[i])
                            {
                                r = 1;
                            }
                            i++;
                        }

                        if (r == 0) //no coll found
                        {
                            if (pos_p1[0, 0] > 0 && isAlive_p1)
                            {
                                pos_p1[0, 0]--;
                            }
                        }
                        direction_p1 = -1;
                        break;
                    case ConsoleKey.S:
                        i = 0;
                        r = 0;
                        while (i < collision_tiles.Length)
                        {
                            if (world[pos_p1[0, 0], pos_p1[0, 1] + 1] == collision_tiles[i])
                            {
                                r = 1;
                            }
                            i++;
                        }

                        if (r == 0) //no coll found
                        {
                            if (pos_p1[0, 1] < world_h - 1 && isAlive_p1)
                            {
                                pos_p1[0, 1]++;
                            }
                        }
                        direction_p1 = 2;
                        break;
                    case ConsoleKey.D:
                        i = 0;
                        r = 0;
                        while (i < collision_tiles.Length)
                        {
                            if (world[pos_p1[0, 0] + 1, pos_p1[0, 1]] == collision_tiles[i])
                            {
                                r = 1;
                            }
                            i++;
                        }

                        if (r == 0) //no coll found
                        {
                            if (pos_p1[0, 0] < world_w - 1 && isAlive_p1)
                            {
                                pos_p1[0, 0]++;
                            }
                        }
                        direction_p1 = 1;
                        break;
                    case ConsoleKey.RightArrow:
                        i = 0;
                        r = 0;
                        while (i < collision_tiles.Length)
                        {
                            if (world[pos_p2[0, 0] + 1, pos_p2[0, 1]] == collision_tiles[i])
                            {
                                r = 1;
                            }
                            i++;
                        }

                        if (r == 0) //no coll found
                        {
                            if (pos_p2[0, 0] < world_w - 1)
                            {
                                pos_p2[0, 0]++;
                            }
                        }
                        direction_p2 = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        i = 0;
                        r = 0;
                        while (i < collision_tiles.Length)
                        {
                            if (world[pos_p2[0, 0] - 1, pos_p2[0, 1]] == collision_tiles[i])
                            {
                                r = 1;
                            }
                            i++;
                        }

                        if (r == 0) //no coll found
                        {
                            if (pos_p2[0, 0] > 0)
                            {
                                pos_p2[0, 0]--;
                            }
                        }
                        direction_p2 = -1;
                        break;
                    case ConsoleKey.UpArrow:
                        i = 0;
                        r = 0;
                        while (i < collision_tiles.Length)
                        {
                            if (world[pos_p2[0, 0], pos_p2[0, 1] - 1] == collision_tiles[i])
                            {
                                r = 1;
                            }
                            i++;
                        }

                        if (r == 0) //no coll found
                        {
                            if (pos_p2[0, 1] > 0)
                            {
                                pos_p2[0, 1]--;
                            }
                        }
                        direction_p2 = -2;
                        break;
                    case ConsoleKey.DownArrow:
                        i = 0;
                        r = 0;
                        while (i < collision_tiles.Length)
                        {
                            if (world[pos_p2[0, 0], pos_p2[0, 1] + 1] == collision_tiles[i])
                            {
                                r = 1;
                            }
                            i++;
                        }

                        if (r == 0) //no coll found
                        {
                            if (pos_p2[0, 1] < world_h - 1)
                            {
                                pos_p2[0, 1]++;
                            }
                        }
                        direction_p2 = 2;
                        break;
                    case ConsoleKey.T:
                        string input = Console.ReadLine();
                        if (input == "test")
                        {
                            Console.WriteLine("test failed.");
                        }
                        else if (input == "info 1")
                        {
                            info_hud = 1;
                        }
                        else
                        {
                            Console.WriteLine("unknown cumannd press cmdlist hepp info pfor more hölp! \n ROFL");
                        }
                        break;
                }
                //HUGE NEW FIRE PROJECT!
                //using an twodemensional int array for 16 bullets for player 1
                //all stuff is checked in this fire project: bullet hits on player and on blocks
                //STRUCT:
                //move
                //check for hit and delet hittet stuff
                //delete bullet if hit
                //Player[1]
                //iterate trough all bullets and check whats going on
                i = 0;
                while (i < 16) //16 bullets for player 1
                {
                    //first check if the bullet is alive
                    if (bullet_info_p1[i, 1] > 0)
                    {
                        if (bullet_info_p1[i, 1] == 1) //start shooting get player pos
                        {
                            bullet_info_p1[i, 2] = pos_p1[0, 0]; //x
                            bullet_info_p1[i, 3] = pos_p1[0, 1]; //y
                            bullet_info_p1[i, 4] = direction_p1; //dir
                        }

                        if (bullet_info_p1[i, 4] == -2) //up
                        {
                            bullet_info_p1[i, 3]--;
                        }
                        else if (bullet_info_p1[i, 4] == 2) //down
                        {
                            bullet_info_p1[i, 3]++;
                        }
                        else if (bullet_info_p1[i, 4] == -1) //left
                        {
                            bullet_info_p1[i, 2]--;
                        }
                        else if (bullet_info_p1[i, 4] == 1) //right
                        {
                            bullet_info_p1[i, 2]++;
                        }

                        //check bullet hittin stuff (deleting stuff)
                        //check for bullet hittin a destroyabel block
                        //check for blocks player1 blocks
                        b = 0;
                        while (b < block_amount) //iterate trough all blocks 
                        {
                            //   isAlive                    BulletP1 X                                    BulletP1 Y                                 || same stuff for player 2
                            if (block_info_p1[b, 1] > 0 && block_info_p1[b, 2] == bullet_info_p1[i, 2] && block_info_p1[b, 3] == bullet_info_p1[i, 3] /*|| block_info_p2[b, 1] > 0 && block_info_p2[b, 2] == bullet_info_p2[i,2] && block_info_p1[b, 3] == bullet_info_p2[i,3]*/)
                            {
                                block_info_p1[b, 1]--; //remove 1 block
                            }
                            b++;
                        }

                        //check for blocks player2 blocks
                        b = 0;
                        while (b < block_amount) //iterate trough all blocks 
                        {
                            //   isAlive                    BulletP1 X                                    BulletP1 Y                                 || same stuff for player 2
                            if (block_info_p2[b, 1] > 0 && block_info_p2[b, 2] == bullet_info_p1[i, 2] && block_info_p2[b, 3] == bullet_info_p1[i, 3] /*|| block_info_p2[b, 1] > 0 && block_info_p2[b, 2] == bullet_info_p2[i,2] && block_info_p1[b, 3] == bullet_info_p2[i,3]*/)
                            {
                                block_info_p2[b, 1]--; //remove 1 block
                            }
                            b++;
                        }

                        //check bullet hittin player2 (deletin player2)
                        if (bullet_info_p1[i, 2] == pos_p2[0, 0] && bullet_info_p1[i, 3] == pos_p2[0, 1] && isAlive_p2)
                        {
                            isAlive_p2 = false;
                            score_p1++;
                        }

                        //check bullet hittin stuff (deleting bullet)

                        //fakefunction:
                        // check for bullet hittin collision

                        if (world[bullet_info_p1[i, 2], bullet_info_p1[i, 3]] == player_block_skin || world[bullet_info_p1[i, 2], bullet_info_p1[i, 3]] == "#")
                        {
                            bullet_info_p1[i, 1] = 0;
                        }
                        else
                        {
                            bullet_info_p1[i, 1]++; //++fire_state
                        }


                    }
                    i++;
                }
                //check for reload
                if (bullets_fired_p1 >= max_ammo_p1)
                {
                    i = 0;
                    r = 0;
                    while (i < max_ammo_p1)
                    {
                        if (bullet_info_p1[i, 1] == 1)
                        {
                            r = 1; //alive bullet found
                        }
                        i++;
                    }

                    if (r == 0) //no alive bullets found --> reload 
                    {
                        bullets_fired_p1 = 0;
                    }
                }





                //##################
                //Shooting Player[2] p1 p1
                //##################
                //iterate trough all bullets and check whats going on
                i = 0;
                while (i < 16) //16 bullets for player 2
                {
                    //first check if the bullet is alive
                    if (bullet_info_p2[i, 1] > 0)
                    {
                        if (bullet_info_p2[i, 1] == 1) //start shooting get player pos
                        {
                            bullet_info_p2[i, 2] = pos_p2[0, 0]; //x
                            bullet_info_p2[i, 3] = pos_p2[0, 1]; //y
                            bullet_info_p2[i, 4] = direction_p2; //dir
                        }

                        if (bullet_info_p2[i, 4] == -2) //up
                        {
                            bullet_info_p2[i, 3]--;
                        }
                        else if (bullet_info_p2[i, 4] == 2) //down
                        {
                            bullet_info_p2[i, 3]++;
                        }
                        else if (bullet_info_p2[i, 4] == -1) //left
                        {
                            bullet_info_p2[i, 2]--;
                        }
                        else if (bullet_info_p2[i, 4] == 1) //right
                        {
                            bullet_info_p2[i, 2]++;
                        }

                        //check bullet hittin stuff (deleting stuff)
                        //check for bullet hittin a destroyabel block
                        //check for blocks player1 blocks
                        b = 0;
                        while (b < block_amount) //iterate trough all blocks 
                        {
                            //   isAlive                    Bulletp2 X                                    Bulletp2 Y                                 || same stuff for player 2
                            if (block_info_p2[b, 1] > 0 && block_info_p2[b, 2] == bullet_info_p2[i, 2] && block_info_p2[b, 3] == bullet_info_p2[i, 3] /*|| block_info_p1[b, 1] > 0 && block_info_p1[b, 2] == bullet_info_p1[i,2] && block_info_p2[b, 3] == bullet_info_p1[i,3]*/)
                            {
                                block_info_p2[b, 1]--; //remove 1 block
                            }
                            b++;
                        }

                        //check for blocks player2 blocks
                        b = 0;
                        while (b < block_amount) //iterate trough all blocks 
                        {
                            //   isAlive                    Bulletp2 X                                    Bulletp2 Y                                 || same stuff for player 2
                            if (block_info_p1[b, 1] > 0 && block_info_p1[b, 2] == bullet_info_p2[i, 2] && block_info_p1[b, 3] == bullet_info_p2[i, 3] /*|| block_info_p1[b, 1] > 0 && block_info_p1[b, 2] == bullet_info_p1[i,2] && block_info_p2[b, 3] == bullet_info_p1[i,3]*/)
                            {
                                block_info_p1[b, 1]--; //remove 1 block
                            }
                            b++;
                        }

                        //check bullet hittin player2 (deletin player2)
                        if (bullet_info_p2[i, 2] == pos_p1[0, 0] && bullet_info_p2[i, 3] == pos_p1[0, 1] && isAlive_p1)
                        {
                            isAlive_p1 = false;
                            score_p2++;
                        }

                        //check bullet hittin stuff (deleting bullet)

                        //fakefunction:
                        // check for bullet hittin collision

                        if (world[bullet_info_p2[i, 2], bullet_info_p2[i, 3]] == player_block_skin || world[bullet_info_p2[i, 2], bullet_info_p2[i, 3]] == "#")
                        {
                            bullet_info_p2[i, 1] = 0;
                        }
                        else
                        {
                            bullet_info_p2[i, 1]++; //++fire_state
                        }


                    }
                    i++;
                }
                //check for reload
                if (bullets_fired_p2 >= max_ammo_p2)
                {
                    i = 0;
                    r = 0;
                    while (i < max_ammo_p2)
                    {
                        if (bullet_info_p2[i, 1] == 1)
                        {
                            r = 1; //alive bullet found
                        }
                        i++;
                    }

                    if (r == 0) //no alive bullets found --> reload 
                    {
                        bullets_fired_p2 = 0;
                    }
                }














                ////Check for bullet hittin a player
                ////Player[1] getz hit
                //if (pos_p1[0,0] == pos_bullet_p2[0,0] && pos_p1[0,1] == pos_bullet_p2[0,1] && isAlive_p1)
                //{
                //    world_border = "2";
                //    isAlive_p1 = false;
                //    score_p2++;
                //}
                ////Player[2] getz hit
                //if (pos_p2[0, 0] == pos_bullet_p1[0, 0] && pos_p2[0, 1] == pos_bullet_p1[0, 1] && isAlive_p2)
                //{
                //    world_border = "1";
                //    isAlive_p2 = false;
                //    score_p1++;
                //}


                //Respawn
                //Player[1]
                if (!isAlive_p1)
                {
                    if (respawn_delay_p1 > 15)
                    {
                        isAlive_p1 = true;
                        pos_p1[0, 0] = spawnX_p1;
                        pos_p1[0, 1] = spawnY_p1;
                        respawn_delay_p1 = 0;
                        //score_p1--;
                    }
                    respawn_delay_p1++;
                }
                //Player[2]
                if (!isAlive_p2)
                {
                    if (respawn_delay_p2 > 15)
                    {
                        isAlive_p2 = true;
                        pos_p2[0, 0] = spawnX_p2;
                        pos_p2[0, 1] = spawnY_p2;
                        respawn_delay_p2 = 0;
                        //score_p2--;
                    }
                    respawn_delay_p2++;
                }

                //Check for escaping the map so early to prevent bugsis
                //Player[1]
                if (pos_p1[0, 0] < 0 || pos_p1[0, 0] > world_w - 1 || pos_p1[0, 1] < 0 || pos_p1[0, 1] > world_h - 1)
                {
                    Console.Clear();
                    Console.WriteLine("YOU DIED!");
                    pos_p1[0, 0] = spawnX_p1;
                    pos_p1[0, 1] = spawnY_p1;
                    isAlive_p1 = false;
                }
                //Player[2]
                if (pos_p2[0, 0] < 0 || pos_p2[0, 0] > world_w - 1 || pos_p2[0, 1] < 0 || pos_p2[0, 1] > world_h - 1)
                {
                    Console.Clear();
                    Console.WriteLine("YOU DIED!");
                    pos_p2[0, 0] = spawnX_p2;
                    pos_p2[0, 1] = spawnY_p2;
                    isAlive_p2 = false;
                }

                ////Bullet Fire++ stuff !
                ////Player[1]
                //if (fire_state_p1 > 0) //firing
                //{
                //    if (fire_state_p1 == 1) //shoot get fire direction
                //    {
                //        pos_bullet_p1[0, 0] = pos_p1[0, 0];
                //        pos_bullet_p1[0, 1] = pos_p1[0, 1];
                //        fire_dir_p1 = direction_p1;
                //    }
                //    //let the bullet fly in the fire_dir
                //    if (fire_dir_p1 == -2) //up
                //    {
                //        pos_bullet_p1[0, 1]--;
                //    }
                //    else if (fire_dir_p1 == 2) //down
                //    {
                //        pos_bullet_p1[0, 1]++;
                //    }
                //    else if (fire_dir_p1 == -1) //left
                //    {
                //        pos_bullet_p1[0, 0]--;
                //    }
                //    else if (fire_dir_p1 == 1) //right
                //    {
                //        pos_bullet_p1[0, 0]++;
                //    }


                //    //check for bullet hittin a destroyabel block
                //    //check for blocks
                //    //Player[1]
                //    i = 0;
                //    while (i < 10) //iterate trough all blocks (atm 10)
                //    {
                //        //   isAlive                    BulletP1 X                                    BulletP1 Y                               || same stuff for player 2
                //        if (block_info_p1[i, 1] == 1 && block_info_p1[i, 2] == pos_bullet_p1[0, 0] && block_info_p1[i, 3] == pos_bullet_p1[0, 1] || block_info_p1[i, 1] == 1 && block_info_p1[i, 2] == pos_bullet_p2[0, 0] && block_info_p1[i, 3] == pos_bullet_p2[0, 1])
                //        {
                //            block_info_p1[i, 1] = 0;
                //        }
                //        i++;
                //    }

                //    //fakefunction:
                //    // check for bullet hittin collision
                //    i = 0;
                //    r = 0;
                //    while (i < collision_tiles.Length)
                //    {
                //        if (world[pos_bullet_p1[0, 0], pos_bullet_p1[0, 1]] == collision_tiles[i])
                //        {
                //            r = 1;
                //        }
                //        i++;
                //    }


                //    //Check for deleting bullet cuz reached map end
                //    if (pos_bullet_p1[0, 0] < 0 || pos_bullet_p1[0, 0] > world_w - 1 || pos_bullet_p1[0, 1] < 0 || pos_bullet_p1[0, 1] > world_h - 1)
                //    {
                //        fire_state_p1 = 0;
                //        pos_bullet_p1[0, 0] = pos_p1[0, 0];
                //        pos_bullet_p1[0, 1] = pos_p1[0, 1];
                //    }
                //    else if (r == 1) // collision on bullet pos found
                //    {
                //        fire_state_p1 = 0;
                //        pos_bullet_p1[0, 0] = pos_p1[0, 0];
                //        pos_bullet_p1[0, 1] = pos_p1[0, 1];
                //    }
                //    else
                //    {
                //        fire_state_p1++;

                //    }
                //}
                ////Player[2]
                //if (fire_state_p2 > 0) //firing
                //{
                //    if (fire_state_p2 == 1) //shoot get fire direction
                //    {
                //        pos_bullet_p2[0, 0] = pos_p2[0, 0];
                //        pos_bullet_p2[0, 1] = pos_p2[0, 1];
                //        fire_dir_p2 = direction_p2;
                //    }
                //    //let the bullet fly in the fire_dir
                //    if (fire_dir_p2 == -2) //up
                //    {
                //        pos_bullet_p2[0, 1]--;
                //    }
                //    else if (fire_dir_p2 == 2) //down
                //    {
                //        pos_bullet_p2[0, 1]++;
                //    }
                //    else if (fire_dir_p2 == -1) //left
                //    {
                //        pos_bullet_p2[0, 0]--;
                //    }
                //    else if (fire_dir_p2 == 1) //right
                //    {
                //        pos_bullet_p2[0, 0]++;
                //    }

                //    //fakefunction:
                //    // check for bullet hittin collision
                //    i = 0;
                //    r = 0;
                //    while (i < collision_tiles.Length)
                //    {
                //        if (world[pos_bullet_p2[0, 0], pos_bullet_p2[0, 1]] == collision_tiles[i])
                //        {
                //            r = 1;
                //        }
                //        i++;
                //    }


                //    //Check for deleting bullet cuz reached map end
                //    if (pos_bullet_p2[0, 0] < 0 || pos_bullet_p2[0, 0] > world_w - 1 || pos_bullet_p2[0, 1] < 0 || pos_bullet_p2[0, 1] > world_h - 1)
                //    {
                //        fire_state_p2 = 0;
                //        pos_bullet_p2[0, 0] = pos_p2[0, 0];
                //        pos_bullet_p2[0, 1] = pos_p2[0, 1];
                //    }
                //    else if (r == 1) // collision on bullet pos found
                //    {
                //        fire_state_p2 = 0;
                //        pos_bullet_p2[0, 0] = pos_p2[0, 0];
                //        pos_bullet_p2[0, 1] = pos_p2[0, 1];
                //    }
                //    else
                //    {
                //        fire_state_p2++;

                //    }
                //}



                Console.Clear();
                if (info_hud == 1)
                {
                    Console.WriteLine("p1[{0}][{1}]     p2[{2}][{3}] dir1[{4}]", pos_p1[0, 0], pos_p1[0, 1], pos_p2[0, 0], pos_p2[0, 1], direction_p1);
                    Console.WriteLine("bulletX[{0}] bulletY[{1}]", bullet_info_p1[0, 2], bullet_info_p1[0, 3]);
                    Console.WriteLine("BlockLevel[{0}]", block_info_p1[0, 1]);
                }
                //create world
                i_x = 0;
                i_y = 0;

                while (i_y < world_h)
                {
                    while (i_x < world_w)
                    {
                        world[i_x, i_y] = " ";
                        i_x++;
                    }
                    i_x = 0;
                    i_y++;
                }

                //add inmap border testy to fuck away outy broder morder 
                //top
                i = 0;
                while (i < world_w)
                {
                    world[i, 0] = map_border;
                    i++;
                }
                //bottom
                i = 0;
                while (i < world_w)
                {
                    world[i, world_h - 1] = map_border;
                    i++;
                }
                //left
                i = 0;
                while (i < world_h)
                {
                    world[0, i] = map_border;
                    i++;
                }
                //right
                i = 0;
                while (i < world_h)
                {
                    world[world_w - 1, i] = map_border;
                    i++;
                }


                //add players:
                //Player[1]
                if (isAlive_p1)
                {
                    world[pos_p1[0, 0], pos_p1[0, 1]] = player_skin_p1;
                }
                //Player[2]
                if (isAlive_p2)
                {
                    world[pos_p2[0, 0], pos_p2[0, 1]] = player_skin_p2;
                }

                ////add bullets: (old)
                ////Player[1]
                //if (fire_state_p1 > 0)
                //{
                //    world[pos_bullet_p1[0, 0], pos_bullet_p1[0, 1]] = bullet_skin_p1;
                //}
                ////Player[2]
                //if (fire_state_p2 > 0)
                //{
                //    world[pos_bullet_p2[0, 0], pos_bullet_p2[0, 1]] = bullet_skin_p2;
                //}


                //add bullets NEW:
                //Player[1]
                //iterate trough all bullets and draw them if onfire
                i = 0;
                while (i < 15)
                {
                    if (bullet_info_p1[i, 1] > 0)
                    {
                        world[bullet_info_p1[i, 2], bullet_info_p1[i, 3]] = "+";
                    }
                    i++;
                }

                //Player[2]
                //iterate trough all bullets and draw them if onfire
                i = 0;
                while (i < 15)
                {
                    if (bullet_info_p2[i, 1] > 0)
                    {
                        world[bullet_info_p2[i, 2], bullet_info_p2[i, 3]] = "+";
                    }
                    i++;
                }




                //add obstacllz
                world[8, 1] = "#";
                world[8, 2] = "#";
                world[7, 2] = "#";
                world[6, 2] = "#";
                world[5, 2] = "#";
                world[5, 3] = "#";
                world[5, 4] = "#";
                world[5, 5] = "#";
                world[4, 5] = "#";
                world[5, 6] = "#";

                world[20, 5] = "#";
                world[20, 4] = "#";
                world[20, 3] = "#";
                world[19, 6] = "#";
                world[20, 6] = "#";
                world[21, 6] = "#";

                world[22, 8] = "#";
                world[21, 8] = "#";
                world[20, 8] = "#";


                world[40, 2] = "#";
                world[40, 4] = "#";
                world[40, 5] = "#";
                world[41, 5] = "#";
                world[47, 5] = "#";
                world[48, 5] = "#";

                //add player blocks
                //Player[1]
                //check all indexes for beeing alive and updating pos
                i = 0;
                while (i < block_amount)
                {
                    if (block_info_p1[i, 1] > 0) //0 == dead 1+ == alive
                    {
                        world[block_info_p1[i, 2], block_info_p1[i, 3]] = player_block_skin;
                    }
                    i++;
                }
                //Player[2]
                //check all indexes for beeing alive and updating pos
                i = 0;
                while (i < block_amount)
                {
                    if (block_info_p2[i, 1] > 0) //0 == dead 1+ == alive
                    {
                        world[block_info_p2[i, 2], block_info_p2[i, 3]] = player_block_skin;
                    }
                    i++;
                }

                //print world
                i_x = 0;
                i_y = 0;
                //i_border = 0;

                //while (i_border < world_w + 2)
                //{
                //    Console.Write(world_border);
                //    i_border++;
                //}
                Console.Write("\n");
                //i_border = 0;
                while (i_y < world_h)
                {
                    //Console.Write(world_border);
                    while (i_x < world_w)
                    {
                        Console.Write(world[i_x, i_y]);
                        i_x++;
                    }
                    //Console.Write("{0}\n", world_border);
                    Console.Write("\n");
                    i_x = 0;
                    i_y++;
                }
                //while (i_border < world_w + 2)
                //{
                //    Console.Write(world_border);
                //    i_border++;
                //}

                //print 

                Console.WriteLine("Ammo2 {0}/{1}", max_ammo_p2 - bullets_fired_p2, max_ammo_p2);
                Console.WriteLine("Ammo {0}/{1}", max_ammo_p1 - bullets_fired_p1, max_ammo_p1);
                Console.WriteLine("\nPlayer1: {0}  Player2: {1}", score_p1, score_p2);


            } while (cki.Key != ConsoleKey.X);
        }
    }
}
