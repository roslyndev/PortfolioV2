## Description

 - CineVerse는 간단한 영화 리뷰 및 추천 사이트 입니다.


### Structure

```mermaid
classDiagram
    User <|-- Scene
    User <|-- Review
    User <|-- Comment
    User : +String email
    User : +String nickname
    User: +isMammal()
    User: +mate()
    class Scene{
      +String Title
      +String Thumbnail
      +movies()
      +series()
    }
    class Review{
      -int point
      -recommand()
    }
    class Comment{
      +String comment
      +like()
      +unlike()
    }
```