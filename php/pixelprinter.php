<?php

    imagecolorallocate($im, 100,100,100);
    $color = imagecolorallocate($im, 0, 0, 0);
    for ($i = 0; $i < 10000; $i++)
    {
        $x = rand(0,1920);
        $y = rand(0,1080);
        echo "x: " . $x . " y: " . $y . "\n";
        imagesetpixel($im, $x, $y, $color);
        imagesetpixel($im, $x, $y, $color);
    }
    
?>
