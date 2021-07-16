from flask import request
from flask_restplus import Api, Resource, fields, Namespace
from marshmallow import ValidationError

from app import resources, schemas, models

api = Api(version='1.0', title='Magazine Subscription API', 
          description='A simple API to manage User subscriptions to magazines.')

# Define Resources here

User = api.model('User', {
    'name': fields.String(description='Name of the user')
})

Magazine = api.model('Magazine', {
    'title': fields.String(description='Title of the magazine')
})

Subscription = api.model('Subscription', {
    'user_id': fields.Integer(description='User id for the subscription'),
    'magazine_id': fields.Integer(description='Magazine id for the subscription')
})

# get all users
@api.route('/api/users')
class getUsers(Resource):
	def get(self):
		all_users = models.User.query.all()
		return schemas.users_schema.dump(all_users)

# get specific user by id
@api.route('/api/users/<int:userid>', endpoint='users')
@api.doc(params={'userid': 'The user id of the user you would like to retrieve'})
class getUser(Resource):
	def get(self, userid):
		user_schema = schemas.UserSchema()
		user = models.User.query.filter(models.User.id == userid).one()
		return user_schema.dump(user)

# get all magazines
@api.route('/api/magazines')
class getMagazines(Resource):
	def get(self):
		all_magazines = models.Magazine.query.all()
		return schemas.magazines_schema.dump(all_magazines)

# get specific magazine by id
@api.route('/api/magazines/<int:magazineid>')
@api.doc(params={'magazineid': 'The magazine id of the magazine you would like to retrieve'})
class getMagazine(Resource):
	def get(self, magazineid):
		magazine_schema = schemas.MagazineSchema()
		magazine = models.Magazine.query.filter(models.Magazine.id == magazineid).one()
		return magazine_schema.dump(magazine)

# get all subscriptions
@api.route('/api/subscriptions')
class getSubscriptions(Resource):
	def get(self):
		all_subs = models.Subscription.query.all()
		return schemas.subscriptions_schema.dump(all_subs)

# get specific subscription by id
@api.route('/api/subscriptions/<int:subid>')
@api.doc(params={'subid': 'The subscription id of the subscription you would like to retrieve'})
class getSubscription(Resource):
	def get(self, subid):
		sub_schema = schemas.SubscriptionSchema()
		sub = models.Subscription.query.filter(models.Subscription.id == subid).one()
		return sub_schema.dump(sub)

# get user's subscriptions by user id
@api.route('/api/users/<int:userid>/subscriptions')
@api.doc(params={'userid': 'The user id of the user you would like to pull subscription information for'})
class getSubscription(Resource):
	def get(self, userid):
		try:
			subs = models.Subscription.query.filter_by(user_id=userid).all()
			return schemas.subscriptions_schema.dump(subs)
		except Exception:
			return {'Error': 'Invalid Subscription id'}

# add user
@api.route('/api/users/add', methods=['POST'])
@api.doc(responses={ 200: 'OK', 400: 'No input data provided', 422: 'Unable to validate'})
class createUser(Resource):
	@api.expect(User)
	def post(self):
		json_data = request.get_json()
		if not json_data:
			return {'Error' : 'No input data provided'}, 400
		# Validate
		try:
			data = schemas.user_schema.load(json_data)
		except ValidationError as err:
			return err.messages, 422
		newName = data['name']
		user = models.User.query.filter_by(name=newName).first()
		if user is None:
			user = models.User(name=newName)
			models.db.session.add(user)
			models.db.session.commit()
			result = schemas.user_schema.dump(models.User.query.get(user.id))
			return {'message': 'Created new user.', 'user': result}

# add magazine
@api.route('/api/magazines/add', methods=['POST'])
@api.doc(responses={ 200: 'OK', 400: 'No input data provided'})
class createMagazine(Resource):
	@api.expect(Magazine)
	def post(self):
		json_data = request.get_json()
		if not json_data:
			return {'Error' : 'No input data provided'}, 400
		# Validate
		try:
			data = schemas.magazine_schema.load(json_data)
		except ValidationError as err:
			return err.messages, 422
		newTitle = data['title']
		magazine = models.Magazine.query.filter_by(title=newTitle).first()
		if magazine is None:
			magazine = models.Magazine(title=newTitle)
			models.db.session.add(magazine)
			models.db.session.commit()
			result = schemas.magazine_schema.dump(models.Magazine.query.get(magazine.id))
			return {'message': 'Created new magazine.', 'magazine': result}

