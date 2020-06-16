#!/usr/bin/python3

from filehash import FileHash
import os
import random
import requests
import time

__author__ = "Ben Mullins"

key = ["d7a17b6095201e1ceae53c3b641570c1e2ded917a5dd539a63881b0c995f978b",
    "755e4553523011c90fe5d90dc2d6efa496a8d93ab86987f1c40648b2acab0194",
    "297976d2dcef91658e23560426ea0b719d82a6ba0a68439ca2a813f41e7d7e4f"]

"""
Find all the files in a directory on VirusTotal and notify if any are potentially malicious.

June 16, 2020
"""

def main():
    basepath = "/Users/ben/operating_systems" # Directory you want to scan
    sha256hasher = FileHash("sha256")
    print("Finding hashes to send to VirusTotal...")
    hashlist = sha256hasher.hash_dir(basepath)

    for item in hashlist:
        try:
            shahash = item[1]
            filename = item[0]
            params = {'apikey': key[random.randint(0,2)], 'resource': shahash} # get around API limit with 3 keys
            hashresponse = requests.get("https://www.virustotal.com/vtapi/v2/file/report", params=params, timeout=3) 
            try:
                json_payload = hashresponse.json()
                print(filename + " : " + shahash)
                if json_payload["response_code"] == 1: # 1 - No problem. 0 - Not in database
                    print("    " + str(json_payload["positives"]))
                else:
                    print("    Could not find file in VirusTotal Database.")
                time.sleep(3) # still have to wait on API limits
            except Exception as err:
                print(err)
                pass

        except Exception as err:
            print(err)


if __name__ == "__main__":
    print("VirusTotal Lookup")
    print("Made by " + __author__)
    main()