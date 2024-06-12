#define LED1 3
#define LED2 5
char a =' ';

void setup() {
  // put your setup code here, to run once:
   pinMode(LED1, OUTPUT);
   pinMode(LED2, OUTPUT);
   Serial.begin(9600);
   Serial.println("控制两个led灯");
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()>0){
    a=char(Serial.read());
    delay(500);
  }
  if(a=='1'){
    digitalWrite(LED1,LOW);
    digitalWrite(LED2,LOW);
  }
  if(a=='2'){
    digitalWrite(LED1,LOW);
    digitalWrite(LED2,HIGH);
  }
  if(a=='3'){
    digitalWrite(LED1,HIGH);
    digitalWrite(LED2,LOW);
  }
  if(a=='4'){
    digitalWrite(LED1,HIGH);
    digitalWrite(LED2,HIGH);
  }
     
}
