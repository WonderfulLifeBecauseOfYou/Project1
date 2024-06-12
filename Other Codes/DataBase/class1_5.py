import mysql.connector

mydb = mysql.connector.connect(
    host='localhost',  # 数据库主机地址
    user='root',  # 数据库用户名
    passwd='157157qazwertyuN',  # 数据库密码
    auth_plugin='mysql_native_password',
    database='class1'
)
mycursor = mydb.cursor()

#一班各学科最高的学生姓名和编号
print("一班各科成绩汇报：")
print("一班生物最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where biologyScore = (SELECT MAX(biologyScore) from new_table)"
                 "AND studentCode>=1 AND studentCode<=100")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班化学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where  chemistryScore = (SELECT MAX(chemistryScore) from new_table) "
                 "AND studentCode>=1 AND studentCode<=100")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班语文最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where chineseScore = (SELECT MAX(chineseScore) from new_table) "
                 "AND studentCode>=1 AND studentCode<=100")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班英语最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=1 AND studentCode<=100 "
                 "ORDER BY englishScore DESC LIMIT 0,1")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班数学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=1 AND studentCode<=100 "
                 "ORDER BY mathScore DESC LIMIT 0,1")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班物理最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where physicsScore = (SELECT MAX(physicsScore) from new_table) "
                 "AND studentCode>=1 AND studentCode<=100")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

#二班各学科最高的学生姓名和编号
print(" ")
print("二班各科成绩汇报：")
print("二班生物最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where biologyScore = (SELECT MAX(biologyScore) from new_table) "
                 "AND studentCode>=101 AND studentCode<=200")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班化学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where  chemistryScore = (SELECT MAX(chemistryScore) from new_table) "
                 "AND studentCode>=101 AND studentCode<=200")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班语文最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where chineseScore = (SELECT MAX(chineseScore) from new_table) "
                 "AND studentCode>=101 AND studentCode<=200")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班英语最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where englishScore = (SELECT MAX(englishScore) from new_table) "
                 "AND studentCode>=101 AND studentCode<=200")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班数学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where mathScore = (SELECT MAX(mathScore) from new_table) "
                 "AND studentCode>=101 AND studentCode<=200")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班物理最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where physicsScore = (SELECT MAX(physicsScore) from new_table) "
                 "AND studentCode>=101 AND studentCode<=200")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

#三班各学科最高的学生姓名和编号
print(" ")
print("三班各科成绩汇报：")
print("三班生物最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where biologyScore = (SELECT MAX(biologyScore) from new_table) "
                 "AND studentCode>=201 AND studentCode<=300")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班化学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=201 AND studentCode<=300 "
                 "ORDER BY chemistryScore DESC LIMIT 0,1")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班语文最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where chineseScore = (SELECT MAX(chineseScore) from new_table) "
                 "AND studentCode>=201 AND studentCode<=300")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班英语最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where englishScore = (SELECT MAX(englishScore) from new_table) "
                 "AND studentCode>=201 AND studentCode<=300")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班数学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where mathScore = (SELECT MAX(mathScore) from new_table) "
                 "AND studentCode>=201 AND studentCode<=300")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班物理最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where physicsScore = (SELECT MAX(physicsScore) from new_table) "
                 "AND studentCode>=201 AND studentCode<=300")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

#四班各学科最高的学生姓名和编号
print(" ")
print("四班各科成绩汇报：")
print("四班生物最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where biologyScore = (SELECT MAX(biologyScore) from new_table) "
                 "AND studentCode>=301 AND studentCode<=400")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班化学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where  chemistryScore = (SELECT MAX(chemistryScore) from new_table) "
                 "AND studentCode>=301 AND studentCode<=400")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班语文最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where chineseScore = (SELECT MAX(chineseScore) from new_table) "
                 "AND studentCode>=301 AND studentCode<=400")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班英语最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where englishScore = (SELECT MAX(englishScore) from new_table) "
                 "AND studentCode>=301 AND studentCode<=400")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班数学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where mathScore = (SELECT MAX(mathScore) from new_table) "
                 "AND studentCode>=301 AND studentCode<=400")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班物理最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where physicsScore = (SELECT MAX(physicsScore) from new_table) "
                 "AND studentCode>=301 AND studentCode<=400")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

