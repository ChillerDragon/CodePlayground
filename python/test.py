#!/usr/bin/env python2

file = open("test.dat", 'w')

inp = raw_input("_ ")


cc = 0
out = ""
for c in inp:
    if (cc < 3):
        c = c.upper()
    #print("c: " + c + " inp: " + inp)
    cc += 1
    out += c

print(out)


"""
for i in xrange(len(inp)):
    cc = 0
    print(i)
    for c in inp:
        if (cc <= i):
            c = c.upper()
            print ("TRIGGER")
        cc += 1
    file.write(inp + "\n")
"""
