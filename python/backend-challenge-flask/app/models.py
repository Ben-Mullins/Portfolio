import flask_bcrypt
from flask_sqlalchemy import SQLAlchemy
from sqlalchemy.orm import declarative_base
from sqlalchemy import Column, Integer, String, ForeignKey, DateTime


db = SQLAlchemy()
Base = db.declarative_base()

# Define models here

class User(db.Model):
	id = db.Column(db.Integer, primary_key=True)
	name = db.Column(db.String())

class Subscription(db.Model):
	id = db.Column(db.Integer, primary_key=True)
	user_id = db.Column(db.Integer, db.ForeignKey('user.id'))
	user = db.relationship('User', backref='users')
	magazine_id = db.Column(db.Integer, db.ForeignKey('magazine.id'))
	magazine = db.relationship('Magazine', backref='magazines')

class Magazine(db.Model):
	id = db.Column(db.Integer, primary_key=True)
	title = db.Column(db.String(255))
