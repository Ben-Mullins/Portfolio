#/usr/bin/env python3

import calendar
import datetime
import os

dayOfWeek = ["Monday", "Tuesday", "Wednsday", "Thursday", "Friday", "Saturday", "Sunday"]

a = [1,1,1,1,
     1,0,0,1,
     1,1,1,1,
     1,0,0,1,
     1,0,0,1]

b = [1,1,1,0,
     1,0,0,1,
     1,1,1,0,
     1,0,0,1,
     1,1,1,1]

c = [1,1,1,1,
     1,0,0,1,
     1,0,0,0,
     1,0,0,1,
     1,1,1,1]

d = [1,1,1,0,
     1,0,0,1,
     1,0,0,1,
     1,0,0,1,
     1,1,1,0]

e = [1,1,1,1,
     1,0,0,0,
     1,1,1,0,
     1,0,0,0,
     1,1,1,1]

f = [1,1,1,1,
     1,0,0,0,
     1,1,1,0,
     1,0,0,0,
     1,0,0,0]

g = [1,1,1,1,
     1,0,0,0,
     1,0,1,1,
     1,0,0,1,
     1,1,1,1]

h = [1,0,0,1,
     1,0,0,1,
     1,1,1,1,
     1,0,0,1,
     1,0,0,1]

i = [1,1,1,
     0,1,0,
     0,1,0,
     0,1,0,
     1,1,1]

j = [1,1,1,1,
     0,0,1,0,
     0,0,1,0,
     1,0,1,0,
     0,1,0,0]

k = [1,0,0,1,
     1,0,1,0,
     1,1,0,0,
     1,0,1,0,
     1,0,0,1]

l = [1,0,0,0,
     1,0,0,0,
     1,0,0,0,
     1,0,0,0,
     1,1,1,0]

m = [1,0,0,0,1,
     1,1,0,1,1,
     1,0,1,0,1,
     1,0,0,0,1,
     1,0,0,0,1]

n = [1,0,0,1,
     1,1,0,1,
     1,0,1,1,
     1,0,0,1,
     1,0,0,1]

o = [0,1,1,0,
     1,0,0,1,
     1,0,0,1,
     1,0,0,1,
     0,1,1,0]

p = [1,1,1,1,
     1,0,0,1,
     1,1,1,1,
     1,0,0,0,
     1,0,0,0]

q = [0,1,1,0,0,
     1,0,0,1,0,
     1,0,0,1,0,
     1,0,0,1,0,
     0,1,1,1,1]

r = [1,1,1,1,
     1,0,0,1,
     1,1,1,1,
     1,0,1,0,
     1,0,1,1]

s = [1,1,1,
     1,0,0,
     1,1,1,
     0,0,1,
     1,1,1]

t = [1,1,1,1,1,
     0,0,1,0,0,
     0,0,1,0,0,
     0,0,1,0,0,
     0,0,1,0,0]

u = [1,0,0,1,
     1,0,0,1,
     1,0,0,1,
     1,0,0,1,
     0,1,1,0]

v = [1,0,0,0,1,
     1,0,0,0,1,
     0,1,0,1,0,
     0,1,0,1,0,
     0,0,1,0,0]

w = [1,0,0,0,1,
     1,0,0,0,1,
     1,0,1,0,1,
     1,1,0,1,1,
     1,0,0,0,1]

x = [1,0,1,
     1,0,1,
     0,1,0,
     1,0,1,
     1,0,1]

y = [1,0,1,
     1,0,1,
     0,1,0,
     0,1,0,
     0,1,0]

z = [1,1,1,1,
     0,0,0,1,
     0,0,1,0,
     0,1,0,0,
     1,1,1,1]

space = [0,
     0,
     0,
     0,
     0]

