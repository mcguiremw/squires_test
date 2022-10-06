import requests

from configs import get_server
from configs import get_city_endpoints
from configs import get_user_endpoints
from ..data import city_amsterdam


server_configs = get_server()
city_endpoints = get_city_endpoints()
user_endpoints = get_user_endpoints()

BASE_URL = f"{server_configs['ip']}:{server_configs['port']}"


def test_get_city():
    response = requests.get(f"{BASE_URL}{city_endpoints['city']}")
    assert response.status_code == 200


def test_post_city():
    response = requests.post(
        f"{BASE_URL}{city_endpoints['city']}",
        data=city_amsterdam)
    assert response.status_code == 200


def test_delete_city():
    pass