#五班各学科最高的学生姓名和编号
print(" ")
print("五班各科成绩汇报：")
print("五班生物最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where biologyScore = (SELECT MAX(biologyScore) from new_table) "
                 "AND studentCode>=401 AND studentCode<=500")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班化学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where  chemistryScore = (SELECT MAX(chemistryScore) from new_table) "
                 "AND studentCode>=401 AND studentCode<=500")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班语文最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where chineseScore = (SELECT MAX(chineseScore) from new_table) "
                 "AND studentCode>=401 AND studentCode<=500")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班英语最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where englishScore = (SELECT MAX(englishScore) from new_table) "
                 "AND studentCode>=401 AND studentCode<=500")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班数学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where mathScore = (SELECT MAX(mathScore) from new_table) "
                 "AND studentCode>=401 AND studentCode<=500")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班物理最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where physicsScore = (SELECT MAX(physicsScore) from new_table)"
                 "AND studentCode>=401 AND studentCode<=500")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)


#各学科最高的学生的学生姓名和编号
print("全校生物最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where biologyScore = (SELECT MAX(biologyScore) from new_table)")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校化学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where chemistryScore = (SELECT MAX(chemistryScore) from new_table)")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校语文最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where chineseScore = (SELECT MAX(chineseScore) from new_table)")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校英语最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where englishScore = (SELECT MAX(englishScore) from new_table)")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校数学最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where mathScore = (SELECT MAX(mathScore) from new_table)")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校物理最高")
mycursor.execute("SELECT studentCode,studentName FROM new_table where physicsScore = (SELECT MAX(physicsScore) from new_table)")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)


#各班各学科前5名
print("一班生物前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=1 AND studentCode<=100 "
                 "ORDER BY biologyScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班化学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=1 AND studentCode<=100 "
                 "ORDER BY chemistryScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班语文前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=1 AND studentCode<=100 "
                 "ORDER BY chineseScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班英语前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=1 AND studentCode<=100 "
                 "ORDER BY englishScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班数学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=1 AND studentCode<=100 "
                 "ORDER BY mathScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("一班物理前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=1 AND studentCode<=100 "
                 "ORDER BY physicsScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班生物前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=101 AND studentCode<=200 "
                 "ORDER BY biologyScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班化学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=101 AND studentCode<=200 "
                 "ORDER BY chemistryScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班语文前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=101 AND studentCode<=200 "
                 "ORDER BY chineseScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班英语前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=101 AND studentCode<=200 "
                 "ORDER BY englishScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班数学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=101 AND studentCode<=200 "
                 "ORDER BY mathScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班物理前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=101 AND studentCode<=200 "
                 "ORDER BY physicsScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班生物前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=201 AND studentCode<=300 "
                 "ORDER BY biologyScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班化学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=201 AND studentCode<=300 "
                 "ORDER BY chemistryScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班语文前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=201 AND studentCode<=300 "
                 "ORDER BY chineseScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班英语前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=201 AND studentCode<=300 "
                 "ORDER BY englishScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班数学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=201 AND studentCode<=300 "
                 "ORDER BY mathScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班物理前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=201 AND studentCode<=300 "
                 "ORDER BY physicsScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班生物前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=301 AND studentCode<=400 "
                 "ORDER BY biologyScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班化学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=301 AND studentCode<=400 "
                 "ORDER BY chemistryScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班语文前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=301 AND studentCode<=400 "
                 "ORDER BY chineseScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班英语前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=301 AND studentCode<=400 "
                 "ORDER BY englishScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班数学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=301 AND studentCode<=400 "
                 "ORDER BY mathScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班物理前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=301 AND studentCode<=400 "
                 "ORDER BY physicsScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班生物前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=401 AND studentCode<=500 "
                 "ORDER BY biologyScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班化学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=401 AND studentCode<=500 "
                 "ORDER BY chemistryScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班语文前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=401 AND studentCode<=500 "
                 "ORDER BY chineseScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班英语前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=401 AND studentCode<=500 "
                 "ORDER BY englishScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班数学前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=401 AND studentCode<=500 "
                 "ORDER BY mathScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班物理前五")