def getLetterDates(startingDate, letter):
    returnArray = []
    letterArray = []
    letter = letter.upper()
    length = 0
    if letter == "A":
        letterArray = a
        length = 4
    elif letter == "B":
        letterArray = b
        length = 4
    elif letter == "C":
        letterArray = c
        length = 4
    elif letter == "D":
        letterArray = d
        length = 4
    elif letter == "E":
        letterArray = e
        length = 4
    elif letter == "F":
        letterArray = f
        length = 4
    elif letter == "G":
        letterArray = g
        length = 4
    elif letter == "H":
        letterArray = h
        length = 4
    elif letter == "I":
        letterArray = i
        length = 3
    elif letter == "J":
        letterArray = j
        length = 4
    elif letter == "K":
        letterArray = k
        length = 4
    elif letter == "L":
        letterArray = l
        length = 3
    elif letter == "M":
        letterArray = m
        length = 5
    elif letter == "N":
        letterArray = n
        length = 4
    elif letter == "O":
        letterArray = o
        length = 4
    elif letter == "P":
        letterArray = p
        length = 4
    elif letter == "Q":
        letterArray = q
        length = 5
    elif letter == "R":
        letterArray = r
        length = 4
    elif letter == "S":
        letterArray = s
        length = 3
    elif letter == "T":
        letterArray = t
        length = 5
    elif letter == "U":
        letterArray = u
        length = 4
    elif letter == "V":
        letterArray = v
        length = 5
    elif letter == "W":
        letterArray = w
        length = 5
    elif letter == "X":
        letterArray = x
        length = 3
    elif letter == "Y":
        letterArray = y
        length = 3
    elif letter == "Z":
        letterArray = z
        length =  4
    elif letter == " ":
        letterArray = space
        length = 1
    else:
        print("Invalid character.'{0}'".format(letter))
        return None
    #build dates list and return/write to file
    count = 0
    for pixel in letterArray:
        #print(count, count % length)
        if pixel == 1:
            returnArray.append(startingDate)
        if count % length != length - 1: #forward a week
            startingDate = startingDate + datetime.timedelta(weeks = 1)
        else: # back a few weeks and forward a day
            startingDate = startingDate - datetime.timedelta(weeks = 3)
            startingDate = startingDate + datetime.timedelta(days = 1)
        count += 1
    wrapper = [returnArray, length] # gotta return two values, build a wrapper
    return wrapper

def generateFile(word):
    print("No config file found. Creating config...")
    today = datetime.datetime.now() - datetime.timedelta(weeks = 4)
    startingDate = today
    while getDayOfWeek(startingDate) != "Monday": # Has to start on a Monday
        startingDate = startingDate + datetime.timedelta(days = 1)
    print("The config will start on {0}-{1}-{2}".format(startingDate.year,
                                                        startingDate.month,
                                                        startingDate.day))
    word = word.upper()
    totalLength = 0
    for letter in word:
        dates = getLetterDates(startingDate, letter)
        if dates is not None:
            totalLength += (dates[1] + 1) # +1 for the space. Gotta be less than 50 length
            writeToFile(dates)
            startingDate = startingDate + datetime.timedelta(weeks = dates[1] + 1)
            if totalLength > 50:
                print("String is too long. Cannot write to Github.")
                exit()
        else:
            print("Exiting program because of invalid character.")
            exit()

def writeToFile(dates):
    with open("gitRider.conf", "a") as f:
        for date in dates[0]:
            f.write("{0}-{1}-{2}\n".format(date.year, date.month, date.day))

def getDayOfWeek(date):
    day = date.weekday()
    return dayOfWeek[day]

def pushToGit():
    print("Today is a push day!")
    os.system("echo a >> changefile.txt")
    os.system("git add changefile.txt")
    os.system("git commit -m \"Draw\"")
    os.system("git push -u origin master")

def pushOrNaw():
    date = datetime.datetime.now() + datetime.timedelta(weeks = 1)
    today = "{0}-{1}-{2}".format(date.year, date.month, date.day)
    push = True # assumed true unless a match is found
    with open("gitRider.conf", "r") as f:
        for line in f.read().splitlines():
            if today == line:
                push = False
                break
    if push:
        pushToGit()
    else:
        print("Not a push day.")

def main():
    if not os.path.exists("gitrider.conf"):
        generateFile("ben mullins")
    pushOrNaw()
        
if __name__ == "__main__":
    main()