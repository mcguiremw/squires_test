from dataclasses import dataclass


@dataclass
class LoginModel:
    name: str
    password: str

    @classmethod
    def from_dict(cls, data: dict) -> "LoginModel":
        return cls(
            name=data["name"],
            password=data["password"]
        )