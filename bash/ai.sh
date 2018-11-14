#!/bin/bash

#Struct:
# arrayname:  what it does:
# words         saves all words the ai learns
# words_freq    frequently reacorded words (coudl be important)
# words_i1      i=info 1=how many times he heard the word

words=()
words+=('foo')
words+=('bar')
words_freq=()
words_i1=()

#option vars
is_menu=1
is_dbg=0
collect_input=1
dbg_msg=()

echo "loading brain..."

while IFS=\= read word; do
    words+=($word)
done < words.txt

for i in "${words[@]}"
do
	echo "$i"
done

while (( is_menu ))
do
    read -p "command: " menu_cmd

    if [ "$menu_cmd" = "start" ]
    then
        echo "starting..."
        is_menu=0
    elif [ "$menu_cmd" = "hack" ]
    then
        echo "hacked the ai"
    elif [ "$menu_cmd" = "debug" ]
    then
        is_dbg=1
    elif [ "$menu_cmd" = "debug_wlist" ]
    then
        is_dbg=2
    elif [ "$menu_cmd" = "debug_file" ]
    then
        is_dbg=3
    else
        echo "unknow command."
    fi
done


while (( collect_input ))
do
read -p "tell me a word: " new_word


if [[ " ${words[@]} " =~ " ${new_word} " ]]; then
    echo "I already know this word ._."
fi

if [[ ! " ${words[@]} " =~ " ${new_word} " ]]; then
    echo "Thank you for the new input :)"
    words+=($new_word)
    printf "%s\n" "${words[@]}" | sort | uniq > words.txt
fi





dbg_msg+="======== filsize info ========="


file=words.txt
maximumsize=16
actualsize=$(du -k "$file" | cut -f 1)
if [ $actualsize -ge $maximumsize ]; then
dbg_mgs+="words [$actualsize/$maximumsize] kB full"
dbg_msg+="error: words full"
dbg_msg+="stop collecting new input..."
collect_input=0
#echo "terminating ai..."
#exit
else
dbg_msg+="words [$actualsize/$maximumsize] kB"
#dbg_msg+="brain [1/71239] ultra"
fi

if (( is_dbg ))
then
    echo "====== word list ======"
    for i in "${words[@]}"
    do
        echo "$i"
    done

    printf "${dbg_msg[@]}"


#    for i in "${dbg_msg[@]}"
#    do
#        echo "${dbg_msg[@]}"
#    done
fi

dbg_msg=()


done
