# EF-Core-Relationships-Demo
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
  "name": "John Wick"
}
```
### Add User Method 2 (with Profile)
``` json
{
  "name": "James Bond",
  "profile": {
    "bio": "An intelligent agent of England."    
  }
}
```
### Add Profile
``` json
{
  "bio": "A danagerous man in America.",
  "userid": 1
}
```
### Get Users
``` json
[
  {
    "id": 1,
    "name": "John Wick",
    "profile": {
      "id": 2,
      "bio": "A danagerous man in America.",
      "userId": 1,
      "user": null
    }
  },
  {
    "id": 2,
    "name": "James Bond",
    "profile": {
      "id": 1,
      "bio": "An intelligent agent of England.",
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
    "name": "John Wick",
    "profile": {
      "id": 2,
      "bio": "A danagerous man in America.",
      "userId": 1,
      "user": null
    }
  },
  {
    "id": 2,
    "name": "James Bond",
    "profile": {
      "id": 1,
      "bio": "An intelligent agent of England.",
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
### Add Post
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

## 3. Many-To-Many
### Models
``` csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<StudentCourse>? StudentsCourses { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<StudentCourse>? StudentsCourses { get; set; }
}

public class StudentCourse
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public Student? Student { get; set; }

    public int CourseId { get;set; }
    public Course? Course { get; set; }
}
```
Table structure for the provided classes, based on a relational database schema:

### Table: `Students`
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the student. |
| `Name`          | `string`      | `NO`         | Name of the student.        |

### Table: `Courses`
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the course. |
| `Name`          | `string`      | `NO`         | Name of the course.         |

### Table: `StudentCourses`
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the Student-Course relation. |
| `StudentId`     | `int`         | `NO`         | Foreign key referencing `Students.Id`. |
| `CourseId`      | `int`         | `NO`         | Foreign key referencing `Courses.Id`.  |

### Relationships
1. **Many-to-Many Relationship**:
   - A `Student` can enroll in multiple `Courses`.
   - A `Course` can have multiple `Students` enrolled.
   - This relationship is implemented through the `StudentCourses` join table.
2. **Foreign Key Constraints**:
   - `StudentCourses.StudentId` is a foreign key referencing `Students.Id`.
   - `StudentCourses.CourseId` is a foreign key referencing `Courses.Id`.

### Add Student
``` json
{
  "name": "Student-1"
}
```
### Add Course
``` json
{
  "name": "BA"
}
```
### Add StudentCourse
``` json
{
  "studentId": 2,  
  "courseId": 2
}
```
### Get Students
``` json
[
  {
    "id": 1,
    "name": "Student-1",
    "studentsCourses": [
      {
        "id": 1,
        "studentId": 1,
        "student": null,
        "courseId": 1,
        "course": null
      }
    ]
  },
  {
    "id": 2,
    "name": "Student-2",
    "studentsCourses": [
      {
        "id": 2,
        "studentId": 2,
        "student": null,
        "courseId": 1,
        "course": null
      },
      {
        "id": 3,
        "studentId": 2,
        "student": null,
        "courseId": 2,
        "course": null
      }
    ]
  }
]
```
### Get Courses
``` json
[
  {
    "id": 1,
    "name": "BA",
    "studentsCourses": [
      {
        "id": 1,
        "studentId": 1,
        "student": null,
        "courseId": 1,
        "course": null
      },
      {
        "id": 2,
        "studentId": 2,
        "student": null,
        "courseId": 1,
        "course": null
      }
    ]
  },
  {
    "id": 2,
    "name": "BSC",
    "studentsCourses": [
      {
        "id": 3,
        "studentId": 2,
        "student": null,
        "courseId": 2,
        "course": null
      }
    ]
  }
]
```
### Get StudentsCourses
``` json
[
  {
    "id": 1,
    "studentId": 1,
    "student": {
      "id": 1,
      "name": "Student-1",
      "studentsCourses": [
        null
      ]
    },
    "courseId": 1,
    "course": {
      "id": 1,
      "name": "BA",
      "studentsCourses": [
        null,
        {
          "id": 2,
          "studentId": 2,
          "student": {
            "id": 2,
            "name": "Student-2",
            "studentsCourses": [
              null,
              {
                "id": 3,
                "studentId": 2,
                "student": null,
                "courseId": 2,
                "course": {
                  "id": 2,
                  "name": "BSC",
                  "studentsCourses": [
                    null
                  ]
                }
              }
            ]
          },
          "courseId": 1,
          "course": null
        }
      ]
    }
  },
  {
    "id": 2,
    "studentId": 2,
    "student": {
      "id": 2,
      "name": "Student-2",
      "studentsCourses": [
        null,
        {
          "id": 3,
          "studentId": 2,
          "student": null,
          "courseId": 2,
          "course": {
            "id": 2,
            "name": "BSC",
            "studentsCourses": [
              null
            ]
          }
        }
      ]
    },
    "courseId": 1,
    "course": {
      "id": 1,
      "name": "BA",
      "studentsCourses": [
        {
          "id": 1,
          "studentId": 1,
          "student": {
            "id": 1,
            "name": "Student-1",
            "studentsCourses": [
              null
            ]
          },
          "courseId": 1,
          "course": null
        },
        null
      ]
    }
  },
  {
    "id": 3,
    "studentId": 2,
    "student": {
      "id": 2,
      "name": "Student-2",
      "studentsCourses": [
        {
          "id": 2,
          "studentId": 2,
          "student": null,
          "courseId": 1,
          "course": {
            "id": 1,
            "name": "BA",
            "studentsCourses": [
              {
                "id": 1,
                "studentId": 1,
                "student": {
                  "id": 1,
                  "name": "Student-1",
                  "studentsCourses": [
                    null
                  ]
                },
                "courseId": 1,
                "course": null
              },
              null
            ]
          }
        },
        null
      ]
    },
    "courseId": 2,
    "course": {
      "id": 2,
      "name": "BSC",
      "studentsCourses": [
        null
      ]
    }
  }
]
```
# Relationships
Here’s the explanation of the relationships along with **models** and **table structures** for each type:

---

### **1. One-to-One Relationship**
#### Example: `User` and `Profile`

#### Models
```csharp
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

#### Table Structure
**Table: `Users`**
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the user.  |
| `Name`          | `string`      | `NO`         | Name of the user.          |

**Table: `Profiles`**
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the profile. |
| `Bio`           | `string`      | `NO`         | Biography of the user.     |
| `UserId`        | `int`         | `NO`         | Foreign key referencing `Users.Id`. |

---

### **2. One-to-Many Relationship**
#### Example: `Blog` and `Post`

#### Models
```csharp
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

#### Table Structure
**Table: `Blogs`**
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the blog.  |
| `Title`         | `string`      | `NO`         | Title of the blog.         |

**Table: `Posts`**
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the post.  |
| `Content`       | `string`      | `NO`         | Content of the post.       |
| `BlogId`        | `int`         | `NO`         | Foreign key referencing `Blogs.Id`. |

---

### **3. Self-Referential Relationship**
#### Example: `Employee` with Manager

#### Models
```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ManagerId { get; set; }
    public Employee? Manager { get; set; }
    public ICollection<Employee>? Subordinates { get; set; }
}
```

#### Table Structure
**Table: `Employees`**
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the employee. |
| `Name`          | `string`      | `NO`         | Name of the employee.      |
| `ManagerId`     | `int`         | `YES`        | Foreign key referencing `Employees.Id`. |

---

### **4. Polymorphic Relationship**
#### Example: `Comment` can belong to multiple entities (`Post`, `Photo`)

#### Models
```csharp
public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public int ParentId { get; set; }
    public string ParentType { get; set; } = null!; // Example: "Post", "Photo"
}
```

#### Table Structure
**Table: `Comments`**
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the comment. |
| `Content`       | `string`      | `NO`         | Content of the comment.    |
| `ParentId`      | `int`         | `NO`         | Foreign key referencing the parent entity. |
| `ParentType`    | `string`      | `NO`         | Indicates the parent entity type (e.g., `Post` or `Photo`). |

---

### **5. Many-to-Many with Extra Attributes**
#### Example: `Student` enrolls in `Course` with additional attributes like `EnrollmentDate`

#### Models
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<StudentCourse>? StudentCourses { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<StudentCourse>? StudentCourses { get; set; }
}

public class StudentCourse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Grade { get; set; } = null!;
}
```

#### Table Structure
**Table: `Students`**
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the student. |
| `Name`          | `string`      | `NO`         | Name of the student.        |

**Table: `Courses`**
| **Column Name** | **Data Type** | **Nullable** | **Description**            |
|------------------|---------------|--------------|----------------------------|
| `Id`            | `int`         | `NO`         | Primary key for the course. |
| `Name`          | `string`      | `NO`         | Name of the course.         |

**Table: `StudentCourses`**
| **Column Name**      | **Data Type** | **Nullable** | **Description**                |
|-----------------------|---------------|--------------|--------------------------------|
| `Id`                 | `int`         | `NO`         | Primary key for the record.    |
| `StudentId`          | `int`         | `NO`         | Foreign key referencing `Students.Id`. |
| `CourseId`           | `int`         | `NO`         | Foreign key referencing `Courses.Id`.  |
| `EnrollmentDate`     | `datetime`    | `NO`         | Date of enrollment.            |
| `Grade`              | `string`      | `NO`         | Grade achieved in the course.  |

---

These examples show how different types of relationships can be modeled and structured in databases. Let me know if you need additional assistance! 😊
