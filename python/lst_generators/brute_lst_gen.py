#!/usr/bin/python
#by ChillerDragon

dat = open('brute.lst','w')
mylst = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789'
complete_list=[]
BruteStr=''
for current in xrang(10):
	a = [i for i in mylst]
	for y in xrange(current):
		a = [x+i for i in mylst for x in a]
	complete_list = complete_list+a
	print(BruteStr)
	BruteStr+=a
