#define LED_RED               A1
#define LED_GREEN             A2
#define LED_BLUE              5
#define BUZZ                  3
#define LPG_sensorPin         A0
void setup()
{
  pinMode(LPG_sensorPin,INPUT);
  pinMode(LED_RED,OUTPUT);
  pinMode(LED_GREEN,OUTPUT);
  pinMode(LED_BLUE,OUTPUT);
  digitalWrite(LED_RED,1);
  digitalWrite(LED_GREEN,1);
  digitalWrite(LED_BLUE,1);
  pinMode(BUZZ,OUTPUT );
  digitalWrite(BUZZ,0);
  Serial.begin(9600); 
  Serial.println("lab6 PIR clik");
}
void loop()
{
int val;
val=analogRead(LPG_sensorPin);
Serial.println(val,DEC);
 if(val>=500)
   { 
    Serial.println("可燃气浓度过高，危险");
    digitalWrite(BUZZ,1);//蜂鸣器响
    delay(50);
    digitalWrite(BUZZ,0);
    while(val>=500)
    {digitalWrite(LED_RED,0);
    delay(500);
    digitalWrite(LED_RED,1);
    delay(500);
    val=analogRead(LPG_sensorPin);
   }
   }
  else if(val<500&&val>0)
    {
      Serial.println("检测到可燃气");
      digitalWrite(LED_BLUE,0);
      Serial.println(val,DEC);
      val=analogRead(LPG_sensorPin);
      digitalWrite(LED_BLUE,1);
      }
   else
   {
     Serial.println("没有检测到可燃气");
     Serial.println(val,DEC);
     while(analogRead(LPG_sensorPin)==0)
     {
       digitalWrite(LED_GREEN,0);
     }
     digitalWrite(LED_GREEN,1);
      val=analogRead(LPG_sensorPin);
   }
  delay(500);
}
