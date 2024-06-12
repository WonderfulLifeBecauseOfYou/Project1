#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>
#define SEALEVELPRESSURE_HPA (1013.25)

Adafruit_BME280 bme;

#define BC26_RESET_PIN        A0
#define BC26_PWR_KEY          6
#define BC26_PSM_PIN          7
#define LED_RED               A1
#define LED_GREEN             A2
#define LED_BLUE              5
#define BUZZ                  3

#define DEFAULT_TIMEOUT       10   //seconds
#define BUF_LEN               300

#define BC26_SUCC_RSP               "OK"
#define BC26_AT_CHECK               "AT\r\n"
#define BC26_ECHO_OFF               "ATE1\r\n"
#define BC26_CHECK_GPRS_ATTACH      "AT+CGATT?\r\n"
#define BC26_CGATT_SUCC_POSTFIX     "+CGATT: 1"
#define BC26_ALI_PRESET             "AT+QMTCFG=\"ALIAUTH\",0,\"%s\",\"%s\",\"%s\"\r\n"
#define BC26_ALI_OPEN_LINK          "AT+QMTOPEN=0,\"iot-as-mqtt.cn-shanghai.aliyuncs.com\",1883\r\n"
#define BC26_ALI_OPEN_LINK_SUCC     "+QMTOPEN: 0,0"
#define BC26_ALI_BUILD_LINK         "AT+QMTCONN=0,\"clientExample\"\r\n"
#define BC26_ALI_BUILD_LINK_SUCC    "+QMTCONN: 0,0,0"
#define BC26_ALI_SENSOR_UPLOAD      "AT+QMTPUB=0,12,1,0,\"/sys/%s/%s/thing/event/property/post\",\"{'id':'110','version':'1.0','method':'thing.event.property.post','params':{'Temperature':%d.%02d,'Humidity':%d.%02d,'Pressure':%d.%02d}}\"\r\n"
#define BC26_ALI_SENSOR_UPLOAD_SUCC "+QMTPUB: 0,12,0"
#define BC26_ALI_DISCON             "AT+QMTDISC=0\r\n"
#define BC26_ALI_DISCON_SUCC        "+QMTDISC: 0,0"

#define ProductKey                  "a1QvwLljlk1"
#define DeviceName                  "PKTH100B_CZ1"
#define DeviceSecret                "j9jl038YlarEkx0wvzOlbqd2DF6ntcY"

char      ATcmd[BUF_LEN];
//char      ATrsp[BUF_LEN];
char      ATbuffer[BUF_LEN];
unsigned  bme280_status;
float     bme280_temperature;
float     bme280_humidity;
float     bme280_pressure;

void setup() {
  Serial.begin(115200);
  LED_init();
  BC26_init();

  bme280_status = bme.begin();
  while (!bme280_status) bme280_status = bme.begin();
  digitalWrite(LED_RED, LOW);
}

void loop() {
  while (1)
  {
    digitalWrite(LED_GREEN, HIGH);
    BC26_reset();

    if (!BC26_network_check())continue;
    digitalWrite(LED_GREEN, LOW);

    if (!BC26_Ali_connect())continue;
    break;
  }
  digitalWrite(LED_BLUE, LOW);
  for (int count = 1; count <= 20; count++)
  {
    bme280_temperature = bme.readTemperature();
    bme280_humidity = bme.readHumidity();
    bme280_pressure = bme.readPressure() / 1000;
    if (BC26_sensor_upload(bme280_temperature, bme280_humidity, bme280_pressure))BEEP();
    delay(10000);
  }
  while (!check_send_cmd(BC26_ALI_DISCON, BC26_ALI_DISCON_SUCC, DEFAULT_TIMEOUT)); //关
  LED_init();
  while (1);
}

void BC26_init()
{
  pinMode(BC26_RESET_PIN, OUTPUT);
  pinMode(BC26_PWR_KEY, OUTPUT);
  pinMode(BC26_PSM_PIN, OUTPUT);
  digitalWrite(BC26_PWR_KEY, LOW);
  digitalWrite(BC26_PSM_PIN, LOW);
}

void BC26_reset()
{
  digitalWrite(BC26_RESET_PIN, HIGH);
  delay(100);
  digitalWrite(BC26_RESET_PIN, LOW);
  delay(20000);
  Serial.flush();
}

