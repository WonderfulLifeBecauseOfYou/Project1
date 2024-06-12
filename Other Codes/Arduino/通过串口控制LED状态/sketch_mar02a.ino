int led=13;
char val=' ';

void setup() {
  // put your setup code here, to run once:
  pinMode(led,OUTPUT);
  Serial.begin(9600);
  Serial.println("输入: ");
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()>0){
  val = char(Serial.read());
  delay(1000);
  }
  if(val=='0'){
    digitalWrite(led, HIGH);
  }
  if(val=='1'){
    digitalWrite(led, LOW);
  }
}
