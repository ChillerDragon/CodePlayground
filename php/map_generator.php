<?php
    /*
    function createmap($suffix, $size, $color)
    {
        $im = imagecreatetruecolor(1920,1080) or die("gd error meh");
        
        function createtile($posX, $posY)
        {
            for ($x = $posX; $x <= $posX + $size; $x++)
            {
                for ($y = $posY; $y <= $posY + $size; $y++)
                {
                    $rand_r = $color;
                    $rand_g = $color;
                    $rand_b = $color;
                    $color = imagecolorallocate($im,$rand_r,$rand_g,$rand_b);
                    imagesetpixel($im, $x, $y, $color);
                }
            }
        }
        createtile(250, 250);
        
        imagepng($im, "maps/map_".$suffix.".png");
    }
    createmap("001", 100, 255);
    */
    
    //$im = imagecreatetruecolor(1920,1080) or die("gd error meh");
    
    function createtile($posX, $posY, $size, $im)
    {
        $im = imagecreatetruecolor(1920,1080) or die("gd error meh");
        for ($x = $posX; $x <= $posX + $size; $x++)
        {
            for ($y = $posY; $y <= $posY + $size; $y++)
            {
                $rand_r = $color;
                $rand_g = $color;
                $rand_b = $color;
                $color = imagecolorallocate($im,$rand_r,$rand_g,$rand_b);
                imagesetpixel($im, $x, $y, $color);
            }
        }
        return $im;
    }
    
    //createtile(200, 200, 100);
    imagepng(createtile(200, 200, 100, $im), "maps/map_001.png");
    ?>
<img src="frame.png">