bool BC26_network_check()
{
  bool flag;

  flag = check_send_cmd(BC26_AT_CHECK, BC26_SUCC_RSP, DEFAULT_TIMEOUT);
  if (!flag)return false;

  flag = check_send_cmd(BC26_ECHO_OFF, BC26_SUCC_RSP, DEFAULT_TIMEOUT);
  if (!flag)return false;

  flag = check_send_cmd(BC26_CHECK_GPRS_ATTACH, BC26_CGATT_SUCC_POSTFIX, DEFAULT_TIMEOUT);
  if (!flag)return false;

  flag = check_send_cmd("AT+QMTCFG=\"KEEPALIVE\",1,240\r\n", BC26_SUCC_RSP, DEFAULT_TIMEOUT);
  return flag;
}

bool BC26_Ali_connect()
{
  bool flag;
  bool flag2=0;
  cleanBuffer(ATcmd, BUF_LEN);
  snprintf(ATcmd, BUF_LEN, BC26_ALI_PRESET, ProductKey, DeviceName, DeviceSecret);
  flag = check_send_cmd(ATcmd, BC26_SUCC_RSP, DEFAULT_TIMEOUT);
  if (!flag)return false;

    flag = check_send_cmd(BC26_ALI_OPEN_LINK, BC26_SUCC_RSP, 40);
    if (flag)
    {
     int i = 0;
     unsigned long timeStart;
     timeStart = millis();
     cleanBuffer(ATbuffer, BUF_LEN);
     while(1){ 
     while (Serial.available())
    {
      ATbuffer[i++] = Serial.read();
      if (i >= BUF_LEN)return false;
    }
    if (NULL != strstr(ATbuffer, BC26_ALI_OPEN_LINK_SUCC))  break;
    if ((unsigned long)(millis() - timeStart > 5*60*1000)) break;  
    }
    }
    Serial.flush();
    if (NULL != strstr(ATbuffer,BC26_ALI_OPEN_LINK_SUCC)) flag2=true;
    if (!flag2)return false;


  flag = check_send_cmd(BC26_ALI_BUILD_LINK, BC26_ALI_BUILD_LINK_SUCC,40);
  return flag;
}

bool BC26_sensor_upload(float temperature, float humidity, float pressure)
{
  bool flag;
  int inte1, frac1;
  int inte2, frac2;
  int inte3, frac3;

  cleanBuffer(ATcmd, BUF_LEN);

  inte1 = (int)(temperature);
  frac1 = (temperature - inte1) * 100;

  inte2 = (int)(humidity);
  frac2 = (humidity - inte2) * 100;

  inte3 = (int)(pressure);
  frac3 = (pressure - inte3) * 100;

  snprintf(ATcmd, BUF_LEN, BC26_ALI_SENSOR_UPLOAD, ProductKey, DeviceName, inte1, frac1, inte2, frac2, inte3, frac3);
  flag = check_send_cmd(ATcmd, BC26_ALI_SENSOR_UPLOAD_SUCC, 20);
  return flag;
}

bool check_send_cmd(const char* cmd, const char* resp, unsigned int timeout)
{
  int i = 0;
  unsigned long timeStart;
  timeStart = millis();
  cleanBuffer(ATbuffer, BUF_LEN);
  Serial.print(cmd);

  while (1)
  {
    while (Serial.available())
    {
      ATbuffer[i++] = Serial.read();
      if (i >= BUF_LEN)return false;
    }
    if (NULL != strstr(ATbuffer, resp))break;
    if ((unsigned long)(millis() - timeStart > timeout * 1000)) break;
  }
  Serial.flush();

  if (NULL != strstr(ATbuffer, resp))return true;
  return false;
}

void cleanBuffer(char *buf, int len)
{
  for (int i = 0; i < len; i++)
  {
    buf[i] = '\0';
  }
}

void LED_init()
{
  pinMode(LED_RED, OUTPUT);
  pinMode(LED_GREEN, OUTPUT);
  pinMode(LED_BLUE, OUTPUT);
  pinMode(BUZZ, OUTPUT);
  digitalWrite(LED_RED, HIGH);
  digitalWrite(LED_GREEN, HIGH);
  digitalWrite(LED_BLUE, HIGH);
  digitalWrite(BUZZ, LOW);
}

void BEEP()
{
  digitalWrite(BUZZ, HIGH);
  delay(500);
  digitalWrite(BUZZ, LOW);
}
