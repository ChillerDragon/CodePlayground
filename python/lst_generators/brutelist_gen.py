#!/usr/bin/python
import itertools
def bruteforce(charset, maxlength):
    try:
        return (''.join(candidate)
            for candidate in itertools.chain.from_iterable(itertools.product(charset, repeat=i)
            for i in range(1, maxlength + 1)))
    except KeyboardInterrupt:
        pass
brute_chars = raw_input("Brute chars: ")
max_brute = raw_input("Maxlength(int): ")
print("Starting creating brute strings...")
brute_list = list(bruteforce(brute_chars, int(max_brute)))
print("Finished brutelist...")
brutefile = open('cBRUTEFORCE.lst', 'w')
for i in brute_list:
    brutefile.write(i + '\n')
brutefile.close()
print("finished saving.")