# add subscription
@api.route('/api/subscriptions/add', methods=['POST'])
@api.doc(responses={ 200: 'OK', 400: 'No input data provided', 422: 'Error handling request'})
class createSubscription(Resource):
	@api.expect(Subscription)
	def post(self):
		json_data = request.get_json()
		if not json_data:
			return {'Error' : 'No input data provided'}, 400
		# Validate
		try:
			data = schemas.subscription_schema.load(json_data)
		except ValidationError as err:
			return err.messages, 422
		user_id = data['user_id']
		magazine_id = data['magazine_id']
		magazine = models.Magazine.query.filter_by(id=magazine_id).first()
		user = models.User.query.filter_by(id=user_id).first()
		subscription = models.Subscription.query.filter_by(user=user, magazine=magazine).first()
		if subscription is None and user is not None and magazine is not None:
			subscription = models.Subscription(user_id=user_id, magazine_id=magazine_id)
			models.db.session.add(subscription)
			models.db.session.commit()
			result = schemas.subscription_schema.dump(models.Subscription.query.get(subscription.id))
			return {'message': 'Created new subscription.', 'subscription': result}
		else:
			return {'Error': 'Subscription already exists, or user/magazine does not exist'}

# delete user + their subscriptions
@api.route('/api/users/delete/<int:userid>')
@api.doc(params={'userid': 'The user id of the user you would like to delete'},
					responses={ 200: 'OK', 400: 'No input data provided', 422: 'Invalid user id given'})
class deleteUser(Resource):
	def delete(self, userid):
		try:
			models.User.query.filter_by(id=userid).delete()
			models.Subscription.query.filter_by(user_id=user_id).delete()
			models.db.session.commit()
			return {'message': 'User and their subscriptions deleted successfully.'}
		except Exception as err:
			return {'Error': 'Unable to find user with that id'}, 422

# delete magazine
@api.route('/api/users/delete/<int:magazineid>')
@api.doc(params={'magazineid': 'The magazine id of the magazine you would like to delete'},
				responses={ 200: 'OK', 400: 'No input data provided', 422: 'Invalid magazine id given'})
class deleteMagazine(Resource):
	def delete(self, magazineid):
		try:
			models.Magazine.query.filter_by(id=magazineid).delete()
			models.db.session.commit()
			return {'message': 'Magazine deleted successfully.'}
		except Exception as err:
			return {'Error': 'Unable to find magazine with that id'}, 422

# delete subscription
@api.route('/api/subscriptions/delete', methods=['DELETE'])
@api.doc(responses={ 200: 'OK', 400: 'No input data provided', 422: 'Improperly formatted request'})
class deleteSubscription(Resource):
	@api.expect(Subscription)
	def delete(self):
		json_data = request.get_json()
		if not json_data:
			return {'Error' : 'No input data provided'}, 400
		# Validate
		try:
			data = schemas.subscription_schema.load(json_data)
		except ValidationError as err:
			return {'Error': 'Improperly formatted request'}, 422
		user_id = data['user_id']
		magazine_id = data['magazine_id']
		magazine = models.Magazine.query.filter_by(id=magazine_id).first()
		user = models.User.query.filter_by(id=user_id).first()
		subscription = models.Subscription.query.filter_by(user=user, magazine=magazine).first()
		if subscription is not None:
			models.Subscription.query.filter_by(user_id=user_id, magazine_id=magazine_id).delete()
			models.db.session.commit()
			result = schemas.subscription_schema.dump(models.Subscription.query.get(subscription.id))
			return {'message': 'Deleted subscription.', 'subscription': result}
		else:
			return {'Error': 'Subscription does not exist'}
