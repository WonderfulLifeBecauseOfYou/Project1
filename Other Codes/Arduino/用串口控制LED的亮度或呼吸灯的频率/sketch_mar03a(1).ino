int led=9;
int s;


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("控制呼吸灯频率。");
}

void loop() {
  // put your main code here, to run repeatedly:
  s=int(Serial.read());
  if(s<=255||s>=0){
  analogWrite(led,s);
  Serial.println("亮度为"+s);
  }
  delay(1000);
}