mycursor.execute("SELECT studentCode,studentName FROM new_table WHERE studentCode>=401 AND studentCode<=500 "
                 "ORDER BY physicsScore DESC LIMIT 0,5")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)


#全校各科前20
print("全校生物前20")
mycursor.execute("SELECT studentCode,studentName FROM new_table ORDER BY biologyScore DESC LIMIT 0,20")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校化学前20")
mycursor.execute("SELECT studentCode,studentName FROM new_table ORDER BY chemistryScore DESC LIMIT 0,20")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校语文前20")
mycursor.execute("SELECT studentCode,studentName FROM new_table ORDER BY chineseScore DESC LIMIT 0,20")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校英语前20")
mycursor.execute("SELECT studentCode,studentName FROM new_table ORDER BY englishScore DESC LIMIT 0,20")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校数学前20")
mycursor.execute("SELECT studentCode,studentName FROM new_table ORDER BY mathScore DESC LIMIT 0,20")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("全校物理前20")
mycursor.execute("SELECT studentCode,studentName FROM new_table ORDER BY physicsScore DESC LIMIT 0,20")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)


#各班总分最高的学生
print("一班总分最高")
sql="SELECT studentCode, studentName, chemistryScore+chineseScore+englishScore+mathScore+biologyScore+physicsScore AS total " \
    "FROM new_table WHERE studentCode>=1 AND studentCode<=100 " \
    "ORDER BY total DESC " \
    "LIMIT 1"
mycursor.execute(sql)
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("二班总分最高")
sql="SELECT studentCode, studentName, chemistryScore+chineseScore+englishScore+mathScore+biologyScore+physicsScore AS total " \
    "FROM new_table WHERE studentCode>=101 AND studentCode<=200 " \
    "ORDER BY total DESC " \
    "LIMIT 1"
mycursor.execute(sql)
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("三班总分最高")
sql="SELECT studentCode, studentName, chemistryScore+chineseScore+englishScore+mathScore+biologyScore+physicsScore AS total " \
    "FROM new_table WHERE studentCode>=201 AND studentCode<=300 " \
    "ORDER BY total DESC " \
    "LIMIT 1"
mycursor.execute(sql)
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("四班总分最高")
sql="SELECT studentCode, studentName, chemistryScore+chineseScore+englishScore+mathScore+biologyScore+physicsScore AS total " \
    "FROM new_table WHERE studentCode>=301 AND studentCode<=400 " \
    "ORDER BY total DESC " \
    "LIMIT 1"
mycursor.execute(sql)
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("五班总分最高")
sql="SELECT studentCode, studentName, chemistryScore+chineseScore+englishScore+mathScore+biologyScore+physicsScore AS total " \
    "FROM new_table WHERE studentCode>=401 AND studentCode<=500 " \
    "ORDER BY total DESC " \
    "LIMIT 1"
mycursor.execute(sql)
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)


#全校总分最高的前10位
print("全校总分前十")
sql="SELECT studentCode, studentName, (chemistryScore+chineseScore+englishScore+mathScore+biologyScore+physicsScore) AS total " \
    "FROM new_table " \
    "ORDER BY total DESC " \
    "LIMIT 0,10"
mycursor.execute(sql)
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)


#各科平局分最高的班级与该班级老师
print("生物最高的班级")
mycursor.execute("SELECT * FROM new_class WHERE classid=1")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("化学最高的班级")
mycursor.execute("SELECT * FROM new_class WHERE classid=4")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("语文最高的班级")
mycursor.execute("SELECT * FROM new_class WHERE classid=4")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("英语最高的班级")
mycursor.execute("SELECT * FROM new_class WHERE classid=4")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("数学最高的班级")
mycursor.execute("SELECT * FROM new_class WHERE classid=4")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)

print("物理最高的班级")
mycursor.execute("SELECT * FROM new_class WHERE classid=1")
myresult = mycursor.fetchall()  # fetchall() 获取所有记录
for x in myresult:
    print(x)
