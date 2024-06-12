int ledpin=8;
int led=2;
unsigned char state=0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  attachInterrupt(0, blink, RISING);
  pinMode(ledpin, OUTPUT);
  pinMode(led, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(state!=0){
    state=0;
    digitalWrite(ledpin,HIGH);
    delay(600);
  }else
  digitalWrite(ledpin,LOW);
}

void blink(){
  state++;
}