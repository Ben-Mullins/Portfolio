#!/usr/bin/python3

import json

testData = """
{
"a": "Offer",
"inLanguage": "et",
"availabl": {
    "Another one": {
        "one": "lul",
        "two": "kekw",
        "three": {
            "Hacker": "man",
            "Explosion": "lel"
        }
    },
    "a": "Place",
    "address": {
        "a": "PostalAddress",
        "name": "Oklahoma"
    }
},
"description": "Smith and Wesson 686 357 magnum 6 inch barrel wood handle great condition shoots great.",
"priceCurrency": "USD",
"geonames_address": [
    {
        "a": "PopulatedPlace",
        "hasIdentifier": {
            "a": "Identifier",
            "label": "4552707",
            "hasType": "http://dig.isi.edu/gazetteer/data/SKOS/IdentifierTypes/GeonamesId"
        },
        "hasPreferredName": {
            "a": "Name",
            "label": "Tahlequah"
        },
        "uri": "http://dig.isi.edu/gazetteer/data/geonames/place/4552707",
        "fallsWithinState1stDiv": {
            "a": "State1stDiv",
            "uri": "http://dig.isi.edu/gazetteer/data/geonames/place/State1stDiv/US_OK",
            "hasName": {
                "a": "Name",
                "label": "Oklahoma"
            }
        },
        "score": 0.5,
        "fallsWithinCountry": {
            "a": "Country",
            "uri": "http://dig.isi.edu/gazetteer/data/geonames/place/Country/US",
            "hasName": {
                "a": "Name",
                "label": "United States"
            }
        },
        "fallsWithinCountyProvince2ndDiv": {
            "a": "CountyProvince2ndDiv",
            "uri": "http://dig.isi.edu/gazetteer/data/geonames/place/CountyProvince2ndDiv/US_OK_021"
        },
        "geo": {
            "lat": 35.91537,
            "lon": -94.96996
        }
    }
],
"price": 750,
"title": "For Sale: Smith &amp; Wesson 686",
"publisher": {
    "a": "Organization",
    "name": "armslist.com",
    "uri": "http://dig.isi.edu/weapons/data/organization/armslist"
},
"uri": "http://dig.isi.edu/weapons/data/page/13AD9516F01012C5F89E8AADAE5D7E1E2BA97FF9/1433463841000/processed",
"seller": {
    "a": "PersonOrOrganization",
    "description": "Private Party"
}
}

"""

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

    for obj in json.loads(testData).items():
        print("")
        getChildren(obj, 0) 

if __name__ == "__main__":
    main()
