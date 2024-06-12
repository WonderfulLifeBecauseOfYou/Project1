class Account:
    def __init__(self, id=0, balance=100, annualInterestRate=0):
        self.__id = id
        self.__balance = balance
        self.__annualInterestRate = annualInterestRate / 100


    def annualInterestRate(self):
        return self.__annualInterestRate

    def id(self, value):
        self.__id = value

    def balance(self, value):
        self.__balance = value

    def annualInterestRate(self, value):
        self.__annualInterestRate = value / 100

    def getMonthlyInterestRate(self):
        return self.__annualInterestRate / 12

    def getMonthlyInterest(self):
        return self.__balance * self.getMonthlyInterestRate()

    def withdraw(self, amount):
        if amount > 0 and amount <= self.__balance:
            self.__balance -= amount
            return True
        else:
            return False

    def deposit(self, amount):
        if amount > 0:
            self.__balance += amount
            return True
        else:
            return False

# Test the Account class
account = Account(id=1122, balance=20000, annualInterestRate=4.5)
account.withdraw(2500)
account.deposit(3000)

# Print account information
print(f"Account ID: {account.id}")
print(f"Balance: ${account.balance}")
print(f"Monthly Interest Rate: {account.getMonthlyInterestRate() * 100}%")
print(f"Monthly Interest: ${account.getMonthlyInterest()}")