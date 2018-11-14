//written with sh_cpp_api.sh by ChillerDragon
#include <iostream>
int main ()
{
system("#!/bin/bash\n#assembly compiler helper by ChillerDragon\necho \"======\"\ncd Desktop/assembly #hardcodet\necho \"warning hardcodet path:\"\npwd\necho \"======\"\nread -p \"no extension_ \" raw_name\nnasm_name=\"$raw_name.asm\"\nld_name=\"$raw_name.o\"\n\nwhile true\ndo\n    clear\n    echo \"assembly compiler helper by ChillerDragon\"\n    echo \"========================\"\n    echo \"[0/3] starting...\"\n    echo \"[1/3] writing macho file...\"\n    nasm -f macho $nasm_name\n    echo \"[2/3] linking exec..\"\n    ld -static -o $raw_name -e start $ld_name\n    echo \"[3/3] removing macho file...\"\n    rm $ld_name\n    echo \"========================\"\n    read -n 1 -s -p \"Press any key to continue\"\ndone\n");
}