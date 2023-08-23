# Section 4-6 상속성

> 객체지향 프로그래밍의 3대 요소(상속성/은닉성/다형성)  
> 상속성 : 부모 클래스의 특성을 자식 클래스가 물려받아 사용하는 성질

---

### 클래스 상속하기
```C#
class Knight : Player // Player 클래스는 미리 선언되어 있어야 한다.
{}
```

- Knight 클래스를 파생 클래스 또는 자식 클래스라고 부른다.
- Player 클래스를 기반 클래스 또는 부모 클래스라고 부른다.

---
### 클래스 상속의 기능
```C#
class Player
{
    static public int counter = 1;
    public int id;
    public int hp;
    public int attack;
}

class Knight : Player
{
    public Knight()
    {
        id = 10;
        this.hp = 100;
        base.attack = 20;
    }
}
```

- 자식 클래스는 상속받은 부모 클래스가 가지고 있는 필드와 메소드를 사용할 수 있다.
- base 키워드는 '부모의' 의 의미를 가지고 있다. 
- this.hp = 100 도 결과적으로는 부모 클래스의 필드에 대한 변경이라 할 수 있다.

---

### 상속 관계에서의 생성자 동작
```c#
class Player
{
    public Player()
    {
        Console.WriteLine("Player 생성자 호출!");
    }
}

class Knight : Player
{
    public Knight() : base
    {
        Console.WriteLine("Knight 생성자 호출!");
    }
}

class program
{
    static void Main(string[] args)
    {
        Knight knight = new Knight();   
    }
}

```

- Knight 클래스의 생성자를 사용하더라도, 부모 클래스의 기본 생성자가 먼저 실행된 후 지정한 Knight 클래스 생성자가 실행된다. 
- 즉, Player 기본 생성자 -> Knight 기본 생성자 순으로 실행된다.
- base 키워드가 없더라도 부모 클래스의 기본 생성자가 먼저 실행된다.

```c#
public Player(int hp)
{
    this.hp = hp;
    Console.WriteLine("Player hp 생성자 호출");
}

class Knight : Player
{
    public Knight() : base(10)
    {
        Console.WriteLine("Knight 생성자 호출!");
        Console.WriteLine(this.hp);
    }
}
```
- 부모 클래스의 다른 생성자를 이용하기 위해서 해당 생성자의 인자 입력 방식으로 base()를 채워주면 된다.