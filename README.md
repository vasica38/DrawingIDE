## Title
Draw IDE
## How to use Application, examples
<b>COLOR</b> red | black | green | blue => set the color.<br>
<b>ELLIPSE</b> 0,0,100,200,true => drawing an eclipse with coordinates (0,0) and width 100 and height 200.<br>
<b>CIRCLE</b> 0,0,100,true => drawing a circle with coordinates (0,0) and radius 100.<br>
<b>FONT</b> Arial => set text style. <br>
<b>FUNCTION</b> X^2+2*X-1 => draw a function plot. <br>
<b>IMAGE</b> 100,100, C:\Image.png => load an image and is drawing to form.<br>
<b>LINE</b> 100,100, 200, 200 => draw a line between those two coordinates.<br>
<b>RECTANGLE</b> 100,100, 200, 200, true => draw a rectangle between those two coordinates.<br>
<b>TEXT</b> 'hello world', 100,100 => writes text 'hello world' to coordinates 100,100.<br>
<b>ANIMATE</b>  => Animation.<br>
<br>
For and if example <br>
FOR i=10 TO 100 STEP 10 DO <br>
{ <br>
circle @i,@i,10,false <br>
line @i,@i,100,10 <br>
line @i,@i,10,100 <br>
} <br>
<br>







