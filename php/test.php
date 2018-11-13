<?php

echo "test";
echo PHP_EOL;
$i=0;
for ($x = 0; $x <= 1920; $x++)
{
for ($y = 0;$y <= 1080;$y++)
{
//echo "(".$x."|".$y.")\n";
echo rand(0,255)."\n";
$i++;
}
}
echo "total steps: ".$i."\n";
