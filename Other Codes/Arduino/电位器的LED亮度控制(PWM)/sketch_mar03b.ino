int led=8;
int light=0;
int add=5;

void setup() {
  // put your setup code here, to run once:
}

void loop() {
  // put your main code here, to run repeatedly:
  analogWrite(led,light);
  light=light+add;
  if(light==0||light==255){
    add=-add;
  }
  delay(300);
}
