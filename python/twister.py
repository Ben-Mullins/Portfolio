#/usr/bin/env python3

import configparser
import json
import os
from pymongo import MongoClient
import requests
from requests.auth import HTTPBasicAuth
import ssl

"""
This script looks at domain(s), uses dnstwist to
generate permutations of the domains to find possible typosquatting
domains that are registered, compares them to a MongoDB of domains
we've already seen, adds new domains, and creates a ticket with all of
the new domains in Jira at low priority.
"""

config = configparser.ConfigParser()
domainlist = { # Jira Key is dictionary key, table of domains owned by customer is the value.
    "LEAGUE" : ["leeguhlejunz.com"],
    "OSRS" : ["runescape.com"."oldschoolrunescape.com"]
    }

config.read("config.ini")

def get_list(jira_key):
    """
    get_list takes a domain name as an argument and appends permutations of it to a file.
    """
    print("Running dnstwist on " + jira_key)
    os.system("rm registered_domains.csv")
    for domain in domainlist[jira_key]:
        os.system("dnstwist --registered --format csv " + domain + " >> registered_domains.csv")

def query_mongo(query_table):
    """
    Takes a Mongo query containing a list of domains
    as an argument and returns a list of all newly registered domains
    """
    print("Querying Mongo")
    already_seen_domains = []
    new_domains = []
    try:
        client = MongoClient(config["mongo"]["key"], ssl = True, ssl_cert_reqs = ssl.CERT_NONE)
        db = client.get_database("domains")
        records = db.domains
        query = {"$or":query_table}
        response = records.find(query)

        for item in response: # record all known domains
            already_seen_domains.append(item["domain"])

        with open("registered_domains.csv", "r") as file: # record all new domains
            for line in file.read().splitlines():
                if "fuzzer" in line: 
                    continue
                else:
                    if line.split(",")[1] in already_seen_domains:
                        continue
                    else:
                        new_domains.append({"domain":line.split(",")[1]})

    except Exception as err:
        print(err)

    return new_domains

def import_to_mongo(new_domains):
    """
    Takes an array of dictionaries and inserts them into mongo
    """
    print("Importing data to Mongo")
    client = MongoClient(config["mongo"]["key"], ssl = True, ssl_cert_reqs = ssl.CERT_NONE)
    db = client.get_database("domains")
    records = db.domains
    records.insert_many(new_domains)

def create_ticket(jira_key, new_domains):
    """
    Creates a medium priority ticket in Jira
    """
    print("Creating a ticket in Jira")
    url = "https://<Insert Jira Link>/rest/api/3/issue"
    auth = HTTPBasicAuth(config["jira"]["email"], config["jira"]["pass"])
    headers = {
       "Accept": "application/json",
       "Content-Type": "application/json"
    }

    payload = json.dumps( {
      "update": {},
      "fields": {
        "summary": "New typosquatted domain(s) registered for " + jira_key,
        "issuetype": {
          "id": "10004"
        },
        "components": [
          {
            "id": "10000"
          }
        ],
        "project": {
          "key": jira_key
        },
        "description": {
          "type": "doc",
          "version": 1,
          "content": [
            {
              "type": "paragraph",
              "content": [
                {
                  "text": "Newly registered sites: " + str(new_domains),
                  "type": "text"
                }
              ]
            }
          ]
        },
        "priority": {
          "id": "3"
        },
        "labels": [
          "alert"
        ]
      }
    } )

    response = requests.request(
       "POST",
       url,
       data=payload,
       headers=headers,
       auth=auth
    )

    print(json.dumps(json.loads(response.text), sort_keys=True, indent=4, separators=(",", ": ")))

def main():
    # fetch registered domains
    for jira_key in domainlist:
        get_list(jira_key)

    # Look up data in mongo, import and create ticket if missing
        query = [] 
        with open("registered_domains.csv", "r") as file:
            for line in file.read().splitlines():
                if "fuzzer" in line: 
                    continue
                else:
                    site = str(line.split(",")[1])
                    query.append({"domain":site})
        new_domains = query_mongo(query)

        if len(new_domains) > 0:
            create_ticket(jira_key, new_domains)
            import_to_mongo(new_domains)
        else:
            print("No new domains found.")

if __name__ == "__main__":
    main()

