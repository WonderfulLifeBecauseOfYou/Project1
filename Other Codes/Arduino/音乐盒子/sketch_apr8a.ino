#define NTC0 -1
#define NTC1 262
#define NTC2 294
#define NTC3 330
#define NTC4 350
#define NTC5 393
#define NTC6 441
#define NTC7 495
 
#define NTCL1 131
#define NTCL2 147
#define NTCL3 165
#define NTCL4 175
#define NTCL5 196
#define NTCL6 221
#define NTCL7 248	
 
#define NTCH1 525
#define NTCH2 589
#define NTCH3 661
#define NTCH4 700
#define NTCH5 786
#define NTCH6 882
#define NTCH7 990
//列出全部C调的频率
#define WHOLE 1
#define HALF 0.5
#define QUARTER 0.25
#define EIGHTH 0.25
#define SIXTEENTH 0.625
//列出所有节拍
int tune[]=                 
  NTC5,NTC5,NTC6,
  NTCH1,NTC6,NTC5,NTC6,NTCH1,NTC6,NTC5,
  NTC3,NTC3,NTC3,NTC5,
  NTC6,NTC6,NTC5,NTCH3,NTCH3,NTCH2,NTCH1,
  NTCH2,NTCH1,NTCH2,
  NTCH3,NTCH3,NTCH2,NTCH3,NTCH2,NTCH1,NTCH2,NTCH1,NTC6,
 
  NTCH2,NTCH2,NTCH2,NTCH1,NTC6,NTC5,
  NTC6,NTC5,NTC5,NTCH1,NTC6,NTC5,NTC1,NTC3,
  NTC2,NTC1,NTC2,
  NTC3,NTC5,NTC5,NTC3,NTCH1,NTC7,
  NTC6,NTC5,NTC6,NTCH1,NTCH2,NTCH3,
 
  NTCH3,NTCH2,NTCH1,NTC5,NTCH1,NTCH2,NTCH3,
 
  NTCH2,NTC0,NTCH3,NTCH2,
  NTCH1,NTC0,NTCH2,NTCH1,NTC6,NTC0,
 
  NTCH2,NTC6,NTCH1,NTCH1,NTCH1,NTC6,NTC5,NTC3,
  NTC5,
  NTC5,NTC6,NTCH1,NTC7,NTC6,
  NTCH3,NTCH3,NTCH3,NTCH3,NTCH2,NTCH2,NTCH1,
  NTC6,NTCH3,NTCH2,NTCH1,NTCH2,NTCH1,NTC6,
  NTCH1,
};
float durt[]=                 
{
0.5,0.25,0.25,
1.5,0.5,0.5,0.25,0.25,0.5,0.5,
1+1+1,0.5,0.25,0.25,
1.5,0.5,0.5,0.5,0.25,0.25,0.5,
1+1+1,0.5,0.5,
0.5,0.5,0.5,0.25,0.25,0.5,0.25,0.25,0.5,
0.5,0.5,0.5,0.25,0.25,1+1,
0.5,0.5,0.5,0.5,0.5,0.5,0.5,0.5,
1+1+1,0.5,0.5,
 
 
1.5,0.5,0.5,0.5,0.5,0.5,
1.5,0.5,1,0.5,0.25,0.25,
1.5,0.5,0.5,0.5,0.5,0.25,0.25,
1+1+1,0.5,0.25,0.25,
1,0.5,0.25,0.25,1,1,
0.5,0.5,0.5,0.5,1,0.25,0.25,0.5,
1+1+1+1,
0.5,0.5,0.5,0.5,1+1,
0.5,0.5,0.5,0.5,1.5,0.25,0.25,
1.5,0.5,1,0.25,0.25,0.25,0.25,1+1+1+1,
 
};
int length;
int tonepin=6;   
void setup()
{
  pinMode(tonepin,OUTPUT);
  length=sizeof(tune)/sizeof(tune[0]);  
}
void loop()
{
  for(int x=0;x<length;x++)
  {
    tone(tonepin,tune[x]);
    delay(500*durt[x]);   
  }
  delay(2000);
}