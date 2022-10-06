import configparser


config = configparser.ConfigParser()
config.read('../configs/test_configs.ini')


def get_server():
    return config['SERVER']


def get_city_endpoints():
    return config['CITY_ENDPOINTS']


def get_user_endpoints():
    return config['USER_ENDPOINTS']