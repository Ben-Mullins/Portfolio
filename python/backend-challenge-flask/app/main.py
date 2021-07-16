from flask import Flask

from flask_restplus import Api
from marshmallow import ValidationError

from app import models, schemas, resources

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///test.db'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
app.config['PROPAGATE_EXCEPTIONS'] = True

models.db.init_app(app)
schemas.ma.init_app(app)
resources.api.init_app(app)

@app.before_first_request
def create_tables():
    models.db.create_all()
    #user_schema = schemas.UserSchema()
    #magazine_schema = schemas.MagazineSchema()
    #user = models.User(name='Chad Wellington')
    #magazine = models.Magazine(title='Lift Weights')
    #subscription = models.Subscription(user=user, magazine=magazine)
    #models.db.session.add(user)
    #models.db.session.add(magazine)
    #models.db.session.add(subscription)
    #models.db.session.commit()
    #print('Initial:', user_schema.dump(user))



if __name__ == '__main__':
    app.run(port=5000, debug=True)
