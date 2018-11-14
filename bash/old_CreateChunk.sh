#!/bin/bash

function CreateChunk {
Chunk=()
posX=$1
if [ $posX -gt $render_dist ]
then
    c=$((posX - render_dist))
    c_size=$((posX + render_dist))
    while [  $c -lt $c_size ]; do

        if [ "$c" = "$posX" ]
        then
            Chunk+="a"
        else
            Chunk+="${world[$c]}"
        fi

    c=$((c + 1))
done
else
    c=$((posX - render_dist))
    c_size=$((posX + render_dist))
    while [  $c -lt $c_size ]; do

        if [ "$c" = "$posX" ]
        then
            Chunk+="a"
        elif [ $c -lt 0 ]
        then
            Chunk+=" "
        else
            Chunk+="${world[$c]}"
        fi

        c=$((c + 1))
    done
fi
}
