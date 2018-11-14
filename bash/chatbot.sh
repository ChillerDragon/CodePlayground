#!/bin/bash
#functions:

ynk_checker()
{
main_text=$1

if echo "$main_text" | grep -q "yes"; then
	return 0
elif echo "$main_text" | grep -q "no"; then
	return 1
else
	return 404
fi
}


bot_name="bot:"




while true; do
read -p " " inp

#hardcodet ones
if [ "$inp" = "hello" ]; then
	echo $bot_name hello.
elif [ "$inp" = "ay m8" ]; then
	echo $bot_name yo swagg
elif [ "$inp" = "bye" ]; then
	echo $bot_name bye.
	exit
else
	#No hardcodet found?
	#--> switch to dynamic mode
	#search words in inp string
	if echo "$inp" | grep -q "hello"; then
		echo $bot_name hello.
	elif echo "$inp" | grep -q "haha"; then
		echo $bot_name xD
	else
		echo $bot_name meaning of life
	fi
fi
done
