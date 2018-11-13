<?php
    function createpartyframe($suffix)
    {
        $im = imagecreatetruecolor(1920,1080) or die("gd error meh");
        for ($x = 0; $x <= 1920; $x++)
        {
            for ($y = 0; $y <= 1080; $y++)
            {
                $rand_r = rand(0,255);
                $rand_g = rand(0,255);
                $rand_b = rand(0,255);
                $color = imagecolorallocate($im,$rand_r,$rand_g,$rand_b);
                imagesetpixel($im, $x, $y, $color);
                //echo "xy(".$x."|".$y.") rgb(".$rand_r."|".$rand_g."|".$rand_b.")\n";
            }
        }
        imagepng($im, "frames/frame".$suffix.".png");
    }
    
    for ($i = 0; $i < 60; $i++)
    {
        createpartyframe($i);
    }
?>
<img src="frame.png">
