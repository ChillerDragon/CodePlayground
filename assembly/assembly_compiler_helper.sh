#!/bin/bash
#assembly compiler helper by ChillerDragon
echo "======"
cd Desktop/assembly #hardcodet
echo "warning hardcodet path:"
pwd
echo "======"
read -p "no extension_ " raw_name
nasm_name="$raw_name.asm"
ld_name="$raw_name.o"

while true
do
    clear
    echo "assembly compiler helper by ChillerDragon"
    echo "========================"
    echo "[0/3] starting..."
    echo "[1/3] writing macho file..."
    nasm -f macho $nasm_name
    echo "[2/3] linking exec.."
    ld -static -o $raw_name -e start $ld_name
    echo "[3/3] removing macho file..."
    rm $ld_name
    echo "========================"
    read -n 1 -s -p "Press any key to continue"
done
