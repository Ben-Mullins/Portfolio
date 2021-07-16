from flask_marshmallow import Marshmallow
from typing import List

from flask_marshmallow import Marshmallow
from app import models

ma = Marshmallow()

# Define Schemas here 
class UserSchema(ma.SQLAlchemySchema):
	class Meta:
		model = models.User

	id = ma.auto_field()
	name = ma.auto_field()

class SubscriptionSchema(ma.SQLAlchemyAutoSchema):
	class Meta:
		model = models.Subscription
		include_fk = True

class MagazineSchema(ma.SQLAlchemySchema):
	class Meta:
		model = models.Magazine

	id = ma.auto_field()
	title = ma.auto_field()

user_schema = UserSchema()
users_schema = UserSchema(many=True)

magazine_schema = MagazineSchema()
magazines_schema = MagazineSchema(many=True)

subscription_schema = SubscriptionSchema()
subscriptions_schema = SubscriptionSchema(many=True)