#!/usr/bin/env python2
# somehow doesnt worked ._.
# but idk how. the cpp file compiled and looked good but the executed version beaved weird
# tested with compiler.sh (assembly compiler helper)
# because he forgets vars (fixxed with ;)
# the ";" solotion is bad... look at this example:
# while true
# do
# we dont wanna have "while true; do;"
# so better use "\n" works same as files
# but keep in mind system(); starts in user dir pwd = Users/chillerdragon
# if you wanna execute files in current dir you have to implement it to the api


##########################################################
#                     w a r n i n g                      #
#                                                        #
# whole api is a bit unfinished and not completly tested #
##########################################################

import sys
import os
import os.path

file_name=raw_input("no extension_ ")
out_file=file_name + ".cpp"
src_file=file_name + ".sh"

if not os.path.isfile(src_file):
    print("ERROR: source file > " + src_file + " < not found")
    sys.exit()

if not os.path.isfile(out_file):
    writeFile = open(out_file, "w")
    writeFile.write('//written with sh_cpp_api.sh by ChillerDragon' + '\n')
    writeFile.write('#include <iostream>' + '\n')
    writeFile.write('int main ()' + '\n')
    writeFile.write('{' + '\n')
    writeFile.write('system("')
    
    with open(src_file, "r") as ins:
        for line in ins:
            e_line = line.replace('"', '\\"')
            #writeFile.write('system("' + e_line[:-1] + '");' + '\n') #old broken no remember var version
            writeFile.write(e_line[:-1] + "\\n")

    writeFile.write('");' + "\n")
    writeFile.write('}')
    writeFile.close()
else:
    print("ERROR: can't overwrite > " + out_file + " < ")
