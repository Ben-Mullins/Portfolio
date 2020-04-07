#!/usr/bin/python3

"""
Pull listings from KSL via webscraping (with beautiful soup)
and alert when there is a 125 gallon tank for less than $200
"""

from bs4 import BeautifulSoup
import json
import re
import requests
import time

__author__ = "Ben Mullins"

data = ""
rex = re.compile('id\":([^,]*).+?(?=\"price\")\"price\":([^,]*),.+?(?=\"title\")\"title\":\"([^\"]*)')
user_agent = 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:74.0) Gecko/20100101 Firefox/74.0'

linkurl = "https://classifieds.ksl.com/listing/"
url = "https://classifieds.ksl.com/search/Pets-and-Livestock/Fish"

def getItems(pageNum, foundItems):
    """
    getItems reaches out to ksl classifieds and pulls the listings from that page,
    along with title, price, and the link to the listing.

    pageNum: integer - page number you want to visit

    foundItems: set - this is to prevent duplicate notifications and
    keep track of items already found.
    """
    if pageNum == 0:
        page = requests.get(url, headers={'User-Agent': user_agent})
    else:
        page = requests.get(url + "/page/" + str(pageNum), headers={'User-Agent': user_agent})

    soup = BeautifulSoup(page.text, "html.parser")
    wrapper = soup.find("div", class_="page-wrap")

    for line in str(wrapper).splitlines():
        if "listings: [{\"id\":" in line:
            data = line[33:-2]
            break
    #print(data)
    items = re.findall(rex, data)

    for item in items:
        name = item[2]
        price = item[1]
        number = item[0]

        if "ISO" not in name and number not in foundItems:
            if ("125" in name or "200" in name or "250" in name) and ("Tank" in name or "Aquarium" in name) and float(price) < 200:
                notify(name, price, number)
                foundItems.add(number)

    return foundItems

def notify(name, price, number):
    """
    change this function to however you want to be notified of an item
    (whether it's through Twilio, just a notification on your screen,
    or some other means)
    """
    print(name + " : $" + price)
    print(linkurl + number + "\n")

if __name__ == "__main__":

    foundItems = set()

    print("KSL Classifieds Webscraper")
    print("Author: " + __author__ + "\n")

    while True:
        foundItems = getItems(0, foundItems)
        time.sleep(10)
