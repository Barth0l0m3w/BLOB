PImage bg;

void setup(){
  bg = loadImage("background3.png");
  PImage bg;
  
size(1366,768);


}
void draw(){
  background(bg);
textSize(60);

fill(#f0aa13);
String s = "1. Delano   89500 2. Jan         48750       3. Salvador 48700 4. Salvador 48600 5. Salvador 48500 6. Salvador 48450 7. Salvador 47400 8. Salvador 46700 9. Salvador 45000 10. Salvador 48727";

text(s, 425, 70,550, 680);  // Text wraps within text box
}
void mouseClicked() {
  println("MouseX  "+ mouseX);
   println("MouseY  "+ mouseY);
  
}
