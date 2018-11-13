<?php
    function createmap($suffix, $x1, $x2, $y1, $y2)
    {
        $im = imagecreatetruecolor(1920,1080) or die("gd error meh");
        for ($x = $x1; $x <= $x2; $x++)
        {
            for ($y = $y1; $y <= $y2; $y++)
            {
                //$rand_r = rand(0,255);
                //$rand_g = rand(0,255);
                //$rand_b = rand(0,255);
                $rand_r = 255;
                $rand_g = 255;
                $rand_b = 255;
                $color = imagecolorallocate($im,$rand_r,$rand_g,$rand_b);
                imagesetpixel($im, $x, $y, $color);
                //echo "xy(".$x."|".$y.") rgb(".$rand_r."|".$rand_g."|".$rand_b.")\n";
            }
        }
        imagepng($im, "maps/map_".$suffix.".png");
    }
    
    for ($i = 0; $i < 20; $i++ )
    {
        createmap($i, $i + 100, $i + 200, $i + 100, $i + 200);
    }
    
    //createmap("h7t8h", 100,200,100,200);
    ?>
<img src="frame.png">
