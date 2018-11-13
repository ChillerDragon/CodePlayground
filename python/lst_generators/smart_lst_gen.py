#!/usr/bin/env python2
#Bruteforce list generator by ChillerDragon
#Copyright (c) 2017
#thanks to Mr Elliot for help c:

para0 = raw_input("para0: ")
para1 = raw_input("para1: ")
para0_upper = para0.upper()
para1_upper = para1.upper()
para0_lower = para0.lower()
para1_lower = para1.lower()

file_name = para0[0:5] + "_gen.lst"
file_path = "smart_lists/" + file_name
binary_steps = raw_input("binary_steps: ")
binary_steps = int(binary_steps)
if (binary_steps > 10):
    print("dude 10 steps are enough")
    binary_steps = 10

file = open(file_path, 'w')


#bruteforce combine p0 and p1
#used binary system
def binary_combiner(p0, p1):
    tmp_str = ""
    for i in xrange(binary_steps):
        i = format(i, 'b')
        #print(str(i))
        #replace all 0 with para0 and 1 with para1 and u get a nice brute combinding
        for c in i:
            if (c == '0'):
                tmp_str += p0
            elif (c == '1'):
                tmp_str += p1
            else:
                print("-error- c = " + c)

        #file.write("unflipped: " + str(i)+ "\n")
        file.write(tmp_str + "\n")
        tmp_str = ""

    #flip it arund
    tmp_str = ""
    for i in xrange(binary_steps):
        i = format(i, 'b')
        for c in i:
            if (c == '0'):
                tmp_str += p1
            elif (c == '1'):
                tmp_str += p0
            else:
                print("-error- c = " + c)

        #file.write("flipped: " + str(i)+ "\n")
        file.write(tmp_str + "\n")
        tmp_str = ""



binary_combiner(para0, para1)
binary_combiner(para0_lower, para1)
binary_combiner(para0_lower, para1_lower)
binary_combiner(para0, para1_lower)
binary_combiner(para0_upper, para1)
binary_combiner(para0, para1_upper)
binary_combiner(para0_upper, para1_upper)
binary_combiner(para0_upper, para1_lower)
binary_combiner(para0_lower, para1_upper)

#add numberz
for i in xrange(12345678):
    aBuf = para0 + str(i)
    file.write(aBuf + "\n")
    aBuf = para1 + str(i)
    file.write(aBuf + "\n")
    aBuf = str(i) + para0
    file.write(aBuf + "\n")
    aBuf = str(i) + para1
    file.write(aBuf + "\n")



#not working nocase stuff
"""
    for i in xrange(len(para0)):
    cc = 0
    aBuf = ""
    for c in para0:
    if (cc <= i):
    c = c.upper()
    cc += 1
    aBuf += c
    file.write(aBuf + "\n")
    
    def nocase(str):
    nocase_loop = true
    i = 0
    cc = 0
    while (nocase_loop == true):
    i = format(i, 'b')
    for c in i:
    if (c == '1'):
    cc += 1
    i += 1
    """

file.close()
