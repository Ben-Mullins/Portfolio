#!/usr/bin/python3
import re
import ssl
from pymongo import MongoClient

__author__ = "Ben Mullins"

def main():
    print("\nYou have entered a chatroom with J.A.M.E.S\n________________________________________________\n")
    send = ""
    recieve = "Hello, hooman!"
    prevRecieve = ""
    client = MongoClient("mongodb+srv://Bot:James@conversation-syqee.mongodb.net/test?retryWrites=true&w=majority", ssl = True, ssl_cert_reqs = ssl.CERT_NONE)
    db = client.get_database('James')
    records = db.Conversation

    print("J.A.M.E.S: " + recieve)

    while send != "quit()":
        send = input("\nYou: ")
        prevRecieve = recieve

        #Set up reply
        replies = records.find_one({"In" : re.sub(r'[^a-zA-Z0-9\s]+', '', send.lower())})

        if 'Out' in str(replies):
            recieve = str(replies).split("'Out': '")[1][:-2]
            print("\nJ.A.M.E.S: " + recieve)

        else:
            print("\nJ.A.M.E.S: I do not understand what that means how would you respond if i said '" + send + "' to you?")
            recieve = (send)

        #Add to database
        addon = {
            "In" : re.sub(r'[^a-zA-Z0-9\s]+', '', prevRecieve.lower()),
            "Out" : re.sub(r'[^a-zA-Z0-9\s]+', '', send.lower()),
        }
        records.insert_one(addon)

if __name__ == "__main__":
    main()
