from dataclasses import dataclass


@dataclass
class User:
    id: int
    name: str
    email: str
    password: str

    @classmethod
    def from_dict(cls, data: dict) -> "User":
        return cls(
            id=data["id"],
            name=data["name"],
            email=data["email"],
            password=data["password"]
        )