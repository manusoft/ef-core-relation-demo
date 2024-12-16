# ef-core-relation-demo
## 1. One-To-One
### Models
``` csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Profile? Profile { get; set; }
}

public class Profile
{
    public int Id { get; set; }
    public string Bio { get; set; } = null!;

    public int UserId { get; set; }
    public User? User { get; set; }
}
```
### Add User Method 1
``` json
{
  "name": "Azrag-Dog"
}
```
### Add User Method 2 (with Profile)
``` json
{
  "name": "Basma-Dog",
  "profile": {
    "bio": "A saluki dog, brown color."    
  }
}
```
### Add Profile Method
``` json
{
  "bio": "A saluki dog, brown color.",
  "userid": 1
}
```
### Get Users
``` json
[
  {
    "id": 1,
    "name": "Azrag-Dog",
    "profile": {
      "id": 2,
      "bio": "A saluki dog, broww color.",
      "userId": 1,
      "user": null
    }
  },
  {
    "id": 2,
    "name": "Basma-Dog",
    "profile": {
      "id": 1,
      "bio": "A Saluki dog, brow color.",
      "userId": 2,
      "user": null
    }
  }
]
```
### Get Profile
``` json
[
  {
    "id": 1,
    "name": "Azrag-Dog",
    "profile": {
      "id": 2,
      "bio": "A saluki dog, broww color.",
      "userId": 1,
      "user": null
    }
  },
  {
    "id": 2,
    "name": "Basma-Dog",
    "profile": {
      "id": 1,
      "bio": "A Saluki dog, brow color.",
      "userId": 2,
      "user": null
    }
  }
]
```

