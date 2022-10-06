user_one = {"id": 0, "name":"allen", "email":"allen@gmail.com", "password":"abc123"}
user_two = {"id": 1, "name":"bob", "email":"bob@gmail.com", "password":"abc123"}
user_three = {"id": 2, "name":"charlie", "email":"charlie@gmail.com", "password":"abc123"}


login_one = {k:v for k,v in user_one.items() if k in ["name", "password"]}
login_two = {k:v for k,v in user_two.items() if k in ["name", "password"]}
login_three = {k:v for k,v in user_three.items() if k in ["name", "password"]}


city_amsterdam = {"id":0, "cityName":"Amsterdam", "country":"Netherlands"}
city_copenhagen = {"id":1, "cityName":"Copenhagen", "country":"Denmark"}
city_nyc = {"id":2, "cityName":"NYC", "country":"USA"}