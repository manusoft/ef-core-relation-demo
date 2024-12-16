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
Table structure for the provided classes, based on a relational database schema:

### Table: `Users`
| **Column Name** | **Data Type** | **Nullable** | **Description**          |
|------------------|---------------|--------------|--------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the user.|
| `Name`          | `string`      | `NO`         | Name of the user.        |

### Table: `Profiles`
| **Column Name** | **Data Type** | **Nullable** | **Description**          |
|------------------|---------------|--------------|--------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the profile.|
| `Bio`           | `string`      | `NO`         | Biography of the user.   |
| `UserId`        | `int`         | `NO`         | Foreign key referencing `Users.Id`.|

### Relationships
1. **One-to-One Relationship**:  
   - A `User` can have one `Profile`.
   - A `Profile` must reference one `User` via `UserId`.
2. **Foreign Key Constraint**:
   - `Profiles.UserId` is a foreign key referencing `Users.Id`.

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
      "bio": "A saluki dog, brown color.",
      "userId": 1,
      "user": null
    }
  },
  {
    "id": 2,
    "name": "Basma-Dog",
    "profile": {
      "id": 1,
      "bio": "A Saluki dog, brown color.",
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
      "bio": "A saluki dog, brown color.",
      "userId": 1,
      "user": null
    }
  },
  {
    "id": 2,
    "name": "Basma-Dog",
    "profile": {
      "id": 1,
      "bio": "A Saluki dog, brown color.",
      "userId": 2,
      "user": null
    }
  }
]
```

## 2. One-To-Many
### Models
``` csharp
public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public ICollection<Post>? Posts { get; set; }
}

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;

    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}
```
Table structure for the provided classes, based on a relational database schema:

### Table: `Blogs`
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the blog.  |
| `Title`         | `string`      | `NO`         | Title of the blog.         |

### Table: `Posts`
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the post.  |
| `Content`       | `string`      | `NO`         | Content of the post.       |
| `BlogId`        | `int`         | `NO`         | Foreign key referencing `Blogs.Id`. |

### Relationships
1. **One-to-Many Relationship**:
   - A `Blog` can have multiple `Posts`.
   - A `Post` belongs to one `Blog` via `BlogId`.
2. **Foreign Key Constraint**:
   - `Posts.BlogId` is a foreign key referencing `Blogs.Id`.

### Add Blog Method 1
``` json
{
  "title": "Blog-1"
}
```
### Add Blog Method 2 (with Posts)
``` json
{
  "title": "Blog-2",
  "posts": [
    {
      "content": "This is Blog-2 content-1"
    },
    {
      "content": "This is blog-2 content-2"
    }
  ]
}
```
### Add Post Method
``` json
{
  "content": "This is Blog-1 content.",
  "blogId": 1
}
```
### Get Blogs
``` json
[
  {
    "id": 1,
    "title": "Blog-1",
    "posts": [
      {
        "id": 1,
        "content": "This is Blog-1 content.",
        "blogId": 1,
        "blog": null
      },
      {
        "id": 2,
        "content": "This is Blog-1 content-2.",
        "blogId": 1,
        "blog": null
      },
      {
        "id": 3,
        "content": "This is Blog-1 content-3.",
        "blogId": 1,
        "blog": null
      }
    ]
  },
  {
    "id": 2,
    "title": "Blog-2",
    "posts": [
      {
        "id": 4,
        "content": "This is Blog-2 content-1",
        "blogId": 2,
        "blog": null
      },
      {
        "id": 5,
        "content": "This is blog-2 content-2",
        "blogId": 2,
        "blog": null
      }
    ]
  }
]
```
### Get Posts
``` json
[
  {
    "id": 1,
    "content": "This is Blog-1 content.",
    "blogId": 1,
    "blog": {
      "id": 1,
      "title": "Blog-1",
      "posts": [
        null,
        {
          "id": 2,
          "content": "This is Blog-1 content-2.",
          "blogId": 1,
          "blog": null
        },
        {
          "id": 3,
          "content": "This is Blog-1 content-3.",
          "blogId": 1,
          "blog": null
        }
      ]
    }
  },
  {
    "id": 2,
    "content": "This is Blog-1 content-2.",
    "blogId": 1,
    "blog": {
      "id": 1,
      "title": "Blog-1",
      "posts": [
        {
          "id": 1,
          "content": "This is Blog-1 content.",
          "blogId": 1,
          "blog": null
        },
        null,
        {
          "id": 3,
          "content": "This is Blog-1 content-3.",
          "blogId": 1,
          "blog": null
        }
      ]
    }
  },
  {
    "id": 3,
    "content": "This is Blog-1 content-3.",
    "blogId": 1,
    "blog": {
      "id": 1,
      "title": "Blog-1",
      "posts": [
        {
          "id": 1,
          "content": "This is Blog-1 content.",
          "blogId": 1,
          "blog": null
        },
        {
          "id": 2,
          "content": "This is Blog-1 content-2.",
          "blogId": 1,
          "blog": null
        },
        null
      ]
    }
  },
  {
    "id": 4,
    "content": "This is Blog-2 content-1",
    "blogId": 2,
    "blog": {
      "id": 2,
      "title": "Blog-2",
      "posts": [
        null,
        {
          "id": 5,
          "content": "This is blog-2 content-2",
          "blogId": 2,
          "blog": null
        }
      ]
    }
  },
  {
    "id": 5,
    "content": "This is blog-2 content-2",
    "blogId": 2,
    "blog": {
      "id": 2,
      "title": "Blog-2",
      "posts": [
        {
          "id": 4,
          "content": "This is Blog-2 content-1",
          "blogId": 2,
          "blog": null
        },
        null
      ]
    }
  }
]
```

