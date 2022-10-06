from dataclasses import dataclass


@dataclass
class City:
    id: int
    cityName: str
    country: str

    @classmethod
    def from_dict(cls, data: dict) -> "City":
        return cls(
            id=data["id"],
            cityName=data["cityName"],
            country=data["country"]
        )