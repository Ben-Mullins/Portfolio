#!/usr/bin/python3
import re
from pymongo import MongoClient

__author__ = "Ben Mullins"

def main():
    print("\nYou have entered a chatroom with J.A.M.E.S\n____________________________________\n")
    send = ""
    recieve = "Hello, hooman!"
    prevRecieve = ""
    client = MongoClient("mongodb+srv://Bot:James@conversation-syqee.mongodb.net/test?retryWrites=true&w=majority")
    db = client.get_database('James')
    records = db.Conversation

    print("J.A.M.E.S: " + recieve)

    while send != "quit()":
        
        send = input("You: ")
        prevRecieve = recieve

        #Set up reply
        replies = records.find_one({"In" : re.sub(r'[^a-zA-Z0-9\s]+', '', send.lower())})

        if 'Out' in str(replies):
            recieve = str(replies).split("'Out': '")[1][:-2]
        else:
            recieve = send

        print("J.A.M.E.S: " + recieve)
        #Add to database
        addon = {
            "In" : re.sub(r'[^a-zA-Z0-9\s]+', '', prevRecieve.lower()),
            "Out" : re.sub(r'[^a-zA-Z0-9\s]+', '', send.lower()),
        }
        records.insert_one(addon)

if __name__ == "__main__":
    main()