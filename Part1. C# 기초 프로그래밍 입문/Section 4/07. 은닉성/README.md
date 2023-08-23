# Section 4-7 은닉성

> 객체지향 프로그래밍의 3대 요소(상속성/은닉성/다형성)  
> 은닉성 : 멤버변수나 메소드가 노출되지 않도록 하는 기법  
> 자동차 예로, 전기장치나 엔진 등의 핵심 부품이나 기술이 외부에 노출이 되지 않도록 하는 것

---

### 은닉성이 없다면?
```C#
class Knight : Player 
{
    public int hp;               // 사용에 주의가 필요한 필드

    public void SecretFunction() // 사용에 주의가 필요한 메소드
    {
        //Code .. 
    }
}
```
- 주의가 필요한 필드나 메소드에 대해 실수로 사용하는 경우가 많아진다.
- 여러명이 작업하는 프로젝트의 경우 은닉성 설정으로 실수를 줄일 수 있다.
- 프로그램 규모가 커지면 커질수록 중요해지는 개념이다.

---
### 접근 한정자
- public    : 모두에게 공유하는 접근 한정자
- private   : 자기 자신(객체) 내부에서만 접근할 수 있는 접근 한정자  
- protected : 상속을 받은 자식 클래스에서는 접근을 허용하는 접근 한정자
```C#
class Player
{
    private int hp;       // private 한정자의 hp 필드
    public void setHp(){  // public 한정자의 setHp 메소드

    }
}
```

> private 필드를 public 메소드를 이용해서 조작함을 하는 이유
> - 메소드를 이용해 값을 변경함으로써 디버그에 편리하다.
> - 디버그 호출 스택을 확인함으로써 규모가 큰 프로젝트에서의 관리에 이점이 있다.

---
### protected 한정자의 사용
```C#
class Player
{
    protected int hp;
    protected int attack;
}

class Knight : Player
{
    public Knight()
    {
        this.hp = 100;     // protected 한정자로 선언된 필드이지만, 자식 클래스에서는 접근이 가능하다.
        this.attack = 10;
    }
}
```
- protected 한정자가 사용된 필드와 메소드는 자식 클래스에서만 접근할 수 있다.