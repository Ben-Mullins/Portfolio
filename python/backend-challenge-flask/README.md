Backend Engineer Coding Challenge - Flask
=========================================

## Problem Statement
Create the back end portion of a simple magazine subscription service where
users can manage subscriptions to available magazines using a REST API.

## Stack
You can choose to implement a solution to this problem in any set of Python
technologies you choose, but if you'd like a frame of reference (and time-saver),
this repo contains a sample project starter with the following web stack:

* Python 3
* [Flask](https://flask.palletsprojects.com/)
* [Flask RESTPlus](https://flask-restplus.readthedocs.io/en/stable/)
* [SQLALchemy](https://docs.sqlalchemy.org/en/14/)
* SQLite3

## Setup
* Install [Poetry](https://python-poetry.org/docs/#installation)
  ```bash
  # On Linux/MacOS
  curl -sSL https://raw.githubusercontent.com/python-poetry/poetry/master/get-poetry.py | python -
  ```
* Install project dependencies
  ```bash
  poetry install
  ```

## Implementation details
* Create SQLAlchemy ORM models
  * Add new definitions in `app/models.py`
* Create schemas for marshalling/serializing for each of the models
  * Add new definitions in `app/schemas.py`
* Create API endpoints for each of the models
  * Add new definitions in `app/resources.py`

## Running / Testing
* poetry run python -m app.main

