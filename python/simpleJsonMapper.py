#!/usr/bin/python3

import json

def getChildren(obj, level):
    print(" |" * level, end = "")
    print(" " + str(obj[0]))
    try:
        if str(type(obj[1])) == "<class 'dict'>":
            for item in obj[1].items():
                getChildren(item, level + 1)

    except Exception as err:
        print(err)

def main():
    levels = 0
    with open("output.json", "r") as f:
        info = json.load(f)

    for obj in info.items():
        print("")
        getChildren(obj, 0) 

if __name__ == "__main__":
    main()
