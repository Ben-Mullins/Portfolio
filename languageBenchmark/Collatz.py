import sys
import time

def main():
    startTime = time.time()
    count = 1
    answer = 1
    broken = False
    file = open("python.txt", "w+")

    while not broken:
        while answer != 1:
            if answer % 2 == 1:
                answer = (answer * 3) + 1
            elif answer <= 0:
                print(str(count) + " solved the Collatz conjecture!")
                sys.exit()

            else:
                answer = answer/2

        count = count + 1
        answer = count
        if count % 100000 == 0:
            print("Reached " + str(count) + " in "+ str(time.time() - startTime) + " seconds.") # print updates
            file.write(str(count) + "," + str(time.time() - startTime) + "\n") # write to a file


if __name__ == '__main__':
    main()